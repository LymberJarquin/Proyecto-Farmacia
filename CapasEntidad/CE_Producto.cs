using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapasEntidad
{
    public class CE_Producto
    {
        public string CodigoProducto { get; set; }


        public int idProducto { get; set; }
        public string Codigo_Barras { get; set; }
        public string Descripcion { get; set; }
        public string Concentracion { get; set; }
        public decimal Stock { get; set; }
        public decimal Costo { get; set; }
        public decimal Precio_Venta { get; set; }
        public string RegistroSanitario { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public string Estado { get; set; }
        public int idPresentacion { get; set; }
        public int idLaboratorio { get; set; }
    }
}
