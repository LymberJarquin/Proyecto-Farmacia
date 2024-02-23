using CapasDatos;
using CapasEntidad;
using CapasNegocio;
using Microsoft.ReportingServices.ReportProcessing.OnDemandReportObjectModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Farmacia_Tutorial.Vistas
{
    public partial class FrmLaboratorios : Form
    {
        
        public FrmLaboratorios()
        {
            InitializeComponent();
        }
        CN_Laboratorio con = new CN_Laboratorio();
        CE_Laboratorio obj = new CE_Laboratorio();
        private string _laboratorio = null;
        string Operacion = "Insertar";

        void limpiar()
        {
            txtNombre.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            ckbActivo.Checked = false;
            Operacion = "Insertar";
        }

        public void mostrados()
        {
            dtgLaboratorio.DataSource = con.CNObtenerLaboratorio();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Operacion == "Insertar")
            {
                con.CNAgregarLaboratorio(txtNombre.Text, txtDireccion.Text, Convert.ToInt32(txtTelefono.Text), ckbActivo.Checked ? "Activo" : "Inactivo");
            }
            else if (Operacion == "Update")
            {
                if (dtgLaboratorio.SelectedRows.Count > 0)
                {
                    txtNombre.Text = dtgLaboratorio.CurrentRow.Cells["Nombre"].Value.ToString();
                    txtDireccion.Text = dtgLaboratorio.CurrentRow.Cells["Direccion"].Value.ToString();
                    txtTelefono.Text = dtgLaboratorio.CurrentRow.Cells["Telefono"].Value.ToString();
                    ckbActivo.Text = dtgLaboratorio.CurrentRow.Cells["Estado"].Value.ToString();


                }
                else
                {
                    con.CNActualizarLaboratorio(Convert.ToInt32(_laboratorio), txtNombre.Text, txtDireccion.Text, Convert.ToInt32(txtTelefono.Text), ckbActivo.Checked ? "Activo" : "Inactivo");
                    MessageBox.Show("Update correcto", "Mensaje");
                    Operacion = "Insertar";
                }
            }
            limpiar();
            mostrados();

            //if (!ValidarCampos())
            //    return;

            //GuardarDatos();
        }

        //private bool ValidarCampos()
        //{
        //    // Validar cada campo individualmente
        //    if (string.IsNullOrEmpty(txtNombre.Text))
        //    {
        //        MostrarMensaje("Debes ingresar un Nombre.", "Advertencia", MessageBoxIcon.Warning);
        //        return false;
        //    }


        //    if (string.IsNullOrEmpty(txtDireccion.Text))
        //    {
        //        MostrarMensaje("Debes ingresar una Dirección.", "Advertencia", MessageBoxIcon.Warning);
        //        return false;
        //    }

        //    if (string.IsNullOrEmpty(txtTelefono.Text))
        //    {
        //        MostrarMensaje("Debes ingresar un Teléfono.", "Advertencia", MessageBoxIcon.Warning);
        //        return false;
        //    }

        //    // Validar que se haya seleccionado el estado (Activo o Inactivo)
        //    //if (!ckbActivo.Checked)
        //    //{
        //    //    MostrarMensaje("Debes seleccionar un estado (Activo o Inactivo).", "Advertencia", MessageBoxIcon.Warning);
        //    //    return false;
        //    //}


        //    // Todos los campos son válidos
        //    return true;
        //}

        //private void GuardarDatos()
        //{
        //    if (Operacion == "Insertar")
        //    {
        //        con.CNAgregarLaboratorio(txtNombre.Text, txtDireccion.Text, Convert.ToInt32(txtTelefono.Text), ckbActivo.Checked ? "Activo" : "Inactivo");
        //        MostrarMensaje("Datos guardados correctamente.", "Éxito", MessageBoxIcon.Information);
        //    }
        //    else if (Operacion == "Update")
        //    {
        //        if (dtgLaboratorio.SelectedRows.Count > 0)
        //        {
        //            txtNombre.Text = dtgLaboratorio.CurrentRow.Cells["Nombre"].Value.ToString();
        //            txtDireccion.Text = dtgLaboratorio.CurrentRow.Cells["Direccion"].Value.ToString();
        //            txtTelefono.Text = dtgLaboratorio.CurrentRow.Cells["Telefono"].Value.ToString();
        //            ckbActivo.Text = dtgLaboratorio.CurrentRow.Cells["Estado"].Value.ToString();
        //        }
        //        else
        //        {
        //            con.CNActualizarLaboratorio(Convert.ToInt32(_laboratorio), txtNombre.Text, txtDireccion.Text, Convert.ToInt32(txtTelefono.Text), ckbActivo.Checked ? "Activo" : "Inactivo");
        //            MostrarMensaje("Datos actualizados correctamente.", "Éxito", MessageBoxIcon.Information);
        //            Operacion = "Insertar";
        //        }
        //    }
        //    limpiar();
        //    mostrados();
        //}

        //private void MostrarMensaje(string mensaje, string titulo, MessageBoxIcon icono)
        //{
        //    MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, icono);
        //}

        ///*******************************************************************************************************88

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dtgLaboratorio.SelectedRows.Count > 0)
            {
                _laboratorio = dtgLaboratorio.CurrentRow.Cells["Codigo"].Value.ToString();
                con.CNEliminarLaboratorio(_laboratorio);
                MessageBox.Show("Eliminado correctamente", "Mensaje", MessageBoxButtons.OK);
                mostrados();
            }
        }

        private void FrmLaboratorios_Load(object sender, EventArgs e)
        {
            mostrados();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            Reporte.Frm_Rpt_Laboratorio frm_Rpt_Laboratorio = new Reporte.Frm_Rpt_Laboratorio();
            frm_Rpt_Laboratorio.ShowDialog();
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Evita que se ingrese caracteres no permitidos
                MessageBox.Show("Ingrese solo letras para la Nombre.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (e.KeyChar == (char)Keys.Enter)
            {
                txtDireccion.Focus();
                e.Handled = true; // Evita que se genere el sonido de Windows al presionar Enter
                MessageBox.Show("Se ha cambiado al campo de Direccion.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtTelefono.Focus();
                e.Handled = true; // Evita que se genere el sonido de Windows al presionar Enter
                MessageBox.Show("Se ha cambiado al campo de Telefono.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Si el campo ya tiene 8 caracteres y no es una tecla de control, se ignora la entrada
            if (txtTelefono.TextLength == 8 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("El número de teléfono debe tener exactamente 8 caracteres.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Verificar si se ingresó un carácter que no es un dígito
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Evitar que se ingresen caracteres no numéricos
                MessageBox.Show("Ingrese solo números para el número de teléfono.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Si se presiona Enter, cambiar el foco al siguiente control
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Cambiar el foco al siguiente control
                // Por ejemplo, si el siguiente control es txtRuc, reemplaza "siguienteControl" con "txtRuc"
                ckbActivo.Focus();
                e.Handled = true; // Evitar que se genere el sonido de Windows al presionar Enter
                MessageBox.Show("Se ha cambiado al campo Activo o Inactivo.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ckbActivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnGuardar.Focus();
                e.Handled = true; // Evita que se genere el sonido de Windows al presionar Enter
                MessageBox.Show("Se ha cambiado al campo de Guardar.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dtgLaboratorio_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = dtgLaboratorio.CurrentCell.RowIndex;

            Operacion = "Update";
            _laboratorio = dtgLaboratorio[0, fila].Value.ToString();
            txtNombre.Text = dtgLaboratorio[1, fila].Value.ToString();
            txtDireccion.Text = dtgLaboratorio[2, fila].Value.ToString();
            txtTelefono.Text = dtgLaboratorio[3, fila].Value.ToString();

            if (dtgLaboratorio[4, fila].Value.ToString() == "Activo")
            {
                ckbActivo.Checked = true;
            }
            else
            {
                ckbActivo.Checked = false;
            }
        }
    }
}
