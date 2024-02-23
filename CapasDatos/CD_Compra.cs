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
    public class CD_Compra
    {
        SqlConnection cn = new SqlConnection("Data Source=.;Initial Catalog=FARMACIA;Integrated Security=True");
        public void CD_AgregarCompra(CE_Compra _Compra)
        {
            cn.Open();
            SqlCommand command = new SqlCommand("USP_Compra_insert", cn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Numero", _Compra.Numero);
            command.Parameters.AddWithValue("@Fecha", _Compra.Fecha);
            command.Parameters.AddWithValue("@TipoPago", _Compra.TipoPago);
            command.Parameters.AddWithValue("@SubTotal", _Compra.SubTotal);
            command.Parameters.AddWithValue("@Total", _Compra.Total);
            command.Parameters.AddWithValue("@Igv", _Compra.Igv);
            command.Parameters.AddWithValue("@Estado", _Compra.Estado);
            command.Parameters.AddWithValue("@idProveedor", _Compra.idProveedor);
            command.Parameters.AddWithValue("@idEmpleado", _Compra.idEmpleado);
            command.Parameters.AddWithValue("@idTipoComprobante", _Compra.idTipoComprobante);
            command.ExecuteNonQuery();
            command.Parameters.Clear();
            cn.Close();

        }

        public void CDEliminarCompra(CE_Compra _Compra)
        {
            cn.Open();

            SqlCommand command = new SqlCommand("USP_Compra_Delete", cn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@idCompra", _Compra.CodigoCompra);
            command.ExecuteNonQuery();
            command.Parameters.Clear();
            cn.Close();

        }

        public void CDModificarCompra(CE_Compra _Compra)
        {
            cn.Open();
            SqlCommand command = new SqlCommand("USP_Compra_Update", cn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@idCompra", _Compra.idCompra);
            command.Parameters.AddWithValue("@Numero", _Compra.Numero);
            command.Parameters.AddWithValue("@Fecha", _Compra.Fecha);
            command.Parameters.AddWithValue("@TipoPago", _Compra.TipoPago);
            command.Parameters.AddWithValue("@SubTotal", _Compra.SubTotal);
            command.Parameters.AddWithValue("@Total", _Compra.Total);
            command.Parameters.AddWithValue("@Igv", _Compra.Igv);
            command.Parameters.AddWithValue("@Estado", _Compra.Estado);
            command.Parameters.AddWithValue("@idProveedor", _Compra.idProveedor);
            command.Parameters.AddWithValue("@idEmpleado", _Compra.idEmpleado);
            command.Parameters.AddWithValue("@idTipoComprobante", _Compra.idTipoComprobante);
            command.ExecuteNonQuery();
            command.Parameters.Clear();
            cn.Close();

        }

        public DataTable CDObtenerCompra()
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("USP_Compra_obtener", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cn.Close();
            return dt;
        }

        public DataTable CDObtenerConsultasCompra()
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("USP_ConsultaCompra_obtener", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cn.Close();
            return dt;
        }

        public DataTable CD_ObtenerDatosPorRangoFecha(DateTime inicio, DateTime final)
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("ObtenerDatosPorRangoFecha1", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FechaInicio", inicio);
            cmd.Parameters.AddWithValue("@FechaFin", final);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            ad.Fill(ds);
            cn.Close();
            return ds;
        }


        public void ActualizarCompraEstado(string codigo, string anular)
        {
            try
            {

                    cn.Open();

                    using (SqlCommand command = new SqlCommand("ActualizarCompraEstado", cn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@idcompra", SqlDbType.VarChar).Value = codigo;
                        command.Parameters.Add("@estado", SqlDbType.VarChar).Value = anular;

                        command.ExecuteNonQuery();
                    }
                
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar estado de compra: " + ex.Message);
            }
        }


        public DataTable ListarDetalleCompraPorParametro(string parametro, string valor)
        {
            DataTable dt = new DataTable();

            try
            {

                cn.Open();

                using (SqlCommand command = new SqlCommand("sp_ListarDetalleCompraPorParametro", cn))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Agregar parámetros
                    command.Parameters.AddWithValue("@Parametro", parametro);
                    command.Parameters.AddWithValue("@Valor", valor);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dt);
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar detalle de compra por parámetro: " + ex.Message);
            }

            return dt;
        }

        public SqlDataReader ObtenerUltimoIdCompra()
        {
            SqlDataReader reader = null;
            try
            {

                cn.Open();
                using (SqlCommand command = new SqlCommand("UltimoIdCompra", cn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    reader = command.ExecuteReader();
                }

                return reader;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }



        public long ObtenerUltimoIdEmpleado()
        {
            SqlDataReader reader = null;
            try
            {

                cn.Open();
                using (SqlCommand command = new SqlCommand("UltimoIdEmpleado", cn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    reader = command.ExecuteReader();
                }

                return 0;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
