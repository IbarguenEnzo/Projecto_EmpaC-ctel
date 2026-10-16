using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using Empa.Negocio;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Empa.Presentacion
{
    public partial class Form1 : Form
    {
        private readonly CN_Productos _objetoNegocio = new CN_Productos();
        private bool _esEdicion = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                CargarCategorias();
                CargarFiltroCategorias(); // <--- AGREGAR ESTA LÍNEA AQUÍ
                CargarProductos();
                CargarAuditoria();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al iniciar: " + ex.Message, "Depuración", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //MÉTODOS DE CARGA DE DATOS
        private void CargarCategorias()
        {
            cmbCategoria.DataSource = _objetoNegocio.ObtenerCategorias();
            cmbCategoria.DisplayMember = "NombreCat";
            cmbCategoria.ValueMember = "IdCategoria";
            cmbCategoria.SelectedIndex = -1;
        }

        private void CargarProductos()
        {
            dgvProductos.DataSource = null;
            dgvProductos.DataSource = _objetoNegocio.ObtenerProductos();
        }

        private void CargarAuditoria()
        {
            dgvAuditoria.DataSource = null;
            dgvAuditoria.DataSource = _objetoNegocio.ObtenerAuditoria();
        }

        // CARGAR EL FILTRO DE CATEGORÍAS CON LA OPCIÓN "VER TODOS"
        private void CargarFiltroCategorias()
        {
            DataTable dtCategorias = _objetoNegocio.ObtenerCategorias();
            DataTable dtFiltro = dtCategorias.Copy();

            DataRow filaTodas = dtFiltro.NewRow();
            filaTodas["IdCategoria"] = 0;
            filaTodas["NombreCat"] = "-- Ver Todos los Productos --";

            dtFiltro.Rows.InsertAt(filaTodas, 0);

            cmbFiltroCategoria.DataSource = dtFiltro;
            cmbFiltroCategoria.DisplayMember = "NombreCat";
            cmbFiltroCategoria.ValueMember = "IdCategoria";
            cmbFiltroCategoria.SelectedIndex = 0;
        }

        private void cmbFiltroCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFiltroCategoria.SelectedValue == null) return;

            if (int.TryParse(cmbFiltroCategoria.SelectedValue.ToString(), out int idCategoriaSeleccionada))
            {
                DataTable dtProductos = _objetoNegocio.ObtenerProductos();
                DataView dv = dtProductos.DefaultView;

                if (idCategoriaSeleccionada == 0)
                {
                    dv.RowFilter = string.Empty;
                }
                else
                {
                    dv.RowFilter = "IdCategoria = " + idCategoriaSeleccionada;
                }

                dgvProductos.DataSource = dv;
            }
        }

        private void LimpiarFormulario()
        {
            txtID.Clear();
            txtNombre.Clear();
            txtPrecio.Clear();
            txtStock.Clear();
            cmbCategoria.SelectedIndex = -1;
            _esEdicion = false;
            if (cmbFiltroCategoria.Items.Count > 0)
            {
                cmbFiltroCategoria.SelectedIndex = 0;
            }
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // SEGURIDAD DE FLUJO: Si por error _esEdicion está en true pero no hay ID, lo pasamos a false (Registro nuevo)
                if (_esEdicion && string.IsNullOrWhiteSpace(txtID.Text))
                {
                    _esEdicion = false;
                }

                if (cmbCategoria.SelectedValue == null)
                {
                    MessageBox.Show("Por favor, seleccione una categoría válida del menú desplegable.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string mensajeError;

                if (_esEdicion == false)
                {
                    // --- LÓGICA DE REGISTRO NUEVO ---
                    bool exito = _objetoNegocio.RegistrarProducto(
                        txtNombre.Text,
                        txtPrecio.Text.Trim(),
                        txtStock.Text.Trim(),
                        cmbCategoria.SelectedValue,
                        out mensajeError
                    );

                    if (exito)
                    {
                        MessageBox.Show("Producto registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimpiarFormulario();
                        CargarProductos();
                        CargarAuditoria();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo registrar el producto: " + mensajeError, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    // --- LÓGICA DE ACTUALIZACIÓN ---
                    if (string.IsNullOrWhiteSpace(txtID.Text))
                    {
                        MessageBox.Show("Falta el ID para actualizar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    int idProducto = Convert.ToInt32(txtID.Text);
                    bool exito = _objetoNegocio.ModificarProducto(
                        idProducto,
                        txtNombre.Text,
                        txtPrecio.Text.Trim(),
                        txtStock.Text.Trim(),
                        cmbCategoria.SelectedValue,
                        out mensajeError
                    );

                    if (exito)
                    {
                        MessageBox.Show("Producto actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimpiarFormulario();
                        CargarProductos();
                        CargarAuditoria();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo actualizar el producto: " + mensajeError, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción no controlada en el botón: " + ex.Message, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count > 0)
            {
                _esEdicion = true;
                txtID.Text = dgvProductos.CurrentRow.Cells["IdProducto"].Value.ToString();
                txtNombre.Text = dgvProductos.CurrentRow.Cells["NombreProd"].Value.ToString();
                txtPrecio.Text = dgvProductos.CurrentRow.Cells["Precio"].Value.ToString();
                txtStock.Text = dgvProductos.CurrentRow.Cells["StockDisponible"].Value.ToString();
                cmbCategoria.SelectedValue = dgvProductos.CurrentRow.Cells["IdCategoria"].Value;
            }
            else
            {
                MessageBox.Show("Seleccione una fila del catálogo para editar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDeshabilitar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count > 0)
            {
                
                int idProducto = Convert.ToInt32(dgvProductos.CurrentRow.Cells["IdProducto"].Value);

                DialogResult resultado = MessageBox.Show(
                    "¿Estás seguro de que deseas deshabilitar (borrado lógico) este producto?",
                    "Confirmación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (resultado == DialogResult.Yes)
                {
                    string mensajeError;
                    bool exito = _objetoNegocio.DeshabilitarProducto(idProducto, out mensajeError);

                    if (exito)
                    {
                        MessageBox.Show("Producto deshabilitado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimpiarFormulario();
                        CargarProductos();
                        CargarAuditoria();
                    }
                    else
                    {
                        MessageBox.Show("Error al deshabilitar: " + mensajeError, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione una fila del catálogo para deshabilitar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            MessageBox.Show("Formulario limpiado. Listo para registrar un nuevo producto.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnExportarPDF_Click(object sender, EventArgs e)
        {
            if (dgvAuditoria.Rows.Count == 0)
            {
                MessageBox.Show("No hay registros de auditoría para exportar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog guardarPDF = new SaveFileDialog
            {
                Filter = "Archivo PDF (*.pdf)|*.pdf",
                FileName = $"Reporte_Auditoria_EmpaCoctel_{DateTime.Now:yyyyMMdd_HHmmss}.pdf"
            };

            if (guardarPDF.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    iTextSharp.text.Document doc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4.Rotate(), 20f, 20f, 20f, 20f);
                    PdfWriter.GetInstance(doc, new FileStream(guardarPDF.FileName, FileMode.Create));
                    doc.Open();

                    iTextSharp.text.Font fuenteTitulo = iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA_BOLD, 16f);
                    iTextSharp.text.Font fuenteSubtitulo = iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, 10f);

                    doc.Add(new iTextSharp.text.Paragraph("REPORTE DE TRAZABILIDAD Y AUDITORÍA", fuenteTitulo));
                    doc.Add(new iTextSharp.text.Paragraph($"Sistema: EmpaCóctel MVP | Fecha de Emisión: {DateTime.Now:dd/MM/yyyy HH:mm:ss}", fuenteSubtitulo));
                    doc.Add(new iTextSharp.text.Paragraph($"Usuario Generador: {Environment.UserName}\n\n", fuenteSubtitulo));

                    PdfPTable tabla = new PdfPTable(dgvAuditoria.Columns.Count);
                    tabla.WidthPercentage = 100f;

                    foreach (DataGridViewColumn columna in dgvAuditoria.Columns)
                    {
                        PdfPCell celdaHeader = new PdfPCell(new iTextSharp.text.Phrase(columna.HeaderText, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA_BOLD, 9f)));
                        celdaHeader.BackgroundColor = iTextSharp.text.BaseColor.LightGray;
                        tabla.AddCell(celdaHeader);
                    }

                    foreach (DataGridViewRow fila in dgvAuditoria.Rows)
                    {
                        if (!fila.IsNewRow)
                        {
                            foreach (DataGridViewCell celda in fila.Cells)
                            {
                                string valor = celda.Value?.ToString() ?? "";
                                tabla.AddCell(new iTextSharp.text.Phrase(valor, iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, 8f)));
                            }
                        }
                    }

                    doc.Add(tabla);
                    doc.Close();

                    MessageBox.Show("Reporte de Auditoría PDF generado con éxito.", "Producto registrado correctamente.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al generar el PDF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}