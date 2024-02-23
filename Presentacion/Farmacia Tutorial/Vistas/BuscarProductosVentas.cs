using CapasNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Farmacia_Tutorial.Vistas
{
    public partial class BuscarProductosVentas : Form
    {
        public BuscarProductosVentas()
        {
            InitializeComponent();
        }
        CN_Productos _Productos = new CN_Productos();

        public delegate void Datos(string Codigo, string CodigoBarras, string Descripcion, string Concentracion, string Categoria,string Stock, string costoprod, string Venta, int codpre, int codlab);

        public event Datos MisDatos4;
        public void mostrados()
        {
            dtgProductosVentas.DataSource = _Productos.CNObtenerBuscarProductoVentas();
        }
        void limpiar()
        {
            txtBuscar.Text = "";
        }
        private void BuscarProductosVentas_Load(object sender, EventArgs e)
        {
            mostrados();
            // Ocultar columnas según índices especificados
            foreach (int index in new int[] { 8 })
            {
                dtgProductosVentas.Columns[index].Visible = false;
            }

            foreach (int index in new int[] { 9 })
            {
                dtgProductosVentas.Columns[index].Visible = false;
            }

        }

        private void btnTodo_Click(object sender, EventArgs e)
        {
            limpiar();
            mostrados();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmProductos frmProductos = new FrmProductos();
            frmProductos.ShowDialog();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            FrmVenta frmVenta = new FrmVenta();
            frmVenta.txtNombreProducto.Text = "";
            frmVenta.txtConcentracion.Text = "";
            frmVenta.txtStockProducto.Text = "";
            frmVenta.txtPrecio.Text = "";
            frmVenta.ShowDialog();

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string busqueda = txtBuscar.Text;
            DataTable Resultado = _Productos.CN_Buscar1(busqueda);

            dtgProductosVentas.DataSource = Resultado;
        }

        private void dtgProductosVentas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int indice = dtgProductosVentas.CurrentRow.Index;


            this.MisDatos4(dtgProductosVentas[0, indice].Value.ToString(), dtgProductosVentas[1, indice].Value.ToString(), dtgProductosVentas[3, indice].Value.ToString(), dtgProductosVentas[4, indice].Value.ToString(), dtgProductosVentas[2, indice].Value.ToString(), dtgProductosVentas[5, indice].Value.ToString(), dtgProductosVentas[6, indice].Value.ToString(), dtgProductosVentas[7, indice].Value.ToString(), Convert.ToInt32(dtgProductosVentas[8, indice].Value.ToString()), Convert.ToInt32(dtgProductosVentas[9, indice].Value.ToString()));

        }
    }
}
