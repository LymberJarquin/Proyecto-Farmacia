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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Farmacia_Tutorial.Vistas
{
    public partial class ReporteEmpleados : Form
    {
        public ReporteEmpleados()
        {
            InitializeComponent();

        }

        CN_Empleado _Empleado = new CN_Empleado();




        private void CargarListaEmpleado()
        {

            DataTable dataTable = _Empleado.ObtenerListaEmpleado();
            dtgReporteEmpleados.DataSource = dataTable;
            txtCantidadRegistros.Text = dataTable.Rows.Count.ToString();

        }

        private void rbDni_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDni.Checked)
            {
                cmbSexo.SelectedIndex = 0;
                cmbSexo.Enabled = false;
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
                cmbSexo.SelectedIndex = 0;
                cmbSexo.Enabled = false;
                txtDni.Enabled = false;
                txtDni.Text = "";
                txtEspecialidad.Enabled = true;
                txtEspecialidad.Focus();
                btnBuscar.Enabled = true;
                CargarListaEmpleado();
            }
        }

        private void rbSexo_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSexo.Checked)
            {
                cmbSexo.Focus();
                cmbSexo.SelectedIndex = 0;
                cmbSexo.Enabled = true;
                txtDni.Enabled = false;
                txtDni.Text = "";
                txtEspecialidad.Enabled = false;
                txtEspecialidad.Text = "";
                btnBuscar.Enabled = true;
                CargarListaEmpleado();
            }
        }

        private void rbMostrarReporte_General_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMostrarReporte_General.Checked)
            {
                CargarListaEmpleado();
                cmbSexo.SelectedIndex = 0;
                cmbSexo.Enabled = false;
                txtDni.Text = "";
                txtDni.Enabled = false;
                txtEspecialidad.Enabled = false;
                txtEspecialidad.Text = "";
                btnBuscar.Enabled = false;
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ReporteEmpleados_Load(object sender, EventArgs e)
        {
            CargarListaEmpleado();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string tipoBusqueda = string.Empty;
            string parametro = string.Empty;

            if (rbSexo.Checked)
            {
                tipoBusqueda = "Genero";
                parametro = cmbSexo.SelectedItem.ToString();
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
            else if (rbMostrarReporte_General.Checked)
            {
                // No es necesario especificar un tipo de búsqueda si se busca todo
                tipoBusqueda = "Todo";
            }

            DataTable resultadoBusqueda = _Empleado.BuscarEmpleado(tipoBusqueda, parametro);

            // Lógica para actualizar la interfaz de usuario con el resultado de la búsqueda
            // ...

            // Puedes utilizar 'resultadoBusqueda' para llenar tu DataGridView, por ejemplo:
            dtgReporteEmpleados.DataSource = resultadoBusqueda;
            txtCantidadRegistros.Text = resultadoBusqueda.Rows.Count.ToString();
        }

    }
}
