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
    public class CD_DetalleVenta
    {
        SqlConnection cn = new SqlConnection("Data Source=DESKTOP-3CPHA0J\\JEMMINSON;Initial Catalog=FARMACIA;Integrated Security=True");
        private DataSet ds;
        public void CD_AgregarDetalleVenta(CE_DetalleVenta _DetalleVenta)
        {
            cn.Open();
            SqlCommand command = new SqlCommand("USP_detalleventa_insert", cn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IdVenta", _DetalleVenta.IdVenta);
            command.Parameters.AddWithValue("@idProducto", _DetalleVenta.idProducto);
            command.Parameters.AddWithValue("@Cantidad", _DetalleVenta.Cantidad);
            command.Parameters.AddWithValue("@Costo", _DetalleVenta.Costo);
            command.Parameters.AddWithValue("@Precio", _DetalleVenta.Precio);
            command.Parameters.AddWithValue("@Importe", _DetalleVenta.Importe);
            command.ExecuteNonQuery();
            command.Parameters.Clear();
            cn.Close();

        }

        public void CDEliminarDetalleVenta(CE_DetalleVenta _DetalleVenta)
        {
            cn.Open();

            SqlCommand command = new SqlCommand("USP_detalleventa_Delete", cn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@idDetalleVenta", _DetalleVenta.CodigoDetalleVenta);
            command.ExecuteNonQuery();
            command.Parameters.Clear();
            cn.Close();

        }

        public void CDModificarDetalleVenta(CE_DetalleVenta _DetalleVenta)
        {
            cn.Open();
            SqlCommand command = new SqlCommand("USP_detalleventa_Update", cn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@idDetalleVenta", _DetalleVenta.idDetalleVenta);
            command.Parameters.AddWithValue("@idVenta", _DetalleVenta.IdVenta);
            command.Parameters.AddWithValue("@idProducto", _DetalleVenta.idProducto);
            command.Parameters.AddWithValue("@Cantidad", _DetalleVenta.Cantidad);
            command.Parameters.AddWithValue("@Costo", _DetalleVenta.Costo);
            command.Parameters.AddWithValue("@Precio", _DetalleVenta.Precio);
            command.Parameters.AddWithValue("@Importe", _DetalleVenta.Importe);
            command.ExecuteNonQuery();
            command.Parameters.Clear();
            cn.Close();

        }

        public DataTable CDObtenerDetalleVenta()
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("USP_detalleventa_obtener", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cn.Close();
            return dt;
        }



        //public DataTable CDObtenerClientesConFacturas()
        //{
        //    cn.Open();
        //    SqlCommand cmd = new SqlCommand("ObtenerClientesConFacturas", cn);
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    cn.Close();
        //    return dt;
        //}

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
    }
}
