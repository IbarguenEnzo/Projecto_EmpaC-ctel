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
            CargarCategorias();
            CargarProductos();
            CargarAuditoria();
        }

        // ============================================================================
        // MÉTODOS DE CARGA DE DATOS
        // ============================================================================
        private void CargarCategorias()
        {
            cmbCategoria.DataSource = _objetoNegocio.ObtenerCategorias();
            cmbCategoria.DisplayMember = "NombreCat";
            cmbCategoria.ValueMember = "IdCategoria";
            cmbCategoria.SelectedIndex = -1;
        }

        private void CargarProductos()
        {
            dgvProductos.DataSource = _objetoNegocio.ObtenerProductos();
        }

        private void CargarAuditoria()
        {
            dgvAuditoria.DataSource = _objetoNegocio.ObtenerAuditoria();
        }

        private void LimpiarFormulario()
        {
            txtID.Clear();
            txtNombre.Clear();
            txtPrecio.Clear();
            txtStock.Clear();
            cmbCategoria.SelectedIndex = -1;
            _esEdicion = false;
        }

        // ============================================================================
        // BOTONES DE OPERACIÓN (CRUD)
        // ============================================================================
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string mensajeError;

            if (_esEdicion == false)
            {
                // INSERCIÓN
                bool exito = _objetoNegocio.RegistrarProducto(
                    txtNombre.Text,
                    txtPrecio.Text,
                    txtStock.Text,
                    cmbCategoria.SelectedValue,
                    out mensajeError
                );

                if (exito)
                {
                    MessageBox.Show("Producto registrado correctamente en EmpaCóctel.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarFormulario();
                    CargarProductos();
                    CargarAuditoria();
                }
                else
                {
                    MessageBox.Show(mensajeError, "Error de Validación (IEEE 830)", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                // ACTUALIZACIÓN
                int idProducto = Convert.ToInt32(txtID.Text);
                bool exito = _objetoNegocio.ModificarProducto(
                    idProducto,
                    txtNombre.Text,
                    txtPrecio.Text,
                    txtStock.Text,
                    cmbCategoria.SelectedValue,
                    out mensajeError
                );

                if (exito)
                {
                    MessageBox.Show("Producto modificado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarFormulario();
                    CargarProductos();
                    CargarAuditoria();
                }
                else
                {
                    MessageBox.Show(mensajeError, "Error de Validación (IEEE 830)", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count > 0)
            {
                int idProducto = Convert.ToInt32(dgvProductos.CurrentRow.Cells["IdProducto"].Value);
                string nombreProd = dgvProductos.CurrentRow.Cells["NombreProd"].Value.ToString();

                DialogResult respuesta = MessageBox.Show(
                    $"¿Está seguro de deshabilitar el producto \"{nombreProd}\"?",
                    "Confirmación (Borrado Lógico)",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (respuesta == DialogResult.Yes)
                {
                    string mensajeError;
                    bool exito = _objetoNegocio.DeshabilitarProducto(idProducto, out mensajeError);

                    if (exito)
                    {
                        MessageBox.Show("Producto deshabilitado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimpiarFormulario();
                        CargarProductos();
                        CargarAuditoria();
                    }
                    else
                    {
                        MessageBox.Show(mensajeError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione un producto a deshabilitar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        // ============================================================================
        // GENERACIÓN DE REPORTE PDF (CUMPLIMIENTO ISO 27001)
        // ============================================================================
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
                    Document doc = new Document(PageSize.A4.Rotate(), 20, 20, 20, 20);
                    PdfWriter.GetInstance(doc, new FileStream(guardarPDF.FileName, FileMode.Create));
                    doc.Open();

                    // Encabezado
                    Font fuenteTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16);
                    Font fuenteSubtitulo = FontFactory.GetFont(FontFactory.HELVETICA, 10);

                    doc.Add(new Paragraph("REPORTE DE TRAZABILIDAD Y AUDITORÍA (ISO 27001)", fuenteTitulo));
                    doc.Add(new Paragraph($"Sistema: EmpaCóctel MVP | Fecha de Emisión: {DateTime.Now:dd/MM/yyyy HH:mm:ss}", fuenteSubtitulo));
                    doc.Add(new Paragraph($"Usuario Generador: {Environment.UserName}\n\n", fuenteSubtitulo));

                    // Tabla de auditoría
                    PdfPTable tabla = new PdfPTable(dgvAuditoria.Columns.Count);
                    tabla.WidthPercentage = 100;

                    foreach (DataGridViewColumn columna in dgvAuditoria.Columns)
                    {
                        PdfPCell celdaHeader = new PdfPCell(new Phrase(columna.HeaderText, FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 9)));
                        celdaHeader.BackgroundColor = BaseColor.LIGHT_GRAY;
                        tabla.AddCell(celdaHeader);
                    }

                    foreach (DataGridViewRow fila in dgvAuditoria.Rows)
                    {
                        if (!fila.IsNewRow)
                        {
                            foreach (DataGridViewCell celda in fila.Cells)
                            {
                                string valor = celda.Value?.ToString() ?? "";
                                tabla.AddCell(new Phrase(valor, FontFactory.GetFont(FontFactory.HELVETICA, 8)));
                            }
                        }
                    }

                    doc.Add(tabla);
                    doc.Close();

                    MessageBox.Show("Reporte de Auditoría PDF generado con éxito.", "ISO 27001 Compliance", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al generar el PDF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}