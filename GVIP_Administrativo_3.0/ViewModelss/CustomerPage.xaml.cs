using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace GVIP_Administrativo_3._0.ViewModelss
{
    /// <summary>
    /// Lógica de interacción para CustomerPage.xaml
    /// </summary>
    public partial class CustomerPage : Page
    {
        public CustomerPage()
        {
            InitializeComponent();
            cbox_opciones.Items.Add("Seleccione una opción");
            cbox_opciones.Items.Add("Agregar");
            cbox_opciones.Items.Add("Consultar");
            cbox_opciones.Items.Add("Eliminar");
            cbox_opciones.Items.Add("Limpiar");
            cbox_opciones.SelectedIndex = 0;



        }

        private void cbox_opciones_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (cbox_opciones.SelectedIndex)
            {
                case 1:
                    if (txt_nombres.Text != "")
                    {

                        Clientes Cliente = new Clientes();
                        


                        if (Cliente.Consultar_existencia_cliente(txt_rfc.Text) && txt_rfc.Text!="")
                        {
                            System.Windows.MessageBox.Show("Ya se encuentra registrado un cliente con ese RFC, por favor verifique los datos");
                        }
                        else
                        {
                            if (txt_edad.Text == "")
                            {
                                txt_edad.Text = "1";
                            }
                            if (Cliente.Agregar_cliente(txt_nombres.Text, txt_Apellido_pat.Text, txt_Apellido_mat.Text, Convert.ToInt32(txt_edad.Text), txt_rfc.Text, txt_direccion.Text))
                            {
                                System.Windows.MessageBox.Show("Cliente Agregado correctamente");

                            }
                        }

                        
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("Por favor introduzca un nombre para el cliente");
                    }
                    cbox_opciones.SelectedIndex = 0;
                    break;
                case 2:
                    if (txt_nombres.Text != "" || txt_rfc.Text != "")
                    {
                        Clientes Cliente = new Clientes();
                        string[] datos_consulta = Cliente.Consultar_cliente(txt_nombres.Text, txt_rfc.Text).Split(',');

                        if (datos_consulta[0] != "Error")
                        {
                            txt_nombres.Text = datos_consulta[0];
                            txt_Apellido_pat.Text = datos_consulta[1];
                            txt_Apellido_mat.Text = datos_consulta[2];
                            txt_edad.Text = datos_consulta[3];
                            txt_rfc.Text = datos_consulta[4];
                            txt_direccion.Text = datos_consulta[5];
                        }
                        else
                        {
                            System.Windows.MessageBox.Show("Error al intentar consultar al Cliente con el nombre especificado");
                        }
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("Por favor introduza el nombre o el RFC del cliente a consultar");
                    }
                    cbox_opciones.SelectedIndex = 0;
                    break;
                case 3:
                    if (txt_nombres.Text != "" || txt_rfc.Text != "")
                    {
                        if(txt_nombres.Text=="Publico general")
                        {
                            System.Windows.MessageBox.Show("No puede eliminar a este cliente");
                        }
                        else
                        {
                            Clientes Cliente = new Clientes();
                            if (Cliente.Eliminar_cliente(txt_nombres.Text, txt_rfc.Text))
                            {
                                System.Windows.MessageBox.Show("Cliente eliminado correctamente");
                                Limpiar_campos();
                            }
                            else
                            {
                                System.Windows.MessageBox.Show("Error al eliminar al Empleado ingresado");
                            }
                        }
                    }
                    
                    cbox_opciones.SelectedIndex = 0;
                    break;
                case 4:
                    Limpiar_campos();
                    cbox_opciones.SelectedIndex = 0;
                    break;


                default:
                    break;
            }
        }

        public void Limpiar_campos()
        {
            txt_nombres.Text = "";
            txt_Apellido_pat.Text = "";
            txt_Apellido_mat.Text = "";
            txt_edad.Text = "";
            txt_rfc.Text = "";
            txt_direccion.Text = "";
        }
    }
}
