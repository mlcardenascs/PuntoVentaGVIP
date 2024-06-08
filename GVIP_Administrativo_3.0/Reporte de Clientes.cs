using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using MySql.Data.MySqlClient;
using Tulpep.NotificationWindow;

namespace GVIP_Administrativo_3._0 {
    public partial class Reporte_de_Clientes : Form {
        public Reporte_de_Clientes( ){
            InitializeComponent();
        }
        private void Reporte_de_Clientes_Load(object sender, EventArgs e ){
            this.WindowState = FormWindowState.Maximized;
            this.panel1.BackColor = Color.FromArgb(74, 89, 152);
            this.button1.Location = new Point(1600, 39);
            this.btnReturn.Location = new Point(1775, 39);
            this.groupBox1.BackColor = Color.FromArgb(163, 180, 220);
            this.comboBox1.Enabled = false;
        }
        private void button1_Click(object sender, EventArgs e) {
            string consulta = null, orden = "ASC";

            if (comboBox1.Text == "Descendente") {
                orden = "DESC";
            }

            if (chkBoxTodo.Checked) {
                consulta = "select * from clientes";
                ShowReport(consulta);
            }else if (chkBoxEdad.Checked){
                consulta = "select * from clientes order by Edad "+ orden;
                ShowReport(consulta);
            }
            else if (chkBoxNombre.Checked) {
                consulta = "select * from clientes order by Nombres " + orden;
                ShowReport(consulta);
            }
        }


        private void ShowReport(string consulta) {
            try {
                DataSetClientes DSClientes = new DataSetClientes();
                string connect = App.cadena_conexion;
                MySqlConnection conexion = new MySqlConnection(connect);
                MySqlDataAdapter da = new MySqlDataAdapter(consulta, conexion);
                da.Fill(DSClientes, DSClientes.Tables[0].TableName);
                ReportDataSource rds = new ReportDataSource("Clientes", DSClientes.Tables[0]);
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
                notifier.ContentText = "El reporte de Clientes se ha generado con exito!";
                notifier.BodyColor = Color.FromArgb(74, 89, 152);
                notifier.TitleColor = Color.FromArgb(255, 255, 255);
                notifier.Delay = 2500;
                notifier.Popup();
            }
            catch(Exception ex) {
                MessageBox.Show("Asegurate de que los parámetros sean correctos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void reportViewer1_ReportExport(object sender, ReportExportEventArgs e) {
            PopupNotifier notifier = new PopupNotifier();
            notifier.TitleText = "Generacion de reportes";
            notifier.ContentText = "El reporte de Clientes se ha guardado con exito!";
            notifier.BodyColor = Color.FromArgb(74, 89, 152);
            notifier.TitleColor = Color.FromArgb(255, 255, 255);
            notifier.Delay = 2500;
            notifier.Popup();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkBoxNombre_CheckedChanged(object sender, EventArgs e)
        {
            this.chkBoxEdad.Checked = false;
            this.chkBoxTodo.Checked = false;
            this.comboBox1.Text = "Ascedente";
            this.comboBox1.Enabled = true;
        }

        private void chkBoxEdad_CheckedChanged(object sender, EventArgs e)
        {
            this.chkBoxTodo.Checked = false;
            this.chkBoxNombre.Checked = false;
            this.comboBox1.Text = "Ascendente";
            this.comboBox1.Enabled = true;
        }

        private void chkBoxTodo_CheckedChanged(object sender, EventArgs e)
        {
            this.chkBoxEdad.Checked = false;
            this.chkBoxNombre.Checked = false;
            this.comboBox1.Enabled = false;
            this.comboBox1.Text = "";
        }
    }
}