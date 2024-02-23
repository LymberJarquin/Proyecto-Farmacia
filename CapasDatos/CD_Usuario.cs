using CapasEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using Microsoft.SqlServer.Server;

namespace CapasDatos
{
    public class CD_Usuario
    {
        SqlConnection cn = new SqlConnection("Data Source=.;Initial Catalog=FARMACIA;Integrated Security=True");
        private DataSet ds;
        public void CD_AgregarUsuario(CE_Usuario _Usuario)
        {
            cn.Open();
            SqlCommand command = new SqlCommand("USP_usuario_insert", cn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Nombres", _Usuario.Nombres);
            command.Parameters.AddWithValue("@Apellidos", _Usuario.Apellidos);
            command.Parameters.AddWithValue("@Dni", _Usuario.Dni);
            command.Parameters.AddWithValue("@Email", _Usuario.Email);
            command.Parameters.AddWithValue("@Usuario", _Usuario.Usuario);
            command.Parameters.AddWithValue("@Contraseña", _Usuario.Contraseña);
            command.Parameters.AddWithValue("@TipoUsuario", _Usuario.TipoUsuario);
            command.Parameters.AddWithValue("@Estado", _Usuario.Estado);
            command.ExecuteNonQuery();
            command.Parameters.Clear();
            cn.Close();

        }

        public void CDEliminarUsuario(CE_Usuario _Usuario)
        {
            cn.Open();

            SqlCommand command = new SqlCommand("USP_usuario_Delete", cn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@idUsuario", _Usuario.CodigoUsuario);
            command.ExecuteNonQuery();
            command.Parameters.Clear();
            cn.Close();

        }

        public void CDModificarUsuario(CE_Usuario _Usuario)
        {
            cn.Open();
            SqlCommand command = new SqlCommand("USP_usuario_Update", cn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@idUsuario", _Usuario.idUsuario);
            command.Parameters.AddWithValue("@Nombres", _Usuario.Nombres);
            command.Parameters.AddWithValue("@Apellidos", _Usuario.Apellidos);
            command.Parameters.AddWithValue("@Dni", _Usuario.Dni);
            command.Parameters.AddWithValue("@Email", _Usuario.Email);
            command.Parameters.AddWithValue("@Usuario", _Usuario.Usuario);
            command.Parameters.AddWithValue("@Contraseña", _Usuario.Contraseña);
            command.Parameters.AddWithValue("@TipoUsuario", _Usuario.TipoUsuario);
            command.Parameters.AddWithValue("@Estado", _Usuario.Estado);
            command.ExecuteNonQuery();
            command.Parameters.Clear();
            cn.Close();

        }

        public void GuardarImagen(string ruta, string nombre)
        {
            try
            {
                

                string SQL = "INSERT INTO usuario (Foto) VALUES (@Foto)";

                using (SqlCommand cmd = new SqlCommand(SQL, cn))
                {
                    byte[] imageBytes = File.ReadAllBytes(ruta);

                    cmd.Parameters.AddWithValue("@Foto", imageBytes);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message);
            }
            finally
            {
                
            }
        }

        public DataTable CDObtenerUsuario()
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("USP_usuario_obtener", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cn.Close();
            return dt;
        }


        public long GetUltimoNumeroUsuario()
        {
            cn.Open();
            DataTable ObjDataTable = new DataTable();
            DataSet ObjDataSet = new DataSet();
            DataRow ObjDataRow;
            SqlCommand cmd = new SqlCommand(string.Format("select MAX(idUsuario) as cod from usuario"), cn);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            cn.Close();
            ObjDataTable = ds.Tables[0];
            ObjDataRow = ObjDataTable.Rows[0];
            return Convert.ToUInt32(ObjDataRow["cod"].ToString());

        }

        public DataTable CD_buscar(string busqueda)
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("USP_usuario_Buscar", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Busqueda", busqueda);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            ad.Fill(ds);
            cn.Close();
            return ds;
        }

        public bool Login(string User, string pass)
        {
            cn.Open();
            using (var command = new SqlCommand())
            {
                command.Connection = cn;
                command.CommandText = "select * from usuario where Usuario=@user and Contraseña=@pass";
                command.Parameters.AddWithValue("@user", User);
                command.Parameters.AddWithValue("@pass", pass);
                command.CommandType = CommandType.Text;
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        CE_Usuario1.idUsuario = reader.GetInt32(0);
                        CE_Usuario1.Nombres = reader.GetString(1);
                        CE_Usuario1.Apellidos = reader.GetString(2);
                        CE_Usuario1.Dni = reader.GetInt32(3);
                        CE_Usuario1.Email = reader.GetString(4);
                        CE_Usuario1.Usuario = reader.GetString(5);
                        CE_Usuario1.Contraseña = reader.GetString(6);
                        CE_Usuario1.TipoUsuario = reader.GetString(7);
                        CE_Usuario1.Estado = reader.GetString(8);
                        
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
