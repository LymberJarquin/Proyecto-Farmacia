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
    public class CN_Compra
    {
        CD_Compra compra_1 = new CD_Compra();

        public DataTable CNObtenerCompras()
        {
            return compra_1.CDObtenerCompra();
        }

        public DataTable CNObtenerConsultaCompras()
        {
            return compra_1.CDObtenerConsultasCompra();
        }

        public void CNAgregarCompra(string Numero,DateTime Fecha, string TipoPago, decimal SubTotal,decimal Total, decimal Igv,string Estado, int idProveedor, int idEmpleado, int idTipoComprobante)
        {
            CE_Compra compra = new CE_Compra();
            compra.Numero = Numero;
            compra.Fecha = Fecha;
            compra.TipoPago = TipoPago;
            compra.SubTotal = SubTotal;
            compra.Total = Total;
            compra.Igv = Igv;
            compra.Estado = Estado;
            compra.idProveedor = idProveedor;
            compra.idEmpleado = idEmpleado;
            compra.idTipoComprobante = idTipoComprobante;

            compra_1.CD_AgregarCompra(compra);

        }

        public void CNActualizarCompra(int idCompra, string Numero, DateTime Fecha, string TipoPago, decimal SubTotal, decimal Total, decimal Igv, string Estado, int idProveedor, int idEmpleado, int idTipoComprobante)
        {
            CE_Compra compra = new CE_Compra();
            compra.idCompra = idCompra;
            compra.Numero = Numero;
            compra.Fecha = Fecha;
            compra.TipoPago = TipoPago;
            compra.SubTotal = SubTotal;
            compra.Total = Total;
            compra.Igv = Igv;
            compra.Estado = Estado;
            compra.idProveedor = idProveedor;
            compra.idEmpleado = idEmpleado;
            compra.idTipoComprobante = idTipoComprobante;

            compra_1.CDModificarCompra(compra);
        }

        public void CNEliminarCompra(string CodigoCompra)
        {
            CE_Compra compra = new CE_Compra();
            compra.CodigoCompra = CodigoCompra;

            compra_1.CDEliminarCompra(compra);
        }

        public DataTable CN_ObtenerDatosPorRangoFecha(DateTime inicio, DateTime final)
        {
            return compra_1.CD_ObtenerDatosPorRangoFecha(inicio,final);
        }

        public void ActualizarCompraEstado(string codigo, string estado)
        {
            try
            {
                compra_1.ActualizarCompraEstado(codigo, estado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable BuscarCompraDetalle(string idCompra)
        {
            DataTable dt = new DataTable();

            try
            {
                dt = compra_1.ListarDetalleCompraPorParametro("id", idCompra);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar detalle de compra: " + ex.Message);
            }

            return dt;
        }

        public SqlDataReader CNObtenerUltimoIdCompra()
        {
            try
            {
                return compra_1.ObtenerUltimoIdCompra();
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
                return compra_1.ObtenerUltimoIdEmpleado();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
