﻿namespace GVIP_Administrativo_3._0
{
    partial class FormProveedores2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormProveedores2));
            this.panel1 = new System.Windows.Forms.Panel();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkBoxVerTodo = new System.Windows.Forms.CheckBox();
            this.chkBoxIdProducto = new System.Windows.Forms.CheckBox();
            this.chkBoxIdProveedor = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblD = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.btnRegresar = new System.Windows.Forms.Button();
            this.btnMostrar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.btnRegresar);
            this.panel1.Controls.Add(this.btnMostrar);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1902, 100);
            this.panel1.TabIndex = 0;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "GVIP_Administrativo_3._0.Proveedores2.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 100);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Padding = new System.Windows.Forms.Padding(520, 0, 0, 0);
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1902, 653);
            this.reportViewer1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.groupBox1.Controls.Add(this.chkBoxVerTodo);
            this.groupBox1.Controls.Add(this.chkBoxIdProducto);
            this.groupBox1.Controls.Add(this.chkBoxIdProveedor);
            this.groupBox1.Location = new System.Drawing.Point(24, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(412, 75);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parámetros";
            // 
            // chkBoxVerTodo
            // 
            this.chkBoxVerTodo.AutoSize = true;
            this.chkBoxVerTodo.Location = new System.Drawing.Point(302, 44);
            this.chkBoxVerTodo.Name = "chkBoxVerTodo";
            this.chkBoxVerTodo.Size = new System.Drawing.Size(86, 20);
            this.chkBoxVerTodo.TabIndex = 2;
            this.chkBoxVerTodo.Text = "Ver Todo";
            this.chkBoxVerTodo.UseVisualStyleBackColor = true;
            // 
            // chkBoxIdProducto
            // 
            this.chkBoxIdProducto.AutoSize = true;
            this.chkBoxIdProducto.Location = new System.Drawing.Point(164, 44);
            this.chkBoxIdProducto.Name = "chkBoxIdProducto";
            this.chkBoxIdProducto.Size = new System.Drawing.Size(97, 20);
            this.chkBoxIdProducto.TabIndex = 1;
            this.chkBoxIdProducto.Text = "Id Producto";
            this.chkBoxIdProducto.UseVisualStyleBackColor = true;
            // 
            // chkBoxIdProveedor
            // 
            this.chkBoxIdProveedor.AutoSize = true;
            this.chkBoxIdProveedor.Location = new System.Drawing.Point(10, 45);
            this.chkBoxIdProveedor.Name = "chkBoxIdProveedor";
            this.chkBoxIdProveedor.Size = new System.Drawing.Size(107, 20);
            this.chkBoxIdProveedor.TabIndex = 0;
            this.chkBoxIdProveedor.Text = "Id Proveedor";
            this.chkBoxIdProveedor.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.groupBox2.Controls.Add(this.lblD);
            this.groupBox2.Controls.Add(this.txtID);
            this.groupBox2.Location = new System.Drawing.Point(491, 14);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(299, 74);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ID\'s";
            // 
            // lblD
            // 
            this.lblD.AutoSize = true;
            this.lblD.Location = new System.Drawing.Point(85, 18);
            this.lblD.Name = "lblD";
            this.lblD.Size = new System.Drawing.Size(30, 16);
            this.lblD.TabIndex = 1;
            this.lblD.Text = "Id ...";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(88, 43);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(100, 22);
            this.txtID.TabIndex = 0;
            // 
            // btnRegresar
            // 
            this.btnRegresar.Location = new System.Drawing.Point(1800, 41);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(75, 23);
            this.btnRegresar.TabIndex = 6;
            this.btnRegresar.Text = "Regresar";
            this.btnRegresar.UseVisualStyleBackColor = true;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // btnMostrar
            // 
            this.btnMostrar.Location = new System.Drawing.Point(1697, 41);
            this.btnMostrar.Name = "btnMostrar";
            this.btnMostrar.Size = new System.Drawing.Size(75, 23);
            this.btnMostrar.TabIndex = 5;
            this.btnMostrar.Text = "Mostrar";
            this.btnMostrar.UseVisualStyleBackColor = true;
            this.btnMostrar.Click += new System.EventHandler(this.btnMostrar_Click);
            // 
            // FormProveedores2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1902, 753);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormProveedores2";
            this.Text = "Reporte Proveedores";
            this.Load += new System.EventHandler(this.FormProveedores2_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkBoxVerTodo;
        private System.Windows.Forms.CheckBox chkBoxIdProducto;
        private System.Windows.Forms.CheckBox chkBoxIdProveedor;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblD;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Button btnRegresar;
        private System.Windows.Forms.Button btnMostrar;
    }
}