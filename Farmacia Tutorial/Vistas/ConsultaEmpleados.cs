using CapasNegocio;
using Microsoft.ReportingServices.ReportProcessing.OnDemandReportObjectModel;
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
    public partial class ConsultaEmpleados : Form
    {
        public ConsultaEmpleados()
        {
            InitializeComponent();
        }
        CN_Empleado _Empleado = new CN_Empleado();

        public void mostrados()
        {
            dtgConsultaEmpleados.DataSource = _Empleado.CNObtenerConsultaEmpleado();
        }
        private void ConsultaEmpleados_Load(object sender, EventArgs e)
        {
            mostrados();
            //CargarListaEmpleado();
        }

        private void CargarListaEmpleado()
        {

            DataTable dataTable = _Empleado.ObtenerListaEmpleado();
            dtgConsultaEmpleados.DataSource = dataTable;
            txtCantidadRegistros.Text = dataTable.Rows.Count.ToString();

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rbGenero_CheckedChanged(object sender, EventArgs e)
        {
            if (rbGenero.Checked)
            {
                cmbGenero.Focus();
                cmbGenero.SelectedIndex = 0;
                cmbGenero.Enabled = true;
                txtDni.Enabled = false;
                txtDni.Text = "";
                txtEspecialidad.Enabled = false;
                txtEspecialidad.Text = "";
                btnBuscar.Enabled = true;
                CargarListaEmpleado();
            }
        }

        private void rbDni_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDni.Checked)
            {
                cmbGenero.SelectedIndex = 0;
                cmbGenero.Enabled = false;
                txtDni.Enabled = true;
                txtDni.Focus();
                txtEspecialidad.Text = "";
                txtEspecialidad.Enabled = false;
                btnBuscar.Enabled = true;
                CargarListaEmpleado();
            }
        }

        private void rbEspecialidad_CheckedChanged(object sender, EventArgs e)
        {
            if (rbEspecialidad.Checked)
            {
                cmbGenero.SelectedIndex = 0;
                cmbGenero.Enabled = false;
                txtDni.Enabled = false;
                txtDni.Text = "";
                txtEspecialidad.Enabled = true;
                txtEspecialidad.Focus();
                btnBuscar.Enabled = true;
                CargarListaEmpleado();
            }
        }

        private void rbMostrarTodos_Empleados_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMostrarTodos_Empleados.Checked)
            {
                CargarListaEmpleado();
                cmbGenero.SelectedIndex = 0;
                cmbGenero.Enabled = false;
                txtDni.Text = "";
                txtDni.Enabled = false;
                txtEspecialidad.Enabled = false;
                txtEspecialidad.Text = "";
                btnBuscar.Enabled = false;
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
            else if (rbEspecialidad.Checked)
            {
                tipoBusqueda = "ESPECIALIDAD";
                parametro = txtEspecialidad.Text;
            }
            else if (rbMostrarTodos_Empleados.Checked)
            {
                // No es necesario especificar un tipo de búsqueda si se busca todo
                tipoBusqueda = "Todo";
            }

            DataTable resultadoBusqueda = _Empleado.BuscarEmpleado(tipoBusqueda, parametro);

            // Lógica para actualizar la interfaz de usuario con el resultado de la búsqueda
            // ...

            // Puedes utilizar 'resultadoBusqueda' para llenar tu DataGridView, por ejemplo:
            dtgConsultaEmpleados.DataSource = resultadoBusqueda;
            txtCantidadRegistros.Text = resultadoBusqueda.Rows.Count.ToString();
        }
    }
}
