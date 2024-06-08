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
using System.Windows.Shapes;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Windows.Interop;
using GVIP_Administrativo_3._0.ViewModelss;
using System.Drawing;



namespace GVIP_Administrativo_3._0.View
{
    /// <summary>
    /// Lógica de interacción para PrincipalView.xaml
    /// </summary>
    public partial class PrincipalView : Window
    {
        public PrincipalView()
        {
            InitializeComponent();
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
            txtNombreUsuario.Text = App.usuario_global;

            WindowState=WindowState.Maximized;

            Tema tema = new Tema();

            List<Tema> Colores_tema = tema.Cargar_tema();

            
            

            /* 
             Lateral_izquierdo.Color = (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString(Convert.ToString(Colores_tema[0].Principal));
            Lateral_derecho.Color = (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString(Convert.ToString(Colores_tema[0].Secundario));

            btnVentas.Tag = (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString(Convert.ToString(Colores_tema[0].Iconos));
            texto_ventas.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString(Colores_tema[0].Letras);
*/
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);

        private void pnlControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WindowInteropHelper helper = new WindowInteropHelper(this);
            SendMessage(helper.Handle,161, (IntPtr)2, (IntPtr)0);

        }

        private void pnlControl_MouseEnter(object sender, MouseEventArgs e)
        {
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnMaximize_Click(object sender, RoutedEventArgs e)
        {

            if (this.WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Maximized;
            }
            else
            {
                this.WindowState = WindowState.Normal;
            }
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {

            this.WindowState = WindowState.Minimized;
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnVentas_Click(object sender, RoutedEventArgs e)
        {
            ContenedorPrincipal.Content = new SalesPage();
            TituloContenido.Text = "Ventas";
        }

        private void btnVentas_completo_Click(object sender, RoutedEventArgs e)
        {

        }

        //Metodos para reiniciar el contenido principal remotamente

        public void Reiniciar_ventas()
        {
            ContenedorPrincipal.Content = new SalesPage();
            TituloContenido.Text = "Ventas";
        }


        private void btnEmpleados_Click(object sender, RoutedEventArgs e)
        {
            ContenedorPrincipal.Content = new EmployeePage();
            TituloContenido.Text = "Empleados";
        }

        private void btnClientes_Click(object sender, RoutedEventArgs e)
        {
            ContenedorPrincipal.Content = new CustomerPage();
            TituloContenido.Text = "Clientes";
        }

        private void btnProductos_Click(object sender, RoutedEventArgs e)
        {
            ContenedorPrincipal.Content = new ProductPage();
            TituloContenido.Text = "Productos";
        }

        private void btnProveedores_Click(object sender, RoutedEventArgs e)
        {
            ContenedorPrincipal.Content = new SupplierPage();
            TituloContenido.Text = "Proveedores";
        }

        private void btnUsuarios_Click(object sender, RoutedEventArgs e)
        {
            ContenedorPrincipal.Content = new UsersPage();
            TituloContenido.Text = "Usuarios";
        }

        private void btnReportes_Click(object sender, RoutedEventArgs e)
        {
            ContenedorPrincipal.Content = new ReportPage();
            TituloContenido.Text = "Reportes";
        }

        

        public void btnConfiguracion_Click(object sender, RoutedEventArgs e)
        {
            ContenedorPrincipal.Content = new SettingsPage();
            TituloContenido.Text = "Configuración";
        }

        public void Recargar_tema()
        {
            ContenedorPrincipal.Content = new ReportPage();
            TituloContenido.Text = "Configuración";
        }

        private void btn_misterio_Click(object sender, RoutedEventArgs e)
        {
            Tema tema = new Tema();

            tema.apagar2();
        }

        private void btncerrar_sesion_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.Application.Restart();
            System.Windows.Application.Current.Shutdown();
        }
    }
}
