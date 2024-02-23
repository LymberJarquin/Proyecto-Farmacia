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
    public class CN_Laboratorio
    {
        CD_Laboratorio _Laboratorio1 = new CD_Laboratorio();

        public DataTable CNObtenerLaboratorio()
        {
            return _Laboratorio1.CDObtenerLaboratorio();
        }

        public void CNAgregarLaboratorio(string Nombre, string Direccion, int Telefono, string Estado)
        {
            CE_Laboratorio _Laboratorio = new CE_Laboratorio();
            _Laboratorio.Nombre = Nombre;
            _Laboratorio.Direccion = Direccion;
            _Laboratorio.Telefono = Telefono;
            _Laboratorio.Estado = Estado;

            _Laboratorio1.CD_AgregarLaboratorio(_Laboratorio);

        }

        public void CNActualizarLaboratorio(int idLaboratorio, string Nombre, string Direccion, int Telefono, string Estado)
        {
            CE_Laboratorio _Laboratorio = new CE_Laboratorio();
            _Laboratorio.idLaboratorio = idLaboratorio;
            _Laboratorio.Nombre = Nombre;
            _Laboratorio.Direccion = Direccion;
            _Laboratorio.Telefono = Telefono;
            _Laboratorio.Estado = Estado;

            _Laboratorio1.CDModificarLaboratorio(_Laboratorio);
        }

        public void CNEliminarLaboratorio(string CodigoLaboratorio)
        {
            CE_Laboratorio _Laboratorio = new CE_Laboratorio();
            _Laboratorio.CodigoLaboratorio = CodigoLaboratorio;

            _Laboratorio1.CDEliminarLaboratorio(_Laboratorio);
        }
    }
}
