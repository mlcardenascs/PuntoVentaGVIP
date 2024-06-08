using MySql.Data.MySqlClient;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Mysqlx.Crud.Order.Types;

namespace GVIP_Administrativo_3._0 {
    public class Proveedor {

        public string Nombre { get; set; }
        public int ID { get; set; }

        public bool Agregar_proveedor(string nombre, string apellido_paterno, string apellido_materno, string rfc, string direccion, string tipo) {
            bool proveedor_agregado = false;
            using (MySqlConnection conexion = new MySqlConnection(App.cadena_conexion)) {
                MySqlCommand comando = new MySqlCommand("INSERT INTO proveedores(Nombre,Apellido_Paterno,Apellido_Materno,RFC,Direccion,Tipo, Cantidad_productos_provee) VALUES (@nombre, @apellido_paterno, @apellido_materno, @rfc, @direccion, @tipo, @Cantidad_productos_provee);", conexion);

                //@id_empleado, @nombre, @apellido1, @apellido2, @telefono, @rfc, @usuario, @contrasenia"
                comando.Parameters.Add("@nombre", MySqlDbType.VarChar, 45).Value = nombre;
                comando.Parameters.Add("@apellido_paterno", MySqlDbType.VarChar,45).Value = apellido_paterno;
                comando.Parameters.Add("@apellido_materno", MySqlDbType.VarChar, 45).Value = apellido_materno;
                comando.Parameters.Add("@rfc", MySqlDbType.VarChar, 13).Value = rfc;
                comando.Parameters.Add("@direccion", MySqlDbType.VarChar, 100).Value = direccion;
                comando.Parameters.Add("@tipo", MySqlDbType.VarChar, 45).Value = tipo;
                comando.Parameters.Add("@Cantidad_productos_provee", MySqlDbType.Int32).Value = 0;

                try {
                    //verificar si ya esta registrado el proveedor
                    if (!Verificar_existencia(rfc)) {  //si no existe
                        conexion.Open();

                        int rowsaffected = comando.ExecuteNonQuery();
                        if (rowsaffected > 0) {
                            proveedor_agregado = true;
                        }
                        else {
                            proveedor_agregado = false;
                        }
                    }
                    else {  //Si ya existe
                        proveedor_agregado=false;
                    }
                }
                catch (MySqlException ex) {
                    // MessageBox.Show(ex.ToString());
                }
                finally {
                    conexion.Close();
                }
                return proveedor_agregado;
            }
        }

        public bool Eliminar_proveedor(string rfc) {
            bool Proveedor_eliminado = false;

            using (MySqlConnection conexion = new MySqlConnection(App.cadena_conexion)) {
                MySqlCommand comando = new MySqlCommand("DELETE FROM proveedores WHERE RFC=@rfc", conexion);
                comando.Parameters.Add("@rfc", MySqlDbType.VarChar, 13).Value = rfc;
                
                try {
                    conexion.Open();
                    int rowsaffected = comando.ExecuteNonQuery();
                    
                    if (rowsaffected > 0) {
                        Proveedor_eliminado = true;
                    }
                }
                catch (MySqlException ex) {
                    // MessageBox.Show(ex.ToString());
                }
                finally {
                    conexion.Close();
                }
                return Proveedor_eliminado;
            }
        }

        public string Consultar_proveedor(string rfc) {
            string Datos_de_consulta = "";

            using (MySqlConnection conexion = new MySqlConnection(App.cadena_conexion)) {
                MySqlCommand comando = new MySqlCommand("SELECT * FROM proveedores WHERE RFC=@rfc", conexion);
                //@id_empleado, @nombre, @apellido1, @apellido2, @telefono, @rfc, @usuario, @contrasenia"
                comando.Parameters.Add("@rfc", MySqlDbType.VarChar, 13).Value = rfc;

                try {
                    conexion.Open();
                    MySqlDataReader reader = comando.ExecuteReader();
                    reader.Read();

                    if (reader.HasRows) {
                        Datos_de_consulta = reader.GetString(0) + "," + reader.GetString(1) + "," + reader.GetString(2) + "," + reader.GetString(3) + "," + reader.GetString(4) + "," + reader.GetString(5) + "," + reader.GetString(6);
                    }
                    else {
                        Datos_de_consulta = "Error";
                    }
                }
                catch (MySqlException ex) {
                    // MessageBox.Show(ex.ToString());
                }
                finally {
                    conexion.Close();
                }
                return Datos_de_consulta;
            }
        }

        public bool Actualizar_proveedor(string nombre, string apellido_paterno, string apellido_materno, string rfc, string direccion, string tipo) {
            bool proveedor_actualizado = false;
            using (MySqlConnection conexion = new MySqlConnection(App.cadena_conexion)) {
                MySqlCommand comando = new MySqlCommand("UPDATE proveedores " +
                     "SET Nombre=@nombre,Apellido_Paterno=@apellido_paterno,Apellido_Materno=@apellido_materno,Direccion=@direccion,Tipo=@tipo " +
                     "WHERE RFC=@rfc", conexion);

                comando.Parameters.Add("@nombre", MySqlDbType.VarChar, 45).Value = nombre;
                comando.Parameters.Add("@apellido_paterno", MySqlDbType.VarChar, 45).Value = apellido_paterno;
                comando.Parameters.Add("@apellido_materno", MySqlDbType.VarChar, 45).Value = apellido_materno;
                comando.Parameters.Add("@rfc", MySqlDbType.VarChar, 13).Value = rfc;
                comando.Parameters.Add("@direccion", MySqlDbType.VarChar, 100).Value = direccion;
                comando.Parameters.Add("@tipo", MySqlDbType.VarChar, 45).Value = tipo;

                try {
                    conexion.Open();
                    int rowsaffected = comando.ExecuteNonQuery();
                    
                    if (rowsaffected > 0) {
                        proveedor_actualizado = true;
                    }
                }
                catch (MySqlException ex) {
                    // MessageBox.Show(ex.ToString());
                }
                finally {
                    conexion.Close();
                }
                return proveedor_actualizado;
            }
        }

        public bool Verificar_existencia(string rfc) {
            bool proveedor_existe = false;
            using (MySqlConnection conexion = new MySqlConnection(App.cadena_conexion)) {
                MySqlCommand comando = new MySqlCommand("SELECT * FROM proveedores WHERE RFC=@rfc", conexion);
                //@id_empleado, @nombre, @apellido1, @apellido2, @telefono, @rfc, @usuario, @contrasenia"
                comando.Parameters.Add("@rfc", MySqlDbType.VarChar, 13).Value = rfc;

                try {
                    conexion.Open();
                    MySqlDataReader reader = comando.ExecuteReader();
                    reader.Read();

                    if (reader.HasRows) {
                        proveedor_existe=true;
                    }
                    else {
                        proveedor_existe = false;    
                    }
                }
                catch (MySqlException ex) {
                    // MessageBox.Show(ex.ToString());
                }
                finally {
                    conexion.Close();
                }
                return proveedor_existe;
            }
        }

        public List<Proveedor> Obtener_proveedores() {
            List<Proveedor> proveedores = new List<Proveedor>();

            using (MySqlConnection conexion = new MySqlConnection(App.cadena_conexion)) {
                MySqlCommand comando = new MySqlCommand("SELECT * FROM proveedores", conexion);

                try {
                    conexion.Open();
                    MySqlDataReader reader = comando.ExecuteReader();

                    while (reader.Read()) {
                        proveedores.Add(new Proveedor() { Nombre = reader.GetString(1), ID=reader.GetInt32(0) });
                    }
                }
                catch (MySqlException ex) {

                }
                finally {
                    conexion.Close();
                }
                return proveedores;
            }
        }

        public void Aumentar_cantidad_proveedor(string nombre_proveedor) {
            bool aumentado = false;
            using (MySqlConnection conexion = new MySqlConnection(App.cadena_conexion)) {

                MySqlCommand comando = new MySqlCommand("UPDATE proveedores " +
                     "SET Cantidad_productos_provee = Cantidad_productos_provee + 1 " +
                     "WHERE Nombre=@nombre_proveedor", conexion);

                comando.Parameters.Add("@nombre_proveedor", MySqlDbType.VarChar, 45).Value = nombre_proveedor;

                try {
                    conexion.Open();
                    int rowsaffected = comando.ExecuteNonQuery();
                    if (rowsaffected > 0) {
                        aumentado = true;
                        
                    }
                }
                catch (MySqlException ex) {
                }
                finally
                {
                    conexion.Close();
                }
            }
        }

        public void Reducir_cantidad_proveedor(string nombre_proveedor) {
            using (MySqlConnection conexion = new MySqlConnection(App.cadena_conexion)) {

                MySqlCommand comando = new MySqlCommand("UPDATE proveedores " +
                     "SET Cantidad_productos_provee = Cantidad_productos_provee - 1 " +
                     "WHERE Nombre=@nombre_proveedor", conexion);

                comando.Parameters.Add("@nombre_proveedor", MySqlDbType.VarChar, 45).Value = nombre_proveedor;

                try {
                    conexion.Open();
                    int rowsaffected = comando.ExecuteNonQuery();
                    if (rowsaffected > 0) {
                        
                        
                    }
                }
                catch (MySqlException ex) {

                }
                finally {
                    conexion.Close();
                }
            }
        }

    }
}