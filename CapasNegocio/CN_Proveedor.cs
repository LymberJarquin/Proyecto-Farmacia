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
    public class CN_Proveedor
    {
        CD_Proveedor _Proveedor1 = new CD_Proveedor();

        public List<CE_Proveedor> Listar()
        {
            return _Proveedor1.Listar();
        }

        public DataTable CNObtenerProveedor()
        {
            return _Proveedor1.CDObtenerProveedor();
        }

        public DataTable CNObtenerConsultaProveedores()
        {
            return _Proveedor1.CDObtenerConsultaProveedores();
        }

        public DataTable CNObtenerBuscarProveedor()
        {
            return _Proveedor1.CDObtenerBuscarProveedor();
        }

        public DataTable ObtenerListaProveedor()
        {
            return _Proveedor1.GetAllProveedores();
        }

        public void CNAgregarProveedor(string Nombre, string Dni, string Ruc, string Direccion, string Email, string Telefono, string Banco, string Cuenta, string Estado)
        {
            CE_Proveedor _Proveedor = new CE_Proveedor();
            _Proveedor.Nombre = Nombre;
            _Proveedor.Dni = Dni;
            _Proveedor.Ruc = Ruc;
            _Proveedor.Direccion = Direccion;
            _Proveedor.Email = Email;
            _Proveedor.Telefono = Telefono;
            _Proveedor.Banco = Banco;
            _Proveedor.Cuenta = Cuenta;
            _Proveedor.Estado = Estado;
            

            _Proveedor1.CD_AgregarProveedor(_Proveedor);

        }

        public void CNActualizarProveedor(int idProveedor, string Nombre, string Dni, string Ruc, string Direccion, string Email, string Telefono, string Banco, string Cuenta, string Estado)
        {
            CE_Proveedor _Proveedor = new CE_Proveedor();
            _Proveedor.idProveedor = idProveedor;
            _Proveedor.Nombre = Nombre;
            _Proveedor.Dni = Dni;
            _Proveedor.Ruc = Ruc;
            _Proveedor.Direccion = Direccion;
            _Proveedor.Email = Email;
            _Proveedor.Telefono = Telefono;
            _Proveedor.Banco = Banco;
            _Proveedor.Cuenta = Cuenta;
            _Proveedor.Estado = Estado;


            _Proveedor1.CDModificarProveedor(_Proveedor);
        }

        public void CNEliminarProveedor(string CodigoProveedor)
        {
            CE_Proveedor _Proveedor = new CE_Proveedor();
            _Proveedor.CodigoProveedor = CodigoProveedor;

            _Proveedor1.CDEliminarProveedor(_Proveedor);
        }

        public DataTable CNBuscar(string busqueda)
        {
            return _Proveedor1.CD_buscar(busqueda);
        }

        public DataTable CNBuscar1(string busqueda)
        {
            return _Proveedor1.CD_buscar1(busqueda);
        }

        public DataTable BuscarProveedor(string tipoBusqueda, string parametro)
        {
            switch (tipoBusqueda)
            {
                case "NOMBRES":
                    return _Proveedor1.BuscarClientesPorNombres(parametro);

                case "DNI":
                    return _Proveedor1.BuscarClientesPorDNI(parametro);

                case "RUC":
                    return _Proveedor1.BuscarClientesPorRUC(parametro);

                default:
                    // Manejar un caso no esperado
                    return new DataTable();
            }
        }

        public DataTable MostrarTodosProveedores(string buscar)
        {
            return _Proveedor1.MostrarProveedores(buscar);
        }
    }
}
