using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GVIP_Administrativo_3._0 {
    public class Class_Productos {

        public List<Productos> ObtenerProductos() {
            List<Productos> Consulta_productos = new List<Productos>();

            using (MySqlConnection conexion = new MySqlConnection(App.cadena_conexion)) {
                MySqlCommand comando = new MySqlCommand("SELECT * FROM productos ORDER BY ID_Producto", conexion);

                try {
                    conexion.Open();
                    MySqlDataReader reader = comando.ExecuteReader();

                    while (reader.Read()) {
                        Consulta_productos.Add(new Productos() { ID_Producto= reader.GetInt32(0), Nombre= reader.GetString(1), Precio= reader.GetDouble(2), Imagen= reader.GetString(3), Descripcion= reader.GetString(4), Codigo_barras= reader.GetString(6) });
                    }
                }
                catch (MySqlException ex) {
                    
                }
                finally {
                    conexion.Close();
                }
                return Consulta_productos;
            }
        }

    }
}