using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapasEntidad
{
    public class CE_ReporteVentas
    {
        public string Fecha { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string Total { get; set; }
        public string UsuarioRegistro { get; set; }
        public string DocumentoCliente { get; set; }
        public string NombreCliente { get; set; }
        public string Codigo_Barras { get; set; }
        public string Descripcion { get; set; }
        public string Concentracion { get; set; }
        public string Precio { get; set; }
        public string Cantidad { get; set; }
        public string Importe { get; set; }
    }
}
