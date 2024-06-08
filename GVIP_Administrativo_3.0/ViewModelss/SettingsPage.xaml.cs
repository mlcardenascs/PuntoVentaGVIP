using GVIP_Administrativo_3._0.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
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

namespace GVIP_Administrativo_3._0.ViewModelss
{
    /// <summary>
    /// Lógica de interacción para SettingsPage.xaml
    /// </summary>
    public partial class SettingsPage : Page
    {
        PrincipalView vista_principal = new PrincipalView();
        Tema tema = new Tema();
        string principal = "", secundario = "", iconos = "";
        public SettingsPage()
        {
            InitializeComponent();
        }

        private void radio_1_Checked(object sender, RoutedEventArgs e)
        {


            principal = Principal_1.Background.ToString();
            secundario = Secundario_1.Background.ToString();
            iconos = Iconos_1.Background.ToString();
            Actualizar_colores(principal, secundario, iconos);

        }

        private void radio_2_Checked(object sender, RoutedEventArgs e)
        {


            principal = Principal_2.Background.ToString();
            secundario = Secundario_2.Background.ToString();
            iconos = Iconos_2.Background.ToString();
            Actualizar_colores(principal, secundario, iconos);


        }

        private void radio_4_Checked(object sender, RoutedEventArgs e)
        {
            principal = Principal_4.Background.ToString();
            secundario = Secundario_4.Background.ToString();
            iconos = Iconos_4.Background.ToString();
            Actualizar_colores(principal, secundario, iconos);

        }

        private void radio_5_Checked(object sender, RoutedEventArgs e)
        {
            principal = Principal_5.Background.ToString();
            secundario = Secundario_5.Background.ToString();
            iconos = Iconos_5.Background.ToString();
            Actualizar_colores(principal, secundario, iconos);
        }

        private void radio_3_Checked(object sender, RoutedEventArgs e)
        {
            

            principal = Principal_3.Background.ToString();
            secundario = Secundario_3.Background.ToString();
            iconos = Iconos_3.Background.ToString();
            Actualizar_colores(principal,secundario,iconos);

            vista_principal.Recargar_tema();

            
        }

        private void btn_guardar_Click(object sender, RoutedEventArgs e)
        {
            if(radio_1.IsChecked == true || radio_2.IsChecked == true || radio_3.IsChecked == true || radio_4.IsChecked == true || radio_5.IsChecked == true)
            {
                if(tema.Guardar_tema(principal, secundario, iconos))
                {
                    System.Windows.MessageBox.Show("Tema actualizado correctamente");
                    System.Windows.Forms.Application.Restart();
                    System.Windows.Application.Current.Shutdown();

                }
                else
                {
                    System.Windows.MessageBox.Show("error");
                }
            }
            else
            {
                System.Windows.MessageBox.Show("Por favor seleccione un tema antes de presionar el botón de guardar");
            }

        }

        public void Actualizar_colores(string principal, string secundario, string iconos)
        {
            App.Current.Resources["primaryBackColor1"] = (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString(principal);
            App.Current.Resources["colorPrincipal"] = (SolidColorBrush)new BrushConverter().ConvertFromString(principal); ;

            App.Current.Resources["primaryBackColor2"] = (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString(secundario);
            App.Current.Resources["colorSecundario"] = (SolidColorBrush)new BrushConverter().ConvertFromString(secundario);

            App.Current.Resources["Iconos_color"] = (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString(iconos);
            App.Current.Resources["Iconos_brush"] = (SolidColorBrush)new BrushConverter().ConvertFromString(iconos);

            App.Current.Resources["plainTextColor3"] = (SolidColorBrush)new BrushConverter().ConvertFromString(secundario);
        }
    }
}
