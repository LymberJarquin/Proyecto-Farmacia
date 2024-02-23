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
    public partial class BuscarComprobante : Form
    {
        public BuscarComprobante()
        {
            InitializeComponent();
        }



        CN_TipoComprobante _TipoComprobante = new CN_TipoComprobante();


        public delegate void Datos(int cod,string Descripcion);

        public event Datos MisDatos1;
        public void mostrados()
        {
            dtgComprobante.DataSource = _TipoComprobante.CNObtenerBuscarComprobante();

        }



        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmComprobantes frmComprobantes = new FrmComprobantes();
            frmComprobantes.ShowDialog();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            FrmComprobantes frmComprobantes = new FrmComprobantes();
            frmComprobantes.txtDescripcion.Text = "";
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BuscarComprobante_Load(object sender, EventArgs e)
        {
            mostrados();
        }

        private void dtgComprobante_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int indice = dtgComprobante.CurrentRow.Index;


            this.MisDatos1(Convert.ToInt32(dtgComprobante[0, indice].Value), dtgComprobante[1, indice].Value.ToString());
        }
    }
}
