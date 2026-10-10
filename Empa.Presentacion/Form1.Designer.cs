namespace Empa.Presentacion
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtID = new TextBox();
            txtNombre = new TextBox();
            txtPrecio = new TextBox();
            txtStock = new TextBox();
            cmbCategoria = new ComboBox();
            btnGuardar = new Button();
            btnEditar = new Button();
            btnEliminar = new Button();
            btnLimpiar = new Button();
            dgvProductos = new DataGridView();
            dgvAuditoria = new DataGridView();
            btnExportarPDF = new Button();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvAuditoria).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(1, 6);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1117, 613);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(dgvProductos);
            tabPage1.Controls.Add(btnLimpiar);
            tabPage1.Controls.Add(btnEliminar);
            tabPage1.Controls.Add(btnEditar);
            tabPage1.Controls.Add(btnGuardar);
            tabPage1.Controls.Add(cmbCategoria);
            tabPage1.Controls.Add(txtStock);
            tabPage1.Controls.Add(txtPrecio);
            tabPage1.Controls.Add(txtNombre);
            tabPage1.Controls.Add(txtID);
            tabPage1.Controls.Add(label5);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(label1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1109, 585);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Gestión de Productos";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(btnExportarPDF);
            tabPage2.Controls.Add(dgvAuditoria);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1109, 585);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Historial de Auditoría";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 38);
            label1.Name = "label1";
            label1.Size = new Size(21, 15);
            label1.TabIndex = 0;
            label1.Text = "ID:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 78);
            label2.Name = "label2";
            label2.Size = new Size(54, 15);
            label2.TabIndex = 1;
            label2.Text = "Nombre:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(13, 128);
            label3.Name = "label3";
            label3.Size = new Size(60, 15);
            label3.TabIndex = 2;
            label3.Text = "Precio ($):";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(13, 175);
            label4.Name = "label4";
            label4.Size = new Size(39, 15);
            label4.TabIndex = 3;
            label4.Text = "Stock:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(13, 218);
            label5.Name = "label5";
            label5.Size = new Size(61, 15);
            label5.TabIndex = 4;
            label5.Text = "Categoría:";
            // 
            // txtID
            // 
            txtID.Enabled = false;
            txtID.Location = new Point(91, 35);
            txtID.Name = "txtID";
            txtID.Size = new Size(121, 23);
            txtID.TabIndex = 5;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(91, 78);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(121, 23);
            txtNombre.TabIndex = 6;
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(91, 120);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(121, 23);
            txtPrecio.TabIndex = 7;
           // txtPrecio.TextChanged += txtPrecio_TextChanged;
            // 
            // txtStock
            // 
            txtStock.Location = new Point(91, 167);
            txtStock.Name = "txtStock";
            txtStock.Size = new Size(121, 23);
            txtStock.TabIndex = 8;
            // 
            // cmbCategoria
            // 
            cmbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategoria.FormattingEnabled = true;
            cmbCategoria.Location = new Point(91, 218);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(121, 23);
            cmbCategoria.TabIndex = 9;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(13, 321);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(199, 23);
            btnGuardar.TabIndex = 10;
            btnGuardar.Text = "Guardar / Actualizar";
            btnGuardar.UseVisualStyleBackColor = true;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(13, 374);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(199, 23);
            btnEditar.TabIndex = 11;
            btnEditar.Text = "Editar Seleccionado";
            btnEditar.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(13, 432);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(199, 23);
            btnEliminar.TabIndex = 12;
            btnEliminar.Text = "Deshabilitar (Borrado)";
            btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(13, 488);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(199, 23);
            btnLimpiar.TabIndex = 13;
            btnLimpiar.Text = "Limpiar Campos";
            btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // dgvProductos
            // 
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductos.Location = new Point(272, 35);
            dgvProductos.MultiSelect = false;
            dgvProductos.Name = "dgvProductos";
            dgvProductos.ReadOnly = true;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.Size = new Size(817, 476);
            dgvProductos.TabIndex = 14;
            // 
            // dgvAuditoria
            // 
            dgvAuditoria.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAuditoria.Location = new Point(7, 6);
            dgvAuditoria.Name = "dgvAuditoria";
            dgvAuditoria.ReadOnly = true;
            dgvAuditoria.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAuditoria.Size = new Size(1096, 481);
            dgvAuditoria.TabIndex = 0;
            // 
            // btnExportarPDF
            // 
            btnExportarPDF.Location = new Point(896, 534);
            btnExportarPDF.Name = "btnExportarPDF";
            btnExportarPDF.Size = new Size(207, 23);
            btnExportarPDF.TabIndex = 1;
            btnExportarPDF.Text = "Exportar Auditoría a PDF";
            btnExportarPDF.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1130, 612);
            Controls.Add(tabControl1);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EmpaCóctel - Control de Productos y Auditoría";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvAuditoria).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TextBox txtStock;
        private TextBox txtPrecio;
        private TextBox txtNombre;
        private TextBox txtID;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private ComboBox cmbCategoria;
        private Button btnLimpiar;
        private Button btnEliminar;
        private Button btnEditar;
        private Button btnGuardar;
        private DataGridView dgvProductos;
        private DataGridView dgvAuditoria;
        private Button btnExportarPDF;
    }
}
