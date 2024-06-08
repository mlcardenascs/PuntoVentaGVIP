using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GVIP_Administrativo_3._0 {
    public class Productos {
        public int ID_Producto { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public string Imagen { get; set; }
        public string Descripcion { get; set; }
        public string Codigo_barras { get; set; }

        public bool Agregar_producto(string nombre, double precio, string imagen, string descripcion, int cantidad, string codigo_barras,int id_proveedor, string nombre_proveedor) {
            bool producto_agregado = false;
            using (MySqlConnection conexion = new MySqlConnection(App.cadena_conexion)) {
                MySqlCommand comando = new MySqlCommand("INSERT INTO productos(Nombre, Precio,Imagen, Descripcion, Cantidad_disponible, Codigo_barras_texto,Proveedor) VALUES (@nombre, @precio, @imagen, @descripcion,@cantidad, @codigo_barras,@proveedor)", conexion);
                comando.Parameters.Add("@nombre", MySqlDbType.VarChar, 45).Value = nombre;
                comando.Parameters.Add("@precio", MySqlDbType.Decimal).Value = precio;
                comando.Parameters.Add("@Imagen", MySqlDbType.LongBlob).Value = imagen;
                comando.Parameters.Add("@Descripcion", MySqlDbType.VarChar, 100).Value = descripcion;
                comando.Parameters.Add("@cantidad", MySqlDbType.Int32).Value = cantidad;
                comando.Parameters.Add("@codigo_barras", MySqlDbType.VarChar, 45).Value = codigo_barras;
                comando.Parameters.Add("@proveedor", MySqlDbType.VarChar, 45).Value = nombre_proveedor;

                try {
                    //verificar si el producto existe
                    if (!Verificar_existencia(codigo_barras)) {  // si no existe 
                        conexion.Open();

                        int rowsaffected = comando.ExecuteNonQuery();
                        if (rowsaffected > 0) {
                            producto_agregado = true;
                            Agregar_detalle_proveedores(id_proveedor,nombre_proveedor, Obtener_id_producto_agregado(), nombre);
                            Proveedor proveedores = new Proveedor();
                            proveedores.Aumentar_cantidad_proveedor(nombre_proveedor);
                        }
                        else {
                            producto_agregado = false;
                        }
                    }
                    else {  //si existe
                        System.Windows.MessageBox.Show("El producto que intenta registrar ya se encuentra registrado");

                    }
                }
                catch (MySqlException ex) {
                    // MessageBox.Show(ex.ToString());
                }
                finally {
                    conexion.Close();
                }
                return producto_agregado;
            }
        }

        public bool Eliminar_producto(string codigo_barras) {
            bool Producto_eliminado = false;
            using (MySqlConnection conexion = new MySqlConnection(App.cadena_conexion)) {
                MySqlCommand comando = new MySqlCommand("DELETE FROM productos WHERE Codigo_barras_texto=@codigo_barras", conexion);
                comando.Parameters.Add("@codigo_barras", MySqlDbType.VarChar, 45).Value = codigo_barras;

                Productos producto = new Productos();
                string[] datos_producto = producto.Consultar_producto(codigo_barras).Split(',');
                try {
                    conexion.Open();

                    int rowsaffected = comando.ExecuteNonQuery();
                    if (rowsaffected > 0) {
                        Producto_eliminado = true;
                        Proveedor proveedores = new Proveedor();

                        if (datos_producto[0] != "Error") {
                            proveedores.Reducir_cantidad_proveedor(datos_producto[6]);
                        }
                    }
                }
                catch (MySqlException ex) {
                    // MessageBox.Show(ex.ToString());
                }
                finally {
                    conexion.Close();
                }
                return Producto_eliminado;
            }
        }
        public string Consultar_producto(string codigo_barras) {
            string Datos_de_consulta = "";

            using (MySqlConnection conexion = new MySqlConnection(App.cadena_conexion)) {
                MySqlCommand comando = new MySqlCommand("SELECT * FROM productos WHERE Codigo_barras_texto = @codigo_barras", conexion);
                comando.Parameters.Add("@codigo_barras", MySqlDbType.VarChar, 45).Value = codigo_barras;

                try {
                    conexion.Open();
                    MySqlDataReader reader = comando.ExecuteReader();
                    reader.Read();

                    if (reader.HasRows) {
                        Datos_de_consulta = reader.GetString(0) + "," + reader.GetString(1) + "," + reader.GetString(2) + "," + reader.GetString(3) + "," + reader.GetString(4) + "," + reader.GetString(5) + "," + reader.GetString(7);
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

        public bool Actualizar_producto(string codigo_barras, string imagen) {
            bool producto_actualizado = false;
            using (MySqlConnection conexion = new MySqlConnection(App.cadena_conexion)) {
                MySqlCommand comando = new MySqlCommand("UPDATE productos " +
                     "SET Imagen=@imagen " +
                     "WHERE Codigo_barras_texto=@codigo_barras", conexion);

                comando.Parameters.Add("@codigo_barras", MySqlDbType.VarChar, 45).Value = codigo_barras;
                comando.Parameters.Add("@imagen", MySqlDbType.LongBlob).Value = codigo_barras;

                try {
                    conexion.Open();
                    int rowsaffected = comando.ExecuteNonQuery();
                    if (rowsaffected > 0) {
                        producto_actualizado = true;
                    }
                }
                catch (MySqlException ex) {
                    // MessageBox.Show(ex.ToString());
                }
                finally {
                    conexion.Close();
                }
                return producto_actualizado;
            }
        }

        public bool Verificar_existencia(string codigo_barras) {
            bool producto_existe = false;
            using (MySqlConnection conexion = new MySqlConnection(App.cadena_conexion)) {
                MySqlCommand comando = new MySqlCommand("SELECT * FROM productos WHERE Codigo_barras_texto=@codigo_barras", conexion);
                comando.Parameters.Add("@codigo_barras", MySqlDbType.VarChar, 45).Value = codigo_barras;

                try {
                    conexion.Open();
                    MySqlDataReader reader = comando.ExecuteReader();
                    reader.Read();

                    if (reader.HasRows) {
                        producto_existe = true;
                    }
                    else {
                        producto_existe = false;
                    }
                }
                catch (MySqlException ex) {
                    // MessageBox.Show(ex.ToString());
                }
                finally {
                    conexion.Close();
                }
                return producto_existe;
            }
        }

        public bool Agregar_detalle_proveedores(int id_proveedor, string nombre_proveedor, int id_producto, string nombre_producto) {
            bool detalle_agregado = false;
            using (MySqlConnection conexion = new MySqlConnection(App.cadena_conexion)) {
                MySqlCommand comando = new MySqlCommand("INSERT INTO detalle_proveedores(ID_Proveedor,Nombre_proveedor,ID_Producto,Nombre_producto) VALUES (@id_proveedor, @nombre_proveedor, @id_producto, @nombre_producto);", conexion);
                comando.Parameters.Add("@id_proveedor", MySqlDbType.Int32).Value = id_proveedor;
                comando.Parameters.Add("@nombre_proveedor", MySqlDbType.VarChar, 45).Value = nombre_proveedor;
                comando.Parameters.Add("@id_producto", MySqlDbType.Int32).Value = id_producto;
                comando.Parameters.Add("@nombre_producto", MySqlDbType.VarChar, 45).Value = nombre_producto;

                try {
                    conexion.Open();
                    int rowsaffected = comando.ExecuteNonQuery();
                    if (rowsaffected > 0) {
                        detalle_agregado = true;
                    }
                }
                catch (MySqlException ex) {
                    // MessageBox.Show(ex.ToString());
                }
                finally {
                    conexion.Close();
                }
                return detalle_agregado;
            }
        }

        public int Obtener_id_producto_agregado() {
            int id = 0;
            using (MySqlConnection conexion = new MySqlConnection(App.cadena_conexion)) {
                int rowsaffected = 0;
                MySqlCommand comando = new MySqlCommand("select * from productos order by ID_Producto desc limit 1", conexion);

                try {
                    conexion.Open();
                    MySqlDataReader reader = comando.ExecuteReader();
                    reader.Read();
                    id = reader.GetInt32(0);
                }
                catch (MySqlException ex) {
                    //MessageBox.Show(ex.ToString());
                }
                finally {
                    conexion.Close();
                }
            }
            return id;
        }   
    }
}