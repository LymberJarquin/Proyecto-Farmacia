using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CapasDatos;
using CapasEntidad;

namespace CapasNegocio
{
    public class CN_Cliente
    {
        CD_Clientes clientes_1 = new CD_Clientes();

        public DataTable CNObtenerClientess()
        {
            return clientes_1.CDObtenerClientes();
        }

        public DataTable CNObtenerConsultasClientes()
        {
            return clientes_1.CDObtenerConsultasClientes();
        }

        public DataTable CNObtenerBuscarClientes()
        {
            return clientes_1.CDObtenerBuscarClientes();
        }

        public DataTable ObtenerListaClientes()
        {
            return clientes_1.GetAllClientes();
        }

        public void CNAgregarClientes1(string Nombres, string Apellidos, string Sexo, string Dni, string Telefono, string Ruc, string Email, string Direccion)
        {
            CE_Clientes clientes = new CE_Clientes();
            clientes.Nombres = Nombres;
            clientes.Apellidos = Apellidos;
            clientes.Sexo = Sexo;
            clientes.Dni = Dni;
            clientes.Telefono = Telefono;
            clientes.Ruc = Ruc;
            clientes.Email = Email;
            clientes.Direccion = Direccion;

            clientes_1.CD_AgregarClientes(clientes);

        }

        public void CNActualizarClientes(int idCliente, string Nombres, string Apellidos, string Sexo, string Dni, string Telefono, string Ruc, string Email, string Direccion)
        {
            CE_Clientes clientes = new CE_Clientes();
            clientes.idCliente = idCliente;
            clientes.Nombres = Nombres;
            clientes.Apellidos = Apellidos;
            clientes.Sexo = Sexo;
            clientes.Dni = Dni;
            clientes.Telefono = Telefono;
            clientes.Ruc = Ruc;
            clientes.Email = Email;
            clientes.Direccion = Direccion;

            clientes_1.CDModificarClientes(clientes);
        }

        public void CNEliminarClientess(string idCliente)
        {
            CE_Clientes clientes = new CE_Clientes();
            clientes.CodigoCliente = idCliente;

            clientes_1.CDEliminarClientes(clientes);
        }

        public DataTable CN_Buscar(string busqueda)
        {
            return clientes_1.CDbuscar(busqueda);
        }

        public DataTable CN_Buscar1(string busqueda)
        {
            return clientes_1.CDbuscar1(busqueda);
        }

        public DataTable BuscarClientes(string tipoBusqueda, string parametro)
        {
            switch (tipoBusqueda)
            {
                case "Genero":
                    return clientes_1.BuscarClientesPorGenero(parametro);

                case "DNI":
                    return clientes_1.BuscarClientesPorDNI(parametro);

                case "RUC":
                    return clientes_1.BuscarClientesPorRUC(parametro);

                default:
                    // Manejar un caso no esperado
                    return new DataTable();
            }
        }

        public DataTable MostrarTodosClientes(string buscar)
        {
            return clientes_1.MostrarClientes(buscar);
        }
    }
}
