using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.IO;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace GVIP_Administrativo_3._0.ViewModelss
{
    /// <summary>
    /// Lógica de interacción para EmployeePage.xaml
    /// </summary>
    public partial class EmployeePage : Page
    {
        public string direccion_default = App.Imagen_defecto;
        public string direccion_imagen = App.Imagen_defecto;

        public EmployeePage()
        {
            InitializeComponent();
            cbox_opciones.Items.Add("Seleccione una opción");
            cbox_opciones.Items.Add("Agregar");
            cbox_opciones.Items.Add("Consultar");
            cbox_opciones.Items.Add("Eliminar");
            cbox_opciones.Items.Add("Actualizar");
            cbox_opciones.Items.Add("Limpiar");
            cbox_opciones.SelectedIndex = 0;

            Cargar_Puestos();

            Date_fecha_contratacion.DisplayDateEnd = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));

            direccion_imagen = direccion_default;
        }

        private void btn_prueba_fecha_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show(Date_fecha_contratacion.SelectedDate.Value.ToString("yyyy-MM-dd"));
        }

        private void cbox_opciones_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (cbox_opciones.SelectedIndex)
            {
                //caso 1: agregar empleado
                case 1:
                    if (Validar_campos())
                    {
                        if ((txt_rfc.Text.Length == 13 || txt_rfc.Text.Length == 12) & txt_curp.Text.Length == 18)
                        {
                            Empleado Empleados = new Empleado();
                            string fecha_contratacion = Date_fecha_contratacion.SelectedDate.Value.ToString("yyyy-MM-dd");
                            string usuario = "", imagen = "";

                            //consultar si el empleado ya se encuentra registrado en el sistema
                            if (Empleados.Consultar_existencia_empleado(txt_curp.Text))
                            {
                                //si ya se encuentra registrado el empleado, mandaremos un mensaje y no realizaremos ningún cambio
                                System.Windows.MessageBox.Show("El empleado ya se encuentra registrado en el sistema");
                            }
                            else
                            {
                                //En el caso de que aun no se encuentre registrado, agregaremos al empleado a la BD
                                if (Empleados.Agregar_empleado(txt_nombres.Text, txt_Apellido_pat.Text, txt_Apellido_mat.Text, Convert.ToInt32(txt_edad.Text), txt_curp.Text, txt_rfc.Text, txt_direccion.Text, cbox_puesto.SelectedItem.ToString(), Convert.ToDecimal(txt_sueldo.Text), fecha_contratacion, direccion_imagen))
                                {
                                    System.Windows.MessageBox.Show("Empleado Agregado correctamente");
                                }
                                else
                                {
                                    System.Windows.MessageBox.Show("Error al agregar empleado");
                                }
                            }
                        }
                        else
                        {
                            System.Windows.MessageBox.Show("Por favor verifique la longitud del CURP y RFC");
                        }



                    }
                    cbox_opciones.SelectedIndex = 0;
                    break;
                //caso 2: consultar empmleado
                case 2:

                    if (txt_curp.Text != "")
                    {
                        Empleado Empleados = new Empleado();

                        string[] Datos_empleado = Empleados.Consultar_empleado(txt_curp.Text).Split(',');

                        //cadena_consulta.Split(',');

                        if (Datos_empleado[0] != "Error")
                        {

                            txt_nombres.Text = Datos_empleado[1];
                            txt_Apellido_pat.Text = Datos_empleado[2];
                            txt_Apellido_mat.Text = Datos_empleado[3];
                            txt_edad.Text = Datos_empleado[4];
                            txt_rfc.Text = Datos_empleado[6];
                            txt_direccion.Text = Datos_empleado[7];
                            cbox_puesto.SelectedItem = Datos_empleado[8];
                            txt_sueldo.Text = Datos_empleado[9];
                            Date_fecha_contratacion.SelectedDate = Convert.ToDateTime(Datos_empleado[10]);

                            //Actualizar la imagen obtenida de la consulta
                            Actualizar_imagen_consulta(Datos_empleado[11]);
                        }
                        else
                        {
                            System.Windows.MessageBox.Show("Error al realizar la consulta ");
                        }
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("por favor introduzca el CURP de un Empleado para consultarlo");
                    }
                    cbox_opciones.SelectedIndex = 0;
                    break;
                //Eliminar empleado
                case 3:
                    if (txt_curp.Text != "")
                    {
                        Empleado Empleados = new Empleado();
                        if (Empleados.Eliminar_empleado(txt_curp.Text))
                        {
                            System.Windows.MessageBox.Show("Empleado eliminado correctamente");
                        }
                        else
                        {
                            System.Windows.MessageBox.Show("Error al eliminar al empleado");
                        }
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("Por favor introduzca el CURP de un empleado para eliminarlo");
                    }
                    cbox_opciones.SelectedIndex = 0;
                    Limpiar_campos();

                    break;
                case 4:
                    //Actualizar los datos del empleado

                    if (txt_curp.Text != "")
                    {
                        if (Validar_campos())
                        {
                            Empleado Empleados = new Empleado();
                            string fecha_contratacion = Date_fecha_contratacion.SelectedDate.Value.ToString("yyyy-MM-dd");

                            if (Empleados.Consultar_existencia_empleado(txt_curp.Text) == false)
                            {
                                //si ya se encuentra registrado el empleado, mandaremos un mensaje y no realizaremos ningún cambio
                                System.Windows.MessageBox.Show("El Empleado que intenta modificar no se encuentra registrado");
                            }
                            else
                            {
                                //En el caso de que aun no se encuentre registrado, agregaremos al empleado a la BD
                                if (Empleados.Actualizar_empleado(txt_nombres.Text, txt_Apellido_pat.Text, txt_Apellido_mat.Text, Convert.ToInt32(txt_edad.Text), txt_curp.Text, txt_rfc.Text, txt_direccion.Text, cbox_puesto.SelectedItem.ToString(), Convert.ToDecimal(txt_sueldo.Text), fecha_contratacion, direccion_imagen))
                                {
                                    System.Windows.MessageBox.Show("Empleado Actualizado correctamente");
                                }
                                else
                                {
                                    System.Windows.MessageBox.Show("Error al Actualizar empleado");
                                }
                            }
                        }

                    }
                    else
                    {
                        System.Windows.MessageBox.Show("Por favor ingrese un curp para actualizar");
                    }
                    cbox_opciones.SelectedIndex = 0;
                    break;

                case 5:
                    //Limpiar campos
                    Limpiar_campos();
                    cbox_opciones.SelectedIndex = 0;
                    break;

                default:
                    break;

            }
        }

        public bool Validar_campos()
        {
            bool campos_validos = false;

            if (txt_nombres.Text == "" || txt_Apellido_pat.Text == "" || txt_Apellido_mat.Text == "" || txt_curp.Text == "" || txt_edad.Text == "" || txt_direccion.Text == "" || txt_rfc.Text == "" || txt_sueldo.Text == "")
            {
                System.Windows.MessageBox.Show("Por favor rellene todos los campos");
                return campos_validos;
            }
            else
            {
                campos_validos = true;
            }



            return campos_validos;
        }
        public void Limpiar_campos()
        {
            txt_nombres.Text = "";
            txt_Apellido_pat.Text = "";
            txt_Apellido_mat.Text = "";
            txt_curp.Text = "";
            txt_edad.Text = "";
            txt_direccion.Text = "";
            txt_rfc.Text = "";
            cbox_puesto.SelectedItem = "Empleado";
            txt_sueldo.Text = "";
            Date_fecha_contratacion.SelectedDate = DateTime.Now;
            Imagen_empleado.Source = null;
        }
        public void Cargar_Puestos()
        {
            Empleado Empleados = new Empleado();
            List<Clientes> Lista_Puestos = Empleados.Consultar_nombres_puestos();

            for (var j = 0; j < Lista_Puestos.Count; j++)
            {

                cbox_puesto.Items.Add(Lista_Puestos[j].Nombre);
            }
            cbox_puesto.SelectedItem = "Empleado";
        }

        //System.Windows.MessageBox.Show(Convert.ToString(dlg.FileName));
        private void btn_imagen_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.ShowDialog();

            direccion_imagen = dlg.FileName;

            if (direccion_imagen == "")
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
            Imagen_empleado.Source = logo;
        }

        public void Actualizar_imagen_consulta(string direccion)
        {
            BitmapImage logo = new BitmapImage();
            logo.BeginInit();
            logo.UriSource = new Uri(direccion);
            logo.EndInit(); // Getting the exception here
            Imagen_empleado.Source = logo;
        }


    }
}


/*
 * 
 * Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.ShowDialog();

            
            FileStream fs = new FileStream(dlg.FileName, FileMode.Open,FileAccess.Read);

            byte[] data = new byte[fs.Length];
            fs.Read(data, 0, System.Convert.ToInt32(fs.Length));

            fs.Close();

            string encoded = Convert.ToBase64String(data);
            Productos producto = new Productos();

            if(producto.Actualizar_producto("123456789", encoded))
            {
                System.Windows.MessageBox.Show("Se agrego la imagen");
            }

            Imagen_empleado.Source = LoadImage(data);
*/