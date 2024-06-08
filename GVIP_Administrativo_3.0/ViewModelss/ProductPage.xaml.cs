using System;
using System.Collections.Generic;
using System.IO.Packaging;
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
    /// Lógica de interacción para ProductPage.xaml
    /// </summary>
    /// 
    
    public partial class ProductPage : Page
    {
        public string direccion_default = App.Imagen_defecto;
        string direccion_imagen = App.Imagen_defecto;
        public List<Proveedor> Lista_proveedores = new List<Proveedor>();

        public ProductPage()
        {
            InitializeComponent();
            cbox_opciones.Items.Add("Seleccione una opción");
            cbox_opciones.Items.Add("Agregar");
            cbox_opciones.Items.Add("consultar");
            cbox_opciones.Items.Add("Eliminar");
            cbox_opciones.Items.Add("Limpiar");
            cbox_opciones.SelectedIndex = 0;

            Cargar_proveedores();
            cbox_proveedores.SelectedIndex = 0;

        }

        private void cbox_opciones_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch(cbox_opciones.SelectedIndex)
            {
                case 1:
                    if(Validar_campos())
                    {
                        Productos Producto = new Productos();



                        if(Producto.Agregar_producto(txt_nombre.Text,Convert.ToDouble(txt_precio.Text),direccion_imagen,txt_descripcion.Text, Convert.ToInt32(txt_cantidad.Text), txt_codigo_barras.Text, Lista_proveedores[cbox_proveedores.SelectedIndex].ID, Lista_proveedores[cbox_proveedores.SelectedIndex].Nombre))
                        {
                            System.Windows.MessageBox.Show("Producto agregado correctamente");
                        }
                        else
                        {
                            System.Windows.MessageBox.Show("Error al intentar agregar el producto");
                        }
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("Por favor ingrese todos los datos del producto");
                    }
                    cbox_opciones.SelectedIndex = 0;

                    break;
                case 2:
                    if(txt_codigo_barras.Text!="")
                    {
                        Productos Producto = new Productos();
                        string[] Datos_consulta = Producto.Consultar_producto(txt_codigo_barras.Text).Split(',');

                        if (Datos_consulta[0]!="Error")
                        {
                            txt_nombre.Text = Datos_consulta[1];
                            txt_precio.Text= Datos_consulta[2];
                            Actualizar_imagen_consulta(Datos_consulta[3]);
                            txt_descripcion.Text= Datos_consulta[4];
                            txt_cantidad.Text= Datos_consulta[5];

                            cbox_proveedores.SelectedItem = Datos_consulta[6];
                        }
                        else
                        {
                            System.Windows.MessageBox.Show("No se encontraron datos para el producto con el código de barras: " + txt_codigo_barras.Text);
                        }
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("Por favor introduza un código de barras para buscar un producto");
                    }
                    cbox_opciones.SelectedIndex = 0;
                    break;
                case 3:
                    if(txt_codigo_barras.Text!="")
                    {
                        Productos Producto = new Productos();
                        if(Producto.Eliminar_producto(txt_codigo_barras.Text))
                        {
                            System.Windows.MessageBox.Show("Producto eliminado correctamente");
                        }
                        else
                        {
                            System.Windows.MessageBox.Show("Error al intentar eliminar el producto");
                        }
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("Por favor ingrese un Código de barras para eliminar el producto");
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
            txt_nombre.Text = "";
            txt_precio.Text = "";
            txt_descripcion.Text = "";
            txt_cantidad.Text = "";
            txt_codigo_barras.Text = "";
            imagen_producto.Source = null;
        }



        public bool Validar_campos()
        {
            if(txt_cantidad.Text=="")
            {
                txt_cantidad.Text = "1";
            }
            if(txt_precio.Text=="")
            {
                txt_precio.Text = "1";
            }


            if(txt_nombre.Text=="" ||txt_descripcion.Text==""||txt_codigo_barras.Text=="" )
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btn_imagen_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.ShowDialog();

            direccion_imagen = dlg.FileName;
            
            if(direccion_imagen=="")
            {
                direccion_imagen = direccion_default;
            }
            else
            {
                direccion_imagen = dlg.FileName;
                direccion_imagen = direccion_imagen.Replace(@"\", "/");
            }

            BitmapImage logo = new BitmapImage();
            logo.BeginInit();
            logo.UriSource = new Uri(direccion_imagen);
            logo.EndInit(); // Getting the exception here
            imagen_producto.Source = logo;
        }

        public void Actualizar_imagen_consulta(string direccion)
        {
            BitmapImage logo = new BitmapImage();
            logo.BeginInit();
            logo.UriSource = new Uri(direccion);
            logo.EndInit(); // Getting the exception here
            imagen_producto.Source = logo;
        }

        public void Cargar_proveedores()
        {
            Proveedor proveedores = new Proveedor();

            Lista_proveedores = proveedores.Obtener_proveedores();

            for (var j = 0; j < Lista_proveedores.Count; j++)
            {

                cbox_proveedores.Items.Add(Lista_proveedores[j].Nombre);
            }
        }

        
    }
}
