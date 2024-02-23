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
    public class CN_Reporte
    {
        private CD_Reporte cdReporte = new CD_Reporte();

        public List<CE_ReporteCompras> ObtenerReporteCompras(string fechaInicio, string fechaFin, int idProveedor)
        {
            return cdReporte.ObtenerReporteCompras(fechaInicio, fechaFin, idProveedor);
        }

        public List<CE_ReporteVentas> Venta(string fechainicio, string fechafin)
        {
            return cdReporte.Venta(fechainicio, fechafin);
        }

    }
}
