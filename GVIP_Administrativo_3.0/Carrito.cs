using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GVIP_Administrativo_3._0 {
    public class Carrito {

        public int ID_Producto { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public string Imagen { get; set; }
        public string Descripcion { get; set; }

        public string Codigo_barras { get; set; }
        public int Cantidad { get; set; }
        public double Subtotal { get; set; }
        
        public DateTime Fecha { get; set; }

        public Carrito() {

        }
    }
}
