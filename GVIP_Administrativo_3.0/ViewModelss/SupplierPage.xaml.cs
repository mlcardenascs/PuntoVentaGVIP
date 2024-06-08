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

namespace GVIP_Administrativo_3._0.ViewModelss
{
    /// <summary>
    /// Lógica de interacción para SupplierPage.xaml
    /// </summary>
    public partial class SupplierPage : Page
    {
        public SupplierPage()
        {
            InitializeComponent();
            cbox_opciones.Items.Add("Seleccione una opción");
            cbox_opciones.Items.Add("Agregar");
            cbox_opciones.Items.Add("consultar");
            cbox_opciones.Items.Add("Actualizar");
            cbox_opciones.Items.Add("Eliminar");
            cbox_opciones.Items.Add("Limpiar");
            cbox_opciones.SelectedIndex = 0;

            cbox_tipo_proveedor.Items.Add("Particular");
            cbox_tipo_proveedor.Items.Add("Empresa");
            cbox_tipo_proveedor.SelectedIndex = 0;
        }

        private void cbox_opciones_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch(cbox_opciones.SelectedIndex)
            {
                case 1:
                    //agregar
                    if(txt_nombre.Text!= "" && txt_rfc.Text!="" && txt_direccion.Text!= "" )
                    {
                       if(txt_rfc.Text.Length == 12 || txt_rfc.Text.Length==13)
                        {
                            Proveedor proveedores = new Proveedor();

                            if (proveedores.Agregar_proveedor(txt_nombre.Text, txt_apellido_paterno.Text, txt_apellido_materno.Text, txt_rfc.Text, txt_direccion.Text, Convert.ToString(cbox_tipo_proveedor.SelectedItem)))
                            {
                                System.Windows.MessageBox.Show("Proveedor agregado correctamente");
                            }
                            else
                            {
                                System.Windows.MessageBox.Show("Error al intentar agregar el proveedor");
                            }
                        }
                        else
                        {
                            System.Windows.MessageBox.Show("Por favor verifica la longitud del RFC");
                        }
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("Por favor ingrese los campos necesario para agregar al proveedor");
                    }
                    cbox_opciones.SelectedIndex = 0;
                    break;
                case 2:
                    //consultar
                    if(txt_rfc.Text!= "")
                    {
                        Proveedor Proveedores = new Proveedor();

                        string[] Datos_consulta = Proveedores.Consultar_proveedor(txt_rfc.Text).Split(',');
                        if (Datos_consulta[0]!="Error")
                        {
                            txt_nombre.Text = Datos_consulta[1];
                            txt_apellido_paterno.Text = Datos_consulta[2];
                            txt_apellido_materno.Text = Datos_consulta[3];
                            txt_direccion.Text = Datos_consulta[5];
                            cbox_tipo_proveedor.SelectedItem = Datos_consulta[6];
                        }
                        else
                        {
                            System.Windows.MessageBox.Show("No se encontraron datos para el RFC introducido");

                        }
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("Por favor ingresa un RFC para consultar el Proveedor");
                    }
                    cbox_opciones.SelectedIndex = 0;
                    break;
                case 3:
                    //actualizar
                    if (txt_nombre.Text != "" && txt_rfc.Text != "" && txt_direccion.Text != "")
                    {
                        Proveedor proveedores = new Proveedor();

                        if (proveedores.Actualizar_proveedor(txt_nombre.Text, txt_apellido_paterno.Text, txt_apellido_materno.Text, txt_rfc.Text, txt_direccion.Text, Convert.ToString(cbox_tipo_proveedor.SelectedItem)))
                        {
                            System.Windows.MessageBox.Show("Proveedor Actualizado correctamente");
                        }
                        else
                        {
                            System.Windows.MessageBox.Show("Error al intentar Actualizar el proveedor");
                        }
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("Por favor ingrese los campos necesario para Actualizar al proveedor");
                    }
                    cbox_opciones.SelectedIndex = 0;
                    break;
                case 4:
                    //eliminar
                    if (txt_rfc.Text != "")
                    {
                        Proveedor Proveedores = new Proveedor();

                        if (Proveedores.Eliminar_proveedor(txt_rfc.Text))
                        {
                            System.Windows.MessageBox.Show("Proveedor eliminado correctamente");
                        }
                        else
                        {
                            System.Windows.MessageBox.Show("Error al intentar eliminar al proveedor con el rfc: " + txt_rfc.Text);
                        }
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("Por favor introduzca el RFC de un proveedor para eliminarlo");
                    }
                    cbox_opciones.SelectedIndex = 0;

                    break;
                case 5:
                    Limpiar_campos();
                    cbox_opciones.SelectedIndex = 0;
                    break;

                default:
                    break;
            }

        }

        public void Limpiar_campos()
        {
            txt_nombre.Text = "";
            txt_apellido_paterno.Text = "";
            txt_apellido_materno.Text = "";
            txt_rfc.Text = "";
            txt_direccion.Text = "";
            cbox_tipo_proveedor.SelectedIndex = 0;
        }
    }
}
