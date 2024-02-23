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
    public partial class BuscarProductosCompras : Form
    {
        public BuscarProductosCompras()
        {
            InitializeComponent();
        }

        CN_Productos _Productos = new CN_Productos();

        public void mostrados()
        {
            dtgProductosCompras.DataSource = _Productos.CNObtenerBuscarProductoCompras();
        }

        public delegate void Datos(string ID, string codigo_Barras, string Presentacion, string Producto, string Concentracion, string Stock, string Costo, int codpre,int codlab);

        public event Datos MisDatos3;

        void limpiar()
        {
            txtBuscar.Text = "";
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BuscarProductosCompras_Load(object sender, EventArgs e)
        {
            mostrados();

            // Ocultar columnas según índices especificados
            foreach (int index in new int[] { 7 })
            {
                dtgProductosCompras.Columns[index].Visible = false;
            }

            foreach (int index in new int[] { 8 })
            {
                dtgProductosCompras.Columns[index].Visible = false;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmProductos frmProductos = new FrmProductos();
            frmProductos.ShowDialog();
        }

        private void btnTodo_Click(object sender, EventArgs e)
        {
            mostrados();
            limpiar();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            FrmCompras frmCompras = new FrmCompras();
            frmCompras.txtCodigo.Text = "";
            frmCompras.txtPresentacion.Text = "";
            frmCompras.txtProducto.Text = "";
            frmCompras.txtConcentracion.Text = "";
            frmCompras.txtStock.Text = "";
            frmCompras.txtCosto.Text = "";
            
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string busqueda = txtBuscar.Text;
            DataTable Resultado = _Productos.CN_Buscar1(busqueda);

            dtgProductosCompras.DataSource = Resultado;
        }

        private void dtgProductosCompras_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int indice = dtgProductosCompras.CurrentRow.Index;


            this.MisDatos3(dtgProductosCompras[0, indice].Value.ToString(), dtgProductosCompras[1, indice].Value.ToString(), dtgProductosCompras[2, indice].Value.ToString(), dtgProductosCompras[3, indice].Value.ToString(), dtgProductosCompras[4, indice].Value.ToString(), dtgProductosCompras[5, indice].Value.ToString(), dtgProductosCompras[6, indice].Value.ToString(), Convert.ToInt32(dtgProductosCompras[7, indice].Value.ToString()), Convert.ToInt32(dtgProductosCompras[8, indice].Value.ToString()));
        }
    }
}
