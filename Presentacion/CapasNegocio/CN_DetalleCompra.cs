using CapasDatos;
using CapasEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapasNegocio
{
    public class CN_DetalleCompra
    {
        CD_DetalleCompra _DetalleCompra1 = new CD_DetalleCompra();

        public DataTable CNObtenerDetalleCompras()
        {
            return _DetalleCompra1.CDObtenerDetalleCompra();
        }

        public void CNAgregarDetalleCompra(int idCompra, int idProducto, int Cantidad, decimal Costo, decimal Importe)
        {
            CE_DetalleCompra _DetalleCompra = new CE_DetalleCompra();
            _DetalleCompra.idCompra = idCompra;
            _DetalleCompra.idProducto = idProducto;
            _DetalleCompra.Cantidad = Cantidad;
            _DetalleCompra.Costo = Costo;
            _DetalleCompra.Importe = Importe;

           _DetalleCompra1.CD_AgregarDetalleCompra(_DetalleCompra);

        }

        public void CNActualizarDetalleCompra(int idDetalleCompra,int idCompra, int idProducto, int Cantidad, decimal Costo, decimal Importe)
        {
            CE_DetalleCompra _DetalleCompra = new CE_DetalleCompra();
            _DetalleCompra.idDetalleCompra = idDetalleCompra;
            _DetalleCompra.idCompra = idCompra;
            _DetalleCompra.idProducto = idProducto;
            _DetalleCompra.Cantidad = Cantidad;
            _DetalleCompra.Costo = Costo;
            _DetalleCompra.Importe = Importe;

            _DetalleCompra1.CDModificarDetalleCompra(_DetalleCompra);
        }

        public void CNEliminarCompra(string CodigoDetalleCompra)
        {
            CE_DetalleCompra _DetalleCompra = new CE_DetalleCompra();
            _DetalleCompra.CodigoDetalleCompra = CodigoDetalleCompra;

            _DetalleCompra1.CDEliminarDetalleCompra(_DetalleCompra);
        }


    }
}
