using CapasEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace CapasDatos
{
    public class CD_Empleado
    {
        SqlConnection cn = new SqlConnection("Data Source=DESKTOP-3CPHA0J\\JEMMINSON;Initial Catalog=FARMACIA;Integrated Security=True");
      
        public void CD_AgregarEmpleado(CE_Empleados _Empleados)
        {
            cn.Open();
            SqlCommand command = new SqlCommand("USP_empleado_insert", cn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Nombres", _Empleados.Nombres);
            command.Parameters.AddWithValue("@Apellidos", _Empleados.Apellidos);
            command.Parameters.AddWithValue("@Especialidad", _Empleados.Especialidad);
            command.Parameters.AddWithValue("@Sexo", _Empleados.Sexo);
            command.Parameters.AddWithValue("@Dni", _Empleados.Dni);
            command.Parameters.AddWithValue("@Email", _Empleados.Email);
            command.Parameters.AddWithValue("@Telefono", _Empleados.Telefono);
            command.Parameters.AddWithValue("@Direccion", _Empleados.Direccion);
            command.Parameters.AddWithValue("@HoraIngreso", _Empleados.HoraIngreso);
            command.Parameters.AddWithValue("@HoraSalida", _Empleados.HoraSalida);
            command.Parameters.AddWithValue("@Sueldo", _Empleados.Sueldo);
            command.Parameters.AddWithValue("@Estado", _Empleados.Estado);
            command.Parameters.AddWithValue("@idUsuario", _Empleados.idUsuario);
            command.ExecuteNonQuery();
            command.Parameters.Clear();
            cn.Close();

        }

        public void CDEliminarEmpleado(CE_Empleados _Empleados)
        {
            cn.Open();

            SqlCommand command = new SqlCommand("USP_empleado_Delete", cn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@idEmpleado", _Empleados.CodigoEmpleado);
            command.ExecuteNonQuery();
            command.Parameters.Clear();
            cn.Close();

        }

        public void CDModificarEmpleado(CE_Empleados _Empleados)
        {
            cn.Open();
            SqlCommand command = new SqlCommand("USP_empleado_Update", cn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@idEmpleado", _Empleados.idEmpleado);
            command.Parameters.AddWithValue("@Nombres", _Empleados.Nombres);
            command.Parameters.AddWithValue("@Apellidos", _Empleados.Apellidos);
            command.Parameters.AddWithValue("@Especialidad", _Empleados.Especialidad);
            command.Parameters.AddWithValue("@Sexo", _Empleados.Sexo);
            command.Parameters.AddWithValue("@Dni", _Empleados.Dni);
            command.Parameters.AddWithValue("@Email", _Empleados.Email);
            command.Parameters.AddWithValue("@Telefono", _Empleados.Telefono);
            command.Parameters.AddWithValue("@Direccion", _Empleados.Direccion);
            command.Parameters.AddWithValue("@HoraIngreso", _Empleados.HoraIngreso);
            command.Parameters.AddWithValue("@HoraSalida", _Empleados.HoraSalida);
            command.Parameters.AddWithValue("@Sueldo", _Empleados.Sueldo);
            command.Parameters.AddWithValue("@Estado", _Empleados.Estado);
            command.Parameters.AddWithValue("@idUsuario", _Empleados.idUsuario);
            command.ExecuteNonQuery();
            command.Parameters.Clear();
            cn.Close();

        }

        public DataTable CDObtenerEmpleado()
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("USP_empleado_obtener", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cn.Close();
            return dt;
        }

        public DataTable CDObtenerUsuario()
        {
            DataTable tabla = new DataTable();
            cn.Open();
            SqlCommand cmd = new SqlCommand("listarUsuario", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader leerfilas = cmd.ExecuteReader();
            tabla.Load(leerfilas);
            leerfilas.Close();
            cn.Close();
            return tabla;

        }

        public DataTable CDObtenerBuscarEmpleado()
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("USP_buscarempleado_obtener", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cn.Close();
            return dt;
        }

        public SqlDataReader CDObtenerCodEmpleado(int coduser)
        {
            SqlDataReader reader = null;
            try
            {

                cn.Open();
                using (SqlCommand command = new SqlCommand("USP_CodEmpleado", cn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@coduser", coduser);
                    reader = command.ExecuteReader();
                }

                return reader;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public DataTable CDObtenerConsultaEmpleado()
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("USP_ConsultaEmpleados_obtener", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cn.Close();
            return dt;
        }

        public DataTable CD_buscar(string busqueda)
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("USP_empleado_Buscar", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Busqueda", busqueda);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            ad.Fill(ds);
            cn.Close();
            return ds;
        }

        public DataTable GetAllEmpleado()
        {
            DataTable dataTable = new DataTable();

            cn.Open();

            string query = "SELECT idEmpleado as Codigo,Nombres,Apellidos,Especialidad,Sexo,Dni as DNI,Email,Telefono,Direccion,HoraIngreso as Ingreso,HoraSalida as Salida,Sueldo FROM empleado";

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

            string query = string.Format("select idEmpleado as Codigo,Nombres,Apellidos,Especialidad,Sexo,Dni as DNI,Email,Telefono,Direccion,HoraIngreso as Ingreso,HoraSalida as Salida,Sueldo from empleado  where  Sexo like '%{0}%';", genero);

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

            string query = string.Format("select idEmpleado as Codigo,Nombres,Apellidos,Especialidad,Sexo,Dni as DNI,Email,Telefono,Direccion,HoraIngreso as Ingreso,HoraSalida as Salida,Sueldo from empleado  where  Dni like '%{0}%';", dni);

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

        public DataTable BuscarClientesPorEspecialidad(string especialidad)
        {
            DataTable tablaClientes = new DataTable();

            // Lógica para consultar la base de datos y llenar la tabla con los resultados
            cn.Open();

            string query = string.Format("select idEmpleado as Codigo,Nombres,Apellidos,Especialidad,Sexo,Dni as DNI,Email,Telefono,Direccion,HoraIngreso as Ingreso,HoraSalida as Salida,Sueldo from empleado where  Especialidad like '%{0}%';", especialidad);

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
    }
}
