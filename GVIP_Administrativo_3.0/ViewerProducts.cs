using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using MySql.Data.MySqlClient;
using Tulpep.NotificationWindow;

namespace GVIP_Administrativo_3._0 {
    public partial class ViewerProducts : Form {
        public ViewerProducts() {
            InitializeComponent();
        }
        private void ViewerProducts_Load(object sender, EventArgs e) {
            this.WindowState = FormWindowState.Maximized;
            this.reportViewer1.RefreshReport();
            this.btnMostrar.Location = new Point(1600, 39);
            this.btnRegresar.Location = new Point(1775, 39);
            this.panel1.BackColor = Color.FromArgb(74, 89, 152);
            this.groupBox1.BackColor = Color.FromArgb(163, 180, 220);
        }

        private void btnRegresar_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void btnMostrar_Click(object sender, EventArgs e) {
            string consulta = null;
            if (chkBoxCantidad.Checked && (comboBox1.Text == "Ascendente")) {
                consulta = "select * from productos order by Cantidad_disponible ASC";
                ShowReport(consulta);
            }else if (chkBoxCantidad.Checked && (comboBox1.Text == "Descendente")) {
                consulta = "select * from productos order by Cantidad_disponible DESC";
                ShowReport(consulta);
            }else if (chkBoxPrecio.Checked && (comboBox1.Text == "Ascendente")) {
                consulta = "select * from productos order by Precio ASC";
                ShowReport(consulta);
            }else if (chkBoxPrecio.Checked && (comboBox1.Text == "Descendente")) {
                consulta = "select * from productos order by Precio DESC";
                ShowReport(consulta);   
            }else if (chkBoxTodo.Checked) {
                consulta = "select * from productos";
                ShowReport(consulta);
            }
            
        }

        private void ShowReport(string consulta) {
            try {
                DataSetProductos DSProductos = new DataSetProductos();
                string connect = App.cadena_conexion;
                MySqlConnection conexion = new MySqlConnection(connect);
                MySqlDataAdapter da = new MySqlDataAdapter(consulta, conexion);
                da.Fill(DSProductos, DSProductos.Tables[0].TableName);
                ReportDataSource rds = new ReportDataSource("Productos", DSProductos.Tables[0]);
                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(rds);
                this.reportViewer1.LocalReport.Refresh();
                this.reportViewer1.RefreshReport();
                conexion.Close();
                ReportParameter PFecha = new ReportParameter("PFecha", DateTime.Now.ToString());
                this.reportViewer1.LocalReport.SetParameters(PFecha);
                this.reportViewer1.RefreshReport();

                PopupNotifier notifier = new PopupNotifier();
                notifier.TitleText = "Generacion de reportes";
                notifier.ContentText = "El reporte de productos se ha generado con exito!";
                notifier.BodyColor = Color.FromArgb(74, 89, 152);
                notifier.TitleColor = Color.FromArgb(255, 255, 255);
                notifier.Delay = 2500;
                notifier.Popup();
            } catch (Exception ex) {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void reportViewer1_ReportExport(object sender, ReportExportEventArgs e) {
            PopupNotifier notifier = new PopupNotifier();
            notifier.TitleText = "Generacion de reportes";
            notifier.ContentText = "El reporte a sido guardado con exito!";
            notifier.BodyColor = Color.FromArgb(74, 89, 152);
            notifier.TitleColor = Color.FromArgb(255, 255, 255);
            notifier.Delay = 2500;
            notifier.Popup();
        }

        private void chkBoxPrecio_CheckedChanged(object sender, EventArgs e) {
            this.chkBoxCantidad.Checked = false;
            this.chkBoxTodo.Checked = false;
            this.comboBox1.Focus();
            comboBox1.Enabled = true;
        }

        private void chkBoxCantidad_CheckedChanged(object sender, EventArgs e) {
            this.chkBoxPrecio.Checked = false;
            this.chkBoxTodo.Checked = false;
            this.comboBox1.Focus();
            comboBox1.Enabled = true;

        }

        private void chkBoxTodo_CheckedChanged(object sender, EventArgs e) {
            this.chkBoxCantidad.Checked = false;
            this.chkBoxPrecio.Checked = false;
            this.comboBox1.Enabled = false;          
        }
    }
}
