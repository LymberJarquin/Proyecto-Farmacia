using CapasNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Farmacia_Tutorial.Vistas
{
    public partial class ConsultaClientes : Form
    {
        public ConsultaClientes()
        {
            InitializeComponent();
        }
        CN_Cliente _Cliente = new CN_Cliente();

        //public void mostrados()
        //{
        //    dtgConsultaClientes.DataSource = _Cliente.CNObtenerConsultasClientes();
        //}

        private void ConsultaClientes_Load(object sender, EventArgs e)
        {
            CargarListaClientes();
        }

        private void CargarListaClientes()
        {
           
                DataTable dataTable = _Cliente.ObtenerListaClientes();
                dtgConsultaClientes.DataSource = dataTable;
                txtCantidadRegistros.Text = dataTable.Rows.Count.ToString();
           
        }

        private void rbGenero_CheckedChanged(object sender, EventArgs e)
        {
            if (rbGenero.Checked)
            {
                CargarListaClientes();
                btnBuscar.Enabled = true;
                cmbGenero.SelectedIndex = 0;
                cmbGenero.Enabled = true;
                txtDni.Enabled = false;
                txtDni.Text = "";
                txtRuc.Text = "";
                txtRuc.Enabled = false;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string tipoBusqueda = string.Empty;
            string parametro = string.Empty;

            if (rbGenero.Checked)
            {
                tipoBusqueda = "Genero";
                parametro = cmbGenero.SelectedItem.ToString();
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
            else if (rbMostrarTodos_Clientes.Checked)
            {
                // No es necesario especificar un tipo de búsqueda si se busca todo
                tipoBusqueda = "Todo";
            }

            DataTable resultadoBusqueda = _Cliente.BuscarClientes(tipoBusqueda, parametro);

            // Lógica para actualizar la interfaz de usuario con el resultado de la búsqueda
            // ...

            // Puedes utilizar 'resultadoBusqueda' para llenar tu DataGridView, por ejemplo:
            dtgConsultaClientes.DataSource = resultadoBusqueda;
            txtCantidadRegistros.Text = resultadoBusqueda.Rows.Count.ToString();
        }

        private void rbDni_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDni.Checked)
            {
                CargarListaClientes();
                cmbGenero.SelectedIndex = 0;
                cmbGenero.Enabled = false;
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
                CargarListaClientes();
                cmbGenero.SelectedIndex = 0;
                cmbGenero.Enabled = false;
                txtRuc.Enabled = true;
                txtRuc.Focus();
                txtDni.Text = "";
                txtDni.Enabled = false;
                btnBuscar.Enabled = true;
            }
        }

        private void rbMostrarTodos_Clientes_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMostrarTodos_Clientes.Checked)
            {
                CargarListaClientes();
                txtDni.Text = "";
                txtDni.Enabled = false;
                txtRuc.Text = "";
                txtRuc.Enabled = false;
                btnBuscar.Enabled = false;

                cmbGenero.SelectedIndex = 0;
                cmbGenero.Enabled = false;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
