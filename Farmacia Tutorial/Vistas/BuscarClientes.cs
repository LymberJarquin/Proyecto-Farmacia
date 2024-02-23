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
    public partial class BuscarClientes : Form
    {
        public BuscarClientes()
        {
            InitializeComponent();
        }

        CN_Cliente _Cliente = new CN_Cliente();

        void limpiar()
        {
            txtBuscar.Text = "";
        }
        public void mostrados()
        {
            dtgClientes.DataSource = _Cliente.CNObtenerBuscarClientes();
        }

        public delegate void Datos(int cod, string Nombres, string Ruc);

        public event Datos MisDatos1;

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmCliente frmCliente = new FrmCliente();
            frmCliente.ShowDialog();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            FrmVenta frmVenta = new FrmVenta();
            frmVenta.txtNombreCliente.Text = "";
            frmVenta.txtRuc.Text = "";
            this.Show();

        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMostrar_Todo_Click(object sender, EventArgs e)
        {
            limpiar();
            mostrados();
        }

        private void BuscarClientes_Load(object sender, EventArgs e)
        {
            mostrados();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string busqueda = txtBuscar.Text;
            DataTable Resultado = _Cliente.CN_Buscar1(busqueda);

            dtgClientes.DataSource = Resultado;
        }

        private void dtgClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int indice = dtgClientes.CurrentRow.Index;


            this.MisDatos1(Convert.ToInt32(dtgClientes[0, indice].Value), dtgClientes[1, indice].Value.ToString(), dtgClientes[4, indice].Value.ToString());

        }
    }
}
