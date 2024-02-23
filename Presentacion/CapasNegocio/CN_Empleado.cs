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
    public class CN_Empleado
    {
        CD_Empleado _Empleado1 = new CD_Empleado();

        public DataTable CNObtenerEmpleado()
        {
            return _Empleado1.CDObtenerEmpleado();
        }

        public DataTable CNObtenerUsuario()
        {
            CD_Empleado categoriaDAO = new CD_Empleado();
            return categoriaDAO.CDObtenerUsuario();
        }

        public SqlDataReader CNObtenerCodEmpleado(int cod)
        {
            return _Empleado1.CDObtenerCodEmpleado(cod);
        }

        public DataTable CNObtenerBuscarEmpleado()
        {
            return _Empleado1.CDObtenerBuscarEmpleado();
        }

        public DataTable CNObtenerConsultaEmpleado()
        {
            return _Empleado1.CDObtenerConsultaEmpleado();
        }

        public DataTable ObtenerListaEmpleado()
        {
            return _Empleado1.GetAllEmpleado();
        }

        public void CNAgregarEmpleado(string Nombres, string Apellidos, string Especialidad, string Sexo, string Dni, string Email, int Telefono, string Direccion, string HoraIngreso, string HoraSalida, decimal Sueldo, string Estado, int idUsuario)
        {
            CE_Empleados _Empleados = new CE_Empleados();
            _Empleados.Nombres = Nombres;
            _Empleados.Apellidos = Apellidos;
            _Empleados.Especialidad = Especialidad;
            _Empleados.Sexo = Sexo;
            _Empleados.Dni = Dni;
            _Empleados.Email = Email;
            _Empleados.Telefono = Telefono;
            _Empleados.Direccion = Direccion;
            _Empleados.HoraIngreso = HoraIngreso;
            _Empleados.HoraSalida = HoraSalida;
            _Empleados.Sueldo = Sueldo;
            _Empleados.Estado = Estado;
            _Empleados.idUsuario = idUsuario;

            _Empleado1.CD_AgregarEmpleado(_Empleados);

        }

        public void CNActualizarEmpleado(int idEmpleado, string Nombres, string Apellidos, string Especialidad, string Sexo, string Dni, string Email, int Telefono, string Direccion, string HoraIngreso, string HoraSalida, decimal Sueldo, string Estado, int idUsuario)
        {
            CE_Empleados _Empleados = new CE_Empleados();
            _Empleados.idEmpleado = idEmpleado;
            _Empleados.Nombres = Nombres;
            _Empleados.Apellidos = Apellidos;
            _Empleados.Especialidad = Especialidad;
            _Empleados.Sexo = Sexo;
            _Empleados.Dni = Dni;
            _Empleados.Email = Email;
            _Empleados.Telefono = Telefono;
            _Empleados.Direccion = Direccion;
            _Empleados.HoraIngreso = HoraIngreso;
            _Empleados.HoraSalida = HoraSalida;
            _Empleados.Sueldo = Sueldo;
            _Empleados.Estado = Estado;
            _Empleados.idUsuario = idUsuario;

            _Empleado1.CDModificarEmpleado(_Empleados);
        }

        public void CNEliminarEmpleado(string CodigoEmpleado)
        {
            CE_Empleados _Empleados = new CE_Empleados();
            _Empleados.CodigoEmpleado = CodigoEmpleado;

            _Empleado1.CDEliminarEmpleado(_Empleados);
        }

        public DataTable CN_Buscar(string busqueda)
        {
            return _Empleado1.CD_buscar(busqueda);
        }

        public DataTable BuscarEmpleado(string tipoBusqueda, string parametro)
        {
            switch (tipoBusqueda)
            {
                case "Genero":
                    return _Empleado1.BuscarClientesPorGenero(parametro);

                case "DNI":
                    return _Empleado1.BuscarClientesPorDNI(parametro);

                case "ESPECIALIDAD":
                    return _Empleado1.BuscarClientesPorEspecialidad(parametro);

                default:
                    // Manejar un caso no esperado
                    return new DataTable();
            }
        }
    }
}
