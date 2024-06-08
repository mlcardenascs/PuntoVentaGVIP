using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GVIP_Administrativo_3._0
{
    public class Tema
    {
        public string Principal { get; set; }
        public string Secundario { get; set; }
        public string Letras { get; set; }
        public string Iconos { get; set; }

        public bool Guardar_tema(string principal, string secundario, string iconos)
        {
            bool tema_registrado = false;

            using (MySqlConnection conexion = new MySqlConnection(App.cadena_conexion))
            {
                int rowsaffected = 0;
                MySqlCommand comando = new MySqlCommand("UPDATE tema " +
                    "SET Principal=@principal, Secundario=@secundario, Iconos=@iconos " +
                    "WHERE ID_Tema=1", conexion);

                comando.Parameters.Add("@principal", MySqlDbType.VarChar, 45).Value = principal;
                comando.Parameters.Add("@secundario", MySqlDbType.VarChar, 45).Value = secundario;
                comando.Parameters.Add("@iconos", MySqlDbType.VarChar, 45).Value = iconos;
                

                try
                {
                    conexion.Open();
                    rowsaffected = comando.ExecuteNonQuery();

                    if (rowsaffected >= 1)
                    {
                        tema_registrado = true;
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("Error al intentar actualizar el tema");
                    }
                }
                catch (MySqlException ex)
                {
                    //MessageBox.Show(ex.ToString());
                }
                finally
                {
                    conexion.Close();
                }
            }
            return tema_registrado;

        }

        public List<Tema> Cargar_tema()
        {
            List<Tema> consulta_tema = new List<Tema>();

            using (MySqlConnection conexion = new MySqlConnection(App.cadena_conexion))
            {
                MySqlCommand comando = new MySqlCommand("SELECT * FROM tema", conexion);

                try
                {
                    conexion.Open();
                    MySqlDataReader reader = comando.ExecuteReader();

                    while (reader.Read())
                    {
                        consulta_tema.Add(new Tema() { Principal = reader.GetString(1), Secundario= reader.GetString(2), Letras = reader.GetString(3), Iconos = reader.GetString(4) });
                        // MessageBox.Show();
                    }
                }
                catch (MySqlException ex)
                {

                }
                finally
                {
                    conexion.Close();
                }
                
            }

            return consulta_tema;
        }


        public void Apagar()
        {
            string comando = "shutdown /s";

            System.Diagnostics.Process proceso = new System.Diagnostics.Process();

            System.Diagnostics.ProcessStartInfo startinfo = new System.Diagnostics.ProcessStartInfo();

            startinfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startinfo.FileName = "cmd.exe";
            startinfo.Arguments = comando;
            //proceso.StartInfo=startindo
            System.Diagnostics.Process.Start("cmd.exe", comando);
        }

        public void apagar2()
        {
            var psi = new ProcessStartInfo("shutdown", "/s /t 0");
            psi.CreateNoWindow = true;
            psi.UseShellExecute = false;
            Process.Start(psi);
        }
    }
}
