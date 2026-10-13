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
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            panel1 = new Panel();
            label6 = new Label();
            dgvProductos = new DataGridView();
            btnLimpiar = new Button();
            btnDeshabilitar = new Button();
            btnEditar = new Button();
            btnGuardar = new Button();
            cmbCategoria = new ComboBox();
            txtStock = new TextBox();
            txtPrecio = new TextBox();
            txtNombre = new TextBox();
            txtID = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            tabPage2 = new TabPage();
            btnExportarPDF = new Button();
            dgvAuditoria = new DataGridView();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAuditoria).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tabControl1.Location = new Point(1, 6);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1117, 613);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(panel1);
            tabPage1.Controls.Add(dgvProductos);
            tabPage1.Controls.Add(btnLimpiar);
            tabPage1.Controls.Add(btnDeshabilitar);
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
            tabPage1.ForeColor = SystemColors.ControlText;
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1109, 585);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Gestión de Productos";
            tabPage1.UseVisualStyleBackColor = true;
            tabPage1.Click += tabPage1_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.MidnightBlue;
            panel1.Controls.Add(label6);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1103, 50);
            panel1.TabIndex = 15;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.White;
            label6.Location = new Point(355, 14);
            label6.Name = "label6";
            label6.Size = new Size(430, 25);
            label6.TabIndex = 0;
            label6.Text = "EmpaCóctel - Gestión de Inventario y Auditoría";
            // 
            // dgvProductos
            // 
            dgvProductos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProductos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvProductos.BackgroundColor = Color.White;
            dgvProductos.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = Color.SlateGray;
            dataGridViewCellStyle9.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle9.ForeColor = Color.White;
            dataGridViewCellStyle9.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = DataGridViewTriState.True;
            dgvProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductos.EnableHeadersVisualStyles = false;
            dgvProductos.Location = new Point(264, 68);
            dgvProductos.MultiSelect = false;
            dgvProductos.Name = "dgvProductos";
            dgvProductos.ReadOnly = true;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.Size = new Size(817, 476);
            dgvProductos.TabIndex = 14;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnLimpiar.BackColor = Color.SlateGray;
            btnLimpiar.FlatAppearance.BorderSize = 0;
            btnLimpiar.FlatStyle = FlatStyle.Flat;
            btnLimpiar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnLimpiar.ForeColor = Color.White;
            btnLimpiar.Location = new Point(13, 488);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(199, 23);
            btnLimpiar.TabIndex = 9;
            btnLimpiar.Text = "Limpiar Campos";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnDeshabilitar
            // 
            btnDeshabilitar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnDeshabilitar.BackColor = Color.Crimson;
            btnDeshabilitar.FlatAppearance.BorderSize = 0;
            btnDeshabilitar.FlatStyle = FlatStyle.Flat;
            btnDeshabilitar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnDeshabilitar.ForeColor = Color.White;
            btnDeshabilitar.Location = new Point(13, 432);
            btnDeshabilitar.Name = "btnDeshabilitar";
            btnDeshabilitar.Size = new Size(199, 23);
            btnDeshabilitar.TabIndex = 8;
            btnDeshabilitar.Text = "Deshabilitar (Borrado)";
            btnDeshabilitar.UseVisualStyleBackColor = false;
            btnDeshabilitar.Click += btnDeshabilitar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnEditar.BackColor = Color.DodgerBlue;
            btnEditar.FlatAppearance.BorderSize = 0;
            btnEditar.FlatStyle = FlatStyle.Flat;
            btnEditar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnEditar.ForeColor = Color.White;
            btnEditar.Location = new Point(13, 374);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(199, 23);
            btnEditar.TabIndex = 7;
            btnEditar.Text = "Editar Seleccionado";
            btnEditar.UseVisualStyleBackColor = false;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnGuardar.BackColor = Color.SeaGreen;
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(13, 321);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(199, 23);
            btnGuardar.TabIndex = 6;
            btnGuardar.Text = "Guardar / Actualizar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // cmbCategoria
            // 
            cmbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategoria.FormattingEnabled = true;
            cmbCategoria.Location = new Point(91, 223);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(121, 23);
            cmbCategoria.TabIndex = 5;
            // 
            // txtStock
            // 
            txtStock.Location = new Point(91, 181);
            txtStock.Name = "txtStock";
            txtStock.Size = new Size(121, 23);
            txtStock.TabIndex = 4;
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(91, 142);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(121, 23);
            txtPrecio.TabIndex = 3;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(91, 103);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(121, 23);
            txtNombre.TabIndex = 1;
            // 
            // txtID
            // 
            txtID.Enabled = false;
            txtID.Location = new Point(91, 68);
            txtID.Name = "txtID";
            txtID.Size = new Size(121, 23);
            txtID.TabIndex = 0;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label5.Location = new Point(13, 226);
            label5.Name = "label5";
            label5.Size = new Size(63, 15);
            label5.TabIndex = 4;
            label5.Text = "Categoría:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label4.Location = new Point(13, 184);
            label4.Name = "label4";
            label4.Size = new Size(42, 15);
            label4.TabIndex = 3;
            label4.Text = "Stock:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.Location = new Point(13, 145);
            label3.Name = "label3";
            label3.Size = new Size(63, 15);
            label3.TabIndex = 2;
            label3.Text = "Precio ($):";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.Location = new Point(13, 111);
            label2.Name = "label2";
            label2.Size = new Size(56, 15);
            label2.TabIndex = 1;
            label2.Text = "Nombre:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.Location = new Point(13, 76);
            label1.Name = "label1";
            label1.Size = new Size(23, 15);
            label1.TabIndex = 0;
            label1.Text = "ID:";
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
            // btnExportarPDF
            // 
            btnExportarPDF.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnExportarPDF.BackColor = Color.SlateGray;
            btnExportarPDF.FlatAppearance.BorderSize = 0;
            btnExportarPDF.FlatStyle = FlatStyle.Flat;
            btnExportarPDF.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExportarPDF.ForeColor = Color.White;
            btnExportarPDF.Location = new Point(896, 534);
            btnExportarPDF.Name = "btnExportarPDF";
            btnExportarPDF.Size = new Size(207, 26);
            btnExportarPDF.TabIndex = 10;
            btnExportarPDF.Text = "Exportar Auditoría a PDF";
            btnExportarPDF.UseVisualStyleBackColor = false;
            btnExportarPDF.Click += btnExportarPDF_Click;
            // 
            // dgvAuditoria
            // 
            dgvAuditoria.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvAuditoria.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAuditoria.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvAuditoria.BackgroundColor = Color.White;
            dgvAuditoria.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = Color.DarkSlateGray;
            dataGridViewCellStyle10.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle10.ForeColor = Color.White;
            dataGridViewCellStyle10.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = DataGridViewTriState.True;
            dgvAuditoria.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            dgvAuditoria.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAuditoria.EnableHeadersVisualStyles = false;
            dgvAuditoria.Location = new Point(7, 6);
            dgvAuditoria.Name = "dgvAuditoria";
            dgvAuditoria.ReadOnly = true;
            dgvAuditoria.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAuditoria.Size = new Size(1096, 481);
            dgvAuditoria.TabIndex = 0;
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
            Load += Form1_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            tabPage2.ResumeLayout(false);
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
        private Button btnDeshabilitar;
        private Button btnEditar;
        private Button btnGuardar;
        private DataGridView dgvProductos;
        private DataGridView dgvAuditoria;
        private Button btnExportarPDF;
        private Panel panel1;
        private Label label6;
    }
}
