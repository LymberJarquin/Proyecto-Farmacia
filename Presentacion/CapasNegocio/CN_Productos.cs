using CapasDatos;
using CapasEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapasNegocio
{
    public class CN_Productos
    {
        CD_Productos _Productos1 = new CD_Productos();

        public DataTable CNObtenerProducto()
        {
            return _Productos1.CDObtenerProducto();
        }

        public DataTable CNObtenerBuscarProductoCompras()
        {
            return _Productos1.CDObtenerBuscarProductoCompras();
        }

        public DataTable CNObtenerBuscarProductoVentas()
        {
            return _Productos1.CDObtenerBuscarProductoVentas();
        }

        public DataTable CNObtenerConsultaProducto()
        {
            return _Productos1.CDObtenerConsultasProducto();
        }

        public DataTable ObtenerListaProductos()
        {
            return _Productos1.GetAllProductos();
        }

        public void CNAgregarProducto(string Codigo_Barras,string Descripcion, string Concentracion, decimal Stock, decimal Costo, decimal Precio_Venta, string RegistroSanitario, DateTime FechaVencimiento, string Estado, int idPresentacionn, int idLaboratorio)
        {
            CE_Producto _Productos = new CE_Producto();
            _Productos.Codigo_Barras = Codigo_Barras;
            _Productos.Descripcion = Descripcion;
            _Productos.Concentracion = Concentracion;
            _Productos.Stock = Stock;
            _Productos.Costo = Costo;
            _Productos.Precio_Venta = Precio_Venta;
            _Productos.RegistroSanitario = RegistroSanitario;
            _Productos.FechaVencimiento = FechaVencimiento;
            _Productos.Estado = Estado;
            _Productos.idPresentacion = idPresentacionn;
            _Productos.idLaboratorio = idLaboratorio;
            
            _Productos1.CD_AgregarProducto(_Productos);

        }

        public void CNActualizarProducto(int idProducto, string Codigo_Barras,  string Descripcion, string Concentracion, decimal Stock, decimal Costo, decimal Precio_Venta, string RegistroSanitario, DateTime FechaVencimiento, string Estado, int idPresentacionn, int idLaboratorio)
        {
            CE_Producto _Producto = new CE_Producto();
            _Producto.idProducto = idProducto;
            _Producto.Codigo_Barras = Codigo_Barras;
            _Producto.Descripcion = Descripcion;
            _Producto.Concentracion = Concentracion;
            _Producto.Stock = Stock;
            _Producto.Costo = Costo;
            _Producto.Precio_Venta = Precio_Venta;
            _Producto.RegistroSanitario = RegistroSanitario;
            _Producto.FechaVencimiento = FechaVencimiento;
            _Producto.Estado = Estado;
            _Producto.idPresentacion = idPresentacionn;
            _Producto.idLaboratorio = idLaboratorio;

            _Productos1.CDModificarProducto(_Producto);
        }

        public void CNEliminarProducto(string CodigoProducto)
        {
            CE_Producto _Producto = new CE_Producto();
            _Producto.CodigoProducto = CodigoProducto;

            _Productos1.CDEliminarProducto(_Producto);
        }

        public DataTable CN_Buscar(string busqueda)
        {
            return _Productos1.CD_buscar(busqueda);
        }

        public DataTable CN_Buscar1(string busqueda)
        {
            return _Productos1.CD_buscar1(busqueda);
        }

        public DataTable CN_Buscar2(string busqueda)
        {
            return _Productos1.CD_buscar2(busqueda);
        }

        public DataTable BuscarEmpleado(string tipoBusqueda, string parametro)
        {
            switch (tipoBusqueda)
            {
                case "DESCRIPCION":
                    return _Productos1.BuscarClientesPorDescripcion(parametro);

                case "PRESENTACION":
                    return _Productos1.BuscarClientesPorPresentacion(parametro);

                default:
                    // Manejar un caso no esperado
                    return new DataTable();
            }
        }

        public DataTable MostrarTodosProductos(string buscar)
        {
            return _Productos1.MostrarProductos(buscar);
        }
    }
}
