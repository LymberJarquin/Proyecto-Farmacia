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
    public partial class FrmEmpleados : Form
    {
        public FrmEmpleados()
        {
            InitializeComponent();
        }
        CN_Empleado con = new CN_Empleado();
        CE_Empleados obj = new CE_Empleados();
        private string _empleados = null;
        string Operacion = "Insertar";

        void limpiar()
        {
            txtNombres.Text = "";
            txtApellidos.Text = "";
            cmbSexo.Text = "";
            txtDni.Text = "";
            txtEmail.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            txtEspecialidad.Text = "";
            txtHora_Ingreso.Text = "";
            txtHora_Salida.Text = "";
            txtSueldo.Text = "";
            ckbActivo.Checked = false;
            Operacion = "Insertar";
        }

        public void mostrados()
        {
            dtgEmpleado.DataSource = con.CNObtenerEmpleado();
        }

        private void ListarUsuario()
        {
            CN_Empleado objProd = new CN_Empleado();
            cmbUsuario.DataSource = objProd.CNObtenerUsuario();
            cmbUsuario.DisplayMember = "idUsuario";
            cmbUsuario.ValueMember = "idUsuario";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //CN_Usuario cN_Usuario = new CN_Usuario();
            //long cod = cN_Usuario.NumeroCompra();
            //if (Operacion == "Insertar")
            //{
            //    con.CNAgregarEmpleado(txtNombres.Text, txtApellidos.Text, txtEspecialidad.Text, cmbSexo.Text, txtDni.Text, txtEmail.Text, Convert.ToInt32(txtTelefono.Text), txtDireccion.Text, txtHora_Ingreso.Text, txtHora_Salida.Text, Convert.ToDecimal(txtSueldo.Text), ckbActivo.Checked ? "Activo" : "Inactivo", Convert.ToInt32(cmbUsuario.SelectedValue));
            //}
            //else if (Operacion == "Update")
            //{
            //    if (dtgEmpleado.SelectedRows.Count > 0)
            //    {
            //        txtNombres.Text = dtgEmpleado.CurrentRow.Cells["Nombres"].Value.ToString();
            //        txtApellidos.Text = dtgEmpleado.CurrentRow.Cells["Apellidos"].Value.ToString();
            //        txtEspecialidad.Text = dtgEmpleado.CurrentRow.Cells["Especialidad"].Value.ToString();
            //        cmbSexo.Text = dtgEmpleado.CurrentRow.Cells["Sexo"].Value.ToString();
            //        txtDni.Text = dtgEmpleado.CurrentRow.Cells["Dni"].Value.ToString();                    
            //        txtEmail.Text = dtgEmpleado.CurrentRow.Cells["Email"].Value.ToString();
            //        txtDireccion.Text = dtgEmpleado.CurrentRow.Cells["Direccion"].Value.ToString();
            //        txtTelefono.Text = dtgEmpleado.CurrentRow.Cells["Telefono"].Value.ToString();
            //        txtHora_Ingreso.Text = dtgEmpleado.CurrentRow.Cells["Hora de Ingreso"].Value.ToString();
            //        txtHora_Salida.Text = dtgEmpleado.CurrentRow.Cells["Hora de Salida"].Value.ToString();
            //        txtSueldo.Text = dtgEmpleado.CurrentRow.Cells["Sueldo"].Value.ToString();
            //        ckbActivo.Text = dtgEmpleado.CurrentRow.Cells["Estado"].Value.ToString();
            //        cmbUsuario.SelectedValue = dtgEmpleado.CurrentRow.Cells["idUsuario"].Value.ToString();

            //    }
            //    else
            //    {
            //        con.CNActualizarEmpleado(Convert.ToInt32(_empleados), txtNombres.Text, txtApellidos.Text, txtEspecialidad.Text, cmbSexo.Text, txtDni.Text, txtEmail.Text, Convert.ToInt32(txtTelefono.Text), txtDireccion.Text, txtHora_Ingreso.Text, txtHora_Salida.Text, Convert.ToDecimal(txtSueldo.Text),ckbActivo.Checked ? "Activo" : "Inactivo", Convert.ToInt32(cmbUsuario.SelectedValue));
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
            // Validar cada campo individualmente
            if (string.IsNullOrEmpty(txtNombres.Text))
            {
                MostrarMensaje("Debes ingresar un Nombres.", "Advertencia", MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(txtApellidos.Text))
            {
                MostrarMensaje("Debes ingresar un Apellidos.", "Advertencia", MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(txtEspecialidad.Text))
            {
                MostrarMensaje("Debes seleccionar un Especialidad.", "Advertencia", MessageBoxIcon.Warning);
                return false;
            }

            if (cmbSexo.SelectedIndex == -1)
            {
                MostrarMensaje("Debes ingresar un Sexo.", "Advertencia", MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(txtDni.Text))
            {
                MostrarMensaje("Debes ingresar un Dni.", "Advertencia", MessageBoxIcon.Warning);
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
                MostrarMensaje("Debes ingresar un Telefono.", "Advertencia", MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(txtDireccion.Text))
            {
                MostrarMensaje("Debes ingresar una Direccion.", "Advertencia", MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(txtHora_Ingreso.Text))
            {
                MostrarMensaje("Debes ingresar una Hora Ingreso.", "Advertencia", MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(txtHora_Salida.Text))
            {
                MostrarMensaje("Debes ingresar una Hora Salida.", "Advertencia", MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(txtSueldo.Text))
            {
                MostrarMensaje("Debes ingresar una Sueldo.", "Advertencia", MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(cmbUsuario.Text))
            {
                MostrarMensaje("Debes ingresar una Usuario.", "Advertencia", MessageBoxIcon.Warning);
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
                con.CNAgregarEmpleado(txtNombres.Text, txtApellidos.Text, txtEspecialidad.Text, cmbSexo.Text, txtDni.Text, txtEmail.Text, Convert.ToInt32(txtTelefono.Text), txtDireccion.Text, txtHora_Ingreso.Text, txtHora_Salida.Text, Convert.ToDecimal(txtSueldo.Text), ckbActivo.Checked ? "Activo" : "Inactivo", Convert.ToInt32(cmbUsuario.SelectedValue));
                MostrarMensaje("Datos guardados correctamente.", "Éxito", MessageBoxIcon.Information);
            }
            else if (Operacion == "Update")
            {
                if (dtgEmpleado.SelectedRows.Count > 0)
                {
                    txtNombres.Text = dtgEmpleado.CurrentRow.Cells["Nombres"].Value.ToString();
                    txtApellidos.Text = dtgEmpleado.CurrentRow.Cells["Apellidos"].Value.ToString();
                    txtEspecialidad.Text = dtgEmpleado.CurrentRow.Cells["Especialidad"].Value.ToString();
                    cmbSexo.Text = dtgEmpleado.CurrentRow.Cells["Sexo"].Value.ToString();
                    txtDni.Text = dtgEmpleado.CurrentRow.Cells["Dni"].Value.ToString();
                    txtEmail.Text = dtgEmpleado.CurrentRow.Cells["Email"].Value.ToString();
                    txtDireccion.Text = dtgEmpleado.CurrentRow.Cells["Direccion"].Value.ToString();
                    txtTelefono.Text = dtgEmpleado.CurrentRow.Cells["Telefono"].Value.ToString();
                    txtHora_Ingreso.Text = dtgEmpleado.CurrentRow.Cells["Hora de Ingreso"].Value.ToString();
                    txtHora_Salida.Text = dtgEmpleado.CurrentRow.Cells["Hora de Salida"].Value.ToString();
                    txtSueldo.Text = dtgEmpleado.CurrentRow.Cells["Sueldo"].Value.ToString();
                    ckbActivo.Text = dtgEmpleado.CurrentRow.Cells["Estado"].Value.ToString();
                    cmbUsuario.SelectedValue = dtgEmpleado.CurrentRow.Cells["idUsuario"].Value.ToString();

                }
                else
                {
                    con.CNActualizarEmpleado(Convert.ToInt32(_empleados), txtNombres.Text, txtApellidos.Text, txtEspecialidad.Text, cmbSexo.Text, txtDni.Text, txtEmail.Text, Convert.ToInt32(txtTelefono.Text), txtDireccion.Text, txtHora_Ingreso.Text, txtHora_Salida.Text, Convert.ToDecimal(txtSueldo.Text), ckbActivo.Checked ? "Activo" : "Inactivo", Convert.ToInt32(cmbUsuario.SelectedValue));
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

        private void FrmEmpleados_Load(object sender, EventArgs e)
        {
            mostrados();
            limpiar();
            ListarUsuario();
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
            if (dtgEmpleado.SelectedRows.Count > 0)
            {
                _empleados = dtgEmpleado.CurrentRow.Cells["Codigo"].Value.ToString();
                con.CNEliminarEmpleado(_empleados);
                MessageBox.Show("Eliminado correctamente", "Mensaje", MessageBoxButtons.OK);
                mostrados();
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            Reporte.Frm_Rpt_Empleados frm_Rpt_Empleados = new Reporte.Frm_Rpt_Empleados();
            frm_Rpt_Empleados.ShowDialog();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string busqueda = txtBuscar.Text;
            DataTable Resultado = con.CN_Buscar(busqueda);

            dtgEmpleado.DataSource = Resultado;

        }

        private void txtNombres_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Evita que se ingrese caracteres no permitidos
                MessageBox.Show("Ingrese solo letras para la Nombres.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (e.KeyChar == (char)Keys.Enter)
            {
                txtApellidos.Focus();
                e.Handled = true; // Evita que se genere el sonido de Windows al presionar Enter
                MessageBox.Show("Se ha cambiado al campo de Apellidos.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtApellidos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Evita que se ingrese caracteres no permitidos
                MessageBox.Show("Ingrese solo letras para la Apellidos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (e.KeyChar == (char)Keys.Enter)
            {
                txtEspecialidad.Focus();
                e.Handled = true; // Evita que se genere el sonido de Windows al presionar Enter
                MessageBox.Show("Se ha cambiado al campo de Especialidad.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtEspecialidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Evita que se ingrese caracteres no permitidos
                MessageBox.Show("Ingrese solo letras para la Especialidad.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (e.KeyChar == (char)Keys.Enter)
            {
                cmbSexo.Focus();
                e.Handled = true; // Evita que se genere el sonido de Windows al presionar Enter
                MessageBox.Show("Se ha cambiado al campo de Sexo.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cmbSexo_KeyPress(object sender, KeyPressEventArgs e)
        {
            char inputChar = char.ToUpper(e.KeyChar); // Convertir el carácter a mayúscula

            if (inputChar != 'M' && inputChar != 'F' && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Evitar que se ingresen caracteres no permitidos
                MessageBox.Show("Ingrese solo 'M' o 'F' para el Sexo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (e.KeyChar == (char)Keys.Enter)
            {
                txtDni.Focus();
                e.Handled = true; // Evitar que se genere el sonido de Windows al presionar Enter
                MessageBox.Show("Se ha cambiado al campo de DNI.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                txtDireccion.Focus();
                e.Handled = true; // Evitar que se genere el sonido de Windows al presionar Enter
                MessageBox.Show("Se ha cambiado al campo Direccion.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtHora_Ingreso.Focus();
                e.Handled = true; // Evita que se genere el sonido de Windows al presionar Enter
                MessageBox.Show("Se ha cambiado al campo de Hora Ingreso.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtHora_Ingreso_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solamente números, tecla de retroceso y el carácter de dos puntos (:) para la hora
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ':')
            {
                e.Handled = true;
                MessageBox.Show("Por favor, ingrese solo números y el carácter ':' para la hora.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // Si se presiona Enter, cambiar el foco al siguiente control
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Cambiar el foco al siguiente control
                // Por ejemplo, si el siguiente control es txtRuc, reemplaza "siguienteControl" con "txtRuc"
                txtHora_Salida.Focus();
                e.Handled = true; // Evitar que se genere el sonido de Windows al presionar Enter
                MessageBox.Show("Se ha cambiado al campo Hora Salida.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtHora_Salida_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solamente números, tecla de retroceso y el carácter de dos puntos (:) para la hora
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ':')
            {
                e.Handled = true;
                MessageBox.Show("Por favor, ingrese solo números y el carácter ':' para la hora.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // Si se presiona Enter, cambiar el foco al siguiente control
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Cambiar el foco al siguiente control
                // Por ejemplo, si el siguiente control es txtRuc, reemplaza "siguienteControl" con "txtRuc"
                txtSueldo.Focus();
                e.Handled = true; // Evitar que se genere el sonido de Windows al presionar Enter
                MessageBox.Show("Se ha cambiado al campo Hora Sueldo.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtSueldo_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solamente números, tecla de retroceso y el carácter de punto (.) para el sueldo
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
                MessageBox.Show("Por favor, ingrese solo números y el carácter '.' para el sueldo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // Permitir solamente un punto decimal
            if (e.KeyChar == '.' && (sender as TextBox).Text.Contains('.'))
            {
                e.Handled = true;
                MessageBox.Show("El sueldo solo puede contener un punto decimal.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // Si se presiona Enter, cambiar el foco al siguiente control
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Cambiar el foco al siguiente control
                // Por ejemplo, si el siguiente control es txtRuc, reemplaza "siguienteControl" con "txtRuc"
                cmbUsuario.Focus();
                e.Handled = true; // Evitar que se genere el sonido de Windows al presionar Enter
                MessageBox.Show("Se ha cambiado al campo Hora Usuario.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cmbUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir letras, números y ciertos caracteres especiales
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != '_' && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Por favor, ingrese solo letras, números o guiones bajos (_).", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void dtgEmpleado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = dtgEmpleado.CurrentCell.RowIndex;

            Operacion = "Update";
            _empleados = dtgEmpleado[0, fila].Value.ToString();
            txtNombres.Text = dtgEmpleado[1, fila].Value.ToString();
            txtApellidos.Text = dtgEmpleado[2, fila].Value.ToString();
            cmbSexo.Text = dtgEmpleado[4, fila].Value.ToString();
            txtDni.Text = dtgEmpleado[5, fila].Value.ToString();
            txtEmail.Text = dtgEmpleado[6, fila].Value.ToString();
            txtDireccion.Text = dtgEmpleado[8, fila].Value.ToString();
            txtTelefono.Text = dtgEmpleado[7, fila].Value.ToString();
            txtEspecialidad.Text = dtgEmpleado[3, fila].Value.ToString();
            txtHora_Ingreso.Text = dtgEmpleado[9, fila].Value.ToString();
            txtHora_Salida.Text = dtgEmpleado[10, fila].Value.ToString();
            txtSueldo.Text = dtgEmpleado[11, fila].Value.ToString();
            cmbUsuario.Text = dtgEmpleado[13, fila].Value.ToString();

            //int indiceUsuario = Convert.ToInt32(dtgEmpleado[13, fila].Value); // Supongo que el valor en la celda es un índice numérico
            //if (indiceUsuario >= 0 && indiceUsuario < cmbUsuario.Items.Count)
            //{
            //    cmbUsuario.SelectedIndex = indiceUsuario;
            //}

            if (dtgEmpleado[12, fila].Value.ToString() == "Activo")
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
