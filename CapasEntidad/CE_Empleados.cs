using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapasEntidad
{
    public class CE_Empleados
    {
        public string CodigoEmpleado { get; set; }


        public int idEmpleado { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Especialidad { get; set; }
        public string Sexo { get; set; }
        public string Dni { get; set; }
        public string Email { get; set; }
        public int Telefono { get; set; }     
        public string Direccion { get; set; }
        public string HoraIngreso { get; set; }
        public string HoraSalida { get; set; }
        public decimal Sueldo { get; set; }
        public string Estado { get; set; }
        public int idUsuario { get; set; }
    }
}
