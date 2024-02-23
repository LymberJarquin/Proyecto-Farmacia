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
    public class CD_Laboratorio
    {
        SqlConnection cn = new SqlConnection("Data Source=.;Initial Catalog=FARMACIA;Integrated Security=True");

        public void CD_AgregarLaboratorio(CE_Laboratorio _Laboratorio)
        {
            cn.Open();
            SqlCommand command = new SqlCommand("USP_laboratorio_insert", cn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Nombre", _Laboratorio.Nombre);
            command.Parameters.AddWithValue("@Direccion", _Laboratorio.Direccion);
            command.Parameters.AddWithValue("@Telefono", _Laboratorio.Telefono);
            command.Parameters.AddWithValue("@Estado", _Laboratorio.Estado);
            command.ExecuteNonQuery();
            command.Parameters.Clear();
            cn.Close();

        }

        public void CDEliminarLaboratorio(CE_Laboratorio _Laboratorio)
        {
            cn.Open();

            SqlCommand command = new SqlCommand("USP_laboratorio_Delete", cn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@idLaboratorio", _Laboratorio.CodigoLaboratorio);
            command.ExecuteNonQuery();
            command.Parameters.Clear();
            cn.Close();

        }

        public void CDModificarLaboratorio(CE_Laboratorio _Laboratorio)
        {
            cn.Open();
            SqlCommand command = new SqlCommand("USP_laboratorio_Update", cn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@idLaboratorio", _Laboratorio.idLaboratorio);
            command.Parameters.AddWithValue("@Nombre", _Laboratorio.Nombre);
            command.Parameters.AddWithValue("@Direccion", _Laboratorio.Direccion);
            command.Parameters.AddWithValue("@Telefono", _Laboratorio.Telefono);
            command.Parameters.AddWithValue("@Estado", _Laboratorio.Estado);
            command.ExecuteNonQuery();
            command.Parameters.Clear();
            cn.Close();

        }

        public DataTable CDObtenerLaboratorio()
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("USP_laboratorio_obtener", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cn.Close();
            return dt;
        }
    }
}
