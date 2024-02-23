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
    public partial class ConsultaProductos : Form
    {
        public ConsultaProductos()
        {
            InitializeComponent();
        }
        CN_Productos _Productos = new CN_Productos();

        private void ConsultaProductos_Load(object sender, EventArgs e)
        {
            CargarListaProductos();
        }

        private void CargarListaProductos()
        {

            DataTable dataTable = _Productos.ObtenerListaProductos();
            dtgConsultaProductos.DataSource = dataTable;
            txtCantidadRegistros.Text = dataTable.Rows.Count.ToString();

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rbDescripcion_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDescripcion.Checked)
            {
                CargarListaProductos();
                txtDescripcion.Enabled = true;
                btnBuscar.Enabled = true;
                btnBuscar.Focus();

                txtPresentacion.Enabled = false;
                txtPresentacion.Text = "";
            }
        }

        private void rbPresentacion_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPresentacion.Checked)
            {
                txtDescripcion.Enabled = false;
                txtDescripcion.Text = "";
                txtPresentacion.Enabled = true;
                btnBuscar.Enabled = true;
                txtPresentacion.Focus();
            }
        }

        private void rbMostrarTodos_Productos_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMostrarTodos_Productos.Checked)
            {
                btnBuscar.Enabled = false;
                txtCantidadRegistros.Enabled = false;
                txtDescripcion.Enabled = false;
                txtDescripcion.Text = "";
                txtPresentacion.Enabled = false;
                txtPresentacion.Text = "";
                CargarListaProductos();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string tipoBusqueda = string.Empty;
            string parametro = string.Empty;

            if (rbDescripcion.Checked)
            {
                tipoBusqueda = "DESCRIPCION";
                parametro = txtDescripcion.Text;
            }
            else if (rbPresentacion.Checked)
            {
                tipoBusqueda = "PRESENTACION";
                parametro = txtPresentacion.Text;
            }
            else if (rbMostrarTodos_Productos.Checked)
            {
                // No es necesario especificar un tipo de búsqueda si se busca todo
                tipoBusqueda = "Todo";
            }

            DataTable resultadoBusqueda = _Productos.BuscarEmpleado(tipoBusqueda, parametro);

            // Lógica para actualizar la interfaz de usuario con el resultado de la búsqueda
            // ...

            // Puedes utilizar 'resultadoBusqueda' para llenar tu DataGridView, por ejemplo:
            dtgConsultaProductos.DataSource = resultadoBusqueda;
            txtCantidadRegistros.Text = resultadoBusqueda.Rows.Count.ToString();
        }
    }
}
