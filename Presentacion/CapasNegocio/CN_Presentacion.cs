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
    public class CN_Presentacion
    {
        CD_Presentacion _Presentacion1 = new CD_Presentacion();

        public DataTable CNObtenerPresentacion()
        {
            return _Presentacion1.CDObtenerPresentacion();
        }

        public void CNAgregarPresentacion(string Descripcion, string Estado)
        {
            CE_Presentacion _Presentacion = new CE_Presentacion();
            _Presentacion.Descripcion = Descripcion;
            _Presentacion.Estado = Estado;
            

            _Presentacion1.CD_AgregarPresentacion(_Presentacion);

        }

        public void CNActualizarPresentacion(int idPresentacion, string Descripcion, string Estado)
        {
            CE_Presentacion _Presentacion = new CE_Presentacion();
            _Presentacion.idPresentacion = idPresentacion;
            _Presentacion.Descripcion = Descripcion;
            _Presentacion.Estado = Estado;


            _Presentacion1.CDModificarPresentacion(_Presentacion);
        }

        public void CNEliminarPresentacion(string CodigoPresentacion)
        {
            CE_Presentacion _Presentacion = new CE_Presentacion();
            _Presentacion.CodigoPresentacion = CodigoPresentacion;

            _Presentacion1.CDEliminarPresentacion(_Presentacion);
        }
    }
}
