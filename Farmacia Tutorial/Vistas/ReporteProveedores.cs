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
    public partial class ReporteProveedores : Form
    {
        public ReporteProveedores()
        {
            InitializeComponent();
        }

        CN_Proveedor _Proveedor = new CN_Proveedor();
        private void ListarProveedores(string buscar)
        {
            DataTable tabla = _Proveedor.MostrarTodosProveedores(buscar);

            dtgReporteProveedores.DataSource = tabla;
            txtCantidadRegistros.Text = tabla.Rows.Count.ToString();
        }

        private void rbDni_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDni.Checked)
            {
                txtDni.Enabled = true;
                txtDni.Text = "";
                txtRuc.Enabled = false;
                txtRuc.Text = "";
                btnImprimir.Enabled = true;
                txtDni.Focus();
                ListarProveedores("");
            }
        }

        private void rbRuc_CheckedChanged(object sender, EventArgs e)
        {
            if (rbRuc.Checked)
            {
                txtRuc.Enabled = true;
                txtRuc.Text = "";
                txtDni.Enabled = false;
                txtDni.Text = "";
                btnImprimir.Enabled = true;
                txtRuc.Focus();
                ListarProveedores("");
            }
        }

        private void txtDni_KeyUp(object sender, KeyEventArgs e)
        {
            ListarProveedores(txtDni.Text);
        }

        private void txtRuc_KeyUp(object sender, KeyEventArgs e)
        {
            ListarProveedores(txtRuc.Text);
        }

        private void rbMostrarReporte_General_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMostrarReporte_General.Checked)
            {
                txtDni.Enabled = false;
                txtDni.Text = "";
                txtRuc.Enabled = false;
                txtRuc.Text = "";
                ListarProveedores("");
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
