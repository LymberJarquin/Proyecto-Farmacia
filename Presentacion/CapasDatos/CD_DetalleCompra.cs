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
    public class CD_DetalleCompra
    {
        SqlConnection cn = new SqlConnection("Data Source=DESKTOP-3CPHA0J\\JEMMINSON;Initial Catalog=FARMACIA;Integrated Security=True");
        private DataSet ds;
        public void CD_AgregarDetalleCompra(CE_DetalleCompra _DetalleCompra)
        {
            cn.Open();
            SqlCommand command = new SqlCommand("USP_detallecompra_insert", cn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@idCompra", _DetalleCompra.idCompra);
            command.Parameters.AddWithValue("@idProducto", _DetalleCompra.idProducto);
            command.Parameters.AddWithValue("@Cantidad", _DetalleCompra.Cantidad);
            command.Parameters.AddWithValue("@Costo", _DetalleCompra.Costo);
            command.Parameters.AddWithValue("@Importe", _DetalleCompra.Importe);
            command.ExecuteNonQuery();
            command.Parameters.Clear();
            cn.Close();

        }

        public void CDEliminarDetalleCompra(CE_DetalleCompra _DetalleCompra)
        {
            cn.Open();

            SqlCommand command = new SqlCommand("USP_detallecompra_Delete", cn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@idDetalleCompra", _DetalleCompra.CodigoDetalleCompra);
            command.ExecuteNonQuery();
            command.Parameters.Clear();
            cn.Close();

        }

        public void CDModificarDetalleCompra(CE_DetalleCompra _DetalleCompra)
        {
            cn.Open();
            SqlCommand command = new SqlCommand("USP_detallecompra_Update", cn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@idDetalleCompra", _DetalleCompra.idDetalleCompra);
            command.Parameters.AddWithValue("@idCompra", _DetalleCompra.idCompra);
            command.Parameters.AddWithValue("@idProducto", _DetalleCompra.idProducto);
            command.Parameters.AddWithValue("@Cantidad", _DetalleCompra.Cantidad);
            command.Parameters.AddWithValue("@Costo", _DetalleCompra.Costo);
            command.Parameters.AddWithValue("@Importe", _DetalleCompra.Importe);
            command.ExecuteNonQuery();
            command.Parameters.Clear();
            cn.Close();

        }

        public DataTable CDObtenerDetalleCompra()
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("USP_detallecompra_obtener", cn);
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

  
    }
}
