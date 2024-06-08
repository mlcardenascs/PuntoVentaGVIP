namespace GVIP_Administrativo_3._0
{
    partial class ReportEmpleados
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportEmpleados));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnReturn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.chkBoxTodo = new System.Windows.Forms.CheckBox();
            this.chkBoxFecha = new System.Windows.Forms.CheckBox();
            this.chkBoxSueldo = new System.Windows.Forms.CheckBox();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.btnReturn);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1902, 100);
            this.panel1.TabIndex = 0;
            // 
            // btnReturn
            // 
            this.btnReturn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnReturn.Location = new System.Drawing.Point(1785, 41);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(75, 23);
            this.btnReturn.TabIndex = 2;
            this.btnReturn.Text = "Regresar";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(1635, 32);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Mostrar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.chkBoxTodo);
            this.groupBox1.Controls.Add(this.chkBoxFecha);
            this.groupBox1.Controls.Add(this.chkBoxSueldo);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(483, 74);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ordenar por ...";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Ascendente",
            "Descendente"});
            this.comboBox1.Location = new System.Drawing.Point(266, 30);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(99, 24);
            this.comboBox1.TabIndex = 4;
            // 
            // chkBoxTodo
            // 
            this.chkBoxTodo.AutoSize = true;
            this.chkBoxTodo.Location = new System.Drawing.Point(385, 32);
            this.chkBoxTodo.Name = "chkBoxTodo";
            this.chkBoxTodo.Size = new System.Drawing.Size(86, 20);
            this.chkBoxTodo.TabIndex = 3;
            this.chkBoxTodo.Text = "Ver Todo";
            this.chkBoxTodo.UseVisualStyleBackColor = true;
            this.chkBoxTodo.CheckedChanged += new System.EventHandler(this.chkBoxTodo_CheckedChanged);
            // 
            // chkBoxFecha
            // 
            this.chkBoxFecha.AutoSize = true;
            this.chkBoxFecha.Location = new System.Drawing.Point(108, 32);
            this.chkBoxFecha.Name = "chkBoxFecha";
            this.chkBoxFecha.Size = new System.Drawing.Size(143, 20);
            this.chkBoxFecha.TabIndex = 2;
            this.chkBoxFecha.Text = "Fecha contratación";
            this.chkBoxFecha.UseVisualStyleBackColor = true;
            this.chkBoxFecha.CheckedChanged += new System.EventHandler(this.chkBoxFecha_CheckedChanged);
            // 
            // chkBoxSueldo
            // 
            this.chkBoxSueldo.AutoSize = true;
            this.chkBoxSueldo.Location = new System.Drawing.Point(6, 32);
            this.chkBoxSueldo.Name = "chkBoxSueldo";
            this.chkBoxSueldo.Size = new System.Drawing.Size(72, 20);
            this.chkBoxSueldo.TabIndex = 1;
            this.chkBoxSueldo.Text = "Sueldo";
            this.chkBoxSueldo.UseVisualStyleBackColor = true;
            this.chkBoxSueldo.CheckedChanged += new System.EventHandler(this.chkBoxSueldo_CheckedChanged);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.DocumentMapWidth = 1;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "GVIP_Administrativo_3._0.ReporteEmpleados2.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 100);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Padding = new System.Windows.Forms.Padding(520, 0, 0, 0);
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1902, 653);
            this.reportViewer1.TabIndex = 1;
            this.reportViewer1.ReportExport += new Microsoft.Reporting.WinForms.ExportEventHandler(this.reportViewer1_ReportExport);
            // 
            // ReportEmpleados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1902, 753);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReportEmpleados";
            this.Text = "Reporte de Empleados";
            this.Load += new System.EventHandler(this.ReportEmpleados_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkBoxFecha;
        private System.Windows.Forms.CheckBox chkBoxSueldo;
        private System.Windows.Forms.CheckBox chkBoxTodo;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}