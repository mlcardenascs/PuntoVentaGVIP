using System;
using System.Drawing;
using System.Web.UI.WebControls.WebParts;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using MySql.Data.MySqlClient;
using Tulpep.NotificationWindow;

namespace GVIP_Administrativo_3._0 {
    public partial class ReportEmpleados : Form {
        public ReportEmpleados() {
            InitializeComponent();
        }

        private void ReportEmpleados_Load(object sender, EventArgs e) {
            this.WindowState = FormWindowState.Maximized;
            this.button1.Location = new Point(1600, 39);
            this.btnReturn.Location = new Point(1775, 39);
            this.comboBox1.Enabled = false;
            this.panel1.BackColor = Color.FromArgb(74, 89, 152);
            this.groupBox1.BackColor = Color.FromArgb(163, 180, 220);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string consulta = null, orden = "ASC";

            if (comboBox1.Text == "Descendente")
            {
                orden = "DESC";
            }
            if (chkBoxTodo.Checked)
            {
                consulta = "select * from empleados";
                ShowReport(consulta);
            }
            else if (chkBoxFecha.Checked)
            {
                consulta = "select * from empleados order by Fecha_contratacion " + orden;
                ShowReport(consulta);
            }
            else if (chkBoxSueldo.Checked)
            {
                consulta = "select * from empleados order by Sueldo " + orden;
                ShowReport(consulta);
            }
        }

        private void ShowReport(string consulta) {
            try {
                DataSetEmpleados DSEmpleados = new DataSetEmpleados();
                string connect = App.cadena_conexion;
                MySqlConnection conexion = new MySqlConnection(connect);
                MySqlDataAdapter da = new MySqlDataAdapter(consulta, conexion);
                da.Fill(DSEmpleados, DSEmpleados.Tables[0].TableName);
                ReportDataSource rds = new ReportDataSource("Empleados2", DSEmpleados.Tables[0]);
                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(rds);
                this.reportViewer1.LocalReport.Refresh();
                this.reportViewer1.RefreshReport();
                ReportParameter PFecha = new ReportParameter("PFecha", DateTime.Now.ToString());
                this.reportViewer1.LocalReport.SetParameters(PFecha);
                this.reportViewer1.RefreshReport();
                conexion.Close();

                PopupNotifier notifier = new PopupNotifier();
                notifier.TitleText = "Generacion de reportes";
                notifier.ContentText = "El reporte de Empleados se ha generado con exito!";
                notifier.BodyColor = Color.FromArgb(74, 89, 152);
                notifier.TitleColor = Color.FromArgb(255, 255, 255);
                notifier.Delay = 2500;
                notifier.Popup();
            }
            catch(Exception ex) {
                MessageBox.Show("Asegurate de que los parametros sean correctos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void reportViewer1_ReportExport(object sender, ReportExportEventArgs e) {
            PopupNotifier notifier = new PopupNotifier();
            notifier.TitleText = "Generacion de reportes";
            notifier.ContentText = "El reporte de Empleados se ha guardado con exito!";
            notifier.BodyColor = Color.FromArgb(74, 89, 152);
            notifier.TitleColor = Color.FromArgb(255, 255, 255);
            notifier.Delay = 2500;
            notifier.Popup();
        }

        private void chkBoxEdad_CheckedChanged(object sender, EventArgs e) {
            this.chkBoxFecha.Checked = false;
            this.chkBoxSueldo.Checked = false;
            this.chkBoxTodo.Checked = false;
            this.comboBox1.Enabled = true;
            this.comboBox1.Text = "Ascendente";
        }

        private void btnReturn_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void chkBoxSueldo_CheckedChanged(object sender, EventArgs e) {
            this.chkBoxFecha.Checked = false;
            this.chkBoxTodo.Checked = false;
            this.comboBox1.Enabled = true;
            this.comboBox1.Text = "Ascendente";
        }

        private void chkBoxFecha_CheckedChanged(object sender, EventArgs e) {
            this.chkBoxTodo.Checked = false;
            this.chkBoxSueldo.Checked = false;
            this.comboBox1.Enabled = true;
            this.comboBox1.Text = "Ascendente";
        }

        private void chkBoxTodo_CheckedChanged(object sender, EventArgs e) {
            this.chkBoxFecha.Checked = false;
            this.chkBoxSueldo.Checked = false;
            this.comboBox1.Enabled = false;
            this.comboBox1.Text = "";
        }
    }
}