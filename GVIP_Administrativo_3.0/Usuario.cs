using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Mysqlx.Crud.Order.Types;

namespace GVIP_Administrativo_3._0 {
    class Usuario {
        public bool Agregar_usuario(string curp, string usuario, string contrasenia, string tipo_usuario) {
            bool usuario_registrado = false;

            using (MySqlConnection conexion = new MySqlConnection(App.cadena_conexion))
            {
                int rowsaffected = 0;
                MySqlCommand comando = new MySqlCommand("insert into usuarios (Nombre_usuario, Contrasenia, Nombre, Tipo_usuario) VALUES (@usuario, @contrasenia, @nombre,@tipo_usuario)", conexion);
                string nombre = "";

                comando.Parameters.Add("@curp", MySqlDbType.VarChar, 18).Value = curp;
                comando.Parameters.Add("@usuario", MySqlDbType.VarChar, 45).Value = usuario;
                comando.Parameters.Add("@contrasenia", MySqlDbType.VarChar, 45).Value = contrasenia;
                comando.Parameters.Add("@tipo_usuario", MySqlDbType.VarChar, 45).Value = tipo_usuario;

                try {
                    Empleado empleados = new Empleado();
                    string[] datos_empleado = empleados.Consultar_empleado(curp).Split(',');

                    if (datos_empleado[0] != "Error") {
                        Usuario usuarios = new Usuario();
                        string[] datos_usuario = usuarios.Consultar_usuario(usuario).Split(',');
                        if (datos_usuario[0]=="Error") {
                            comando.Parameters.Add("@nombre", MySqlDbType.VarChar, 45).Value = datos_empleado[1];
                            conexion.Open();
                            rowsaffected = comando.ExecuteNonQuery();

                            if (rowsaffected >= 1) {
                                usuario_registrado = true;
                            }
                        }
                        else {
                            System.Windows.MessageBox.Show("Ya hay un Empleado con ese nombre de usuario, por favor introduzca uno diferente");
                        }
                    }
                    else {
                        System.Windows.MessageBox.Show("Introduzca el CURP de un Empleado registrado en el sistema");
                    }
                }
                catch (MySqlException ex) {
                    //MessageBox.Show(ex.ToString());
                }
                finally {
                    conexion.Close();
                }
            }
            return usuario_registrado;
        }

        public bool Eliminar_usuario(string usuario) {
            bool usuario_eliminado = false;

            using (MySqlConnection conexion = new MySqlConnection(App.cadena_conexion)) {
                int rowsaffected = 0;
                MySqlCommand comando = new MySqlCommand("DELETE FROM usuarios WHERE Nombre_usuario=@usuario", conexion);
                comando.Parameters.Add("@usuario", MySqlDbType.VarChar, 45).Value = usuario;

                try {
                    conexion.Open();
                    rowsaffected = comando.ExecuteNonQuery();

                    if (rowsaffected >= 1) {
                        usuario_eliminado = true;
                    } 
                }
                catch (MySqlException ex) {
                    // MessageBox.Show(ex.ToString());
                }
                finally {
                    conexion.Close();
                }
            }
            return usuario_eliminado;
        }

        public string Consultar_usuario(string usuario) {
            string datos_de_consulta = "";

            using (MySqlConnection conexion = new MySqlConnection(App.cadena_conexion)) {
                MySqlCommand comando = new MySqlCommand("SELECT * FROM usuarios WHERE Nombre_usuario = @usuario", conexion);
                //@id_empleado, @nombre, @apellido1, @apellido2, @telefono, @rfc, @usuario, @contrasenia"
                comando.Parameters.Add("@usuario", MySqlDbType.VarChar, 45).Value = usuario;

                try {
                    conexion.Open();
                    MySqlDataReader reader = comando.ExecuteReader();
                    reader.Read();

                    if (reader.HasRows) {
                        datos_de_consulta = reader.GetString(0) + "," + reader.GetString(1) + "," + reader.GetString(2) + "," + reader.GetString(3);
                    }
                    else {
                        datos_de_consulta = "Error";
                    }
                }
                catch (MySqlException ex) {
                    // MessageBox.Show(ex.ToString());
                }
                finally {
                    conexion.Close();
                }
                return datos_de_consulta;
            }
        }

        public bool Actualizar_usuario( string usuario, string contrasenia, string tipo_usuario) {
            bool usuario_actualizado = false;

            using (MySqlConnection conexion = new MySqlConnection(App.cadena_conexion)) {
                int rowsaffected = 0;
                MySqlCommand comando = new MySqlCommand("UPDATE usuarios " +
                    "SET Contrasenia=@contrasenia, Tipo_usuario=@tipo_usuario " +
                    "WHERE Nombre_usuario=@usuario", conexion);

                comando.Parameters.Add("@usuario", MySqlDbType.VarChar, 45).Value = usuario;
                comando.Parameters.Add("@contrasenia", MySqlDbType.VarChar, 45).Value = contrasenia;
                comando.Parameters.Add("@tipo_usuario", MySqlDbType.VarChar, 45).Value = tipo_usuario;

                try {
                        conexion.Open();
                        rowsaffected = comando.ExecuteNonQuery();

                    if (rowsaffected >= 1) {
                        usuario_actualizado = true;
                    }
                    else {
                        System.Windows.MessageBox.Show("Introduzca el CURP de un Empleado registrado en el sistema");
                    }
                }
                catch (MySqlException ex) {
                    //MessageBox.Show(ex.ToString());
                }
                finally {
                    conexion.Close();
                }
            }
            return usuario_actualizado;
        }
    }
}