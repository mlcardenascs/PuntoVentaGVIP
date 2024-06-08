using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GVIP_Administrativo_3._0 {
    class Sesion {
        public bool Iniciar_sesion(string usuario, string contrasenia)  {
            bool inicio_de_sesion = false;
            string usuario_bd = "", contrasenia_bd = "", nombre_bd = "", tipousuario_bd = "";

            using (MySqlConnection conexion = new MySqlConnection(App.cadena_conexion)) {
                MySqlCommand comando = new MySqlCommand("SELECT * FROM usuarios WHERE Nombre_usuario = @usuario", conexion);
                comando.Parameters.Add("@usuario", MySqlDbType.VarChar, 45).Value = usuario;

                try {
                    conexion.Open();
                    MySqlDataReader reader = comando.ExecuteReader();
                    reader.Read();

                    if (reader.HasRows) {
                        usuario_bd = reader.GetString(0);
                        contrasenia_bd = reader.GetString(1);
                        nombre_bd = reader.GetString(2);
                        tipousuario_bd = reader.GetString(3);
                    }
                }
                catch (MySqlException ex) {
                    //MessageBox.Show(ex.ToString());
                }
                finally {
                    conexion.Close();
                }
            }

            if ((usuario == usuario_bd && contrasenia == contrasenia_bd) && (usuario != "" && contrasenia != "")) {
                inicio_de_sesion = true;
                App.usuario_global = usuario_bd;
                App.nombre_global = nombre_bd;
                App.tipousuario_global = tipousuario_bd;
            }
            else {
                inicio_de_sesion = false;
            }
            return inicio_de_sesion;
        }
    }
}