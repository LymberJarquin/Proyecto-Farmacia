using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapasEntidad;
using CapasNegocio;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Farmacia_Tutorial.Vistas
{
    public partial class FrmCliente : Form
    {
        public FrmCliente()
        {
            InitializeComponent();
        }

        CN_Cliente con = new CN_Cliente();
        CE_Clientes obj = new CE_Clientes();
        private string _clientes = null;
        string Operacion = "Insertar";
        void limpiar()
        {
            txtNombres.Text = "";
            txtApellidos.Text = "";
            cmbSexo.Text = "";
            txtDni.Text = "";
            txtTelefono.Text = "";
            txtRuc.Text = "";
            txtEmail.Text = "";
            txtDireccion.Text = "";
            Operacion = "Insertar";
        }

        public void mostrados()
        {
            dtgClientes.DataSource = con.CNObtenerClientess();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //if (txtNombres.Text == "")
            //    MessageBox.Show("debes ingresar una Nombres.","Advertencia", MessageBoxButtons.OK,MessageBoxIcon.Warning);
            //if (txtApellidos.Text == "")
            //    MessageBox.Show("debes ingresar una Apellidos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //if (cmbSexo.SelectedIndex == -1)
            //    MessageBox.Show("debes ingresar una Sexo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //if (txtDni.Text == "")
            //    MessageBox.Show("debes ingresar una Dni.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //if (txtTelefono.Text == "")
            //    MessageBox.Show("debes ingresar una Telefono.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //if (txtRuc.Text == "")
            //    MessageBox.Show("debes ingresar una Ruc.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //if (string.IsNullOrEmpty(txtEmail.Text))
            //{
            //    MessageBox.Show("¡Debes ingresar un correo electrónico!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            //// Si el campo de correo electrónico no está vacío, validar su formato
            //else
            //{
            //    // Validando el formato del correo electrónico
            //    Regex regex = new Regex(@"[^@\s]+@[^@\s]+\.[^@\s]+$");
            //    bool isValidEmail = regex.IsMatch(txtEmail.Text);
            //    if (!isValidEmail)
            //    {
            //        MessageBox.Show("¡El formato del correo electrónico es incorrecto!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //    else
            //    {
            //        // Si el correo electrónico tiene un formato válido, mostrar un mensaje de éxito
            //        MessageBox.Show("¡Datos guardados correctamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
            //if (txtDireccion.Text == "")
            //    MessageBox.Show("debes ingresar una Direccion.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //else
            //{


            //    if (Operacion == "Insertar")
            //    {
            //        con.CNAgregarClientes1(txtNombres.Text, txtApellidos.Text, cmbSexo.Text, txtDni.Text, txtTelefono.Text, txtRuc.Text, txtEmail.Text, txtDireccion.Text);
            //        MessageBox.Show("Insertar correcto", "Mensaje");
            //    }
            //    else if (Operacion == "Update")
            //    {
            //        if (dtgClientes.SelectedRows.Count > 0)
            //        {
            //            txtNombres.Text = dtgClientes.CurrentRow.Cells["Nombres"].Value.ToString();
            //            txtApellidos.Text = dtgClientes.CurrentRow.Cells["Apellidos"].Value.ToString();
            //            cmbSexo.Text = dtgClientes.CurrentRow.Cells["Sexo"].Value.ToString();
            //            txtDni.Text = dtgClientes.CurrentRow.Cells["Dni"].Value.ToString();
            //            txtTelefono.Text = dtgClientes.CurrentRow.Cells["Telefono"].Value.ToString();
            //            txtRuc.Text = dtgClientes.CurrentRow.Cells["Ruc"].Value.ToString();
            //            txtEmail.Text = dtgClientes.CurrentRow.Cells["Email"].Value.ToString();
            //            txtDireccion.Text = dtgClientes.CurrentRow.Cells["Direccion"].Value.ToString();
            //        }
            //        else
            //        {
            //            con.CNActualizarClientes(Convert.ToInt32(_clientes), txtNombres.Text, txtApellidos.Text, cmbSexo.Text, txtDni.Text, txtTelefono.Text, txtRuc.Text, txtEmail.Text, txtDireccion.Text);
            //            MessageBox.Show("Update correcto", "Mensaje");
            //            Operacion = "Insertar";
            //        }
            //    }
            //}
            //    limpiar();
            //    mostrados();
            //    


            if (!ValidarCampos())
                return;

            GuardarDatos();


        }

        private bool ValidarCampos()
        {
            // Validar cada campo individualmente
            //if (string.IsNullOrEmpty(txtNombres.Text))
            //{
            //    MostrarMensaje("Debes ingresar un Nombre.", "Advertencia", MessageBoxIcon.Warning);
            //    return false;
            //}

            //if (string.IsNullOrEmpty(txtApellidos.Text))
            //{
            //    MostrarMensaje("Debes ingresar un Apellido.", "Advertencia", MessageBoxIcon.Warning);
            //    return false;
            //}

            //if (cmbSexo.SelectedIndex == -1)
            //{
            //    MostrarMensaje("Debes seleccionar un Sexo.", "Advertencia", MessageBoxIcon.Warning);
            //    return false;
            //}

            //if (string.IsNullOrEmpty(txtDni.Text))
            //{
            //    MostrarMensaje("Debes ingresar un DNI.", "Advertencia", MessageBoxIcon.Warning);
            //    return false;
            //}

            //if (string.IsNullOrEmpty(txtTelefono.Text))
            //{
            //    MostrarMensaje("Debes ingresar un Teléfono.", "Advertencia", MessageBoxIcon.Warning);
            //    return false;
            //}

            //if (string.IsNullOrEmpty(txtRuc.Text))
            //{
            //    MostrarMensaje("Debes ingresar un RUC.", "Advertencia", MessageBoxIcon.Warning);
            //    return false;
            //}

            //if (string.IsNullOrEmpty(txtEmail.Text))
            //{
            //    MostrarMensaje("Debes ingresar un Correo Electrónico.", "Advertencia", MessageBoxIcon.Warning);
            //    return false;
            //}

            //// Validar formato del correo electrónico
            //Regex regex = new Regex(@"[^@\s]+@[^@\s]+\.[^@\s]+$");
            //if (!regex.IsMatch(txtEmail.Text))
            //{
            //    MostrarMensaje("El formato del correo electrónico es incorrecto.", "Error", MessageBoxIcon.Error);
            //    return false;
            //}

            //if (string.IsNullOrEmpty(txtDireccion.Text))
            //{
            //    MostrarMensaje("Debes ingresar una Dirección.", "Advertencia", MessageBoxIcon.Warning);
            //    return false;
            //}

            // Todos los campos son válidos
            return true;
        }

        private void GuardarDatos()
        {
            if (Operacion == "Insertar")
            {
                con.CNAgregarClientes1(txtNombres.Text, txtApellidos.Text, cmbSexo.Text, txtDni.Text, txtTelefono.Text, txtRuc.Text, txtEmail.Text, txtDireccion.Text);
                MostrarMensaje("Datos guardados correctamente.", "Éxito", MessageBoxIcon.Information);
            }
            else if (Operacion == "Update")
            {
                if (dtgClientes.SelectedRows.Count > 0)
                {
                    txtNombres.Text = dtgClientes.CurrentRow.Cells["Nombres"].Value.ToString();
                    txtApellidos.Text = dtgClientes.CurrentRow.Cells["Apellidos"].Value.ToString();
                    cmbSexo.Text = dtgClientes.CurrentRow.Cells["Sexo"].Value.ToString();
                    txtDni.Text = dtgClientes.CurrentRow.Cells["Dni"].Value.ToString();
                    txtTelefono.Text = dtgClientes.CurrentRow.Cells["Telefono"].Value.ToString();
                    txtRuc.Text = dtgClientes.CurrentRow.Cells["Ruc"].Value.ToString();
                    txtEmail.Text = dtgClientes.CurrentRow.Cells["Email"].Value.ToString();
                    txtDireccion.Text = dtgClientes.CurrentRow.Cells["Direccion"].Value.ToString();
                }
                else
                {
                    con.CNActualizarClientes(Convert.ToInt32(_clientes), txtNombres.Text, txtApellidos.Text, cmbSexo.Text, txtDni.Text, txtTelefono.Text, txtRuc.Text, txtEmail.Text, txtDireccion.Text);
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

        private void btnMostrar_Todo_Click(object sender, EventArgs e)
        {
            mostrados();
        }

        private void FrmCliente_Load(object sender, EventArgs e)
        {
            mostrados();
            limpiar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
           
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dtgClientes.SelectedRows.Count > 0)
            {
                _clientes = dtgClientes.CurrentRow.Cells["Codigo"].Value.ToString();
                con.CNEliminarClientess(_clientes);
                MessageBox.Show("Eliminado correctamente", "Mensaje", MessageBoxButtons.OK);
                mostrados();
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            Reporte.Frm_Rpt_Clientes frm_Rpt_Clientes = new Reporte.Frm_Rpt_Clientes();
            frm_Rpt_Clientes.ShowDialog();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string busqueda = txtBuscar.Text;
            DataTable Resultado = con.CN_Buscar(busqueda);

            dtgClientes.DataSource = Resultado;

        }

        private void txtBuscar_TextChanged_1(object sender, EventArgs e)
        {
            string busqueda = txtBuscar.Text;
            DataTable Resultado = con.CN_Buscar(busqueda);

            dtgClientes.DataSource = Resultado;
        }

        private void dtgClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = dtgClientes.CurrentCell.RowIndex;

            Operacion = "Update";
            _clientes = dtgClientes[0, fila].Value.ToString();
            txtNombres.Text = dtgClientes[1, fila].Value.ToString();
            txtApellidos.Text = dtgClientes[2, fila].Value.ToString();
            cmbSexo.Text = dtgClientes[3, fila].Value.ToString();
            txtDni.Text = dtgClientes[4, fila].Value.ToString();
            txtTelefono.Text = dtgClientes[5, fila].Value.ToString();
            txtRuc.Text = dtgClientes[6, fila].Value.ToString();
            txtEmail.Text = dtgClientes[7, fila].Value.ToString();
            txtDireccion.Text = dtgClientes[8, fila].Value.ToString();
        }

        //private void txtNombres_KeyPress(object sender, KeyPressEventArgs e)
        //{

        //    if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
        //    {
        //        e.Handled = true; // Evita que se ingrese caracteres no permitidos
        //        MessageBox.Show("Ingrese solo letras para la Nombres.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }

        //    if (e.KeyChar == (char)Keys.Enter)
        //    {
        //        txtApellidos.Focus();
        //        e.Handled = true; // Evita que se genere el sonido de Windows al presionar Enter
        //        MessageBox.Show("Se ha cambiado al campo de Apellidos.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}

        //private void txtApellidos_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
        //    {
        //        e.Handled = true; // Evita que se ingrese caracteres no permitidos
        //        MessageBox.Show("Ingrese solo letras para la Apellidos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }

        //    if (e.KeyChar == (char)Keys.Enter)
        //    {
        //        cmbSexo.Focus();
        //        e.Handled = true; // Evita que se genere el sonido de Windows al presionar Enter
        //        MessageBox.Show("Se ha cambiado al campo de Sexo.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}

        //private void cmbSexo_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    char inputChar = char.ToUpper(e.KeyChar); // Convertir el carácter a mayúscula

        //    if (inputChar != 'M' && inputChar != 'F' && !char.IsControl(e.KeyChar))
        //    {
        //        e.Handled = true; // Evitar que se ingresen caracteres no permitidos
        //        MessageBox.Show("Ingrese solo 'M' o 'F' para el Sexo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }

        //    if (e.KeyChar == (char)Keys.Enter)
        //    {
        //        txtDni.Focus();
        //        e.Handled = true; // Evitar que se genere el sonido de Windows al presionar Enter
        //        MessageBox.Show("Se ha cambiado al campo de DNI.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}

        //private void txtDni_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    // Si el campo ya tiene 16 caracteres y no es una tecla de control, se ignora la entrada
        //    if (txtDni.TextLength == 16 && !char.IsControl(e.KeyChar))
        //    {
        //        e.Handled = true;
        //        MessageBox.Show("El DNI debe tener exactamente 16 caracteres.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }

        //    // Verificar si se ingresó un carácter que no es un dígito
        //    if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
        //    {
        //        e.Handled = true; // Evitar que se ingresen caracteres no numéricos
        //        MessageBox.Show("Ingrese solo números para el DNI.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }

        //    // Si se presiona Enter, cambiar el foco al siguiente control
        //    if (e.KeyChar == (char)Keys.Enter)
        //    {
        //        // Cambiar el foco al siguiente control
        //        // Por ejemplo, si el siguiente control es txtTelefono, reemplaza "siguienteControl" con "txtTelefono"
        //        txtTelefono.Focus();
        //        e.Handled = true; // Evitar que se genere el sonido de Windows al presionar Enter
        //        MessageBox.Show("Se ha cambiado al campo Teléfono.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}

        //private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    // Si el campo ya tiene 8 caracteres y no es una tecla de control, se ignora la entrada
        //    if (txtTelefono.TextLength == 8 && !char.IsControl(e.KeyChar))
        //    {
        //        e.Handled = true;
        //        MessageBox.Show("El número de teléfono debe tener exactamente 8 caracteres.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }

        //    // Verificar si se ingresó un carácter que no es un dígito
        //    if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
        //    {
        //        e.Handled = true; // Evitar que se ingresen caracteres no numéricos
        //        MessageBox.Show("Ingrese solo números para el número de teléfono.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }

        //    // Si se presiona Enter, cambiar el foco al siguiente control
        //    if (e.KeyChar == (char)Keys.Enter)
        //    {
        //        // Cambiar el foco al siguiente control
        //        // Por ejemplo, si el siguiente control es txtRuc, reemplaza "siguienteControl" con "txtRuc"
        //        txtRuc.Focus();
        //        e.Handled = true; // Evitar que se genere el sonido de Windows al presionar Enter
        //        MessageBox.Show("Se ha cambiado al campo RUC.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}

        //private void txtRuc_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    // Si el campo ya tiene 16 caracteres y no es una tecla de control, se ignora la entrada
        //    if (txtRuc.TextLength == 16 && !char.IsControl(e.KeyChar))
        //    {
        //        e.Handled = true;
        //        MessageBox.Show("El RUC debe tener exactamente 16 caracteres.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }

        //    // Verificar si se ingresó un carácter que no es un dígito
        //    if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
        //    {
        //        e.Handled = true; // Evitar que se ingresen caracteres no numéricos
        //        MessageBox.Show("Ingrese solo números para el RUC.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }

        //    // Si se presiona Enter, cambiar el foco al siguiente control
        //    if (e.KeyChar == (char)Keys.Enter)
        //    {
        //        // Cambiar el foco al siguiente control
        //        // Por ejemplo, si el siguiente control es txtEmail, reemplaza "siguienteControl" con "txtEmail"
        //        txtEmail.Focus();
        //        e.Handled = true; // Evitar que se genere el sonido de Windows al presionar Enter
        //        MessageBox.Show("Se ha cambiado al campo Email.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}

        //private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    // Verificar si se ingresó un carácter válido para un correo electrónico
        //    if (!IsValidEmailCharacter(e.KeyChar) && !char.IsControl(e.KeyChar))
        //    {
        //        e.Handled = true; // Evitar que se ingresen caracteres no permitidos
        //        MessageBox.Show("Ingrese solo caracteres válidos para un correo electrónico.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }

        //    // Si se presiona Enter, cambiar el foco al siguiente control
        //    if (e.KeyChar == (char)Keys.Enter)
        //    {
        //        // Cambiar el foco al siguiente control
        //        // Por ejemplo, si el siguiente control es txtNombre, reemplaza "siguienteControl" con "txtNombre"
        //        txtDireccion.Focus();
        //        e.Handled = true; // Evitar que se genere el sonido de Windows al presionar Enter
        //        MessageBox.Show("Se ha cambiado al campo Direccion.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}

        //private bool IsValidEmailCharacter(char character)
        //{
        //    // Definir la expresión regular para validar un carácter de correo electrónico
        //    string pattern = @"[a-zA-Z0-9._%+-@]";
        //    Regex regex = new Regex(pattern);

        //    // Verificar si el carácter coincide con la expresión regular
        //    return regex.IsMatch(character.ToString());
        //}

        //private void txtDireccion_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == (char)Keys.Enter)
        //    {
        //        btnGuardar.Focus();
        //        e.Handled = true; // Evita que se genere el sonido de Windows al presionar Enter
        //        MessageBox.Show("Se ha cambiado al campo de Guardar.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}
    }
}
