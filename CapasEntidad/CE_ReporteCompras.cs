using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapasEntidad
{
    public class CE_ReporteCompras
    {
        public string Fecha { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string Total { get; set; }
        public string UsuarioRegistro { get; set; }
        public string DocumentoProveedor { get; set; }
        public string RazonSocial { get; set; }
        public string Codigo_Barras { get; set; }
        public string Descripcion { get; set; }
        public string Concentracion { get; set; }
        public string Stock { get; set; }
        public string Costo { get; set; }
        public string Cantidad { get; set; }
        public string Importe { get; set; }
    }
}
