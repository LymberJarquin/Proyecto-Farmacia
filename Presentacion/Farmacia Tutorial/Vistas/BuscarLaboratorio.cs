using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapasNegocio;

namespace Farmacia_Tutorial.Vistas
{
    public partial class BuscarLaboratorio : Form
    {
        CN_Laboratorio _Laboratorio = new CN_Laboratorio();
        public BuscarLaboratorio()
        {
            InitializeComponent();
        }

        void limpiar()
        {
            txtBuscar.Text = "";
        }

        public delegate void Datos(int cod,string nombre);

        public event Datos MisDatos2;

        public void mostrados()
        {
            dtgLaboratorio.DataSource = _Laboratorio.CNObtenerLaboratorio();
        }

        private void btnTodo_Click(object sender, EventArgs e)
        {
            mostrados();
            limpiar();
        }

        private void BuscarLaboratorio_Load(object sender, EventArgs e)
        {
            mostrados();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmLaboratorios frmLaboratorios = new FrmLaboratorios();
            frmLaboratorios.ShowDialog();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            //FrmProductos frmProductos = new FrmProductos();
            //frmProductos.txtLaboratorio.Clear();
            //btnRegresar.Focus();
        }

        private void dtgLaboratorio_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int indice = dtgLaboratorio.CurrentRow.Index;


            this.MisDatos2(Convert.ToInt32(dtgLaboratorio[0, indice].Value), dtgLaboratorio[1, indice].Value.ToString());
        }
    }
}
