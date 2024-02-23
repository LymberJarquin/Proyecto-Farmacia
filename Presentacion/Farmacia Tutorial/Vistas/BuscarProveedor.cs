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
    public partial class BuscarProveedor : Form
    {
        public BuscarProveedor()
        {
            InitializeComponent();
        }
        CN_Proveedor n_Proveedor = new CN_Proveedor();

        void limpiar()
        {
            txtBuscar.Text = "";
        }

        public void mostrados()
        {
            dtgProveedor.DataSource = n_Proveedor.CNObtenerBuscarProveedor();
        }

        public delegate void Datos(int Codigo, string Nombres, string Ruc);

        public event Datos MisDatos1;

        private void BuscarProveedor_Load(object sender, EventArgs e)
        {
            mostrados();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            FrmProveedores frmProveedores = new FrmProveedores();
            frmProveedores.ShowDialog();
        }

        private void btnTodo_Click(object sender, EventArgs e)
        {
            mostrados();
            limpiar();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            FrmCompras frmCompras = new FrmCompras();
            frmCompras.txtProveedor.Text = "";
            frmCompras.txtRuc.Text = "";
            
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string busqueda = txtBuscar.Text;
            DataTable Resultado = n_Proveedor.CNBuscar1(busqueda);

            dtgProveedor.DataSource = Resultado;
        }

        private void dtgProveedor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int indice = dtgProveedor.CurrentRow.Index;


            this.MisDatos1(Convert.ToInt32(dtgProveedor[0, indice].Value), dtgProveedor[1, indice].Value.ToString(), dtgProveedor[2, indice].Value.ToString());
        }
    }
}
