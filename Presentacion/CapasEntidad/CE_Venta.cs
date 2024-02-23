using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapasEntidad
{
    public class CE_Venta
    {
        public string CodigoVenta { get; set; }

        public int IdVenta { get; set; }
        public string Serie { get; set; }
        public string Numero { get; set; }
        public DateTime Fecha { get; set; }
        public decimal VentaTotal { get; set; }
        public decimal Descuento { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Igv { get; set; }
        public decimal Total { get; set; }
        public string Estado { get; set; }
        public int idCliente { get; set; }
        public int idEmpleado { get; set; }
        public int idTipoComprobante { get; set; }
    }
}
