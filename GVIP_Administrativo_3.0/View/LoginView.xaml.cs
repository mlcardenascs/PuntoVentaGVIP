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
using MySql.Data.MySqlClient;

namespace GVIP_Administrativo_3._0.View
{
    /// <summary>
    /// Lógica de interacción para LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        string usuario = "", contrasenia = "";
        public LoginView()
        {
            InitializeComponent();

            txtUsuario.Focus();
            WindowState = WindowState.Maximized;

            

            Tema tema = new Tema();

            List<Tema> Colores_tema = tema.Cargar_tema();

            App.Current.Resources["primaryBackColor1"] = (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString(Colores_tema[0].Principal);
            App.Current.Resources["colorPrincipal"] = (SolidColorBrush)new BrushConverter().ConvertFromString(Colores_tema[0].Principal); ;

            App.Current.Resources["primaryBackColor2"] = (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString(Colores_tema[0].Secundario);
            App.Current.Resources["colorSecundario"] = (SolidColorBrush)new BrushConverter().ConvertFromString(Colores_tema[0].Secundario);

            App.Current.Resources["Iconos_color"] = (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString(Colores_tema[0].Iconos);
            App.Current.Resources["Iconos_brush"] = (SolidColorBrush)new BrushConverter().ConvertFromString(Colores_tema[0].Iconos);

            App.Current.Resources["plainTextColor3"] = (SolidColorBrush)new BrushConverter().ConvertFromString(Colores_tema[0].Secundario);

            App.Current.Resources["panelActiveColor"] = (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString(Colores_tema[0].Principal);


            /* 

               Color_fondo.Color = (Color)ColorConverter.ConvertFromString(Convert.ToString(Colores_tema[0].Principal));
              btnIniciar.Background = (SolidColorBrush)new BrushConverter().ConvertFromString(Colores_tema[0].Secundario);
              btnIniciar.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString(Colores_tema[0].Letras);*/

        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void showpassword_Checked(object sender, RoutedEventArgs e)
        {
            txtshowpassword.Text = txtContraseña.Password;
            txtshowpassword.Visibility = Visibility.Visible;
            txtContraseña.Visibility = Visibility.Hidden;
            
        }

        private void showpassword_Unchecked(object sender, RoutedEventArgs e)
        {
            txtshowpassword.Text = txtContraseña.Password;
            txtshowpassword.Visibility = Visibility.Hidden;
            txtContraseña.Visibility = Visibility.Visible;
        }

        private void btnIniciar_Click(object sender, RoutedEventArgs e)
        {
            

            usuario = txtUsuario.Text;

            contrasenia=txtContraseña.Password;

            Sesion sesion = new Sesion();

            if(sesion.Iniciar_sesion(usuario, contrasenia))
            {
                PrincipalView pagina_principal = new PrincipalView();

                this.Close();
                pagina_principal.Show();
            }
            else
            {
                MessageBox.Show("Error en el inicio de sesion");
            }

            

        }
    }
}
