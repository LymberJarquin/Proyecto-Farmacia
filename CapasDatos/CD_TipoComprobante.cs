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
    public class CD_TipoComprobante
    {
        SqlConnection cn = new SqlConnection("Data Source=.;Initial Catalog=FARMACIA;Integrated Security=True");
        private DataSet ds;
        public void CD_AgregarTipoComprobante(CE_TipoComprobante _TipoComprobante)
        {
            cn.Open();
            SqlCommand command = new SqlCommand("USP_tipocomprobante_insert", cn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Descripcion", _TipoComprobante.Descripcion);
            command.Parameters.AddWithValue("@Estado", _TipoComprobante.Estado);
            command.ExecuteNonQuery();
            command.Parameters.Clear();
            cn.Close();

        }

        public void CDEliminarTipoComprobante(CE_TipoComprobante _TipoComprobante)
        {
            cn.Open();

            SqlCommand command = new SqlCommand("USP_tipocomprobante_Delete", cn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@idTipoComprobante", _TipoComprobante.CodigoTipoComprobante);
            command.ExecuteNonQuery();
            command.Parameters.Clear();
            cn.Close();

        }

        public void CDModificarTipoComprobante(CE_TipoComprobante _TipoComprobante)
        {
            cn.Open();
            SqlCommand command = new SqlCommand("USP_tipocomprobante_Update", cn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@idTipoComprobante", _TipoComprobante.idTipoComprobante);
            command.Parameters.AddWithValue("@Descripcion", _TipoComprobante.Descripcion);
            command.Parameters.AddWithValue("@Estado", _TipoComprobante.Estado);
            command.ExecuteNonQuery();
            command.Parameters.Clear();
            cn.Close();

        }

        public DataTable CDObtenerTipoComprobante()
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("USP_tipocomprobante_obtener", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cn.Close();
            return dt;
        }

        public DataTable CDObtenerBuscarComprobante()
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("USP_buscarcomprobante_obtener", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cn.Close();
            return dt;
        }

        public DataTable CDObtenerBuscarComprobanteComprar()
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("USP_buscarcomprobantecompra_obtener", cn);
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
