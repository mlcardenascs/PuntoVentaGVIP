using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GVIP_Administrativo_3._0 {
    public class Venta {
        public bool Agregar_venta(List<Carrito> Carrito, double total, string cliente) {
            bool venta_agregada = false;

            using (MySqlConnection conexion = new MySqlConnection(App.cadena_conexion)) {
                int rowsaffected = 0;
                MySqlCommand comando = new MySqlCommand("insert into ventas (Cliente,Cant_productos,Total) values (@Cliente, @Cant_productos,@Total)", conexion);
                comando.Parameters.Add("@Cliente", MySqlDbType.VarChar, 45).Value = cliente;
                comando.Parameters.Add("@Cant_productos", MySqlDbType.Int32).Value = Carrito.Count;
                comando.Parameters.Add("@Total", MySqlDbType.Decimal).Value = total;

                try {
                    conexion.Open();
                    rowsaffected = comando.ExecuteNonQuery();

                    if (rowsaffected > 0) {
                        Agregar_detalle_venta(Carrito, cliente);
                        venta_agregada = true;
                    }
                }
                catch (MySqlException ex) {
                    //MessageBox.Show(ex.ToString());
                }
                finally {
                    conexion.Close();
                }
            }
            return venta_agregada;
        }

        public bool Agregar_detalle_venta(List<Carrito> Carrito, string cliente) {
            bool detalles_agregados = false;
            using (MySqlConnection conexion = new MySqlConnection(App.cadena_conexion)) {
                int rowsaffected = 0;
                MySqlCommand comando = new MySqlCommand("insert into detalle_ventas(ID_Venta,Fecha,Cliente,ID_Producto,Descripcion,Cantidad,Total) values (@ID_Venta, curdate(), @Cliente,@ID_producto, @Descripcion, @cantidad, @total )", conexion);

                try {
                    conexion.Open();

                    for (var j = 0; j < Carrito.Count; j++) {
                        comando.Parameters.Add("@ID_Venta", MySqlDbType.Int32).Value = Obtener_id_ultima_venta();
                        comando.Parameters.Add("@Cliente", MySqlDbType.VarChar, 45).Value = cliente;
                        comando.Parameters.Add("@ID_producto", MySqlDbType.Int32).Value = Carrito[j].ID_Producto;
                        comando.Parameters.Add("@Descripcion", MySqlDbType.VarChar, 100).Value = Carrito[j].Descripcion;
                        comando.Parameters.Add("@cantidad", MySqlDbType.Int32).Value = Carrito[j].Cantidad;
                        comando.Parameters.Add("@Total", MySqlDbType.Decimal).Value = Carrito[j].Subtotal;
                        rowsaffected = comando.ExecuteNonQuery();

                        if (rowsaffected > 0) {
                            detalles_agregados = true;
                        }
                        else {
                            detalles_agregados = false;
                        }
                        comando.Parameters.Clear();
                    }
                }
                catch (MySqlException ex) {
                    //MessageBox.Show(ex.ToString());
                }
                finally {
                    conexion.Close();
                }
            }
            return detalles_agregados;
        }

        public int Obtener_id_ultima_venta() {
            int id = 0;
            using (MySqlConnection conexion = new MySqlConnection(App.cadena_conexion)) {
                int rowsaffected = 0;
                MySqlCommand comando = new MySqlCommand("select * from ventas order by ID_Venta desc limit 1", conexion);

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

        public List<Carrito> Consultar_venta(int id_venta) {
            List<Carrito> lista_ventas = new List<Carrito>();

            using (MySqlConnection conexion = new MySqlConnection(App.cadena_conexion)) {
                int rowsaffected = 0;
                MySqlCommand comando = new MySqlCommand("select * from detalle_ventas where ID_Venta= @ID_Venta", conexion);
                comando.Parameters.Add("@ID_Venta", MySqlDbType.Int32).Value = id_venta;

                try {
                    conexion.Open();
                    MySqlDataReader reader = comando.ExecuteReader();

                    while(reader.Read()) {
                        lista_ventas.Add(new Carrito() { ID_Producto = reader.GetInt32(4), Cantidad=reader.GetInt32(6),Fecha=reader.GetDateTime(2)});

                    }
                }
                catch (MySqlException ex) {
                    //MessageBox.Show(ex.ToString());
                }
                finally {
                    conexion.Close();
                }
            }
            return lista_ventas;
        }

        public bool Eliminar_venta(int id_venta) {
            bool venta_eliminada = false;

            using (MySqlConnection conexion = new MySqlConnection(App.cadena_conexion)) {
                int rowsaffected = 0;
                MySqlCommand comando = new MySqlCommand("DELETE FROM ventas WHERE ID_Venta=@id_venta", conexion);
                comando.Parameters.Add("@id_venta", MySqlDbType.Int32).Value = id_venta;

                try {
                    conexion.Open();
                    rowsaffected = comando.ExecuteNonQuery();

                    if (rowsaffected > 0 & Eliminar_detalle_venta(id_venta)) {
                        
                        venta_eliminada = true;
                    }
                }
                catch (MySqlException ex) {
                    //MessageBox.Show(ex.ToString());
                }
                finally {
                    conexion.Close();
                }
                return venta_eliminada;
            }
        }

        public bool Eliminar_detalle_venta(int id_venta) {
            bool detalle_eliminado = false;

            using (MySqlConnection conexion = new MySqlConnection(App.cadena_conexion)) {
                int rowsaffected = 0;
                MySqlCommand comando = new MySqlCommand("DELETE FROM detalle_ventas WHERE ID_Venta=@id_venta", conexion);
                comando.Parameters.Add("@id_venta", MySqlDbType.Int32).Value = id_venta;

                try {
                    conexion.Open();
                    rowsaffected = comando.ExecuteNonQuery();

                    if (rowsaffected > 0) {

                        detalle_eliminado = true;
                    }
                }
                catch (MySqlException ex) {
                    //MessageBox.Show(ex.ToString());
                }
                finally {
                    conexion.Close();
                }
                return detalle_eliminado;
            }   
        }
    }
}