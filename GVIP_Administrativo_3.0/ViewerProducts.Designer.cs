namespace GVIP_Administrativo_3._0
{
    partial class ViewerProducts
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewerProducts));
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkBoxTodo = new System.Windows.Forms.CheckBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.chkBoxCantidad = new System.Windows.Forms.CheckBox();
            this.chkBoxPrecio = new System.Windows.Forms.CheckBox();
            this.btnRegresar = new System.Windows.Forms.Button();
            this.btnMostrar = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.btnRegresar);
            this.panel1.Controls.Add(this.btnMostrar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1902, 104);
            this.panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.groupBox1.Controls.Add(this.chkBoxTodo);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.chkBoxCantidad);
            this.groupBox1.Controls.Add(this.chkBoxPrecio);
            this.groupBox1.Location = new System.Drawing.Point(22, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(547, 84);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ordenar por ...";
            // 
            // chkBoxTodo
            // 
            this.chkBoxTodo.AutoSize = true;
            this.chkBoxTodo.Location = new System.Drawing.Point(414, 33);
            this.chkBoxTodo.Name = "chkBoxTodo";
            this.chkBoxTodo.Size = new System.Drawing.Size(86, 20);
            this.chkBoxTodo.TabIndex = 3;
            this.chkBoxTodo.Text = "Ver Todo";
            this.chkBoxTodo.UseVisualStyleBackColor = true;
            this.chkBoxTodo.CheckedChanged += new System.EventHandler(this.chkBoxTodo_CheckedChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Ascendente",
            "Descendente"});
            this.comboBox1.Location = new System.Drawing.Point(265, 31);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(111, 24);
            this.comboBox1.TabIndex = 2;
            // 
            // chkBoxCantidad
            // 
            this.chkBoxCantidad.AutoSize = true;
            this.chkBoxCantidad.Location = new System.Drawing.Point(114, 37);
            this.chkBoxCantidad.Name = "chkBoxCantidad";
            this.chkBoxCantidad.Size = new System.Drawing.Size(117, 20);
            this.chkBoxCantidad.TabIndex = 1;
            this.chkBoxCantidad.Text = "Cantidad Disp.";
            this.chkBoxCantidad.UseVisualStyleBackColor = true;
            this.chkBoxCantidad.CheckedChanged += new System.EventHandler(this.chkBoxCantidad_CheckedChanged);
            // 
            // chkBoxPrecio
            // 
            this.chkBoxPrecio.AutoSize = true;
            this.chkBoxPrecio.Location = new System.Drawing.Point(16, 37);
            this.chkBoxPrecio.Name = "chkBoxPrecio";
            this.chkBoxPrecio.Size = new System.Drawing.Size(68, 20);
            this.chkBoxPrecio.TabIndex = 0;
            this.chkBoxPrecio.Text = "Precio";
            this.chkBoxPrecio.UseVisualStyleBackColor = true;
            this.chkBoxPrecio.CheckedChanged += new System.EventHandler(this.chkBoxPrecio_CheckedChanged);
            // 
            // btnRegresar
            // 
            this.btnRegresar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRegresar.Location = new System.Drawing.Point(1780, 41);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(75, 31);
            this.btnRegresar.TabIndex = 1;
            this.btnRegresar.Text = "Regresar";
            this.btnRegresar.UseVisualStyleBackColor = true;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // btnMostrar
            // 
            this.btnMostrar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnMostrar.Location = new System.Drawing.Point(1648, 41);
            this.btnMostrar.Name = "btnMostrar";
            this.btnMostrar.Size = new System.Drawing.Size(75, 31);
            this.btnMostrar.TabIndex = 0;
            this.btnMostrar.Text = "Mostrar";
            this.btnMostrar.UseVisualStyleBackColor = true;
            this.btnMostrar.Click += new System.EventHandler(this.btnMostrar_Click);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.DocumentMapWidth = 1;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "GVIP_Administrativo_3._0.ReporteProductos.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 104);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Padding = new System.Windows.Forms.Padding(520, 0, 0, 0);
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1902, 649);
            this.reportViewer1.TabIndex = 1;
            this.reportViewer1.ReportExport += new Microsoft.Reporting.WinForms.ExportEventHandler(this.reportViewer1_ReportExport);
            // 
            // ViewerProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1902, 753);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ViewerProducts";
            this.Text = "Reporte de Productos";
            this.Load += new System.EventHandler(this.ViewerProducts_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnRegresar;
        private System.Windows.Forms.Button btnMostrar;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.CheckBox chkBoxCantidad;
        private System.Windows.Forms.CheckBox chkBoxPrecio;
        private System.Windows.Forms.CheckBox chkBoxTodo;
    }
}