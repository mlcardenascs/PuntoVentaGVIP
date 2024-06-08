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
    /// Lógica de interacción para UsersPage.xaml
    /// </summary>
    public partial class UsersPage : Page
    {
        public UsersPage()
        {
            InitializeComponent();

            cbox_opciones.Items.Add("Seleccione una opción");
            cbox_opciones.Items.Add("Agregar");
            cbox_opciones.Items.Add("consultar");
            cbox_opciones.Items.Add("Actualizar");
            cbox_opciones.Items.Add("Eliminar");
            cbox_opciones.Items.Add("Limpiar");
            cbox_opciones.SelectedIndex = 0;

            cbox_tipo_usuario.Items.Add("Empleado");
            cbox_tipo_usuario.Items.Add("Administrador");
            cbox_tipo_usuario.SelectedIndex = 0;

            
        }

        private void cbox_opciones_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch(cbox_opciones.SelectedIndex)
            {
                //Agregar
                case 1:
                    if (Validar_campos())
                    {
                        if(txt_curp.Text.Length == 18)
                        {
                            Usuario usuarios = new Usuario();

                            if (usuarios.Agregar_usuario(txt_curp.Text, txt_usuario.Text, txt_contrasenia1.Text, cbox_tipo_usuario.SelectedItem.ToString()))
                            {
                                System.Windows.MessageBox.Show("Usuario agregado correctamente");
                            }
                            else
                            {
                                System.Windows.MessageBox.Show("Error al intentar agregar al usuario con los datos introducidos");

                            }
                        }
                        else
                        {
                            System.Windows.MessageBox.Show("Por favor verifique la longitud del CURP");
                        }
                        cbox_opciones.SelectedIndex = 0;
                    }
                    cbox_opciones.SelectedIndex = 0;
                    break;
                    //Consultar
                case 2:
                    if (txt_usuario.Text!="")
                    {
                        Usuario usuarios = new Usuario();

                        string[] datos_consulta = usuarios.Consultar_usuario(txt_usuario.Text).Split(',');

                        if (datos_consulta[0]!="Error")
                        {
                            txt_contrasenia1.Text = datos_consulta[1];
                            txt_contrasenia2.Text = datos_consulta[1];
                            cbox_tipo_usuario.SelectedItem = datos_consulta[3];
                        }
                        else
                        {
                            System.Windows.MessageBox.Show("No se encontraron datos para el nombre de usuario proporcionado");
                        }

                    }
                    cbox_opciones.SelectedIndex = 0;
                    break;
                    //Actualizar
                case 3:
                    if (txt_usuario.Text!="" && txt_contrasenia1.Text!="" && txt_contrasenia2.Text!="")
                    {
                        if (txt_contrasenia1.Text == txt_contrasenia2.Text)
                        {
                            Usuario usuarios = new Usuario();

                            if (usuarios.Actualizar_usuario(txt_usuario.Text, txt_contrasenia1.Text, cbox_tipo_usuario.SelectedItem.ToString()))
                            {
                                System.Windows.MessageBox.Show("Usuario actualizado correctamente");
                            }
                            else
                            {
                                System.Windows.MessageBox.Show("Error al intentar actualizar al usuario con los datos introducidos");

                            }
                        }
                        else
                        {
                            System.Windows.MessageBox.Show("Las contraseñas deben coincidir");

                        }

                    }
                    else
                    {
                        System.Windows.MessageBox.Show("Por favor llene todos los campos para continuar");
                    }
                    cbox_opciones.SelectedIndex = 0;
                    break;

                    //Eliminar
                case 4:
                    if(txt_usuario.Text!="")
                    {
                        Usuario usuarios = new Usuario();
                        string[] datos_usuario = usuarios.Consultar_usuario(txt_usuario.Text).Split(',');
                        if (datos_usuario[0] != "Error") //el usuario si existe
                        {
                            if (usuarios.Eliminar_usuario(txt_usuario.Text))
                            {
                                System.Windows.MessageBox.Show("Usuario eliminado correctamente");
                            }
                            else
                            {
                                System.Windows.MessageBox.Show("Error al intentar eliminar al Usuario");
                            }
                        }
                        else
                        {
                            System.Windows.MessageBox.Show("El Usuario que introdujo para eliminar no se encuentra registrado");
                        }
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("Por favor introduzca un nombre de usuario para eliminar");
                    }
                    cbox_opciones.SelectedIndex = 0;
                    break;
                    //Limpiar
                case 5:
                    Limpiar_campos();
                    cbox_opciones.SelectedIndex = 0;
                    break;



                default:
                    break;
            }
        }

        public bool Validar_campos()
        {
            bool campos_validados = false;

            if(txt_curp.Text!="" && txt_usuario.Text!= "" && txt_contrasenia1.Text!="" && txt_contrasenia2.Text!="")
            {
                if(txt_contrasenia1.Text == txt_contrasenia2.Text)
                {
                    campos_validados = true;
                }
                else
                {
                    System.Windows.MessageBox.Show("Las contraseñas deben coincidir");
                }

            }
            else
            {
                System.Windows.MessageBox.Show("Por favor llene todos los campos para continuar");
            }


            return campos_validados;
        }

        public void Limpiar_campos()
        {
            txt_curp.Text = "";
            txt_usuario.Text = "";
            txt_contrasenia1.Text = "";
            txt_contrasenia2.Text = "";
            cbox_tipo_usuario.SelectedIndex = 0;
        }
    }
}
