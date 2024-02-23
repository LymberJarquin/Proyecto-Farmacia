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
    public class CN_DetalleVenta
    {
        CD_DetalleVenta _DetalleVenta1 = new CD_DetalleVenta();

        public DataTable CNObtenerDetalleVenta()
        {
            return _DetalleVenta1.CDObtenerDetalleVenta();
        }

        public void CNAgregarDetalleVenta(int idventa, int idProducto, int Cantidad, decimal Costo, decimal Precio, decimal Importe)
        {
            CE_DetalleVenta _DetalleVenta = new CE_DetalleVenta();
            _DetalleVenta.IdVenta = idventa;
            _DetalleVenta.idProducto = idProducto;
            _DetalleVenta.Cantidad = Cantidad;
            _DetalleVenta.Costo = Costo;
            _DetalleVenta.Precio = Precio;
            _DetalleVenta.Importe = Importe;

            _DetalleVenta1.CD_AgregarDetalleVenta(_DetalleVenta);

        }

        public void CNActualizarDetalleVenta(int IdVenta, int idProducto, int Cantidad, decimal Costo, decimal Precio, decimal Importe)
        {
            CE_DetalleVenta _DetalleVenta = new CE_DetalleVenta();
            _DetalleVenta.IdVenta = IdVenta;
            _DetalleVenta.idProducto = idProducto;
            _DetalleVenta.Cantidad = Cantidad;
            _DetalleVenta.Costo = Costo;
            _DetalleVenta.Precio = Precio;
            _DetalleVenta.Importe = Importe;

            _DetalleVenta1.CDModificarDetalleVenta(_DetalleVenta);
        }

        public void CNEliminarDetalleVenta(string CodigoDetalleVenta)
        {
            CE_DetalleVenta _DetalleVenta = new CE_DetalleVenta();
            _DetalleVenta.CodigoDetalleVenta = CodigoDetalleVenta;

            _DetalleVenta1.CDEliminarDetalleVenta(_DetalleVenta);
        }
    }
}
