using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapasEntidad
{
    public class CE_DetalleVenta
    {
        public string CodigoDetalleVenta { get; set; }


        public int idDetalleVenta { get; set; }
        public int IdVenta { get; set; }
        public int idProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal Costo { get; set; }
        public decimal Precio { get; set; }
        public decimal Importe { get; set; }
    }
}
