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
    public class CD_Productos
    {
        SqlConnection cn = new SqlConnection("Data Source=DESKTOP-3CPHA0J\\JEMMINSON;Initial Catalog=FARMACIA;Integrated Security=True");
   
        public void CD_AgregarProducto(CE_Producto _Producto)
        {
            cn.Open();
            SqlCommand command = new SqlCommand("USP_producto_insert", cn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Codigo_Barras", _Producto.Codigo_Barras);
            command.Parameters.AddWithValue("@Descripcion", _Producto.Descripcion);
            command.Parameters.AddWithValue("@Concentracion", _Producto.Concentracion);
            command.Parameters.AddWithValue("@Stock", _Producto.Stock);
            command.Parameters.AddWithValue("@Costo", _Producto.Costo);
            command.Parameters.AddWithValue("@Precio_Venta", _Producto.Precio_Venta);
            command.Parameters.AddWithValue("@RegistroSanitario", _Producto.RegistroSanitario);
            command.Parameters.AddWithValue("@FechaVencimiento", _Producto.FechaVencimiento);
            command.Parameters.AddWithValue("@Estado", _Producto.Estado);
            command.Parameters.AddWithValue("@idPresentacion", _Producto.idPresentacion);
            command.Parameters.AddWithValue("@idLaboratorio", _Producto.idLaboratorio);
            command.ExecuteNonQuery();
            command.Parameters.Clear();
            cn.Close();

        }

        public void CDEliminarProducto(CE_Producto _Producto)
        {
            cn.Open();

            SqlCommand command = new SqlCommand("USP_producto_Delete", cn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@idProducto", _Producto.CodigoProducto);
            command.ExecuteNonQuery();
            command.Parameters.Clear();
            cn.Close();

        }

        public void CDModificarProducto(CE_Producto _Producto)
        {
            cn.Open();
            SqlCommand command = new SqlCommand("USP_producto_Update", cn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@idProducto", _Producto.idProducto);
            command.Parameters.AddWithValue("@Codigo_Barras", _Producto.Codigo_Barras);
            command.Parameters.AddWithValue("@Descripcion", _Producto.Descripcion);
            command.Parameters.AddWithValue("@Concentracion", _Producto.Concentracion);
            command.Parameters.AddWithValue("@Stock", _Producto.Stock);
            command.Parameters.AddWithValue("@Costo", _Producto.Costo);
            command.Parameters.AddWithValue("@Precio_Venta", _Producto.Precio_Venta);
            command.Parameters.AddWithValue("@RegistroSanitario", _Producto.RegistroSanitario);
            command.Parameters.AddWithValue("@FechaVencimiento", _Producto.FechaVencimiento);
            command.Parameters.AddWithValue("@Estado", _Producto.Estado);
            command.Parameters.AddWithValue("@idPresentacion", _Producto.idPresentacion);
            command.Parameters.AddWithValue("@idLaboratorio", _Producto.idLaboratorio);
            command.ExecuteNonQuery();
            command.Parameters.Clear();
            cn.Close();

        }

        public DataTable CDObtenerProducto()
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("USP_producto_obtener", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cn.Close();
            return dt;
        }

        public DataTable CDObtenerBuscarProductoCompras()
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("USP_buscarproductoscompras_obtener", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cn.Close();
            return dt;
        }

        public DataTable CDObtenerBuscarProductoVentas()
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("USP_buscarproductosventas_obtener", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cn.Close();
            return dt;
        }

        public DataTable CDObtenerConsultasProducto()
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("USP_ConsultaProductos_obtener", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cn.Close();
            return dt;
        }


        public DataTable CD_buscar(string busqueda)
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("USP_producto_Buscar", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Busqueda", busqueda);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            ad.Fill(ds);
            cn.Close();
            return ds;
        }

        public DataTable CD_buscar1(string busqueda)
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("USP_buscarproductoscompras1", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Busqueda", busqueda);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            ad.Fill(ds);
            cn.Close();
            return ds;
        }

        public DataTable CD_buscar2(string busqueda)
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("USP_buscarproductosventas1", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Busqueda", busqueda);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            ad.Fill(ds);
            cn.Close();
            return ds;
        }

        public DataTable GetAllProductos()
        {
            DataTable dataTable = new DataTable();

            cn.Open();

            string query = "SELECT dbo.producto.idProducto as Codigo, dbo.presentacion.Descripcion AS presentacion, dbo.producto.Descripcion, dbo.producto.Concentracion, dbo.producto.Stock, dbo.producto.Costo, dbo.producto.Precio_Venta, \r\n                         dbo.producto.FechaVencimiento, dbo.producto.RegistroSanitario, dbo.laboratorio.Nombre AS Laboratorio, dbo.producto.Estado\r\nFROM            dbo.producto INNER JOIN\r\n                         dbo.presentacion ON dbo.producto.idPresentacion = dbo.presentacion.idPresentacion INNER JOIN\r\n                         dbo.laboratorio ON dbo.producto.idLaboratorio = dbo.laboratorio.idLaboratorio";

            using (SqlCommand command = new SqlCommand(query, cn))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(dataTable);
                }
            }
            cn.Close();

            return dataTable;
        }

        public DataTable BuscarClientesPorDescripcion(string descripcion)
        {
            DataTable tablaClientes = new DataTable();

            // Lógica para consultar la base de datos y llenar la tabla con los resultados
            cn.Open();

            string query = string.Format("SELECT        dbo.producto.idProducto as Codigo, dbo.presentacion.Descripcion AS presentacion, dbo.producto.Descripcion, dbo.producto.Concentracion, dbo.producto.Stock, dbo.producto.Costo, dbo.producto.Precio_Venta, \r\n                         dbo.producto.FechaVencimiento, dbo.producto.RegistroSanitario, dbo.laboratorio.Nombre AS Laboratorio, dbo.producto.Estado\r\nFROM            dbo.producto INNER JOIN\r\n                         dbo.presentacion ON dbo.producto.idPresentacion = dbo.presentacion.idPresentacion INNER JOIN\r\n                         dbo.laboratorio ON dbo.producto.idLaboratorio = dbo.laboratorio.idLaboratorio where dbo.producto.Descripcion like '%{0}%';", descripcion);

            using (SqlCommand command = new SqlCommand(query, cn))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(tablaClientes);
                }
            }
            cn.Close();

            return tablaClientes;
        }

        public DataTable BuscarClientesPorPresentacion(string presentacion)
        {
            DataTable tablaClientes = new DataTable();

            // Lógica para consultar la base de datos y llenar la tabla con los resultados
            cn.Open();

            string query = string.Format("SELECT        dbo.producto.idProducto as Codigo, dbo.presentacion.Descripcion AS presentacion, dbo.producto.Descripcion, dbo.producto.Concentracion, dbo.producto.Stock, dbo.producto.Costo, dbo.producto.Precio_Venta, \r\n                         dbo.producto.FechaVencimiento, dbo.producto.RegistroSanitario, dbo.laboratorio.Nombre AS Laboratorio, dbo.producto.Estado\r\nFROM            dbo.producto INNER JOIN\r\n                         dbo.presentacion ON dbo.producto.idPresentacion = dbo.presentacion.idPresentacion INNER JOIN\r\n                         dbo.laboratorio ON dbo.producto.idLaboratorio = dbo.laboratorio.idLaboratorio  where  dbo.presentacion.Descripcion like '%{0}%';", presentacion);

            using (SqlCommand command = new SqlCommand(query, cn))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(tablaClientes);
                }
            }
            cn.Close();

            return tablaClientes;
        }

        public DataTable MostrarProductos(string buscar)
        {
            DataTable tabla = new DataTable();

                cn.Open();

                string query = "SELECT dbo.producto.idProducto AS Codigo, " +
                   "dbo.presentacion.Descripcion AS Presentacion, " +
                   "dbo.producto.Descripcion, dbo.producto.Concentracion, " +
                   "dbo.producto.Stock, dbo.producto.Costo, dbo.producto.Precio_Venta, " +
                   "dbo.producto.FechaVencimiento, dbo.producto.RegistroSanitario, " +
                   "dbo.laboratorio.Nombre AS Laboratorio, dbo.producto.Estado " +
                   "FROM dbo.producto " +
                   "INNER JOIN dbo.presentacion ON dbo.producto.idPresentacion = dbo.presentacion.idPresentacion " +
                   "INNER JOIN dbo.laboratorio ON dbo.producto.idLaboratorio = dbo.laboratorio.idLaboratorio " +
                   "WHERE dbo.producto.idProducto LIKE '%" + buscar + "%' OR " +
                   "dbo.presentacion.Descripcion LIKE '%" + buscar + "%' OR " +
                   "dbo.producto.Estado LIKE '%" + buscar + "%'";

            using (SqlCommand command = new SqlCommand(query, cn))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(tabla);
                }
            cn.Close();

            return tabla;
        }
    }
}
