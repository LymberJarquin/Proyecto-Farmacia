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
using CapasDatos;
using CapasEntidad;
using CapasNegocio;

namespace Farmacia_Tutorial.Vistas
{
    public partial class FrmProveedores : Form
    {
        public FrmProveedores()
        {
            InitializeComponent();
        }

        CN_Proveedor con = new CN_Proveedor();
        private string _proveedor = null;
        string Operacion = "Insertar";

        void limpiar()
        {
            txtRazonSocial.Text = "";
            txtRuc.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            txtBanco.Text = "";
            ckbActivo.Checked = false;
            txtDni.Text = "";
            txtEmail.Text = "";
            txtCuenta.Text = "";
        }

        private void Mirar()
        {
            dtgProveedor.Enabled = true;
            btnNuevo.Enabled = true;
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
            btnRegresar.Enabled = true;

            txtRazonSocial.Enabled = false;
            txtRuc.Enabled = false;
            txtDni.Enabled = false;
            txtDireccion.Enabled = false;
            txtTelefono.Enabled = false;
            txtEmail.Enabled = false;
            txtBanco.Enabled = false;
            txtCuenta.Enabled = false;
            ckbActivo.Enabled = false;
        }


        private void Modificar()
        {
            dtgProveedor.Enabled = false;
            btnNuevo.Enabled = false;
            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
            btnRegresar.Enabled = false;

            txtRazonSocial.Enabled = true;
            txtRuc.Enabled = true;
            txtDni.Enabled = true;
            txtDireccion.Enabled = true;
            txtTelefono.Enabled = true;
            txtEmail.Enabled = true;
            txtBanco.Enabled = true;
            txtCuenta.Enabled = true;
            ckbActivo.Enabled = true;

            txtRazonSocial.Focus();
        }



        public void mostrados()
        {
            dtgProveedor.DataSource = con.CNObtenerProveedor();
        }


        private bool ValidarCampos()
        {
            // Validar cada campo individualmente
            if (string.IsNullOrEmpty(txtRazonSocial.Text))
            {
                MostrarMensaje("Debes ingresar un Razon Social.", "Advertencia", MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(txtDni.Text))
            {
                MostrarMensaje("Debes ingresar un Dni.", "Advertencia", MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(txtRuc.Text))
            {
                MostrarMensaje("Debes ingresar un Ruc.", "Advertencia", MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(txtDireccion.Text))
            {
                MostrarMensaje("Debes ingresar un Direccion.", "Advertencia", MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                MostrarMensaje("Debes ingresar un Correo Electrónico.", "Advertencia", MessageBoxIcon.Warning);
                return false;
            }

            // Validar formato del correo electrónico
            Regex regex = new Regex(@"[^@\s]+@[^@\s]+\.[^@\s]+$");
            if (!regex.IsMatch(txtEmail.Text))
            {
                MostrarMensaje("El formato del correo electrónico es incorrecto.", "Error", MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(txtTelefono.Text))
            {
                MostrarMensaje("Debes ingresar una Telefono.", "Advertencia", MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(txtBanco.Text))
            {
                MostrarMensaje("Debes ingresar una Banco.", "Advertencia", MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(txtCuenta.Text))
            {
                MostrarMensaje("Debes ingresar una Cuenta.", "Advertencia", MessageBoxIcon.Warning);
                return false;
            }

            // Todos los campos son válidos
            return true;
        }

        private void GuardarDatos()
        {
            if (Operacion == "Insertar")
            {
                con.CNAgregarProveedor(txtRazonSocial.Text, txtDni.Text, txtRuc.Text, txtDireccion.Text, txtEmail.Text, txtTelefono.Text, txtBanco.Text, txtCuenta.Text, ckbActivo.Checked ? "Activo" : "Inactivo");
                MostrarMensaje("Datos guardados correctamente.", "Éxito", MessageBoxIcon.Information);
            }
            else if (Operacion == "Update")
            {
                if (dtgProveedor.SelectedRows.Count > 0)
                {
                    txtRazonSocial.Text = dtgProveedor.CurrentRow.Cells["Razon Social"].Value.ToString();
                    txtDni.Text = dtgProveedor.CurrentRow.Cells["Dni"].Value.ToString();
                    txtRuc.Text = dtgProveedor.CurrentRow.Cells["Ruc"].Value.ToString();
                    txtDireccion.Text = dtgProveedor.CurrentRow.Cells["Direccion"].Value.ToString();
                    txtEmail.Text = dtgProveedor.CurrentRow.Cells["Email"].Value.ToString();
                    txtTelefono.Text = dtgProveedor.CurrentRow.Cells["Telefono"].Value.ToString();
                    txtBanco.Text = dtgProveedor.CurrentRow.Cells["Banco"].Value.ToString();
                    txtCuenta.Text = dtgProveedor.CurrentRow.Cells["Cuenta"].Value.ToString();
                    ckbActivo.Text = dtgProveedor.CurrentRow.Cells["Estado"].Value.ToString();
                }
                else
                {
                    con.CNActualizarProveedor(Convert.ToInt32(_proveedor), txtRazonSocial.Text, txtDni.Text, txtRuc.Text, txtDireccion.Text, txtEmail.Text, txtTelefono.Text, txtBanco.Text, txtCuenta.Text, ckbActivo.Checked ? "Activo" : "Inactivo");
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

        private void FrmProveedores_Load(object sender, EventArgs e)
        {
            mostrados();
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            Reporte.Frm_Rpt_Proveedores frm_Rpt_Proveedores = new Reporte.Frm_Rpt_Proveedores();
            frm_Rpt_Proveedores.ShowDialog();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string busqueda = txtBuscar.Text;
            DataTable Resultado = con.CNBuscar(busqueda);

            dtgProveedor.DataSource = Resultado;
        }

        private void txtRazonSocial_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            {
                txtDni.Focus();
                e.Handled = true; // Evita que se genere el sonido de Windows al presionar Enter
                MessageBox.Show("Se ha cambiado al campo de Dni.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Si el campo ya tiene 16 caracteres y no es una tecla de control, se ignora la entrada
            if (txtDni.TextLength == 16 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("El DNI debe tener exactamente 16 caracteres.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Verificar si se ingresó un carácter que no es un dígito
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Evitar que se ingresen caracteres no numéricos
                MessageBox.Show("Ingrese solo números para el DNI.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Si se presiona Enter, cambiar el foco al siguiente control
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Cambiar el foco al siguiente control
                // Por ejemplo, si el siguiente control es txtTelefono, reemplaza "siguienteControl" con "txtTelefono"
                txtRuc.Focus();
                e.Handled = true; // Evitar que se genere el sonido de Windows al presionar Enter
                MessageBox.Show("Se ha cambiado al campo Ruc.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtRuc_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Si el campo ya tiene 16 caracteres y no es una tecla de control, se ignora la entrada
            if (txtRuc.TextLength == 16 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("El RUC debe tener exactamente 16 caracteres.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Verificar si se ingresó un carácter que no es un dígito
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Evitar que se ingresen caracteres no numéricos
                MessageBox.Show("Ingrese solo números para el RUC.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Si se presiona Enter, cambiar el foco al siguiente control
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Cambiar el foco al siguiente control
                // Por ejemplo, si el siguiente control es txtEmail, reemplaza "siguienteControl" con "txtEmail"
                txtDireccion.Focus();
                e.Handled = true; // Evitar que se genere el sonido de Windows al presionar Enter
                MessageBox.Show("Se ha cambiado al campo Direccion.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Cambiar el foco al siguiente control
                // Por ejemplo, si el siguiente control es txtEmail, reemplaza "siguienteControl" con "txtEmail"
                txtEmail.Focus();
                e.Handled = true; // Evitar que se genere el sonido de Windows al presionar Enter
                MessageBox.Show("Se ha cambiado al campo Email.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si se ingresó un carácter válido para un correo electrónico
            if (!IsValidEmailCharacter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Evitar que se ingresen caracteres no permitidos
                MessageBox.Show("Ingrese solo caracteres válidos para un correo electrónico.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Si se presiona Enter, cambiar el foco al siguiente control
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Cambiar el foco al siguiente control
                // Por ejemplo, si el siguiente control es txtNombre, reemplaza "siguienteControl" con "txtNombre"
                txtTelefono.Focus();
                e.Handled = true; // Evitar que se genere el sonido de Windows al presionar Enter
                MessageBox.Show("Se ha cambiado al campo Telefono.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool IsValidEmailCharacter(char character)
        {
            // Definir la expresión regular para validar un carácter de correo electrónico
            string pattern = @"[a-zA-Z0-9._%+-@]";
            Regex regex = new Regex(pattern);

            // Verificar si el carácter coincide con la expresión regular
            return regex.IsMatch(character.ToString());
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
                txtBanco.Focus();
                e.Handled = true; // Evitar que se genere el sonido de Windows al presionar Enter
                MessageBox.Show("Se ha cambiado al campo Banco de Referencia.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtBanco_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir letras, números, espacios en blanco y guiones
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != '-' && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Por favor, ingrese solo letras, números, espacios en blanco o guiones.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // Si se presiona Enter, cambiar el foco al siguiente control
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Cambiar el foco al siguiente control
                // Por ejemplo, si el siguiente control es txtRuc, reemplaza "siguienteControl" con "txtRuc"
                txtCuenta.Focus();
                e.Handled = true; // Evitar que se genere el sonido de Windows al presionar Enter
                MessageBox.Show("Se ha cambiado al campo Cuenta.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void txtCuenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números, guiones y espacios en blanco
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '-' && e.KeyChar != ' ' && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Por favor, ingrese solo números, guiones o espacios en blanco.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            // Si se presiona Enter, cambiar el foco al siguiente control
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Cambiar el foco al siguiente control
                // Por ejemplo, si el siguiente control es txtRuc, reemplaza "siguienteControl" con "txtRuc"
                btnGuardar.Focus();
                e.Handled = true; // Evitar que se genere el sonido de Windows al presionar Enter
                MessageBox.Show("Se ha cambiado al campo Guardar.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            if (dtgProveedor.SelectedRows.Count > 0)
            {
                _proveedor = dtgProveedor.CurrentRow.Cells["Codigo"].Value.ToString();
                con.CNEliminarProveedor(_proveedor);
                MessageBox.Show("Eliminado correctamente", "Mensaje", MessageBoxButtons.OK);
                mostrados();
            }
        }

        private void btnNuevo_Click_1(object sender, EventArgs e)
        {
            limpiar();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            //btnNuevo.Enabled = true;
            //if (Operacion == "Insertar")
            //{
            //    con.CNAgregarProveedor(txtRazonSocial.Text, txtDni.Text, txtRuc.Text, txtDireccion.Text, txtEmail.Text, txtTelefono.Text, txtBanco.Text, txtCuenta.Text,  ckbActivo.Checked ? "Activo" : "Inactivo");
            //}
            //else if (Operacion == "Update")
            //{

            //    if (dtgProveedor.SelectedRows.Count > 0)
            //    {
            //        txtRazonSocial.Text = dtgProveedor.CurrentRow.Cells["Razon Social"].Value.ToString();
            //        txtDni.Text = dtgProveedor.CurrentRow.Cells["Dni"].Value.ToString();
            //        txtRuc.Text = dtgProveedor.CurrentRow.Cells["Ruc"].Value.ToString();
            //        txtDireccion.Text = dtgProveedor.CurrentRow.Cells["Direccion"].Value.ToString();
            //        txtEmail.Text = dtgProveedor.CurrentRow.Cells["Email"].Value.ToString();
            //        txtTelefono.Text = dtgProveedor.CurrentRow.Cells["Telefono"].Value.ToString();
            //        txtBanco.Text = dtgProveedor.CurrentRow.Cells["Banco"].Value.ToString();
            //        txtCuenta.Text = dtgProveedor.CurrentRow.Cells["Cuenta"].Value.ToString();
            //        ckbActivo.Text = dtgProveedor.CurrentRow.Cells["Estado"].Value.ToString();


            //    }
            //    else
            //    {
            //        con.CNActualizarProveedor(Convert.ToInt32(_proveedor), txtRazonSocial.Text, txtDni.Text, txtRuc.Text, txtDireccion.Text, txtEmail.Text, txtTelefono.Text, txtBanco.Text, txtCuenta.Text, ckbActivo.Checked ? "Activo" : "Inactivo");
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

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            //Mirar();
        }

        private void dtgProveedor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = dtgProveedor.CurrentCell.RowIndex;

            Operacion = "Update";
            _proveedor = dtgProveedor[0, fila].Value.ToString();
            txtRazonSocial.Text = dtgProveedor[1, fila].Value.ToString();
            txtDni.Text = dtgProveedor[2, fila].Value.ToString();
            txtRuc.Text = dtgProveedor[3, fila].Value.ToString();
            txtDireccion.Text = dtgProveedor[4, fila].Value.ToString();
            txtEmail.Text = dtgProveedor[5, fila].Value.ToString();
            txtTelefono.Text = dtgProveedor[6, fila].Value.ToString();
            txtBanco.Text = dtgProveedor[7, fila].Value.ToString();
            txtCuenta.Text = dtgProveedor[8, fila].Value.ToString();
            bool isActive = Convert.ToBoolean(dtgProveedor[9, fila].Value?.ToString() == "Activo");

            if (isActive)
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
