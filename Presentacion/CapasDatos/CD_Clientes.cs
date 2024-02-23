using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapasEntidad;
using System.Net;

namespace CapasDatos
{
    public class CD_Clientes
    {
        SqlConnection cn = new SqlConnection("Data Source=DESKTOP-3CPHA0J\\JEMMINSON;Initial Catalog=FARMACIA;Integrated Security=True");
        public void CD_AgregarClientes(CE_Clientes _Clientes)
        {
            cn.Open();
            SqlCommand command = new SqlCommand("USP_Cliente_insert", cn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Nombres", _Clientes.Nombres);
            command.Parameters.AddWithValue("@Apellidos", _Clientes.Apellidos);
            command.Parameters.AddWithValue("@Sexo", _Clientes.Sexo);
            command.Parameters.AddWithValue("@Dni", _Clientes.Dni);
            command.Parameters.AddWithValue("@Telefono", _Clientes.Telefono);
            command.Parameters.AddWithValue("@Ruc", _Clientes.Ruc);
            command.Parameters.AddWithValue("@Email", _Clientes.Email);
            command.Parameters.AddWithValue("@Direccion", _Clientes.Direccion);
            command.ExecuteNonQuery();
            command.Parameters.Clear();
            cn.Close();

        }

        public void CDEliminarClientes(CE_Clientes _Clientes)
        {
            cn.Open();

            SqlCommand command = new SqlCommand("USP_Cliente_Delete", cn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@idCliente", _Clientes.CodigoCliente);
            command.ExecuteNonQuery();
            command.Parameters.Clear();
            cn.Close();

        }

        public void CDModificarClientes(CE_Clientes _Clientes)
        {
            cn.Open();
            SqlCommand command = new SqlCommand("USP_Cliente_Update", cn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@idCliente", _Clientes.idCliente);
            command.Parameters.AddWithValue("@Nombres", _Clientes.Nombres);
            command.Parameters.AddWithValue("@Apellidos", _Clientes.Apellidos);
            command.Parameters.AddWithValue("@Sexo", _Clientes.Sexo);
            command.Parameters.AddWithValue("@Dni", _Clientes.Dni);
            command.Parameters.AddWithValue("@Telefono", _Clientes.Telefono);
            command.Parameters.AddWithValue("@Ruc", _Clientes.Ruc);
            command.Parameters.AddWithValue("@Email", _Clientes.Email);
            command.Parameters.AddWithValue("@Direccion", _Clientes.Direccion);
            command.ExecuteNonQuery();
            command.Parameters.Clear();
            cn.Close();

        }

        public DataTable CDObtenerClientes()
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("USP_Cliente_obtener", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cn.Close();
            return dt;
        }


        public DataTable CDObtenerConsultasClientes()
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("USP_ConsultaClientes_obtener", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cn.Close();
            return dt;
        }

        public DataTable CDObtenerBuscarClientes()
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("USP_buscarcliente_obtener", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cn.Close();
            return dt;
        }

        public DataTable CDbuscar(string busqueda)
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("USP_Cliente_Buscar", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Busqueda", busqueda);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            ad.Fill(ds);
            cn.Close();
            return ds;
        }

        public DataTable CDbuscar1(string busqueda)
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("USP_buscarcliente1", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Busqueda", busqueda);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            ad.Fill(ds);
            cn.Close();
            return ds;
        }

        public DataTable GetAllClientes()
        {
            DataTable dataTable = new DataTable();
            
            cn.Open();

                string query = "SELECT idCliente as Codigo,Nombres,Apellidos,Sexo,Dni as DNI,Telefono,Ruc,Email,Direccion FROM cliente";

                using (SqlCommand command = new SqlCommand(query, cn))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            cn.Close();

            return dataTable;
        }

        public DataTable BuscarClientesPorGenero(string genero)
        {
            DataTable tablaClientes = new DataTable();

            // Lógica para consultar la base de datos y llenar la tabla con los resultados
            cn.Open();

            string query = string.Format("select idCliente as Codigo,Nombres,Apellidos,Sexo,Dni as DNI,Telefono,Ruc,Email,Direccion from cliente  where  Sexo like '%{0}%';",genero);

            using (SqlCommand command = new SqlCommand(query, cn))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(tablaClientes);
                }
            }
            cn.Close();

            return tablaClientes;
        }

        public DataTable BuscarClientesPorDNI(string dni)
        {
            DataTable tablaClientes = new DataTable();

            // Lógica para consultar la base de datos y llenar la tabla con los resultados
            cn.Open();

            string query = string.Format("select idCliente as Codigo,Nombres,Apellidos,Sexo,Dni as DNI,Telefono,Ruc,Email,Direccion from cliente  where  Dni like '%{0}%';", dni);

            using (SqlCommand command = new SqlCommand(query, cn))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(tablaClientes);
                }
            }
            cn.Close();

            return tablaClientes;
        }

        public DataTable BuscarClientesPorRUC(string ruc)
        {
            DataTable tablaClientes = new DataTable();

            // Lógica para consultar la base de datos y llenar la tabla con los resultados
            cn.Open();

            string query = string.Format("select idCliente as Codigo,Nombres,Apellidos,Sexo,Dni as DNI,Telefono,Ruc,Email,Direccion from cliente  where  Ruc like '%{0}%';", ruc);

            using (SqlCommand command = new SqlCommand(query, cn))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(tablaClientes);
                }
            }
            cn.Close();

            return tablaClientes;
        }

        public DataTable MostrarClientes(string buscar)
        {
            DataTable tabla = new DataTable();

            cn.Open();

            string query = "    SELECT idCliente as Codigo,Nombres,Apellidos,Sexo,Dni,Telefono,Ruc,Email,Direccion FROM cliente " +
                           "WHERE Dni LIKE '%" + buscar + "%' OR Ruc LIKE '%" + buscar + "%';";
            using (SqlCommand command = new SqlCommand(query, cn))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(tabla);
            }
            cn.Close();

            return tabla;
        }
    }
}
