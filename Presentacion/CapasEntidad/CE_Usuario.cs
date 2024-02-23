using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapasEntidad
{
    public  class CE_Usuario
    {
        public  string CodigoUsuario { get; set; }

        public  string idUsuario { get; set; }
        public  string Nombres { get; set; }
        public  string Apellidos { get; set; }
        public  string Dni { get; set; }
        public  string Email { get; set; }
        public  string Usuario { get; set; }
        public  string Contraseña { get; set; }
        public  string TipoUsuario { get; set; }
        public  string Estado { get; set; }
    }

    public static class CE_Usuario1
    {
        public static string CodigoUsuario { get; set; }

        public static int idUsuario { get; set; }
        public static string Nombres { get; set; }
        public static string Apellidos { get; set; }
        public static int Dni { get; set; }
        public static string Email { get; set; }
        public static string Usuario { get; set; }
        public static string Contraseña { get; set; }
        public static string TipoUsuario { get; set; }
        public static string Estado { get; set; }
    }
}
