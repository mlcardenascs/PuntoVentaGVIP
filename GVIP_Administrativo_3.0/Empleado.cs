using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GVIP_Administrativo_3._0 {
    public class Empleado {
        public bool Agregar_empleado(string nombres, string apellido1, string apellido2, int edad, string curp, string rfc, string direccion, string puesto, decimal sueldo, string fecha_contratacion, string imagen) {
            bool empleado_registrado = false;

            using (MySqlConnection conexion = new MySqlConnection(App.cadena_conexion)) {
                int rowsaffected = 0;
                MySqlCommand comando = new MySqlCommand("insert into empleados (Nombres, Apellido_paterno, Apellido_materno, Edad, CURP, RFC, Direccion, Puesto, Sueldo, Fecha_contratacion, Imagen) VALUES (@nombres, @apellido_paterno, @apellido_materno,@edad, @curp, @rfc, @direccion,@puesto, @sueldo, @fecha_contratacion, @imagen)", conexion);

                comando.Parameters.Add("@nombres", MySqlDbType.VarChar, 50).Value = nombres;
                comando.Parameters.Add("@apellido_paterno", MySqlDbType.VarChar, 45).Value = apellido1;
                comando.Parameters.Add("@apellido_materno", MySqlDbType.VarChar, 45).Value = apellido2;
                comando.Parameters.Add("@edad", MySqlDbType.Int32).Value = edad;
                comando.Parameters.Add("@curp", MySqlDbType.VarChar, 18).Value = curp;
                comando.Parameters.Add("@rfc", MySqlDbType.VarChar, 13).Value = rfc;
                comando.Parameters.Add("@direccion", MySqlDbType.VarChar, 100).Value = direccion;
                comando.Parameters.Add("@puesto", MySqlDbType.VarChar, 45).Value = puesto;
                comando.Parameters.Add("@sueldo", MySqlDbType.Decimal).Value = sueldo;
                comando.Parameters.Add("@fecha_contratacion", MySqlDbType.Date).Value = fecha_contratacion;
                comando.Parameters.Add("@imagen", MySqlDbType.VarChar, 100).Value = imagen;

                try {
                    conexion.Open();
                    rowsaffected = comando.ExecuteNonQuery();

                    if (rowsaffected >= 1) {
                        empleado_registrado = true;
                    }
                }
                catch (MySqlException ex) {
                    //MessageBox.Show(ex.ToString());
                }
                finally {
                    conexion.Close();
                }
            }
            return empleado_registrado;
        }

        public bool Eliminar_empleado(string curp) {
            bool empleado_eliminado = false;

            using (MySqlConnection conexion = new MySqlConnection(App.cadena_conexion)) {
                int rowsaffected = 0;
                MySqlCommand comando = new MySqlCommand("DELETE FROM empleados WHERE CURP=@curp", conexion);
                comando.Parameters.Add("@curp", MySqlDbType.VarChar, 18).Value = curp;

                try {
                    conexion.Open();
                    rowsaffected = comando.ExecuteNonQuery();

                    if (rowsaffected >= 1) {
                        empleado_eliminado = true;
                    }
                }
                catch (MySqlException ex) {
                    // MessageBox.Show(ex.ToString());
                }
                finally {
                    conexion.Close();
                }
            }
            return empleado_eliminado;
        }

        public string Consultar_empleado(string curp) {
            string datos_de_consulta = "";

            using (MySqlConnection conexion = new MySqlConnection(App.cadena_conexion)) {
                MySqlCommand comando = new MySqlCommand("SELECT * FROM empleados WHERE CURP = @curp", conexion);
                comando.Parameters.Add("@curp", MySqlDbType.VarChar, 18).Value = curp;

                try {
                    conexion.Open();
                    MySqlDataReader reader = comando.ExecuteReader();
                    reader.Read();

                    if (reader.HasRows) {
                        datos_de_consulta = reader.GetString(0) + "," + reader.GetString(1) + "," + reader.GetString(2) + "," + reader.GetString(3) + "," + reader.GetString(4) + "," + reader.GetString(5) + "," + reader.GetString(6) + "," + reader.GetString(7) + "," + reader.GetString(8) + "," + reader.GetString(9) + "," + reader.GetString(10) + "," + reader.GetString(11);
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

        public bool Actualizar_empleado(string nombres, string apellido1, string apellido2, int edad, string curp, string rfc, string direccion, string puesto, decimal sueldo, string fecha_contratacion, string imagen) {
            bool empleado_actualizado = false;

            using (MySqlConnection conexion = new MySqlConnection(App.cadena_conexion)) {
                int rowsaffected = 0;
                MySqlCommand comando = new MySqlCommand("UPDATE empleados " +
                    "SET Nombres=@nombres, Apellido_paterno=@apellido_paterno, Apellido_materno=@apellido_materno, Edad=@edad, RFC=@rfc, Direccion=@direccion, Puesto=@puesto, Sueldo=@sueldo, Fecha_contratacion=@fecha_contratacion, Imagen=@imagen " +
                    "WHERE CURP=@curp", conexion);

                comando.Parameters.Add("@nombres", MySqlDbType.VarChar, 50).Value = nombres;
                comando.Parameters.Add("@apellido_paterno", MySqlDbType.VarChar, 45).Value = apellido1;
                comando.Parameters.Add("@apellido_materno", MySqlDbType.VarChar, 45).Value = apellido2;
                comando.Parameters.Add("@edad", MySqlDbType.Int32).Value = edad;
                comando.Parameters.Add("@curp", MySqlDbType.VarChar, 18).Value = curp;
                comando.Parameters.Add("@rfc", MySqlDbType.VarChar, 13).Value = rfc;
                comando.Parameters.Add("@direccion", MySqlDbType.VarChar, 100).Value = direccion;
                comando.Parameters.Add("@puesto", MySqlDbType.VarChar, 45).Value = puesto;
                comando.Parameters.Add("@sueldo", MySqlDbType.Decimal).Value = sueldo;
                comando.Parameters.Add("@fecha_contratacion", MySqlDbType.Date).Value = fecha_contratacion;
                comando.Parameters.Add("@imagen", MySqlDbType.VarChar, 100).Value = imagen;

                try {
                    conexion.Open();
                    rowsaffected = comando.ExecuteNonQuery();

                    if (rowsaffected >= 1) {
                        empleado_actualizado = true;
                    }
                }
                catch (MySqlException ex) {
                    //MessageBox.Show(ex.ToString());
                }
                finally {
                    conexion.Close();
                }

            }
            return empleado_actualizado;
        }

        public bool Consultar_existencia_empleado(string curp) {
            using (MySqlConnection conexion = new MySqlConnection(App.cadena_conexion)) {
                bool empleado_existe = false;
                MySqlCommand comando = new MySqlCommand("SELECT * FROM empleados WHERE CURP = @curp", conexion);
                comando.Parameters.Add("@curp", MySqlDbType.VarChar, 18).Value = curp;

                try {
                    conexion.Open();
                    MySqlDataReader reader = comando.ExecuteReader();
                    reader.Read();

                    if (reader.HasRows) {
                        empleado_existe = true;
                    }
                    else {
                        empleado_existe = false;
                    }
                }
                catch (MySqlException ex) {
                    // MessageBox.Show(ex.ToString());
                }
                finally {
                    conexion.Close();
                }
                return empleado_existe;
            }
        }

        public List<Clientes> Consultar_nombres_puestos() {
            List<Clientes> Lista_puestos = new List<Clientes>();

            using (MySqlConnection conexion = new MySqlConnection(App.cadena_conexion)) {
                MySqlCommand comando = new MySqlCommand("SELECT * FROM puestos", conexion);

                try {
                    conexion.Open();
                    MySqlDataReader reader = comando.ExecuteReader();

                    while (reader.Read()) {
                        Lista_puestos.Add(new Clientes() { Nombre = reader.GetString(1) });
                        // MessageBox.Show();
                    }
                }
                catch (MySqlException ex) {

                }
                finally {
                    conexion.Close();
                }
                return Lista_puestos;
            }
        }
    }
}