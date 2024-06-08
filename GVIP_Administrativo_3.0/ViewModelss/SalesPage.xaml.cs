using GVIP_Administrativo_3._0.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GVIP_Administrativo_3._0.ViewModelss
{
    /// <summary>
    /// Lógica de interacción para SalesPage.xaml
    /// </summary>
    public partial class SalesPage : Page
    {
        public Class_Productos objproductos = new Class_Productos();

        public List<Carrito> Carrito = new List<Carrito>();

        public List<Productos> Lista_Productos = new List<Productos>();

        public double total = 0;
        public SalesPage()
        {
            InitializeComponent();

            //List<Productos> Lista_Productos = objproductos.ObtenerProductos();

            Lista_Productos = objproductos.ObtenerProductos();

            Cargar_Clientes();
            Cbox_clientes.SelectedItem = "Publico general";

            cbox_opciones.Items.Add("Seleccione una opción");
            cbox_opciones.Items.Add("Consultar");
            cbox_opciones.Items.Add("Eliminar");
            cbox_opciones.SelectedIndex = 0;

            txt_cod_prueba.Focus();
            txt_cod_prueba.Text = "";

           // MessageBox.Show(Lista_Productos[0].Nombre);

        }

        


        private void prueba1(object sender, MouseEventArgs e)
        {
            
        }

        public void Añadir_al_carrito_lector()
        {
            if (txt_cod_prueba.Text == "CódigoBarras" || txt_cod_prueba.Text == "")
            {
                MessageBox.Show("El producto no se encuentra agregado");
                return;
            }
            ListViewProductos.ItemsSource = null;
            ListViewProductos.Items.Clear();

            string id_producto_busqueda = "";
            bool Producto_encontrado = false, Existe_en_carrito = false;
            int index_busqueda = 0, index_agregado = 0;

            id_producto_busqueda = txt_cod_prueba.Text;



            for (var i = 0; i < Lista_Productos.Count; i++)
            {

                if (id_producto_busqueda == Lista_Productos[i].Codigo_barras)
                {
                    index_busqueda = i;
                    Producto_encontrado = true;
                    break;
                }
                else
                {
                    Producto_encontrado = false;
                }
            }
            if (Producto_encontrado == false)
            {
                MessageBox.Show("El producto no está registrado en el sistema");
            }

            if (Producto_encontrado == true)
            {
                for (var j = 0; j < Carrito.Count; j++)
                {

                    if (id_producto_busqueda == Carrito[j].Codigo_barras)
                    {
                        Carrito[j].Cantidad = Carrito[j].Cantidad + 1;
                        Carrito[j].Subtotal = Carrito[j].Subtotal + Carrito[j].Precio;
                        Existe_en_carrito = true;
                        break;
                    }
                    else
                    {
                        Existe_en_carrito = false;
                    }
                }

                if (Existe_en_carrito == false)
                {
                    Carrito.Add(new Carrito() { ID_Producto = Lista_Productos[index_busqueda].ID_Producto, Nombre = Lista_Productos[index_busqueda].Nombre, Precio = Lista_Productos[index_busqueda].Precio, Imagen = Lista_Productos[index_busqueda].Imagen, Descripcion = Lista_Productos[index_busqueda].Descripcion, Codigo_barras = Lista_Productos[index_busqueda].Codigo_barras, Cantidad = 1 });
                    index_agregado = Carrito.Count - 1;
                    Carrito[index_agregado].Subtotal = Carrito[index_agregado].Subtotal + Carrito[index_agregado].Precio;
                }
            }

            txt_cod_prueba.Text="";
            txt_cod_prueba.Focus();
            Actualizar_total();
            Actualizar_Listas();
        }

        public void Eliminar_del_carrito_lector()
        {

            if (txt_cod_prueba.Text == "CódigoBarras" || txt_cod_prueba.Text == "")
            {
                MessageBox.Show("El producto no se encuentra agregado");
                return;
            }
            string id_producto_busqueda = "";
            bool Existe_en_carrito = false;
            id_producto_busqueda = txt_cod_prueba.Text;


            for (var j = 0; j < Carrito.Count; j++)
            {

                if (id_producto_busqueda == Carrito[j].Codigo_barras)
                {
                    Carrito.RemoveAt(j);
                    Existe_en_carrito = true;
                    break;
                }
                else
                {
                    Existe_en_carrito = false;
                }
            }

            if (!Existe_en_carrito)
            {
                MessageBox.Show("El producto no está agregado");
            }
            else
            { 
                Actualizar_Listas();

            }
        }
        private void btn_prueba_consulta_Click(object sender, RoutedEventArgs e)
        {

            if (txt_cod_prueba.Text == "CódigoBarras" || txt_cod_prueba.Text == "")
            {
                MessageBox.Show("El producto no se encuentra agregado");
                return;
            }
            ListViewProductos.ItemsSource = null;
            ListViewProductos.Items.Clear();
            
            string id_producto_busqueda ="";
            bool Producto_encontrado = false, Existe_en_carrito=false;
            int index_busqueda = 0,index_agregado=0;

            id_producto_busqueda = txt_cod_prueba.Text;

            

            for (var i = 0; i < Lista_Productos.Count; i++)
            {
                
                if (id_producto_busqueda == Lista_Productos[i].Codigo_barras)
                {
                    index_busqueda = i;
                    Producto_encontrado = true;
                    break;
                }
                else
                {
                    Producto_encontrado = false;
                }
            }
            if(Producto_encontrado==false)
            {
                MessageBox.Show("El producto no está registrado en el sistema");
            }

            if(Producto_encontrado==true)
            {
                for (var j = 0; j < Carrito.Count; j++)
                {

                    if (id_producto_busqueda == Carrito[j].Codigo_barras)
                    {
                        Carrito[j].Cantidad = Carrito[j].Cantidad + 1;
                        Carrito[j].Subtotal = Carrito[j].Subtotal + Carrito[j].Precio;
                        Existe_en_carrito = true;
                        break;
                    }
                    else
                    {
                        Existe_en_carrito = false;
                    }
                }

                if (Existe_en_carrito == false)
                {
                    Carrito.Add(new Carrito() { ID_Producto = Lista_Productos[index_busqueda].ID_Producto, Nombre = Lista_Productos[index_busqueda].Nombre, Precio = Lista_Productos[index_busqueda].Precio, Imagen = Lista_Productos[index_busqueda].Imagen, Descripcion = Lista_Productos[index_busqueda].Descripcion, Codigo_barras = Lista_Productos[index_busqueda].Codigo_barras, Cantidad = 1 });
                    index_agregado = Carrito.Count -1;
                    Carrito[index_agregado].Subtotal = Carrito[index_agregado].Subtotal + Carrito[index_agregado].Precio;
                }
            }


            Actualizar_Listas();
            

            //Carrito.Add(new Productos() { ID_Producto = Lista_Productos[index_busqueda+1].ID_Producto, Nombre = Lista_Productos[index_busqueda+1].Nombre, Precio = Lista_Productos[index_busqueda+1].Precio, Imagen = Lista_Productos[index_busqueda+1].Imagen, Descripcion = Lista_Productos[index_busqueda+1].Descripcion });


        }

        private void btn_eliminar_Click(object sender, RoutedEventArgs e)
        {

            if (txt_cod_prueba.Text == "CódigoBarras" || txt_cod_prueba.Text == "")
            {
                MessageBox.Show("El producto no se encuentra agregado");
                return;
            }
            int id_producto_busqueda = 0;
            bool Existe_en_carrito = false;
            id_producto_busqueda = Convert.ToInt32(txt_cod_prueba.Text);


            for (var j = 0; j < Carrito.Count; j++)
            {

                if (id_producto_busqueda == Convert.ToInt32(Carrito[j].Codigo_barras))
                {
                    Carrito.RemoveAt(j);
                    Existe_en_carrito = true;
                    break;
                }
                else
                {
                    Existe_en_carrito = false;
                }
            }

            if(!Existe_en_carrito)
            {
                MessageBox.Show("El producto no está agregado");
            }else
            {
                Actualizar_subtotales();
                Actualizar_total();
                Actualizar_Listas();

            }




        }

        private void btn_sumar1_Click(object sender, RoutedEventArgs e)
        {
            if (txt_cod_prueba.Text == "CódigoBarras" || txt_cod_prueba.Text == "")
            {
                MessageBox.Show("El producto no se encuentra agregado");
                return;
            }
            string id_producto_busqueda = "";
            bool Existe_en_carrito = false;

            

            id_producto_busqueda = txt_cod_prueba.Text;

            for (var j = 0; j < Carrito.Count; j++)
            {

                if (id_producto_busqueda == Carrito[j].Codigo_barras)
                {
                    Carrito[j].Cantidad = Carrito[j].Cantidad + 1;
                    Carrito[j].Subtotal = Carrito[j].Subtotal + Carrito[j].Precio;
                    Existe_en_carrito = true;
                    break;
                }
                else
                {
                    Existe_en_carrito = false;
                }
            }

            if (Existe_en_carrito == false)
            {
                MessageBox.Show("El producto no se encuentra agregado");
            }
            else
            {
                Actualizar_Listas();
            }
            txt_cantidad.Text = Convert.ToString(Carrito[ListViewTotales.SelectedIndex].Cantidad);

        }

        private void btn_restar1_Click(object sender, RoutedEventArgs e)
        {
            if (txt_cod_prueba.Text == "CódigoBarras" || txt_cod_prueba.Text == "")
            {
                MessageBox.Show("El producto no se encuentra agregado");
                return;
            }
            string id_producto_busqueda = "";
            bool Existe_en_carrito = false;

            id_producto_busqueda = txt_cod_prueba.Text;

            for (var j = 0; j < Carrito.Count; j++)
            {

                if (id_producto_busqueda == Carrito[j].Codigo_barras)
                {
                    Carrito[j].Cantidad = Carrito[j].Cantidad - 1;
                    Carrito[j].Subtotal = Carrito[j].Subtotal - Carrito[j].Precio;
                    if (Carrito[j].Cantidad == 0)
                    {
                        Carrito.RemoveAt(j);
                        Actualizar_Listas();
                    }
                    Existe_en_carrito = true;
                    break;
                }
                else
                {
                    Existe_en_carrito = false;
                }
            }

            if (Existe_en_carrito == false)
            {
                MessageBox.Show("El producto no se encuentra agregado");
            }
            else
            {
                Actualizar_subtotales();
                Actualizar_total();
                Actualizar_Listas();
                
            }
            if (ListViewTotales.SelectedIndex!=-1)
            {
                txt_cantidad.Text = Convert.ToString(Carrito[ListViewTotales.SelectedIndex].Cantidad);
            }
            else
            {
                System.Windows.MessageBox.Show("El producto no se encuentra registrado en el carrito");
            }

        }

        public void Actualizar_Listas()
        {
                total = 0;

            Actualizar_subtotales();
            Actualizar_total();
            
            ListViewProductos.ItemsSource = Carrito;
            ListViewProductos.Items.Refresh();

            ListViewTotales.ItemsSource = Carrito;
            ListViewTotales.Items.Refresh();
            
            
        }

        public void Actualizar_total()
        {
            for (var j = 0; j < Carrito.Count; j++)
            {

                total = total + Carrito[j].Subtotal;
            }

            Text_total.Text = "Total:                    $" + Convert.ToString(total);
        }

        public void Actualizar_subtotales()
        {

            for (var j = 0; j < Carrito.Count; j++)
            {

                Carrito[j].Subtotal = Carrito[j].Precio * Carrito[j].Cantidad;
            }

        }

        

        private void ListViewTotales_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {

            txt_cod_prueba.Clear();
            txt_cod_prueba.Text = Carrito[ListViewTotales.SelectedIndex].Codigo_barras;
            txt_cantidad.Text= Convert.ToString(Carrito[ListViewTotales.SelectedIndex].Cantidad);
            txt_cod_prueba.Focus();
        }

        private void Actualizar_cantidad_seleccionado(object sender, KeyEventArgs e)
        {
            if (txt_cod_prueba.Text == "CódigoBarras" || txt_cod_prueba.Text == "")
            {
                MessageBox.Show("El producto no se encuentra agregado");
                txt_cantidad.Text = "1";
                return;
            }

           

            if (ListViewTotales.SelectedIndex < 0)
            {
                MessageBox.Show("Por favor selecciona un articulo desde la lista de subtotales");
                txt_cantidad.Text = "1";
                return;
            }
            


            Carrito[ListViewTotales.SelectedIndex].Cantidad = Convert.ToInt32(txt_cantidad.Text);

            if(Carrito[ListViewTotales.SelectedIndex].Cantidad == 0)
            {
                Carrito.RemoveAt(ListViewTotales.SelectedIndex);
            }
            
            Actualizar_subtotales();
            Actualizar_total();
            Actualizar_Listas();
            txt_cod_prueba.Text = "";
            txt_cod_prueba.Focus();
        }

        private void Borrar_cantidad_txt(object sender, RoutedEventArgs e)
        {
            txt_cantidad.Text = "";
        }

        public void Cargar_Clientes()
        {
            Clientes clientes = new Clientes();

            List<Clientes> Lista_clientes = clientes.Consultar_nombres_cliente();

            for (var j = 0; j < Lista_clientes.Count; j++)
            {

                Cbox_clientes.Items.Add(Lista_clientes[j].Nombre);
            }


        }

        private void btn_finalizar_venta_Click(object sender, RoutedEventArgs e)
        {
            if (Carrito.Count < 1)
            {
                MessageBox.Show("Por favor agrega productos al carrito");
            }
            else
            {
                Venta ventas = new Venta();

                if(ventas.Agregar_venta(Carrito, total, Cbox_clientes.SelectedValue.ToString()))
                {
                    MessageBox.Show("Venta agregada correctamente");
                }
                else
                {
                    MessageBox.Show("Error al agregar la venta");
                }
            }
        }

        private void cbox_opciones_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            Venta ventas = new Venta();

            switch (cbox_opciones.SelectedIndex)
            {
                case 0:
                    //btn_finalizar_venta.Content = "Finalizar Venta";
                    break;

                case 1:
                    //btn_finalizar_venta.Content = "Consultar Venta";
                    
                   if(txt_cod_prueba.Text!="")
                    {
                        Carrito.Clear();
                        Actualizar_Listas();
                        cbox_opciones.SelectedIndex = 0;
                        Carrito = ventas.Consultar_venta(Convert.ToInt32(txt_cod_prueba.Text));

                        if (Carrito.Any())
                        {
                            for (var i = 0; i < Carrito.Count; i++)
                            {
                                for (var j = 0; j < Lista_Productos.Count; j++)
                                {

                                    if (Carrito[i].ID_Producto == Lista_Productos[j].ID_Producto)
                                    {
                                        Carrito[i].Descripcion = Lista_Productos[j].Descripcion;
                                        Carrito[i].Precio = Lista_Productos[j].Precio;
                                        Carrito[i].Nombre = Lista_Productos[j].Nombre;
                                        Carrito[i].Imagen = Lista_Productos[j].Imagen;
                                    }
                                }

                            }
                            Actualizar_Listas();
                            txt_cod_prueba.Focus();
                        }
                        else
                        {
                            System.Windows.MessageBox.Show("No hay datos para la venta indicada");
                        }
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("Ingrese el ID de alguna venta para consultar");
                    }
                    cbox_opciones.SelectedIndex = 0;

                    break;

                case 2:

                    if (txt_cod_prueba.Text != "")
                    {
                        if (ventas.Eliminar_venta(Convert.ToInt32(txt_cod_prueba.Text)))
                        {
                            MessageBox.Show("Venta eliminada correctamente");
                        }
                        else
                        {
                            MessageBox.Show("Error al eliminar la venta");
                        }
                        //btn_finalizar_venta.Content = "Eliminar Venta";
                    }
                    cbox_opciones.SelectedIndex=0;
                    break;

            }
        }

        private void Accion_lector(object sender, KeyEventArgs e)
        {

            switch(cbox_opciones.SelectedIndex)
            {
                case 0:
                    if (e.Key == Key.Enter)
                    {
                        Añadir_al_carrito_lector();
                    }else if (e.Key == Key.Escape)
                    {
                        Eliminar_del_carrito_lector();
                    }
                    break;
                case 1:
                    break;
                case 2:
                    
                    break;
                default:
                    break;
            }

            
            
        }
    }
}
