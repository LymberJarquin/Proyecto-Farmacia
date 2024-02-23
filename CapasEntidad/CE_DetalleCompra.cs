using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapasEntidad
{
    public class CE_DetalleCompra
    {
        public string CodigoDetalleCompra { get; set; }


        public int idDetalleCompra { get; set; }
        public int idCompra { get; set; }
        public int idProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal Costo { get; set; }
        public decimal Importe { get; set; }
       
    }
}
