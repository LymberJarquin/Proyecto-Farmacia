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
    public partial class BuscarPresentacion : Form
    {
        CN_Presentacion _Presentacion = new CN_Presentacion();
        //FrmProductos frmProductos = new FrmProductos();
        public BuscarPresentacion()
        {
            InitializeComponent();
        }
        void limpiar()
        {
            txtBuscar.Text = "";
        }

        public delegate void Datos(int cod, string Descripcion);

        public event Datos MisDatos1;

        public void mostrados()
        {
            dtgPresentacion.DataSource = _Presentacion.CNObtenerPresentacion();
        }

        private void btnToto_Click(object sender, EventArgs e)
        {
            mostrados();
            limpiar();
        }

        private void BuscarPresentacion_Load(object sender, EventArgs e)
        {
            mostrados();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmPresentacion frmPresentacion = new FrmPresentacion();
            frmPresentacion.ShowDialog();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //private void btnLimpiar_Click(object sender, EventArgs e)
        //{

        //    FrmProductos frmProductos = new FrmProductos();
        //    frmProductos.txtPresentacion.Text = "";
        //    //btnsRegresar.Focus();
        //    frmProductos.ShowDialog();
            
        //}

        private void dtgPresentacion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int indice = dtgPresentacion.CurrentRow.Index;


            this.MisDatos1(Convert.ToInt32(dtgPresentacion[0, indice].Value), dtgPresentacion[1, indice].Value.ToString());
        }
    }
}
