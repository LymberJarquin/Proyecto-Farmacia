using CapasEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapasDatos
{
    public class CD_Proveedor
    {
        SqlConnection cn = new SqlConnection("Data Source=.;Initial Catalog=FARMACIA;Integrated Security=True");

        public List<CE_Proveedor> Listar()
        {
            List<CE_Proveedor> lista = new List<CE_Proveedor>();

            using (SqlConnection oconexion = new SqlConnection("Data Source=.;Initial Catalog=FARMACIA;Integrated Security=True"))
            {

                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select IdProveedor,Nombre,Dni,Ruc,Direccion,Email,Telefono,Banco,Cuenta,Estado from proveedor");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {

                            lista.Add(new CE_Proveedor()
                            {
                                idProveedor = Convert.ToInt32(dr["IdProveedor"]),
                                Nombre = dr["Nombre"].ToString(),
                                Dni = dr["Dni"].ToString(),
                                Ruc = dr["Ruc"].ToString(),
                                Direccion = dr["Direccion"].ToString(),
                                Email = dr["Email"].ToString(),
                                Telefono = dr["Telefono"].ToString(),
                                Banco = dr["Banco"].ToString(),
                                Cuenta = dr["Cuenta"].ToString(),
                                //Estado = Convert.ToBoolean(dr["Estado"])
                            });

                        }

                    }


                }
                catch (Exception ex)
                {

                    lista = new List<CE_Proveedor>();
                }
            }

            return lista;

        }


        public void CD_AgregarProveedor(CE_Proveedor _Proveedor)
        {
            cn.Open();
            SqlCommand command = new SqlCommand("USP_proveedor_insert", cn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Nombre", _Proveedor.Nombre);
            command.Parameters.AddWithValue("@Dni", _Proveedor.Dni);
            command.Parameters.AddWithValue("@Ruc", _Proveedor.Ruc);
            command.Parameters.AddWithValue("@Direccion", _Proveedor.Direccion);
            command.Parameters.AddWithValue("@Email", _Proveedor.Email);
            command.Parameters.AddWithValue("@Telefono", _Proveedor.Telefono);
            command.Parameters.AddWithValue("@Banco", _Proveedor.Banco);
            command.Parameters.AddWithValue("@Cuenta", _Proveedor.Cuenta);
            command.Parameters.AddWithValue("@Estado", _Proveedor.Estado);
            command.ExecuteNonQuery();
            command.Parameters.Clear();
            cn.Close();

        }

        public void CDEliminarProveedor(CE_Proveedor _Proveedor)
        {
            cn.Open();

            SqlCommand command = new SqlCommand("USP_proveedor_Delete", cn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@idProveedor", _Proveedor.CodigoProveedor);
            command.ExecuteNonQuery();
            command.Parameters.Clear();
            cn.Close();

        }

        public void CDModificarProveedor(CE_Proveedor _Proveedor)
        {
            cn.Open();
            SqlCommand command = new SqlCommand("USP_proveedor_Update", cn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@idProveedor", _Proveedor.idProveedor);
            command.Parameters.AddWithValue("@Nombre", _Proveedor.Nombre);
            command.Parameters.AddWithValue("@Dni", _Proveedor.Dni);
            command.Parameters.AddWithValue("@Ruc", _Proveedor.Ruc);
            command.Parameters.AddWithValue("@Direccion", _Proveedor.Direccion);
            command.Parameters.AddWithValue("@Email", _Proveedor.Email);
            command.Parameters.AddWithValue("@Telefono", _Proveedor.Telefono);
            command.Parameters.AddWithValue("@Banco", _Proveedor.Banco);
            command.Parameters.AddWithValue("@Cuenta", _Proveedor.Cuenta);
            command.Parameters.AddWithValue("@Estado", _Proveedor.Estado);
            command.ExecuteNonQuery();
            command.Parameters.Clear();
            cn.Close();

        }

        public DataTable CDObtenerProveedor()
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("USP_proveedor_obtener", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cn.Close();
            return dt;
        }

        public DataTable CDObtenerConsultaProveedores()
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("USP_ConsultaProveedores_obtener", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cn.Close();
            return dt;
        }

        public DataTable CDObtenerBuscarProveedor()
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("USP_buscarproveedor_obtener", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cn.Close();
            return dt;
        }


        public DataTable CD_buscar(string busqueda)
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("USP_proveedor_Buscar", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Busqueda", busqueda);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            ad.Fill(ds);
            cn.Close();
            return ds;
        }

        public DataTable CD_buscar1(string busqueda)
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("USP_buscarproveedor1", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Busqueda", busqueda);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            ad.Fill(ds);
            cn.Close();
            return ds;
        }

        public DataTable GetAllProveedores()
        {
            DataTable dataTable = new DataTable();

            cn.Open();

            string query = "SELECT IdProveedor as Codigo,Nombre as Nombres,Dni,Ruc,Direccion,Email,Telefono,Banco,Cuenta,Estado FROM proveedor";

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

        public DataTable BuscarClientesPorNombres(string nombres)
        {
            DataTable tablaClientes = new DataTable();

            // Lógica para consultar la base de datos y llenar la tabla con los resultados
            cn.Open();

            string query = string.Format("SELECT IdProveedor as Codigo,Nombre as Nombres,Dni,Ruc,Direccion,Email,Telefono,Banco,Cuenta,Estado FROM proveedor  where  Nombre like '%{0}%';", nombres);

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

            string query = string.Format("select IdProveedor as Codigo,Nombre as Nombres,Dni,Ruc,Direccion,Email,Telefono,Banco,Cuenta,Estado FROM proveedor  where  Dni like '%{0}%';", dni);

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

            string query = string.Format("select IdProveedor as Codigo,Nombre as Nombres,Dni,Ruc,Direccion,Email,Telefono,Banco,Cuenta,Estado FROM proveedor  where  Ruc like '%{0}%';", ruc);

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

        public DataTable MostrarProveedores(string buscar)
        {
            DataTable tabla = new DataTable();

            cn.Open();

            string query = "SELECT IdProveedor as Codigo, Nombre, Dni, Ruc, Direccion, Email, Telefono, Banco, Cuenta, Estado " +
                           "FROM proveedor " +
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
