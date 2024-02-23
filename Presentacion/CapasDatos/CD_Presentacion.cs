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
    public class CD_Presentacion
    {
        SqlConnection cn = new SqlConnection("Data Source=DESKTOP-3CPHA0J\\JEMMINSON;Initial Catalog=FARMACIA;Integrated Security=True");

        public void CD_AgregarPresentacion(CE_Presentacion _Presentacion)
        {
            cn.Open();
            SqlCommand command = new SqlCommand("USP_presentacion_insert", cn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Descripcion", _Presentacion.Descripcion);
            command.Parameters.AddWithValue("@Estado", _Presentacion.Estado);
            command.ExecuteNonQuery();
            command.Parameters.Clear();
            cn.Close();

        }

        public void CDEliminarPresentacion(CE_Presentacion _Presentacion)
        {
            cn.Open();

            SqlCommand command = new SqlCommand("USP_presentacion_Delete", cn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@idPresentacion", _Presentacion.CodigoPresentacion);
            command.ExecuteNonQuery();
            command.Parameters.Clear();
            cn.Close();

        }

        public void CDModificarPresentacion(CE_Presentacion _Presentacion)
        {
            cn.Open();
            SqlCommand command = new SqlCommand("USP_presentacion_Update", cn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@idPresentacion", _Presentacion.idPresentacion);
            command.Parameters.AddWithValue("@Descripcion", _Presentacion.Descripcion);
            command.Parameters.AddWithValue("@Estado", _Presentacion.Estado);
            command.ExecuteNonQuery();
            command.Parameters.Clear();
            cn.Close();

        }

        public DataTable CDObtenerPresentacion()
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("USP_presentacion_obtener", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cn.Close();
            return dt;
        }

    }
}
