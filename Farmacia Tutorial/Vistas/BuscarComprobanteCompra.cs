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
    public partial class BuscarComprobanteCompra : Form
    {
        public BuscarComprobanteCompra()
        {
            InitializeComponent();
        }
        CN_TipoComprobante _TipoComprobante = new CN_TipoComprobante();

        public void mostrados()
        {
            dtgComprobanteCompra.DataSource = _TipoComprobante.CNObtenerBuscarComprobanteComprar();
        }

        public delegate void Datos(int idTipoComprobante,string Descripcion);

        public event Datos MisDatos2;

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmComprobantes frmComprobantes = new FrmComprobantes();
            frmComprobantes.ShowDialog();
        }

        private void BuscarComprobanteCompra_Load(object sender, EventArgs e)
        {
            mostrados();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            FrmCompras frmCompras = new FrmCompras();
            frmCompras.txtComprobante.Text = "";
           
            //// Obtén una referencia al formulario actual
            //FrmCompras frmCompras = new FrmCompras();

            //// Asegúrate de que el formulario actual es de tipo FrmCompras
            //if (frmCompras != null)
            //{
            //    // Limpia el campo de texto en el formulario actual
            //    frmCompras.txtComprobante.Text = "";

            //    // Muestra el formulario actual

            //}

        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtgComprobanteCompra_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int indice = dtgComprobanteCompra.CurrentRow.Index;


            this.MisDatos2(Convert.ToInt32(dtgComprobanteCompra[0, indice].Value), dtgComprobanteCompra[1, indice].Value.ToString());
        }
    }
}
