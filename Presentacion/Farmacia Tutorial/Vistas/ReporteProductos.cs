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
    public partial class ReporteProductos : Form
    {
        public ReporteProductos()
        {
            InitializeComponent();
        }
        CN_Productos _Productos = new CN_Productos();
        private void ListarCategorias(string buscar)
        {
            DataTable tabla = _Productos.MostrarTodosProductos(buscar);

            dtgReporteProductos.DataSource = tabla;

        }


        private void ReporteProductos_Load(object sender, EventArgs e)
        {
            ListarCategorias("");
        }

        private void rbPresentacion_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPresentacion.Checked)
            {
                txtPresentacion.Enabled = true;
                txtPresentacion.Text = "";
                txtId.Enabled = false;
                txtId.Text = "";
                txtEstado.Enabled = false;
                txtEstado.Text = "";
                btnGenerar.Enabled = true;
                txtPresentacion.Focus();
                ListarCategorias("");
            }
        }

        private void txtPresentacion_KeyUp(object sender, KeyEventArgs e)
        {
            ListarCategorias(txtPresentacion.Text);
        }

        private void rbId_CheckedChanged(object sender, EventArgs e)
        {
            if (rbId.Checked)
            {
                txtId.Enabled = true;
                txtId.Text = "";
                txtPresentacion.Enabled = false;
                txtEstado.Enabled = false;
                txtPresentacion.Text = "";
                txtEstado.Text = "";
                btnGenerar.Enabled = true;
                txtId.Focus();
                ListarCategorias("");
            }
        }

        private void txtId_KeyUp(object sender, KeyEventArgs e)
        {
            ListarCategorias(txtId.Text);
        }

        private void rbEstado_CheckedChanged(object sender, EventArgs e)
        {

            if (rbEstado.Checked)
            {
                txtEstado.Enabled = true;
                txtEstado.Text = "";
                txtPresentacion.Enabled = false;
                txtPresentacion.Text = "";
                txtId.Enabled = false;
                txtId.Text = "";
                btnGenerar.Enabled = true;
                txtEstado.Focus();
                ListarCategorias("");
            }

        }

        private void txtEstado_KeyUp(object sender, KeyEventArgs e)
        {
            ListarCategorias(txtEstado.Text);
        }

        private void rbMostrarReporte_General_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMostrarReporte_General.Checked)
            {
                txtPresentacion.Enabled = false;
                txtPresentacion.Text = "";
                txtId.Enabled = false;
                txtId.Text = "";
                txtEstado.Enabled = false;
                txtEstado.Text = "";
                ListarCategorias("");
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
