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

                    doc.Add(new iTextSharp.text.Paragraph("REPORTE DE TRAZABILIDAD Y AUDITORÍA (ISO 27001)", fuenteTitulo));
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