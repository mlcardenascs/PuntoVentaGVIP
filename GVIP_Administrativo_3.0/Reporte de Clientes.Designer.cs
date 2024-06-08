namespace GVIP_Administrativo_3._0
{
    partial class Reporte_de_Clientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Reporte_de_Clientes));
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkBoxTodo = new System.Windows.Forms.CheckBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.chkBoxEdad = new System.Windows.Forms.CheckBox();
            this.chkBoxNombre = new System.Windows.Forms.CheckBox();
            this.btnReturn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.btnReturn);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1902, 100);
            this.panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkBoxTodo);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.chkBoxEdad);
            this.groupBox1.Controls.Add(this.chkBoxNombre);
            this.groupBox1.Location = new System.Drawing.Point(19, 17);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(483, 74);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ordenar por ...";
            // 
            // chkBoxTodo
            // 
            this.chkBoxTodo.AutoSize = true;
            this.chkBoxTodo.Location = new System.Drawing.Point(382, 37);
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
            this.comboBox1.Location = new System.Drawing.Point(259, 35);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(89, 24);
            this.comboBox1.TabIndex = 2;
            // 
            // chkBoxEdad
            // 
            this.chkBoxEdad.AutoSize = true;
            this.chkBoxEdad.Location = new System.Drawing.Point(142, 37);
            this.chkBoxEdad.Name = "chkBoxEdad";
            this.chkBoxEdad.Size = new System.Drawing.Size(62, 20);
            this.chkBoxEdad.TabIndex = 1;
            this.chkBoxEdad.Text = "Edad";
            this.chkBoxEdad.UseVisualStyleBackColor = true;
            this.chkBoxEdad.CheckedChanged += new System.EventHandler(this.chkBoxEdad_CheckedChanged);
            // 
            // chkBoxNombre
            // 
            this.chkBoxNombre.AutoSize = true;
            this.chkBoxNombre.Location = new System.Drawing.Point(6, 37);
            this.chkBoxNombre.Name = "chkBoxNombre";
            this.chkBoxNombre.Size = new System.Drawing.Size(78, 20);
            this.chkBoxNombre.TabIndex = 0;
            this.chkBoxNombre.Text = "Nombre";
            this.chkBoxNombre.UseVisualStyleBackColor = true;
            this.chkBoxNombre.CheckedChanged += new System.EventHandler(this.chkBoxNombre_CheckedChanged);
            // 
            // btnReturn
            // 
            this.btnReturn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnReturn.Location = new System.Drawing.Point(1567, 42);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(75, 23);
            this.btnReturn.TabIndex = 1;
            this.btnReturn.Text = "Regresar";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(1696, 42);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Mostrar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.DocumentMapWidth = 1;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "GVIP_Administrativo_3._0.ReportClientes.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 100);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Padding = new System.Windows.Forms.Padding(520, 0, 0, 0);
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1902, 653);
            this.reportViewer1.TabIndex = 1;
            this.reportViewer1.ReportExport += new Microsoft.Reporting.WinForms.ExportEventHandler(this.reportViewer1_ReportExport);
            // 
            // Reporte_de_Clientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1902, 753);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Reporte_de_Clientes";
            this.Text = "Reporte de Clientes";
            this.Load += new System.EventHandler(this.Reporte_de_Clientes_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkBoxNombre;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.CheckBox chkBoxEdad;
        private System.Windows.Forms.CheckBox chkBoxTodo;
    }
}