using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapasEntidad;
using System.Windows.Forms;

namespace CapasDatos
{
    public class CD_Reporte
    {

        public List<CE_ReporteCompras> ObtenerReporteCompras(string fechaInicio, string fechaFin, int idProveedor)
        {
            List<CE_ReporteCompras> lista = new List<CE_ReporteCompras>();

            using (SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-3CPHA0J\\JEMMINSON;Initial Catalog=FARMACIA;Integrated Security=True"))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_ReporteCompras", conexion);
                    cmd.Parameters.AddWithValue("@fechainicio", fechaInicio);
                    cmd.Parameters.AddWithValue("@fechafin", fechaFin);
                    cmd.Parameters.AddWithValue("@idproveedor", idProveedor);
                    cmd.CommandType = CommandType.StoredProcedure;

                    conexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            CE_ReporteCompras compra = new CE_ReporteCompras()
                            {
                                Fecha = dr["Fecha"].ToString(),
                                TipoDocumento = dr["TipoDocumento"].ToString(),
                                NumeroDocumento = dr["NumeroDocumento"].ToString(),
                                Total = dr["Total"].ToString(),
                                UsuarioRegistro = dr["UsuarioRegistro"].ToString(),
                                DocumentoProveedor = dr["DocumentoProveedor"].ToString(),
                                RazonSocial = dr["RazonSocial"].ToString(),
                                Codigo_Barras = dr["Codigo_Barras"].ToString(),
                                Descripcion = dr["Descripcion"].ToString(),
                                Concentracion = dr["Concentracion"].ToString(),
                                Stock = dr["Stock"].ToString(),
                                Costo = dr["Costo"].ToString(),
                                Cantidad = dr["Cantidad"].ToString(),
                                Importe = dr["Importe"].ToString(),
                            };
                            lista.Add(compra);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Manejar la excepción apropiadamente
                    // Por ejemplo, registrar el error o lanzar una excepción
                    MessageBox.Show("Error al buscar el reporte: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return lista;
        }


        public List<CE_ReporteVentas> Venta(string fechainicio, string fechafin)
        {
            List<CE_ReporteVentas> lista = new List<CE_ReporteVentas>();

            using (SqlConnection oconexion = new SqlConnection("Data Source=DESKTOP-3CPHA0J\\JEMMINSON;Initial Catalog=FARMACIA;Integrated Security=True"))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    SqlCommand cmd = new SqlCommand("sp_ReporteVentas", oconexion);
                    cmd.Parameters.AddWithValue("@fechainicio", fechainicio);
                    cmd.Parameters.AddWithValue("@fechafin", fechafin);
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {

                            lista.Add(new CE_ReporteVentas()
                            //CE_ReporteVentas ventas = new CE_ReporteVentas()
                            {
                                Fecha = dr["Fecha"].ToString(),
                                TipoDocumento = dr["TipoDocumento"].ToString(),
                                NumeroDocumento = dr["NumeroDocumento"].ToString(),
                                Total = dr["Total"].ToString(),
                                UsuarioRegistro = dr["UsuarioRegistro"].ToString(),
                                DocumentoCliente = dr["DocumentoCliente"].ToString(),
                                NombreCliente = dr["Nombre Cliente"].ToString(),
                                Codigo_Barras = dr["Codigo_Barras"].ToString(),
                                Descripcion = dr["Descripcion"].ToString(),
                                Concentracion = dr["Concentracion"].ToString(),
                                Precio = dr["Precio"].ToString(),
                                Cantidad = dr["Cantidad"].ToString(),
                                Importe = dr["Importe"].ToString(),
                            });
                            
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<CE_ReporteVentas>();
                    MessageBox.Show("Error al buscar el reporte: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return lista;

        }
    }
}
