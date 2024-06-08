using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GVIP_Administrativo_3._0 {
    public class Clientes {
        public string Nombre { get; set; }
        public string rfc { get; set; }

        public bool Agregar_cliente(string nombres, string apellido_paterno, string apellido_materno, int edad, string rfc, string direccion) {
            bool cliente_agregado = false;

            using (MySqlConnection conexion = new MySqlConnection(App.cadena_conexion)) {
                int rowsaffected = 0;
                MySqlCommand comando = new MySqlCommand("insert into clientes (Nombres,Apellido_Paterno,Apellido_materno,Edad,RFC,Direccion) VALUES (@nombres, @apellido_paterno, @apellido_materno, @edad, @rfc, @direccion)", conexion);
                comando.Parameters.Add("@nombres", MySqlDbType.VarChar, 45).Value = nombres;
                comando.Parameters.Add("@apellido_paterno", MySqlDbType.VarChar, 45).Value = apellido_paterno;
                comando.Parameters.Add("@apellido_materno", MySqlDbType.VarChar, 45).Value = apellido_materno;
                comando.Parameters.Add("@edad", MySqlDbType.Int32).Value = edad;
                comando.Parameters.Add("@rfc", MySqlDbType.VarChar, 13).Value = rfc;
                comando.Parameters.Add("@direccion", MySqlDbType.VarChar, 100).Value = direccion;

                try {
                    conexion.Open();
                    rowsaffected = comando.ExecuteNonQuery();

                    if (rowsaffected >= 1) {
                        cliente_agregado = true;
                    }
                }
                catch (MySqlException ex) {
                    //MessageBox.Show(ex.ToString());
                }
                finally {
                    conexion.Close();
                }
            }
            return cliente_agregado;
        }

        public bool Eliminar_cliente(string nombres, string rfc) {
            bool cliente_eliminado = false;

            using (MySqlConnection conexion = new MySqlConnection(App.cadena_conexion)) {
                int rowsaffected = 0;
                MySqlCommand comando = new MySqlCommand("DELETE FROM clientes WHERE Nombres=@nombres", conexion);
                MySqlCommand comando2 = new MySqlCommand("DELETE FROM clientes WHERE RFC=@RFC", conexion);
                comando.Parameters.Add("@nombres", MySqlDbType.VarChar, 45).Value = nombres;
                comando.Parameters.Add("@rfc", MySqlDbType.VarChar, 13).Value = rfc;

                try {
                    conexion.Open();
                    rowsaffected = comando.ExecuteNonQuery();

                    if (rowsaffected >= 1) {
                        cliente_eliminado = true;
                    }
                    else if (rfc != "") {
                        rowsaffected = 0;
                        rowsaffected = comando2.ExecuteNonQuery();
                        if (rowsaffected >= 1) {
                            cliente_eliminado = true;
                        }
                    }
                }
                catch (MySqlException ex) {
                    //MessageBox.Show(ex.ToString());
                }
                finally {
                    conexion.Close();
                }
            }
            return cliente_eliminado;
        }

        public string Consultar_cliente(string nombres, string rfc) {
            string cadena_consulta = "";

            using (MySqlConnection conexion = new MySqlConnection(App.cadena_conexion)) {
                int rowsaffected = 0;
                MySqlCommand comando = new MySqlCommand("SELECT * FROM clientes WHERE Nombres=@nombres", conexion);
                MySqlCommand comando2 = new MySqlCommand("SELECT * FROM clientes WHERE RFC=@rfc", conexion);
                comando.Parameters.Add("@nombres", MySqlDbType.VarChar, 45).Value = nombres;
                comando.Parameters.Add("@rfc", MySqlDbType.VarChar, 13).Value = rfc;

                try {
                    conexion.Open();
                    MySqlDataReader reader = comando.ExecuteReader();
                    reader.Read();

                    if (reader.HasRows) {
                        cadena_consulta = reader.GetString(0);

                        if (reader.IsDBNull(1)) {
                            cadena_consulta = cadena_consulta + "," + "";
                        }
                        else {
                            cadena_consulta = cadena_consulta + "," + reader.GetString(1);
                        }

                        if (reader.IsDBNull(2)) {
                            cadena_consulta = cadena_consulta + "," + "";
                        }
                        else {
                            cadena_consulta = cadena_consulta + "," + reader.GetString(2);
                        }

                        if (reader.IsDBNull(3)) {
                            cadena_consulta = cadena_consulta + "," + "";
                        }
                        else {
                            cadena_consulta = cadena_consulta + "," + reader.GetString(3);
                        }

                        if (reader.IsDBNull(4)) {
                            cadena_consulta = cadena_consulta + "," + "";
                        }
                        else {
                            cadena_consulta = cadena_consulta + "," + reader.GetString(4);
                        }

                        if (reader.IsDBNull(5)) {
                            cadena_consulta = cadena_consulta + "," + "";
                        }
                        else {
                            cadena_consulta = cadena_consulta + "," + reader.GetString(5);
                        }

                    }
                    else if (rfc != "") {
                        conexion.Close();
                        conexion.Open();
                        rowsaffected = 0;
                        MySqlDataReader reader2 = comando2.ExecuteReader();
                        reader2.Read();

                        if (reader2.HasRows) {
                            cadena_consulta = reader2.GetString(0);

                            if (reader2.IsDBNull(1)) {
                                cadena_consulta = cadena_consulta + "," + "";
                            }
                            else {
                                cadena_consulta = cadena_consulta + "," + reader2.GetString(1);
                            }

                            if (reader2.IsDBNull(2)) {
                                cadena_consulta = cadena_consulta + "," + "";
                            }
                            else {
                                cadena_consulta = cadena_consulta + "," + reader2.GetString(2);
                            }

                            if (reader2.IsDBNull(3)) {
                                cadena_consulta = cadena_consulta + "," + "";
                            }
                            else {
                                cadena_consulta = cadena_consulta + "," + reader2.GetString(3);
                            }

                            if (reader2.IsDBNull(4)) {
                                cadena_consulta = cadena_consulta + "," + "";
                            }
                            else {
                                cadena_consulta = cadena_consulta + "," + reader2.GetString(4);
                            }

                            if (reader2.IsDBNull(5)) {
                                cadena_consulta = cadena_consulta + "," + "";
                            }
                            else {
                                cadena_consulta = cadena_consulta + "," + reader2.GetString(5);
                            }
                            if (reader2.IsDBNull(6)) {
                                cadena_consulta = cadena_consulta + "," + "";
                            }
                            else {
                                cadena_consulta = cadena_consulta + "," + reader2.GetString(6);
                            }
                        }
                    }
                    else {
                        cadena_consulta = "Error";
                    }
                }
                catch (MySqlException ex) {
                    //MessageBox.Show(ex.ToString());
                }
                finally {
                    conexion.Close();
                }
            }
            return cadena_consulta;
        }

        public bool Consultar_existencia_cliente(string rfc) {
            bool cliente_existe = false;

            using (MySqlConnection conexion = new MySqlConnection(App.cadena_conexion)) {
                int rowsaffected = 0;
                MySqlCommand comando = new MySqlCommand("SELECT * FROM clientes WHERE RFC=@rfc", conexion);
                comando.Parameters.Add("@rfc", MySqlDbType.VarChar, 13).Value = rfc;

                try {
                    conexion.Open();
                    MySqlDataReader reader = comando.ExecuteReader();
                    reader.Read();

                    if (reader.HasRows) {
                        cliente_existe=true;
                    }
                }
                catch (MySqlException ex) {
                    //MessageBox.Show(ex.ToString());
                }
                finally {
                    conexion.Close();
                }
                return cliente_existe;
            }
        }

        public List<Clientes> Consultar_nombres_cliente() {
            List<Clientes> Consulta_clientes = new List<Clientes>();

            using (MySqlConnection conexion = new MySqlConnection(App.cadena_conexion)) {
                MySqlCommand comando = new MySqlCommand("SELECT * FROM Clientes", conexion);

                try {
                    conexion.Open();
                    MySqlDataReader reader = comando.ExecuteReader();

                    while (reader.Read()) {
                        Consulta_clientes.Add(new Clientes() { Nombre = reader.GetString(0) });
                        // MessageBox.Show();
                    }
                }
                catch (MySqlException ex) {

                }
                finally {
                    conexion.Close();
                }
                return Consulta_clientes;
            }
        }
    }
}