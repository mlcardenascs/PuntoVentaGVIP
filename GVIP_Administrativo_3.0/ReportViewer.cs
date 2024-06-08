using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Microsoft.Reporting.WinForms;
using Tulpep.NotificationWindow;

namespace GVIP_Administrativo_3._0 {
    public partial class ReportViewer : Form {
        public ReportViewer() {
            InitializeComponent();
        }

        private void ReportViewer_Load(object sender, EventArgs e) {
            this.DatePicker1.Enabled = false;
            this.DatePicker2.Enabled = false;
            this.txtIdProducto.Enabled = false;
            this.txtIdVenta.Enabled = false;
            this.reportViewer1.RefreshReport();
            this.WindowState = FormWindowState.Maximized; //Muestra el form maximizado
            this.button1.Location = new Point(1600, 39);
            this.btnReturn.Location = new Point(1775, 39);
            this.panel1.BackColor = Color.FromArgb(74, 89, 152);
            this.groupBox1.BackColor = Color.FromArgb(163, 180, 220);
            this.groupBox2.BackColor = Color.FromArgb(163, 180, 220);
            this.groupBox3.BackColor = Color.FromArgb(163, 180, 220);

            ToolTip tooltip = new ToolTip();
            tooltip.SetToolTip(chkBoxFechas, "La fecha 1 no puede ser mayor a la fecha 2!");
            tooltip.SetToolTip(chkBoxIdProd, "Ingresa un numero válido!");
            tooltip.SetToolTip(chkBoxIdVenta, "Ingresa un numero válido!");
            tooltip.SetToolTip(txtIdProducto, "No ingreses valores nulos o negativos!");
            tooltip.SetToolTip(txtIdVenta, "No ingreses valores nulos o negativos!");
        }

        private void button1_Click(object sender, EventArgs e) {
            //Declaracion de variables para las fechas y los Id
            string fecha1 = null, fecha2 = null, consulta = null, consulta2 = null, id = null; 
             
            //Al final de cada if se llama a una funcion con un string que es la consulta que genera el reporte
            if (chkBoxFechas.Checked) {
                //Obtiene las fechas que elige el usuario y les da un formato para hacer la consulta en MySql
                fecha1 = DatePicker1.Value.ToString("yyyy-MM-dd");
                fecha2 = DatePicker2.Value.ToString("yyyy-MM-dd");
                consulta = "select * from detalle_ventas where Fecha >= '" + fecha1 + "' and Fecha <= '" + fecha2 + "'";
                consulta2 = "select SUM(Total) from detalle_ventas where Fecha >= '"+ fecha1 + "' and Fecha <= '" + fecha2 + "'";

                //Verifica que la fecha 1 no pueda ser mayor a la fecha 2
                if ((Convert.ToInt32(fecha1.Substring(5, 2)) > Convert.ToInt32(fecha2.Substring(5, 2)) && (Convert.ToInt32(fecha1.Substring(8, 2)) > Convert.ToInt32(fecha2.Substring(8, 2)))) || (Convert.ToInt32(fecha1.Substring(8, 2)) > Convert.ToInt32(fecha2.Substring(8, 2)))) {
                    MessageBox.Show("Intervalo no válido. \n Elige otra fecha!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                ShowReport(consulta);
                Putparameters(consulta2);
            //Cambia el string de consulta a uno que seleccione todo dependiendo de un ID de Producto ingresado por el usuarios   
            } else if (chkBoxIdProd.Checked) {
                consulta = "select * from detalle_ventas where ID_Producto = " + txtIdProducto.Text;
                consulta2 = "select SUM(Total) from detalle_ventas where ID_Producto = " + txtIdProducto.Text;
                ShowReport(consulta);
                Putparameters(consulta2);
                //Cambia el string de consulta a uno que seleccione todo dependiendo de un ID de Venta ingresado por el usuarios   
            }
            else if (chkBoxIdVenta.Checked) {
                consulta = "select * from detalle_ventas where ID_Venta = " + txtIdVenta.Text;
                consulta2 = "select SUM(Total) from detalle_ventas where ID_Venta = " + txtIdVenta.Text;
                ShowReport(consulta);
                Putparameters(consulta2);
            }
            else if (chkBoxTodo.Checked) {
                consulta = "select * from detalle_ventas";
                consulta2 = "select SUM(Total) from detalle_ventas";
                ShowReport(consulta);
                Putparameters(consulta2);
            }
        }     
        
        private void Putparameters(string consulta2) {
            try {
                //Obtiene el total de las ventas dependiendo del parametro que elija el usuario
                string connect = App.cadena_conexion;
                MySqlConnection conexion = new MySqlConnection(connect);
                MySqlCommand sentencia = new MySqlCommand(consulta2, conexion);
                conexion.Open();
                MySqlDataReader reader = sentencia.ExecuteReader();
                reader.Read();
                ReportParameter PTotal = new ReportParameter("PTotal", reader.GetString(0));
                this.reportViewer1.LocalReport.SetParameters(PTotal);
                conexion.Close();
            } catch(Exception ex){
                
            }
            //Mostrar la fecha y hora de generacion del reporte
            ReportParameter PFecha = new ReportParameter("PFecha", DateTime.Now.ToString());
            this.reportViewer1.LocalReport.SetParameters(PFecha);
            this.reportViewer1.RefreshReport();
        }

        //Boton para regresar a la pantalla anterior
        private void btnReturn_Click(object sender, EventArgs e) {
            this.Close();
        }

        //Muestra un PopUp al exportar el reporte
        private void reportViewer1_ReportExport(object sender, ReportExportEventArgs e) {
            PopupNotifier notifier = new PopupNotifier();
            notifier.TitleText = "Generacion de reportes";
            notifier.ContentText = "El reporte a sido guardado con exito!";
            notifier.BodyColor = Color.FromArgb(74, 89, 152);
            notifier.TitleColor = Color.FromArgb(255, 255, 255);
            notifier.Delay = 2500;
            notifier.Popup();
        }
        //Funcion que recive un string con la consulta a realizar, hace la conexion a MySql y el resultado lo muestra en una tabla en un reporte
        private void ShowReport(string consulta) {
            try {
                DataSetVentas DSVentas = new DataSetVentas();
                string connect = App.cadena_conexion;
                MySqlConnection conexion = new MySqlConnection(connect);
                MySqlDataAdapter da = new MySqlDataAdapter(consulta, conexion);
                da.Fill(DSVentas, DSVentas.Tables[0].TableName);
                ReportDataSource rds = new ReportDataSource("Ventas", DSVentas.Tables[0]);
                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(rds);
                this.reportViewer1.LocalReport.Refresh();
                this.reportViewer1.RefreshReport();
                conexion.Close();

                //Muestra un PopUp al mostrar el reporte
                PopupNotifier notifier = new PopupNotifier();
                notifier.TitleText = "Generacion de reportes";
                notifier.ContentText = "El reporte de ventas se ha generado con exito!";
                notifier.BodyColor = Color.FromArgb(74, 89, 152);
                notifier.TitleColor = Color.FromArgb(255, 255, 255);
                notifier.Delay = 2500;
                notifier.Popup();
              
            }
            catch(Exception ex){
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Validaciones de los CheckBox para los parametros
        private void chkBoxIdProd_CheckedChanged(object sender, EventArgs e) { 
            this.txtIdProducto.Enabled = true;
            this.txtIdVenta.Enabled = false;
            this.DatePicker1.Enabled = false;
            this.DatePicker2.Enabled = false;
            chkBoxIdVenta.Checked = false;
            chkBoxFechas.Checked = false;
            this.chkBoxTodo.Checked = false;
            txtIdVenta.Clear();
            txtIdProducto.Focus();
        }

        private void chkBoxIdVenta_CheckedChanged(object sender, EventArgs e){
            this.txtIdVenta.Enabled = true;
            this.txtIdProducto.Enabled = false;
            this.DatePicker1.Enabled = false;
            this.DatePicker2.Enabled = false;
            chkBoxIdProd.Checked= false;
            chkBoxTodo.Checked = false;
            chkBoxFechas.Checked = false;
            txtIdProducto.Clear();
            txtIdVenta.Focus();
        }
        private void chkBoxFechas_CheckedChanged(object sender, EventArgs e){
            this.DatePicker1.Enabled = true;
            this.DatePicker2.Enabled = true;
            this.txtIdProducto.Enabled = false;
            this.txtIdVenta.Enabled = false;
            chkBoxIdProd.Checked = false;
            chkBoxIdVenta.Checked = false;
            txtIdProducto.Clear();
            txtIdVenta.Clear();
        }

        private void chkBoxTodo_CheckedChanged(object sender, EventArgs e) {
            this.txtIdProducto.Enabled= false;
            this.txtIdVenta.Enabled = false;
            this.DatePicker1.Enabled = false;
            this.DatePicker2.Enabled = false;
            this.txtIdVenta.Clear();
            this.txtIdProducto.Clear();
            chkBoxFechas.Checked= false;
            chkBoxIdProd.Checked= false;
            chkBoxIdVenta.Checked= false;
        }
    }
}