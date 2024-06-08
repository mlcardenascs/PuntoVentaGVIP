using Microsoft.Reporting.WinForms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tulpep.NotificationWindow;

namespace GVIP_Administrativo_3._0 {
    public partial class ViewerProvider : Form {
        public ViewerProvider() {
            InitializeComponent();
        }

        private void ViewerProvider_Load(object sender, EventArgs e) {
            this.WindowState = FormWindowState.Maximized;
            this.txtID.Enabled= false;
            this.btnMostrar.Location = new Point(1600, 39);
            this.btnRegresar.Location = new Point(1775, 39);
            this.panel1.BackColor = Color.FromArgb(74, 89, 152);
            this.groupBox1.BackColor = Color.FromArgb(163, 180, 220);
            this.groupBox2.BackColor = Color.FromArgb(163, 180, 220);
        }

        private void btnMostrar_Click(object sender, EventArgs e) {
            string consulta = null;
            if (chkBoxIdProveedor.Checked) {
                lblD.Text = "Id Proveedor";
                consulta = "select * from detalle_proveedores where ID_Proveedor = " + txtID.Text;
                ShowReport(consulta);
            }else if (chkBoxIdProducto.Checked){
                lblD.Text = "Id Producto";
                consulta = "select * from detalle_proveedores where ID_Producto = " + txtID.Text;
                ShowReport(consulta);
            }else if (chkBoxVerTodo.Checked) {
                consulta = "select * from detalle_proveedores";
                ShowReport(consulta);
            }

        }

        private void btnRegresar_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void ShowReport(string consulta) {
            try
            {
                DataSetProveedores DSProveedores = new DataSetProveedores();
                string connect = App.cadena_conexion;
                MySqlConnection conexion = new MySqlConnection(connect);
                MySqlDataAdapter da = new MySqlDataAdapter(consulta, conexion);
                da.Fill(DSProveedores, DSProveedores.Tables[0].TableName);
                ReportDataSource rds = new ReportDataSource("Proveedores", DSProveedores.Tables[0]);
                this.ReportViewerProvider.LocalReport.DataSources.Clear();
                this.ReportViewerProvider.LocalReport.DataSources.Add(rds);
                this.ReportViewerProvider.LocalReport.Refresh();
                this.ReportViewerProvider.RefreshReport();
                string fecha = DateTime.Now.ToString();
                ReportParameter PFecha = new ReportParameter("PFecha", DateTime.Now.ToString());
                this.ReportViewerProvider.LocalReport.SetParameters(PFecha);
                this.ReportViewerProvider.RefreshReport();
                conexion.Close();

                PopupNotifier notifier = new PopupNotifier();
                notifier.TitleText = "Generacion de reportes";
                notifier.ContentText = "El reporte de proveedores se ha generado con exito!";
                notifier.BodyColor = Color.FromArgb(74, 89, 152);
                notifier.TitleColor = Color.FromArgb(255, 255, 255);
                notifier.Delay = 2500;
                notifier.Popup();
            } catch (Exception ex) {
                MessageBox.Show("Asegurate de que los parámetros sean correctos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkBoxVerTodo_CheckedChanged(object sender, EventArgs e) {
            this.chkBoxIdProducto.Checked = false;
            this.chkBoxIdProveedor.Checked = false;
            this.txtID.Clear();
            this.txtID.Enabled = false;
        }

        private void chkBoxIdProducto_CheckedChanged(object sender, EventArgs e) {
            this.chkBoxIdProveedor.Checked = false;
            this.chkBoxVerTodo.Checked = false;
            this.txtID.Enabled = true;
            this.txtID.Clear();
        }

        private void chkBoxIdProveedor_CheckedChanged(object sender, EventArgs e) {
            this.chkBoxVerTodo.Checked = false;
            this.chkBoxIdProducto.Checked = false;
            this.txtID.Enabled = true;
            this.txtID.Clear();
        }

        private void ReportViewerProvider_ReportExport(object sender, ReportExportEventArgs e) {
            PopupNotifier notifier = new PopupNotifier();
            notifier.TitleText = "Generacion de reportes";
            notifier.ContentText = "El reporte a sido guardado con exito!";
            notifier.BodyColor = Color.FromArgb(74, 89, 152);
            notifier.TitleColor = Color.FromArgb(255, 255, 255);
            notifier.Delay = 2500;
            notifier.Popup();
        }
    }
}
