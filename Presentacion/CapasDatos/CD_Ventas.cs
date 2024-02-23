using CapasEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapasDatos
{
    public class CD_Ventas
    {
        SqlConnection cn = new SqlConnection("Data Source=DESKTOP-3CPHA0J\\JEMMINSON;Initial Catalog=FARMACIA;Integrated Security=True");
        private DataSet ds;
        public void CD_AgregarVenta(CE_Venta _Venta)
        {
            cn.Open();
            SqlCommand command = new SqlCommand("USP_ventas_insert", cn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Serie", _Venta.Serie);
            command.Parameters.AddWithValue("@Numero", _Venta.Numero);
            command.Parameters.AddWithValue("@Fecha", _Venta.Fecha);
            command.Parameters.AddWithValue("@VentaTotal", _Venta.VentaTotal);
            command.Parameters.AddWithValue("@Descuento", _Venta.Descuento);
            command.Parameters.AddWithValue("@SubTotal", _Venta.SubTotal);
            command.Parameters.AddWithValue("@Igv", _Venta.Igv);
            command.Parameters.AddWithValue("@Total", _Venta.Total);
            command.Parameters.AddWithValue("@Estado", _Venta.Estado);
            command.Parameters.AddWithValue("@idCliente", _Venta.idCliente);
            command.Parameters.AddWithValue("@idEmpleado", _Venta.idEmpleado);
            command.Parameters.AddWithValue("@idTipoComprobante", _Venta.idTipoComprobante);
            command.ExecuteNonQuery();
            command.Parameters.Clear();
            cn.Close();

        }

        public void CDEliminarVenta(CE_Venta _Venta)
        {
            cn.Open();

            SqlCommand command = new SqlCommand("USP_venta_Delete", cn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IdVenta", _Venta.CodigoVenta);
            command.ExecuteNonQuery();
            command.Parameters.Clear();
            cn.Close();

        }

        public void CDModificarVenta(CE_Venta _Venta)
        {
            cn.Open();
            SqlCommand command = new SqlCommand("USP_venta_Update", cn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IdVenta", _Venta.IdVenta);
            command.Parameters.AddWithValue("@Serie", _Venta.Serie);
            command.Parameters.AddWithValue("@Numero", _Venta.Numero);
            command.Parameters.AddWithValue("@Fecha", _Venta.Fecha);
            command.Parameters.AddWithValue("@VentaTotal", _Venta.VentaTotal);
            command.Parameters.AddWithValue("@Descuento", _Venta.Descuento);
            command.Parameters.AddWithValue("@SubTotal", _Venta.SubTotal);
            command.Parameters.AddWithValue("@Igv", _Venta.Igv);
            command.Parameters.AddWithValue("@Total", _Venta.Total);
            command.Parameters.AddWithValue("@Estado", _Venta.Estado);
            command.Parameters.AddWithValue("@idCliente", _Venta.idCliente);
            command.Parameters.AddWithValue("@idEmpleado", _Venta.idEmpleado);
            command.Parameters.AddWithValue("@idTipoComprobante", _Venta.idTipoComprobante);
            command.ExecuteNonQuery();
            command.Parameters.Clear();
            cn.Close();

        }

        public DataTable CDObtenerVenta()
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("USP_venta_obtener", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cn.Close();
            return dt;
        }

        public DataTable CDObtenerConsultaVenta()
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("USP_ConsultaVentas_obtener", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cn.Close();
            return dt;
        }

        public DataTable CD_buscar(string Nombre)
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand(string.Format("select * from Tables_Clientes  where  Nombre_Cliente like '%{0}%';", Nombre), cn);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            cn.Close();
            return ds.Tables["tabla"];
        }

        public DataTable ListarVentaPorFecha( DateTime fechafin)
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("USP_GananciaCaja", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@fechaini", fechaini);
            cmd.Parameters.AddWithValue("@fechafin", fechafin);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            ad.Fill(ds);
            cn.Close();
            return ds;



        }

        public DataTable ListarDetalleVentaPorParametro(DateTime fechaini, DateTime fechafin)
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("USP_GananciaTotalVenta", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@fechaini", fechaini);
            cmd.Parameters.AddWithValue("@fechafin", fechafin);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            ad.Fill(ds);
            cn.Close();
            return ds;
        }

        public int GuardarDetalleVentas(int IdVenta, int IdProducto, int Cantidad, decimal Costo, decimal Precio, decimal Total)
        {
            int resultado = 0;
            SqlConnection conexion = null;

            string cadenaConexion = "Data Source=DESKTOP-3CPHA0J\\JEMMINSON;Initial Catalog=FARMACIA;Integrated Security=True";
            string sentencia_guardar = "INSERT INTO detalleventa (IdVenta, IdProducto, Cantidad, Costo, Precio, Importe) VALUES (@IdVenta, @IdProducto, @Cantidad, @Costo, @Precio, @Total)";

            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    using (SqlCommand comando = new SqlCommand(sentencia_guardar, conexion))
                    {
                        comando.Parameters.AddWithValue("@IdVenta", IdVenta);
                        comando.Parameters.AddWithValue("@IdProducto", IdProducto);
                        comando.Parameters.AddWithValue("@Cantidad", Cantidad);
                        comando.Parameters.AddWithValue("@Costo", Costo);
                        comando.Parameters.AddWithValue("@Precio", Precio);
                        comando.Parameters.AddWithValue("@Total", Total);

                        conexion.Open();
                        resultado = comando.ExecuteNonQuery();
                    }
                }

                //if (resultado > 0)
                //{
                //    MessageBox.Show("Venta realizada con éxito");
                //}
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message, "Error al guardar venta");
            }
            //finally
            //{
            //    if (conexion != null && conexion.State == System.Data.ConnectionState.Open)
            //    {
            //        conexion.Close();
            //    }
            //}

            return resultado;
        }

        public SqlDataReader ObtenerUltimoIdVenta()
        {
            SqlDataReader reader = null;
            try
            {

                cn.Open();
                using (SqlCommand command = new SqlCommand("USP_UltimoNumeroCliente", cn))
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

        public void ActualizarVentasEstado(string codigo, string anular)
        {
            try
            {

                cn.Open();

                using (SqlCommand command = new SqlCommand("ActualizarVentaEstado", cn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@idventa", SqlDbType.VarChar).Value = codigo;
                    command.Parameters.Add("@estado", SqlDbType.VarChar).Value = anular;

                    command.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar estado de venta: " + ex.Message);
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

        public DataTable CD_ObtenerVentasPorFecha(DateTime inicio, DateTime final)
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("VentasPorFecha", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FechaInicio", inicio);
            cmd.Parameters.AddWithValue("@FechaFin", final);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            ad.Fill(ds);
            cn.Close();
            return ds;
        }

    }
}
