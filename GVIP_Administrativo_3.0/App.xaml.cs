using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace GVIP_Administrativo_3._0
{

    /// <summary>
    /// Lógica de interacción para App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static string usuario_global = "", nombre_global = "", tipousuario_global = "";

        public static string cadena_conexion = "server=localhost;port=3306;user id=root;password=24865Cs;database=gvip_db;";
        public static string Imagen_defecto = "C:/Dios.jpg";

        public static string Principal1 = "#1a2849";
        public static string Secundario1 = "#4a5998";
        public static string Letras1 = "#FFFFFF";
        public static string Iconos1 = "#FFFFFF";
        




    }
}
