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
    public partial class ConsultaProveedores : Form
    {
        public ConsultaProveedores()
        {
            InitializeComponent();
        }
        CN_Proveedor _Proveedor = new CN_Proveedor();

        //public void mostrados()
        //{
        //    dtgConsultaProveedores.DataSource = _Proveedor.CNObtenerConsultaProveedores();
        //}
        private void ConsultaProveedores_Load(object sender, EventArgs e)
        {
            CargarListaProveedores();
        }

        private void CargarListaProveedores()
        {

            DataTable dataTable = _Proveedor.ObtenerListaProveedor();
            dtgConsultaProveedores.DataSource = dataTable;
            txtCantidadRegistros.Text = dataTable.Rows.Count.ToString();

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string tipoBusqueda = string.Empty;
            string parametro = string.Empty;

            if (rbNombre.Checked)
            {
                tipoBusqueda = "NOMBRES";
                parametro = txtNombre.Text;
            }
            else if (rbDni.Checked)
            {
                tipoBusqueda = "DNI";
                parametro = txtDni.Text;
            }
            else if (rbRuc.Checked)
            {
                tipoBusqueda = "RUC";
                parametro = txtRuc.Text;
            }
            else if (rbMostrarTodos_Proveedores.Checked)
            {
                // No es necesario especificar un tipo de búsqueda si se busca todo
                tipoBusqueda = "Todo";
            }

            DataTable resultadoBusqueda = _Proveedor.BuscarProveedor(tipoBusqueda, parametro);

            // Lógica para actualizar la interfaz de usuario con el resultado de la búsqueda
            // ...

            // Puedes utilizar 'resultadoBusqueda' para llenar tu DataGridView, por ejemplo:
            dtgConsultaProveedores.DataSource = resultadoBusqueda;
            txtCantidadRegistros.Text = resultadoBusqueda.Rows.Count.ToString();
        }

        private void rbNombre_CheckedChanged(object sender, EventArgs e)
        {
            if (rbNombre.Checked)
            {
                CargarListaProveedores();
                btnBuscar.Enabled = true;
                txtNombre.Text = "";
                txtNombre.Enabled = true;
                txtDni.Enabled = false;
                txtDni.Text = "";
                txtRuc.Text = "";
                txtRuc.Enabled = false;
            }
        }

        private void rbDni_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDni.Checked)
            {
                CargarListaProveedores();
                txtNombre.Text = "";
                txtNombre.Enabled = false;
                txtDni.Enabled = true;
                txtDni.Focus();
                txtRuc.Text = "";
                txtRuc.Enabled = false;
                btnBuscar.Enabled = true;
            }
        }

        private void rbRuc_CheckedChanged(object sender, EventArgs e)
        {
            if (rbRuc.Checked)
            {
                CargarListaProveedores();
                txtNombre.Text = "";
                txtNombre.Enabled = false;
                txtRuc.Enabled = true;
                txtRuc.Focus();
                txtDni.Text = "";
                txtDni.Enabled = false;
                btnBuscar.Enabled = true;
            }
        }

        private void rbMostrarTodos_Proveedores_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMostrarTodos_Proveedores.Checked)
            {
                CargarListaProveedores();
                txtDni.Text = "";
                txtDni.Enabled = false;
                txtRuc.Text = "";
                txtRuc.Enabled = false;
                btnBuscar.Enabled = false;

                txtNombre.Text = "";
                txtNombre.Enabled = false;
            }
        }
    }
}
