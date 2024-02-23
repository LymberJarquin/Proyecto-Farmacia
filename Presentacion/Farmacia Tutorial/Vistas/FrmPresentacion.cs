using CapasEntidad;
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
    public partial class FrmPresentacion : Form
    {
        public FrmPresentacion()
        {
            InitializeComponent();
        }
        CN_Presentacion con = new CN_Presentacion();
        private string _Presentacion = null;
        string Operacion = "Insertar";

        void limpiar()
        {
            txtDescripcion.Text = "";
            ckbActivo.Checked = false;
        }

        public void mostrados()
        {
            dtgPresentacion.DataSource = con.CNObtenerPresentacion();
        }

        private bool ValidarCampos()
        {
            // Validar cada campo individualmente
            if (string.IsNullOrEmpty(txtDescripcion.Text))
            {
                MostrarMensaje("Debes ingresar un Descripcion.", "Advertencia", MessageBoxIcon.Warning);
                return false;
            }

            // Todos los campos son válidos
            return true;
        }

        private void GuardarDatos()
        {
            if (Operacion == "Insertar")
            {
                con.CNAgregarPresentacion(txtDescripcion.Text, ckbActivo.Checked ? "Activo" : "Inactivo");
                MostrarMensaje("Datos guardados correctamente.", "Éxito", MessageBoxIcon.Information);
            }
            else if (Operacion == "Update")
            {
                if (dtgPresentacion.SelectedRows.Count > 0)
                {
                    txtDescripcion.Text = dtgPresentacion.CurrentRow.Cells["Descripcion"].Value.ToString();
                    ckbActivo.Text = dtgPresentacion.CurrentRow.Cells["Estado"].Value.ToString();
                }
                else
                {
                    con.CNActualizarPresentacion(Convert.ToInt32(_Presentacion), txtDescripcion.Text, ckbActivo.Checked ? "Activo" : "Inactivo");
                    MostrarMensaje("Datos actualizados correctamente.", "Éxito", MessageBoxIcon.Information);
                    Operacion = "Insertar";
                }
            }
            limpiar();
            mostrados();
        }

        private void MostrarMensaje(string mensaje, string titulo, MessageBoxIcon icono)
        {
            MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, icono);
        }

        ///*******************************************************************************************************88


        private void FrmPresentacion_Load(object sender, EventArgs e)
        {
            mostrados();
        }


        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Evita que se ingrese caracteres no permitidos
                MessageBox.Show("Ingrese solo letras para la Descripción.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (e.KeyChar == (char)Keys.Enter)
            {
                ckbActivo.Focus();
                e.Handled = true; // Evita que se genere el sonido de Windows al presionar Enter
                MessageBox.Show("Se ha cambiado al campo de boton Activo o Inactivo.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnNuevo_Click_1(object sender, EventArgs e)
        {
            limpiar();
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            //if (Operacion == "Insertar")
            //{
            //    con.CNAgregarPresentacion(txtDescripcion.Text, ckbActivo.Checked ? "Activo" : "Inactivo");
            //}
            //else if (Operacion == "Update")
            //{
            //    if (dtgPresentacion.SelectedRows.Count > 0)
            //    {
            //        txtDescripcion.Text = dtgPresentacion.CurrentRow.Cells["Descripcion"].Value.ToString();
            //        ckbActivo.Text = dtgPresentacion.CurrentRow.Cells["Estado"].Value.ToString();

            //    }
            //    else
            //    {
            //        con.CNActualizarPresentacion(Convert.ToInt32(_Presentacion), txtDescripcion.Text, ckbActivo.Checked ? "Activo" : "Inactivo");
            //        MessageBox.Show("Update correcto", "Mensaje");
            //        Operacion = "Insertar";
            //    }
            //}
            //limpiar();
            //mostrados();

            if (!ValidarCampos())
                return;

            GuardarDatos();
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            if (dtgPresentacion.SelectedRows.Count > 0)
            {
                _Presentacion = dtgPresentacion.CurrentRow.Cells["Codigo"].Value.ToString();
                con.CNEliminarPresentacion(_Presentacion);
                MessageBox.Show("Eliminado correctamente", "Mensaje", MessageBoxButtons.OK);
                mostrados();
            }
        }

        private void btnRegresar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtgPresentacion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = dtgPresentacion.CurrentCell.RowIndex;

            Operacion = "Update";
            _Presentacion = dtgPresentacion[0, fila].Value.ToString();
            txtDescripcion.Text = dtgPresentacion[1, fila].Value.ToString();

            if (dtgPresentacion[2, fila].Value.ToString() == "Activo")
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
