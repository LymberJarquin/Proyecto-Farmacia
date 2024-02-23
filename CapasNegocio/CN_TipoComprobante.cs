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
    public class CN_TipoComprobante
    {
        CD_TipoComprobante _TipoComprobante1 = new CD_TipoComprobante();

        public DataTable CNObtenerTipoComprobante()
        {
            return _TipoComprobante1.CDObtenerTipoComprobante();
        }

        public DataTable CNObtenerBuscarComprobante()
        {
            return _TipoComprobante1.CDObtenerBuscarComprobante();
        }

        public DataTable CNObtenerBuscarComprobanteComprar()
        {
            return _TipoComprobante1.CDObtenerBuscarComprobanteComprar();
        }

        public void CNAgregarTipoComprobante(string Descripcion, string Estado)
        {
            CE_TipoComprobante _TipoComprobante = new CE_TipoComprobante();
            _TipoComprobante.Descripcion = Descripcion;
            _TipoComprobante.Estado = Estado;
           

            _TipoComprobante1.CD_AgregarTipoComprobante(_TipoComprobante);

        }

        public void CNActualizarTipoComprobante(int idTipoComprobante, string Descripcion, string Estado)
        {
            CE_TipoComprobante _TipoComprobante = new CE_TipoComprobante();
            _TipoComprobante.idTipoComprobante = idTipoComprobante;
            _TipoComprobante.Descripcion = Descripcion;
            _TipoComprobante.Estado = Estado;
           
            _TipoComprobante1.CDModificarTipoComprobante(_TipoComprobante);
        }

        public void CNEliminarTipoComprobante(string CodigoTipoComprobante)
        {
            CE_TipoComprobante _TipoComprobante = new CE_TipoComprobante();
            _TipoComprobante.CodigoTipoComprobante = CodigoTipoComprobante;

            _TipoComprobante1.CDEliminarTipoComprobante(_TipoComprobante);
        }
    }
}
