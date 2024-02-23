using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapasEntidad
{
    public class CE_Compra
    {
        public string CodigoCompra { get; set; }


        public int idCompra { get; set; }
        public string Numero { get; set; }
        public DateTime Fecha { get; set; }
        public string TipoPago { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }
        public decimal Igv { get; set; }
        public string Estado { get; set; }
        public int idProveedor { get; set; }
        public int idEmpleado { get; set; }
        public int idTipoComprobante { get; set; }
    }
}
