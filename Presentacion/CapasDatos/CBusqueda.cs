using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapasDatos
{
    public class CBusqueda
    {
        public void buscarCodigo(TextBox txtCodigo, TextBox txtCodBarras, TextBox txtIdPresentacion, TextBox txtConcentracion,TextBox txtDescripcion,TextBox txtStock,TextBox txtCosto)
        {
            string connectionString = "Data Source=DESKTOP-3CPHA0J\\JEMMINSON;Initial Catalog=FARMACIA;Integrated Security=True";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT  dbo.producto.idProducto,dbo.presentacion.idPresentacion, dbo.presentacion.Descripcion AS Presentacion, dbo.producto.Concentracion, dbo.producto.Descripcion, dbo.producto.Stock, dbo.producto.Costo\r\nFROM            dbo.producto INNER JOIN\r\n                         dbo.presentacion ON dbo.producto.idPresentacion = dbo.presentacion.idPresentacion\r\nWHERE        dbo.producto.Codigo_Barras = @Codigobarras";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@Codigobarras", txtCodBarras.Text);

                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        txtCodigo.Text = rdr["idProducto"].ToString();
                        txtIdPresentacion.Text = rdr["Presentacion"].ToString();
                        txtConcentracion.Text = rdr["Concentracion"].ToString();
                        txtDescripcion.Text = rdr["Descripcion"].ToString();
                        txtStock.Text = rdr["Stock"].ToString();
                        txtCosto.Text = rdr["Costo"].ToString();
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se logró realizar la búsqueda, error: " + ex.ToString());
            }
        }

        public void buscarCodigosegundo(TextBox txtCodigo, TextBox txtCodBarras, TextBox txtDescripcion, TextBox txtConcentracion, TextBox txtStock, TextBox txtPrecio_Venta, TextBox txtCosto)
        {
            string connectionString = "Data Source=DESKTOP-3CPHA0J\\JEMMINSON;Initial Catalog=FARMACIA;Integrated Security=True";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT  \r\ndbo.producto.idProducto,dbo.producto.Descripcion, dbo.producto.Concentracion,\r\ndbo.producto.Stock, dbo.producto.Precio_Venta, dbo.producto.Costo FROM dbo.producto \r\nINNER JOIN dbo.presentacion ON dbo.producto.idPresentacion = dbo.presentacion.idPresentacion\r\nWHERE  dbo.producto.Codigo_Barras = @Codigobarras";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@Codigobarras", txtCodBarras.Text);

                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        txtCodigo.Text = rdr["idProducto"].ToString();
                        txtDescripcion.Text = rdr["Descripcion"].ToString();
                        txtConcentracion.Text = rdr["Concentracion"].ToString();
                        txtStock.Text = rdr["Stock"].ToString();
                        txtPrecio_Venta.Text = rdr["Precio_Venta"].ToString();
                        txtCosto.Text = rdr["Costo"].ToString();
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se logró realizar la búsqueda, error: " + ex.ToString());
            }
        }
    }
}
