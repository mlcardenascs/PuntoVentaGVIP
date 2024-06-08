using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace GVIP_Administrativo_3._0.ViewModelss {
    /// <summary>
    /// Lógica de interacción para ReportPage.xaml
    /// </summary>
    public partial class ReportPage : Page {
        public ReportPage() {
            InitializeComponent();
        }
        private void btn_ReporetVentas_Click(object sender, RoutedEventArgs e) {
            ReportViewer rpv = new ReportViewer();
            rpv.Show(); 
        }

        private void btn_ReporteProveedores_Click(object sender, RoutedEventArgs e) {
            ViewerProvider ReportProvier = new ViewerProvider();
            ReportProvier.Show();
            //FormProveedores2 fp2 = new FormProveedores2();
           //fp2.Show();
        }

        private void btn_ReporteProductos_Click(object sender, RoutedEventArgs e) {
            ViewerProducts ViewProducts = new ViewerProducts();
            ViewProducts.Show();
        }

        private void btn_ReporteEmpleados_Click(object sender, RoutedEventArgs e) {
            ReportEmpleados ReporteEmpleados = new ReportEmpleados();
            ReporteEmpleados.Show();
        }

        private void btn_RepprteClientes_Click(object sender, RoutedEventArgs e) {
            Reporte_de_Clientes ReportCustomer = new Reporte_de_Clientes();
            ReportCustomer.Show();
        }
    }
}
