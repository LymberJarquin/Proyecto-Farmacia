using CapasDatos;
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
    public partial class FrmComprobantes : Form
    {
        public FrmComprobantes()
        {
            InitializeComponent();
        }
        CN_TipoComprobante con = new CN_TipoComprobante();
        CE_TipoComprobante obj = new CE_TipoComprobante();
        private string _TipoComprobante = null;
        string Operacion = "Insertar";

        void limpiar()
        {
            txtDescripcion.Text = string.Empty;
            ckbActivo.Checked = false;
            Operacion = "Insertar";
        }

        void mostrados()
        {
            dtgComprobante.DataSource = con.CNObtenerTipoComprobante();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //if (Operacion == "Insertar")
            //{
            //    con.CNAgregarTipoComprobante(txtDescripcion.Text,ckbActivo.Checked ? "Activo" : "Inactivo");
            //}
            //else if (Operacion == "Update")
            //{
            //    if (dtgComprobante.SelectedRows.Count > 0)
            //    {

            //        txtDescripcion.Text = dtgComprobante.CurrentRow.Cells["Descripcion"].Value.ToString();
            //        ckbActivo.Text = dtgComprobante.CurrentRow.Cells["Estado"].Value.ToString();


            //    }
            //    else
            //    {
            //        con.CNActualizarTipoComprobante(Convert.ToInt32(_TipoComprobante), txtDescripcion.Text,ckbActivo.Checked ? "Activo" : "Inactivo");
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

        private bool ValidarCampos()
        {
            if (string.IsNullOrEmpty(txtDescripcion.Text))
            {
                MostrarMensaje("Debes ingresar un Descripcion.", "Advertencia", MessageBoxIcon.Warning);
                return false;
            }

            // Validar que se haya seleccionado el estado (Activo o Inactivo)
            //if (!ckbActivo.Checked && !ckbActivo.Checked)
            //{
            //    MostrarMensaje("Debes seleccionar un estado (Activo o Inactivo).", "Advertencia", MessageBoxIcon.Warning);
            //    return false;
            //}

            // Todos los campos son válidos
            return true;
        }

        private void GuardarDatos()
        {
            if (Operacion == "Insertar")
            {
                con.CNAgregarTipoComprobante(txtDescripcion.Text, ckbActivo.Checked ? "Activo" : "Inactivo");
                MostrarMensaje("Datos guardados correctamente.", "Éxito", MessageBoxIcon.Information);
            }
            else if (Operacion == "Update")
            {
                if (dtgComprobante.SelectedRows.Count > 0)
                {
                    txtDescripcion.Text = dtgComprobante.CurrentRow.Cells["Descripcion"].Value.ToString();
                    ckbActivo.Text = dtgComprobante.CurrentRow.Cells["Estado"].Value.ToString();

                }
                else
                {
                    con.CNActualizarTipoComprobante(Convert.ToInt32(_TipoComprobante), txtDescripcion.Text, ckbActivo.Checked ? "Activo" : "Inactivo");
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

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dtgComprobante.SelectedRows.Count > 0)
            {
                _TipoComprobante = dtgComprobante.CurrentRow.Cells["Codigo"].Value.ToString();
                con.CNEliminarTipoComprobante(_TipoComprobante);
                MessageBox.Show("Eliminado correctamente", "Mensaje", MessageBoxButtons.OK);
                mostrados();
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            Reporte.Frm_Rpt_Comprobantes frm_Rpt_Comprobantes = new Reporte.Frm_Rpt_Comprobantes();
            frm_Rpt_Comprobantes.ShowDialog();
        }

        private void FrmComprobantes_Load(object sender, EventArgs e)
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
                MessageBox.Show("Se ha cambiado al campo de Activo o Inactivo.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void dtgComprobante_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = dtgComprobante.CurrentCell.RowIndex;

            Operacion = "Update";
            _TipoComprobante = dtgComprobante[0, fila].Value.ToString();
            txtDescripcion.Text = dtgComprobante[1, fila].Value.ToString();

            if (dtgComprobante[2, fila].Value.ToString() == "Activo")
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
