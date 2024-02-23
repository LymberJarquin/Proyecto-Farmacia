using CapasEntidad;
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
    public partial class BuscarEmpleados : Form
    {
        public BuscarEmpleados()
        {
            InitializeComponent();
        }
        CN_Empleado _Empleado = new CN_Empleado();
        
        void limpiar()
        {
            txtBuscar.Text = "";
        }

        public void mostrados()
        {
            dtgEmpleados.DataSource = _Empleado.CNObtenerBuscarEmpleado();
        }

        public delegate void Datos(string Nombres, string Apellidos, string Dni, string Email);

        public event Datos MisDatos1;

        private void BuscarEmpleados_Load(object sender, EventArgs e)
        {
            mostrados();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmEmpleados frmEmpleados = new FrmEmpleados();
            frmEmpleados.Show();
        }


        private void btnMostrar_Todo_Click(object sender, EventArgs e)
        {
            limpiar();
            mostrados();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {

        }

        private void dtgEmpleados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int indice = dtgEmpleados.CurrentRow.Index;


            this.MisDatos1(dtgEmpleados[1, indice].Value.ToString(), dtgEmpleados[2, indice].Value.ToString(), dtgEmpleados[3, indice].Value.ToString(), dtgEmpleados[4, indice].Value.ToString());
        }
    }
}
