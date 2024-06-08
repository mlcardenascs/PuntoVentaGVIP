using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Animation;
using Microsoft.Reporting.WinForms;
using MySql.Data.MySqlClient;


namespace GVIP_Administrativo_3._0 {
    public partial class FormProveedores2 : Form {
        public FormProveedores2() {
            InitializeComponent();
        }

        private void FormProveedores2_Load(object sender, EventArgs e) {
            this.WindowState = FormWindowState.Maximized;
        }

        private void btnMostrar_Click(object sender, EventArgs e) {
            string consulta = null;
            if (chkBoxIdProveedor.Checked) {
                lblD.Text = "Id Proveedor";
                consulta = "select a.ID_Detalle_proveedores, a.ID_Proveedor, a.Nombre_proveedor, a.ID_Producto, a.Nombre_producto, b.cant_produtos from detalle_proveedores as a cross join proveedores as b where a.ID_Proveedor = "+txtID.Text+" and b.ID_Proveedor = "+txtID.Text+";";
                ShowReport(consulta);
            }else if (chkBoxIdProducto.Checked){
                lblD.Text = "Id Producto";
                consulta = "select";
            }
        }

        private void ShowReport(string consulta) {
            Proveedores2 prov = new Proveedores2();
            string connect = App.cadena_conexion;
            MySqlConnection conexion = new MySqlConnection(connect);
            MySqlDataAdapter da = new MySqlDataAdapter(consulta, conexion);
            da.Fill(prov, prov.Tables[0].TableName);
            ReportDataSource dataSource = new ReportDataSource("Proveedores2", prov.Tables[0]);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(dataSource);
            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.RefreshReport();
            conexion.Close();

            this.reportViewer1.RefreshReport();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
