using CapasDatos;
using CapasEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapasNegocio
{
    public class CN_Ventas
    {
        CD_Ventas _Ventas1 = new CD_Ventas();

        public DataTable CNObtenerVentas()
        {
            return _Ventas1.CDObtenerVenta();
        }

        public DataTable CNObtenerConsultaVentas()
        {
            return _Ventas1.CDObtenerConsultaVenta();
        }

        public void CNAgregarVentas(string Serie, string Numero, DateTime Fecha, decimal VentaTotal, decimal Descuento, decimal SubTotal, decimal Igv, decimal Total, string Estado, int idCliente, int idEmpleado, int idTipoComprobante)
        {
            CE_Venta _Venta = new CE_Venta();
            _Venta.Serie = Serie;
            _Venta.Numero = Numero;
            _Venta.Fecha = Fecha;
            _Venta.VentaTotal = VentaTotal;
            _Venta.Descuento = Descuento;
            _Venta.SubTotal = SubTotal;
            _Venta.Igv = Igv;
            _Venta.Total = Total;
            _Venta.Estado = Estado;
            _Venta.idCliente = idCliente;
            _Venta.idEmpleado = idEmpleado;
            _Venta.idTipoComprobante = idTipoComprobante;
            
            _Ventas1.CD_AgregarVenta(_Venta);

        }

        public void CNActualizarVentas(int idVentas, string Serie, string Numero, DateTime Fecha, decimal VentaTotal, decimal Descuento, decimal SubTotal, decimal Igv, decimal Total, string Estado, int idCliente, int idEmpleado, int idTipoComprobante)
        {
            CE_Venta _Venta = new CE_Venta();
            _Venta.IdVenta = idVentas;
            _Venta.Serie = Serie;
            _Venta.Numero = Numero;
            _Venta.Fecha = Fecha;
            _Venta.VentaTotal = VentaTotal;
            _Venta.Descuento = Descuento;
            _Venta.SubTotal = SubTotal;
            _Venta.Igv = Igv;
            _Venta.Total = Total;
            _Venta.Estado = Estado;
            _Venta.idCliente = idCliente;
            _Venta.idEmpleado = idEmpleado;
            _Venta.idTipoComprobante = idTipoComprobante;

            _Ventas1.CD_AgregarVenta(_Venta);
        }

        public void CNEliminarVentas(string CodigoVentas)
        {
            CE_Venta _Venta = new CE_Venta();
            _Venta.CodigoVenta = CodigoVentas;

            _Ventas1.CDEliminarVenta(_Venta);
        }


        public DataTable ObtenerVentasPorFecha( DateTime fechaFin)
        {

                return _Ventas1.ListarVentaPorFecha( fechaFin);
        }


        public DataTable CN_ObtenerDatosPorRangoFecha2(DateTime inicio, DateTime final)
        {
            return _Ventas1.CD_ObtenerVentasPorFecha(inicio, final);
        }


        public DataTable ObtenerListarDetalleVentaPorParametro(DateTime fechaIni, DateTime fechafin)
        {

            return _Ventas1.ListarDetalleVentaPorParametro(fechaIni,fechafin);
        }

        public void ActualizarVentaEstado(string codigo, string estado)
        {
            try
            {
                _Ventas1.ActualizarVentasEstado(codigo, estado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SqlDataReader CNObtenerUltimoIdVenta()
        {
            try
            {
                return _Ventas1.ObtenerUltimoIdVenta();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public long CNObtenerUltimoIdEmpleado()
        {
            try
            {
                return _Ventas1.ObtenerUltimoIdEmpleado();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
