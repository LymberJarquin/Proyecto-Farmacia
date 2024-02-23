using CapasDatos;
using CapasEntidad;
using CapasNegocio;
using Microsoft.ReportingServices.ReportProcessing.OnDemandReportObjectModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Farmacia_Tutorial.Vistas
{
    public partial class FrmProductos : Form
    {
        int codlaboratorio;
        int codPresentacion;
        int codproducto;
        public FrmProductos()
        {
            InitializeComponent();
        }
        CN_Productos con1 = new CN_Productos();
        CE_Producto obj = new CE_Producto();
        private string _Producto;
        string Operacion = "Insertar";

        public void limpiar()
        {
            txtCodigoBarras.Text = "";
            txtDescripcion.Text = "";
            txtPresentacion.Text = "";
            txtConcentracion.Text = "";
            ckbActivo.Checked = false;
            txtStock.Text = "";
            txtCosto.Text = "";
            txtPrecio_Venta.Text = "";
            txtLaboratorio.Text = "";
            txtRegistro_Sanitario.Text = "";
            dtpFecha_Vencimiento.Text = "";
            Operacion = "Insertar";
        }

        public void mostrados()
        {
            dtgProducto.DataSource = con1.CNObtenerProducto();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //       if (Operacion == "Insertar")
            //       {
            //           con1.CNAgregarProducto(
            //               obj.Codigo_Barras = txtCodigoBarras.Text,
            //               obj.Descripcion = txtDescripcion.Text,
            //               obj.Concentracion = txtConcentracion.Text, 
            //               obj.Stock = Convert.ToDecimal(txtStock.Text),
            //               obj.Costo = Convert.ToDecimal(txtCosto.Text), 
            //               obj.Precio_Venta = Convert.ToDecimal(txtPrecio_Venta.Text), 
            //               obj.RegistroSanitario = txtRegistro_Sanitario.Text, 
            //               obj.FechaVencimiento = Convert.ToDateTime(dtpFecha_Vencimiento.Value),
            //               obj.Estado = ckbActivo.Checked ? "Activo" : "Inactivo", 
            //               obj.idPresentacion = Convert.ToInt32(codPresentacion), 
            //               obj.idLaboratorio = Convert.ToInt32(codlaboratorio));

            //           MessageBox.Show("REGRISTRO GUARDADO","Mensaje");
            //       }
            //       else if (Operacion == "Update")
            //       {
            //           if (dtgProducto.SelectedRows.Count > 0)
            //           {
            //               txtCodigoBarras.Text = dtgProducto.CurrentRow.Cells["Codigo_Barras"].Value.ToString();
            //               txtDescripcion.Text = dtgProducto.CurrentRow.Cells["Descripcion"].Value.ToString();
            //               txtConcentracion.Text = dtgProducto.CurrentRow.Cells["Concentracion"].Value.ToString();
            //               txtStock.Text = dtgProducto.CurrentRow.Cells["Stock"].Value.ToString();
            //               txtCosto.Text = dtgProducto.CurrentRow.Cells["Costo"].Value.ToString();
            //               txtPrecio_Venta.Text = dtgProducto.CurrentRow.Cells["Precio_Venta"].Value.ToString();
            //               txtRegistro_Sanitario.Text = dtgProducto.CurrentRow.Cells["Registro_Sanitario"].Value.ToString();
            //               dtpFecha_Vencimiento.Text = dtgProducto.CurrentRow.Cells["Fecha_Vencimiento"].Value.ToString();
            //               ckbActivo.Text = dtgProducto.CurrentRow.Cells["Estado"].Value.ToString();
            //             codPresentacion = Convert.ToInt32( txtPresentacion.Text =   dtgProducto.CurrentRow.Cells["Presentacion"].Value.ToString());
            //             codlaboratorio = Convert.ToInt32(  txtLaboratorio.Text =  dtgProducto.CurrentRow.Cells["Laboratorio"].Value.ToString());
            //           }
            //           else
            //           {
            //               con1.CNActualizarProducto(
            //                   obj.idProducto = Convert.ToInt32(_Producto),
            //                   obj.Codigo_Barras = txtCodigoBarras.Text,
            //               obj.Descripcion = txtDescripcion.Text,
            //               obj.Concentracion = txtConcentracion.Text,
            //               obj.Stock = Convert.ToDecimal(txtStock.Text),
            //               obj.Costo = Convert.ToDecimal(txtCosto.Text),
            //               obj.Precio_Venta = Convert.ToDecimal(txtPrecio_Venta.Text),
            //               obj.RegistroSanitario = txtRegistro_Sanitario.Text,
            //               obj.FechaVencimiento = Convert.ToDateTime(dtpFecha_Vencimiento.Value),
            //               obj.Estado = ckbActivo.Checked ? "Activo" : "Inactivo",
            //               obj.idPresentacion = Convert.ToInt32(codPresentacion),
            //               obj.idLaboratorio = Convert.ToInt32(codlaboratorio)
            //);

            //               MessageBox.Show("REGISTRO MODIFICADO", "Mensaje");
            //               Operacion = "Insertar";
            //           }
            //       }
            //       limpiar();
            //       mostrados();


            if (!ValidarCampos())
                return;

            GuardarDatos();
        }

        private bool ValidarCampos()
        {
            // Validar cada campo individualmente
            if (string.IsNullOrEmpty(txtCodigoBarras.Text))
            {
                MostrarMensaje("Debes ingresar un Codigo de barras.", "Advertencia", MessageBoxIcon.Warning);
                return false;
            }

            //if (string.IsNullOrEmpty(txtDescripcion.Text))
            //{
            //    MostrarMensaje("Debes ingresar un Descripcion.", "Advertencia", MessageBoxIcon.Warning);
            //    return false;
            //}

            //if (string.IsNullOrEmpty(txtPresentacion.Text))
            //{
            //    MostrarMensaje("Debes seleccionar un Presentacion.", "Advertencia", MessageBoxIcon.Warning);
            //    return false;
            //}

            //if (string.IsNullOrEmpty(txtConcentracion.Text))
            //{
            //    MostrarMensaje("Debes ingresar un Concentracion.", "Advertencia", MessageBoxIcon.Warning);
            //    return false;
            //}

            //if (string.IsNullOrEmpty(txtStock.Text))
            //{
            //    MostrarMensaje("Debes ingresar un Stock.", "Advertencia", MessageBoxIcon.Warning);
            //    return false;
            //}

            //if (string.IsNullOrEmpty(txtCosto.Text))
            //{
            //    MostrarMensaje("Debes ingresar un Costo.", "Advertencia", MessageBoxIcon.Warning);
            //    return false;
            //}

            //if (string.IsNullOrEmpty(txtPrecio_Venta.Text))
            //{
            //    MostrarMensaje("Debes ingresar un Precio Venta.", "Advertencia", MessageBoxIcon.Warning);
            //    return false;
            //}

            //if (string.IsNullOrEmpty(txtLaboratorio.Text))
            //{
            //    MostrarMensaje("Debes ingresar una Laboratorio.", "Advertencia", MessageBoxIcon.Warning);
            //    return false;
            //}

            //if (string.IsNullOrEmpty(txtRegistro_Sanitario.Text))
            //{
            //    MostrarMensaje("Debes ingresar una Registro Sanitario.", "Advertencia", MessageBoxIcon.Warning);
            //    return false;
            //}

            //// Validar que la fecha de vencimiento no esté vacía
            //if (dtpFecha_Vencimiento.Value == DateTime.MinValue)
            //{
            //    MostrarMensaje("Debes ingresar una Fecha de Vencimiento.", "Advertencia", MessageBoxIcon.Warning);
            //    return false;
            //}

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
                con1.CNAgregarProducto(
                    obj.Codigo_Barras = txtCodigoBarras.Text,
                    obj.Descripcion = txtDescripcion.Text,
                    obj.Concentracion = txtConcentracion.Text,
                    obj.Stock = Convert.ToDecimal(txtStock.Text),
                    obj.Costo = Convert.ToDecimal(txtCosto.Text),
                    obj.Precio_Venta = Convert.ToDecimal(txtPrecio_Venta.Text),
                    obj.RegistroSanitario = txtRegistro_Sanitario.Text,
                    obj.FechaVencimiento = Convert.ToDateTime(dtpFecha_Vencimiento.Value),
                    obj.Estado = ckbActivo.Checked ? "Activo" : "Inactivo",
                    obj.idPresentacion = Convert.ToInt32(codPresentacion),
                    obj.idLaboratorio = Convert.ToInt32(codlaboratorio));
                MostrarMensaje("Datos guardados correctamente.", "Éxito", MessageBoxIcon.Information);
            }
            else if (Operacion == "Update")
            {
                if (dtgProducto.SelectedRows.Count > 0)
                {
                    txtCodigoBarras.Text = dtgProducto.CurrentRow.Cells["Codigo_Barras"].Value.ToString();
                    txtDescripcion.Text = dtgProducto.CurrentRow.Cells["Descripcion"].Value.ToString();
                    txtConcentracion.Text = dtgProducto.CurrentRow.Cells["Concentracion"].Value.ToString();
                    txtStock.Text = dtgProducto.CurrentRow.Cells["Stock"].Value.ToString();
                    txtCosto.Text = dtgProducto.CurrentRow.Cells["Costo"].Value.ToString();
                    txtPrecio_Venta.Text = dtgProducto.CurrentRow.Cells["Precio_Venta"].Value.ToString();
                    txtRegistro_Sanitario.Text = dtgProducto.CurrentRow.Cells["Registro_Sanitario"].Value.ToString();
                    dtpFecha_Vencimiento.Text = dtgProducto.CurrentRow.Cells["Fecha_Vencimiento"].Value.ToString();
                    ckbActivo.Text = dtgProducto.CurrentRow.Cells["Estado"].Value.ToString();
                    codPresentacion = Convert.ToInt32(txtPresentacion.Text = dtgProducto.CurrentRow.Cells["Presentacion"].Value.ToString());
                    codlaboratorio = Convert.ToInt32(txtLaboratorio.Text = dtgProducto.CurrentRow.Cells["Laboratorio"].Value.ToString());
                }
            else
                {
                    con1.CNActualizarProducto(
                        obj.idProducto = Convert.ToInt32(_Producto),
                        obj.Codigo_Barras = txtCodigoBarras.Text,
                    obj.Descripcion = txtDescripcion.Text,
                    obj.Concentracion = txtConcentracion.Text,
                    obj.Stock = Convert.ToDecimal(txtStock.Text),
                    obj.Costo = Convert.ToDecimal(txtCosto.Text),
                    obj.Precio_Venta = Convert.ToDecimal(txtPrecio_Venta.Text),
                    obj.RegistroSanitario = txtRegistro_Sanitario.Text,
                    obj.FechaVencimiento = Convert.ToDateTime(dtpFecha_Vencimiento.Value),
                    obj.Estado = ckbActivo.Checked ? "Activo" : "Inactivo",
                    obj.idPresentacion = Convert.ToInt32(codPresentacion),
                    obj.idLaboratorio = Convert.ToInt32(codlaboratorio)
     );
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dtgProducto.SelectedRows.Count > 0)
            {
                _Producto = dtgProducto.CurrentRow.Cells["Codigo"].Value.ToString();
                con1.CNEliminarProducto(_Producto);
                MessageBox.Show("Eliminado correctamente", "Mensaje", MessageBoxButtons.OK);
                mostrados();
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            Reporte.Frm_Rpt_Productos frm_Rpt_Productos = new Reporte.Frm_Rpt_Productos();
            frm_Rpt_Productos.ShowDialog();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void PonerDatos1(int cod, string Descripcion)
        {
            

            this.txtPresentacion.Text = Descripcion;
            codPresentacion = cod;

        }
        private void btnPresentacion_Click(object sender, EventArgs e)
        {
            BuscarPresentacion buscarPresentacion = new BuscarPresentacion();
            buscarPresentacion.MisDatos1 += new BuscarPresentacion.Datos(PonerDatos1);
            buscarPresentacion.Show();
        }

        void PonerDatos2(int cod, string nombre)
        {

            this.txtLaboratorio.Text = nombre;
            codlaboratorio=cod;


        }

        private void btnLaboratorio_Click(object sender, EventArgs e)
        {
            BuscarLaboratorio buscarLaboratorio = new BuscarLaboratorio();
            buscarLaboratorio.MisDatos2 += new BuscarLaboratorio.Datos(PonerDatos2);
            buscarLaboratorio.Show();
            
        }

        private void FrmProductos_Load(object sender, EventArgs e)
        {
            mostrados();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string busqueda = txtBuscar.Text;
            DataTable Resultado = con1.CN_Buscar(busqueda);

            dtgProducto.DataSource = Resultado;
        }

        //private void txtPrecio_Venta_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
        //    {
        //        e.Handled = true;
        //        System.Media.SystemSounds.Beep.Play();
        //        MessageBox.Show("Ingrese solo números", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }

        //    if (e.KeyChar == (char)Keys.Enter)
        //    {
        //        btnLaboratorio.Focus();
        //        e.Handled = true; // Evita que se genere el sonido de Windows al presionar Enter
        //        MessageBox.Show("Se ha cambiado al campo de boton Laboratorio.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}

        //private void txtCosto_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
        //    {
        //        e.Handled = true;
        //        System.Media.SystemSounds.Beep.Play();
        //        MessageBox.Show("Ingrese solo números", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }

        //    if (e.KeyChar == (char)Keys.Enter)
        //    {
        //        txtPrecio_Venta.Focus();
        //        e.Handled = true; // Evita que se genere el sonido de Windows al presionar Enter
        //        MessageBox.Show("Se ha cambiado al campo de Precio Venta.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}

        //private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
        //    {
        //        e.Handled = true;
        //        System.Media.SystemSounds.Beep.Play();
        //        MessageBox.Show("Ingrese solo números", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }

        //    if (e.KeyChar == (char)Keys.Enter)
        //    {
        //        txtCosto.Focus();
        //        e.Handled = true; // Evita que se genere el sonido de Windows al presionar Enter
        //        MessageBox.Show("Se ha cambiado al campo de Costo.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}

        //private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
        //    {
        //        e.Handled = true; // Evita que se ingrese caracteres no permitidos
        //        MessageBox.Show("Ingrese solo letras para la Descripción.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }

        //    if (e.KeyChar == (char)Keys.Enter)
        //    {
        //        btnPresentacion.Focus();
        //        e.Handled = true; // Evita que se genere el sonido de Windows al presionar Enter
        //        MessageBox.Show("Se ha cambiado al campo de boton Presentación.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}

        //private void txtConcentracion_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    //if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
        //    //{
        //    //    e.Handled = true; // Evita que se ingrese caracteres no permitidos
        //    //    MessageBox.Show("Ingrese solo letras para la Concentracion.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    //}

        //    if (e.KeyChar == (char)Keys.Enter)
        //    {
        //        txtStock.Focus();
        //        e.Handled = true; // Evita que se genere el sonido de Windows al presionar Enter
        //        MessageBox.Show("Se ha cambiado al campo de Stock.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}

        //private void txtRegistro_Sanitario_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
        //    {
        //        e.Handled = true; // Evita que se ingrese caracteres no permitidos
        //        MessageBox.Show("Ingrese solo letras para la Registro Sanitario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }

        //    if (e.KeyChar == (char)Keys.Enter)
        //    {
        //        dtpFecha_Vencimiento.Focus();
        //        e.Handled = true; // Evita que se genere el sonido de Windows al presionar Enter
        //        MessageBox.Show("Se ha cambiado al campo de Fecha de Vencimiento.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}

        private void txtCodigoBarras_KeyPress(object sender, KeyPressEventArgs e)
        {
            SqlConnection C = new SqlConnection("Data Source=DESKTOP-3CPHA0J\\JEMMINSON;Initial Catalog=FARMACIA;Integrated Security=True");
            if (e.KeyChar == (char) Keys.Enter)
            {
                SqlCommand cmd = new SqlCommand("Select Codigo_Barras from producto where  Codigo_Barras=" + txtCodigoBarras.Text, C); /*(este apartado lo que va dentro de las comillas haces mencion ala bd donde esta la tabla)*/

               C.Open();
                SqlDataReader leer = cmd.ExecuteReader();

                if (leer.Read())
                {
                    MessageBox.Show("El codigo  de barra insertado ya existe");
                    //txtCodigoBarras.Focus();
                    C.Close();
                    return;
                }
                else
                {
                    txtDescripcion.Focus();
                    C.Close();
                }
                C.Close();
            }
            //// Verificar si se ha ingresado un dígito
            //if (char.IsDigit(e.KeyChar))
            //{
            //    // Verificar si la longitud actual del texto más el dígito supera los 13 caracteres permitidos
            //    if (txtCodigoBarras.TextLength + 1 > 12)
            //    {
            //        e.Handled = true; // Evitar que se ingrese más de 13 dígitos
            //        MessageBox.Show("El código de barras debe tener exactamente 12 dígitos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
            //else if (!char.IsControl(e.KeyChar))
            //{
            //    e.Handled = true; // Evitar que se ingresen caracteres no numéricos
            //    MessageBox.Show("Ingrese solo números para el código de barras.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

            //if (e.KeyChar == (char)Keys.Enter)
            //{
            //    // Validar si la longitud del código de barras es exactamente 13 caracteres
            //    if (txtCodigoBarras.TextLength == 12)
            //    {
            //        // Si la longitud es correcta, cambiar el foco al siguiente control
            //        txtDescripcion.Focus();
            //        e.Handled = true; // Evitar que se genere el sonido de Windows al presionar Enter
            //        MessageBox.Show("Se ha cambiado al campo de Descripción.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //    else
            //    {
            //        // Si la longitud no es correcta, mostrar un mensaje de error
            //        MessageBox.Show("El código de barras debe tener exactamente 12 dígitos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
        }

        private void dtgProducto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = dtgProducto.CurrentCell.RowIndex;

            Operacion = "Update";
            _Producto = dtgProducto[0, fila].Value.ToString();
            txtDescripcion.Text = dtgProducto[3, fila].Value.ToString();
            txtConcentracion.Text = dtgProducto[4, fila].Value.ToString();
            txtStock.Text = dtgProducto[5, fila].Value.ToString();
            txtCosto.Text = dtgProducto[6, fila].Value.ToString();
            txtPrecio_Venta.Text = dtgProducto[7, fila].Value.ToString();
            txtRegistro_Sanitario.Text = dtgProducto[9, fila].Value.ToString();
            dtpFecha_Vencimiento.Text = dtgProducto[8, fila].Value.ToString();
            //ckbActivo.Text = dtgProducto[8, fila].Value.ToString();
            //txtPresentacion.Text = dtgProducto[2, fila].Value.ToString();
            //txtLaboratorio.Text = dtgProducto[10, fila].Value.ToString();

            if (dtgProducto[11, fila].Value.ToString() == "Activo")
            {
                ckbActivo.Checked = true;
            }
            else
            {
                ckbActivo.Checked = false;
            }
            txtCodigoBarras.Text = dtgProducto[1, fila].Value.ToString();
        }

        //private void btnPresentacion_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (char.IsDigit(e.KeyChar))
        //    {
        //        e.Handled = true; // Evitar que se ingresen números
        //        MessageBox.Show("Ingrese solo letras para la concentración.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }

        //    if (e.KeyChar == (char)Keys.Enter)
        //    {
        //        // Si se presiona Enter, realizar la acción correspondiente del botón
        //        // Aquí puedes colocar el código para cambiar el foco o realizar alguna otra acción
        //        MessageBox.Show("Acción del botón Presentación.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}

        //private void dtpFecha_Vencimiento_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == (char)Keys.Enter)
        //    {
        //        ckbActivo.Focus();
        //        e.Handled = true; // Evita que se genere el sonido de Windows al presionar Enter
        //        MessageBox.Show("Se ha cambiado al campo de Activo o Inactivo.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}

        //private void ckbActivo_KeyPress(object sender, KeyPressEventArgs e)
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
