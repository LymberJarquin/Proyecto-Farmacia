using CapasNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using CapasEntidad;
using CapasDatos;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace Farmacia_Tutorial.Vistas
{
    public partial class FrmCompras : Form
    {
        string numCompra;
        int coduser;
        int codempleado;
        int codcomprobante;
        int codproveedor;
        int CodPresentacion;
        int CodLab;
        CN_Proveedor ObjProveedor = new CN_Proveedor();

        private System.Windows.Forms.Timer barcodeTimer = new System.Windows.Forms.Timer();
        public FrmCompras()
        {

            InitializeComponent();

            // Configura el temporizador
            barcodeTimer.Interval = 500; // Intervalo en milisegundos
            barcodeTimer.Tick += new EventHandler(barcodeTimer_Tick);

            // Configuración de txtFecha
            labelFecha.ForeColor = Color.Blue;
            //txtFecha.Text = FechaHoraActual();

            // Configurar el temporizador
            Timer timer = new Timer();
            timer.Interval = 100; // Intervalo de actualización en milisegundos (1 segundo)
            timer.Tick += timer1_Tick;
            timer.Start();


            //// Configuración de txtFechas
            //txtFecha.ForeColor = Color.Blue;
            //txtFechas.Text = FechaActual();

            // Otras configuraciones
            //txtUltimoId.Text = "0000001";
            //txtNCompra.Text = txtUltimoId.Text;
            txtNCompra.Text = "00000" + GenerarIdCompra();
            //numCompra = GenerarIdCompra();
            //txtUltimoId.Text = numCompra;


            //this.Size = new Size(920, 630);
            //txtIdComprobante.Visible = false;

            lblIdProducto.Visible = false;
            //lblIdProveedor.Visible = false;
            //txtDescripcionProducto.Visible = false;
            //txtIdEmpleado.Visible = false;

            //txtUltimoId.Visible = false;
            btnImprimir.Enabled = false;

            Mirar();

            //txtTipoPago.Visible = false;

            //string[] titulos = { "ID", "PRODUCTO", "PRESENTACIÓN", "DESCRIPCIÓN", "CANT.", "PRECIO", "TOTAL" };
            //dtmDetalle.ColumnIdentifiers.AddRange(titulos);
            //tblDetalleProducto.DataSource = dtmDetalle;
            //CrearTablaDetalleProducto();

        }


        public static string FechaHoraActual()
        {
            DateTime fechaHora = DateTime.Now;
            string formatoFechaHora = "yyyy-MM-dd HH:mm:ss";
            return fechaHora.ToString(formatoFechaHora);
        }

        public static string Fecha()
        {
            DateTime fecha = DateTime.Now;
            string formatoFecha = "yyyy-MM-dd HH:mm:ss";
            return fecha.ToString(formatoFecha);
        }
        void PonerDatos1(int codigo, string Nombre, string Ruc)
        {
            this.txtProveedor.Text = Nombre;
            this.txtRuc.Text = Ruc;
            codproveedor = codigo;
        }
        private void btnProveedor_Ruc_Click(object sender, EventArgs e)
        {
            BuscarProveedor buscarProveedor = new BuscarProveedor();
            buscarProveedor.MisDatos1 += new BuscarProveedor.Datos(PonerDatos1);
            buscarProveedor.ShowDialog();
        }

        private void btnCodigo_Click(object sender, EventArgs e)
        {
            BuscarProductosCompras buscarProductosCompras = new BuscarProductosCompras();
            buscarProductosCompras.MisDatos3 += new BuscarProductosCompras.Datos(PonerDatos3);
            buscarProductosCompras.ShowDialog();
        }


        void PonerDatos2(int cod, string Descripcion)
        {
            this.txtComprobante.Text = Descripcion;
            codcomprobante = cod;

        }
        private void btnComprobante_Click(object sender, EventArgs e)
        {
            BuscarComprobanteCompra buscarComprobanteCompra = new BuscarComprobanteCompra();
            buscarComprobanteCompra.MisDatos2 += new BuscarComprobanteCompra.Datos(PonerDatos2);
            buscarComprobanteCompra.ShowDialog();
        }

        void PonerDatos3(string ID, string codigobarras, string Presentacion, string Producto, string Concentracion, string Stock, string Costo, int codpresent, int codlab)
        {
            this.txtCodigo.Text = ID;
            this.txtCodigoBarras.Text = codigobarras;
            this.txtProducto.Text = Producto;
            this.txtPresentacion.Text = Presentacion;
            this.txtConcentracion.Text = Concentracion;
            this.txtStock.Text = Stock;
            this.txtCosto.Text = Costo;
            CodPresentacion = codpresent;
            CodLab = codlab;

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            double cant;
            if (!string.IsNullOrEmpty(txtCantidad.Text))
            {

                if (txtCantidad.Text.Equals(""))
                {
                    txtCantidad.Text = "0";
                    cant = double.Parse(txtCantidad.Text);
                }
                else
                {
                    cant = double.Parse(txtCantidad.Text);
                }


                int Ind = -0;
                decimal NetoLinea;
                string codigo = txtCodigoBarras.Text.Trim();
                string productos = txtProducto.Text.Trim();
                string Presentacion = txtPresentacion.Text.Trim();
                string Concentracion = txtConcentracion.Text.Trim();
                string cantidad = Convert.ToInt32(txtCantidad.Text.Trim()).ToString();
                string Costo = Convert.ToDecimal(txtCosto.Text.Trim()).ToString();
                string Total = (decimal.Parse(cantidad) * decimal.Parse(Costo)).ToString();


                if (cant > 0)
                {
                    foreach (DataGridViewRow dr in dtgCompra.Rows)
                    {

                        Ind = Ind + 1;
                    }



                    dtgCompra.Rows.Add();

                    dtgCompra[0, Ind].Value = txtCodigo.Text;
                    dtgCompra[1, Ind].Value = txtCodigoBarras.Text;
                    dtgCompra[2, Ind].Value = txtProducto.Text;
                    dtgCompra[3, Ind].Value = txtPresentacion.Text;
                    dtgCompra[4, Ind].Value = txtConcentracion.Text;
                    dtgCompra[5, Ind].Value = txtCantidad.Text;
                    dtgCompra[6, Ind].Value = Convert.ToDecimal(txtCosto.Text);
                    NetoLinea = Convert.ToInt32(txtCantidad.Text) * Convert.ToDecimal(dtgCompra[6, Ind].Value);
                    dtgCompra[7, Ind].Value = NetoLinea;

                    CalcularTotal();
                    CalcularSubTotal();
                    CalcularIGV();

                    txtCodigo.Text = "";
                    txtCodigoBarras.Text = "";
                    txtProducto.Text = "";
                    txtPresentacion.Text = "";
                    txtConcentracion.Text = "";
                    txtCantidad.Text = "";
                    txtCosto.Text = "";
                    txtStock.Text = "";
                    txtTotal.Text = "";
                }
                else
                {
                    MessageBox.Show("Ingrese Cantidad mayor a 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCantidad.Focus();
                }

            }
            else
            {
                MessageBox.Show("Ingrese cantidad", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCantidad.Focus();
            }
        }

        void CalcularTotal()
        {
            CalcularSubTotal();
            CalcularIGV();

            if (double.TryParse(txtSubtotal.Text, out double subtotal) &&
       double.TryParse(txtIGV.Text, out double igv))
            {
                double totalPagar = subtotal + igv;
                txtTotalPagar.Text = totalPagar.ToString("0.0");
            }
        }

        void CalcularSubTotal()
        {
            double totalProd = 0;

            foreach (DataGridViewRow row in dtgCompra.Rows)
            {
                if (double.TryParse(row.Cells[5].Value?.ToString(), out double precioProd) &&
                    double.TryParse(row.Cells[6].Value?.ToString(), out double cantProd))
                {
                    totalProd += precioProd * cantProd;
                }
            }

            txtSubtotal.Text = totalProd.ToString("0.0");
        }

        void CalcularIGV()
        {
            if (double.TryParse(txtSubtotal.Text, out double subtotal))
            {
                double igv = subtotal * 0.15;
                txtIGV.Text = igv.ToString("0.0");
            }
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            CalculateCost();
        }

        private void CalculateCost()
        {
            if (double.TryParse(txtCantidad.Text, out double cantidad) && double.TryParse(txtCosto.Text, out double costo))
            {
                double resultado = cantidad * costo;
                txtTotal.Text = resultado.ToString();
            }
        }

        public string GenerarIdCompra()
        {
            CN_Compra oCompra = new CN_Compra();
            try
            {
                SqlDataReader reader = oCompra.CNObtenerUltimoIdCompra();
                while (reader.Read())
                {
                    if (!reader.IsDBNull(0))
                    {
                        int c = int.Parse(reader[0].ToString()) + int.Parse("1");

                        //int c = int.Parse(reader.GetString(0).Substring(1)) + 1;

                        if (c < 10)
                        {
                            return c.ToString();
                        }
                        if (c < 100)
                        {
                            return c.ToString();
                        }
                        if (c < 1000)
                        {
                            return c.ToString();
                        }
                        if (c < 10000)
                        {
                            return c.ToString();
                        }
                        else
                        {
                            return "C" + c;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                try
                {

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                }
            }
            return "1";
        }
        public int GenerarIdEmpleado(int idemp)
        {
            CN_Empleado oEmpleado = new CN_Empleado();
            try
            {
                SqlDataReader reader = oEmpleado.CNObtenerCodEmpleado(idemp);
                while (reader.Read())
                {
                    if (!reader.IsDBNull(0))
                    {
                        int c = int.Parse(reader[0].ToString());

                        return c;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                try
                {

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                }
            }
            return 1;
        }

        private void FrmCompras_Load(object sender, EventArgs e)
        {
            //GeneratePurchaseNumber();
            coduser = CE_Usuario1.idUsuario;
            //txtNCompra.Text=  GenerarIdCompra();


        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int fila = dtgCompra.SelectedRows.Count;

            if (fila > 0)
            {
                DialogResult result = MessageBox.Show("¿Está seguro de eliminar el producto seleccionado?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in dtgCompra.SelectedRows)
                    {
                        dtgCompra.Rows.Remove(row);
                    }

                    CalcularTotal();
                    CalcularSubTotal();
                    CalcularIGV();
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione al menos una fila para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarTabla()
        {
            try
            {
                int filas = dtgCompra.Rows.Count;

                for (int i = 0; i < filas; i++)
                {
                    dtgCompra.Rows.RemoveAt(0);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al limpiar la tabla.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            txtSubtotal.Text = "0.0";
            txtIGV.Text = "0.0";
            txtTotalPagar.Text = "0.0";
        }

        private void LimpiarCampos()
        {
            // Configurar tus controles de TextBox y Label según sea necesario
            txtSubtotal.Text = "0.0";
            txtIGV.Text = "0.0";
            txtTotalPagar.Text = "0.0";

            lblIdProducto.Text = "";
            txtCodigo.Text = "";
            txtCodigoBarras.Text = "";
            txtProducto.Text = "";
            txtStock.Text = "";
            txtCosto.Text = "";
            txtCantidad.Text = "";
            txtTotal.Text = "";
            txtProveedor.Text = "";
            txtRuc.Text = "";
            //txtIdComprobante.Text = "";
            //txtNCompra.Text = "";
            txtPresentacion.Text = "";
            txtConcentracion.Text = "";



            // Establecer el foco en el control txtCodigoProducto
            txtCodigo.Focus();
        }

        private void Modificar()
        {
            btnNuevo.Enabled = false;

            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
            btnSalir.Enabled = false;

            txtComprobante.Enabled = true;
            txtCodigo.Enabled = true;
            txtCantidad.Enabled = true;
            //labelFecha.Enabled = true;
            txtCosto.ReadOnly = false;
            txtCosto.Enabled = true;

            txtRuc.Enabled = true;
            txtProveedor.Enabled = true;
            txtCodigoBarras.Enabled = true;
            txtPresentacion.Enabled = true;
            txtConcentracion.Enabled = true;
            txtProducto.Enabled = true;
            txtStock.Enabled = true;
            //txtCosto.Enabled = false;
            txtTotal.Enabled = true;
            //txtNCompra.Enabled = t;

            btnComprobante.Enabled = true;
            btnProveedor_Ruc.Enabled = true;
            btnCodigo.Enabled = true;
            btnAgregar.Enabled = true;
            btnEliminar.Enabled = true;
            btnLimpiar.Enabled = true;
            // chkCambiarNumero.Enabled = true;

            txtCodigo.Focus();
        }
        private void Mirar()
        {
            btnNuevo.Enabled = true;
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
            btnSalir.Enabled = true;

            txtComprobante.Enabled = false;
            txtCodigo.Enabled = false;
            txtCantidad.Enabled = false;
            //txtFecha.Enabled = false;
            txtRuc.Enabled = false;
            txtProveedor.Enabled = false;
            txtCodigoBarras.Enabled = false;
            txtPresentacion.Enabled = false;
            txtConcentracion.Enabled = false;
            txtProducto.Enabled = false;
            txtStock.Enabled = false;
            txtCosto.Enabled = false;
            txtTotal.Enabled = false;
            //txtNCompra.Enabled = false;
            //txtNumero.Enabled = false;

            btnProveedor_Ruc.Enabled = false;
            btnCodigo.Enabled = false;
            btnAgregar.Enabled = false;
            btnEliminar.Enabled = false;
            btnLimpiar.Enabled = false;

            btnComprobante.Enabled = false;
            // chkCambiarNumero.Enabled = false;
            // chkCambiarNumero.Checked = false;

            txtSubtotal.Text = "0.0";
            txtIGV.Text = "0.0";
            txtTotalPagar.Text = "0.0";
            lblIdProducto.Text = "";
            txtCodigo.Text = "";
            txtCodigoBarras.Text = "";
            txtProducto.Text = "";
            txtCantidad.Text = "";
            txtCosto.Text = "";
            txtCantidad.Text = "";
            txtTotal.Text = "";
            txtNCompra.Text = "";
            txtNCompra.Text = "00000" + GenerarIdCompra();
            txtCodigo.Focus();

            txtProveedor.Text = "";
            txtRuc.Text = "";
            txtComprobante.Text = "";
            txtPresentacion.Text = "";
            txtConcentracion.Text = "";
        }



        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarTabla();

        }

        private void MostrarMensaje(string mensaje, string titulo, MessageBoxIcon icono)
        {
            MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, icono);
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrEmpty(txtProveedor.Text))
            {
                MostrarMensaje("Debes ingresar un Proveedor.", "Advertencia", MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(txtRuc.Text))
            {
                MostrarMensaje("Debes ingresar un Ruc.", "Advertencia", MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(txtComprobante.Text))
            {
                MostrarMensaje("Debes seleccionar un Tipo de Comprobante.", "Advertencia", MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

            private void btnGuardar_Click(object sender, EventArgs e)
        {
           

            if (!ValidarCampos())
                return;

            int i;

            CN_DetalleCompra comdet = new CN_DetalleCompra();
            CN_Productos prod = new CN_Productos();

            CN_Compra cN_ = new CN_Compra();
            cN_.CNAgregarCompra(txtUltimoId.Text, Convert.ToDateTime(labelFecha.Text),
                txtTipoPago.Text, Convert.ToDecimal(txtSubtotal.Text),
                Convert.ToDecimal(txtTotalPagar.Text), Convert.ToDecimal(txtIGV.Text), "Normal", Convert.ToInt32(codproveedor), Convert.ToInt32(codempleado), Convert.ToInt32(codcomprobante));

            /*
            Guardar en la tabla detalle de compras
            y en la tabla productos (Existencias)
            */
            for (i = 0; (i <= (this.dtgCompra.RowCount - 1)); i++)
            {
                comdet.CNAgregarDetalleCompra(Convert.ToInt32(txtUltimoId.Text), Convert.ToInt32(dtgCompra[0, i].Value), Convert.ToInt32(dtgCompra[5, i].Value), Convert.ToDecimal(dtgCompra[6, i].Value), Convert.ToDecimal(dtgCompra[7, i].Value));

                ////prod.CNAgregarProducto(dtgCompra[2, i].Value.ToString(), dtgCompra[3, i].Value.ToString(),
                ////    dtgCompra[4, i].Value.ToString(), Convert.ToInt32(dtgCompra[5, i].Value),
                ////    Convert.ToDecimal(dtgCompra[6, i].Value),
                ////    Convert.ToDecimal(dtgCompra[6, i].Value) + (Convert.ToDecimal(dtgCompra[6, i].Value) * Convert.ToDecimal(0.2)),
                ////    "EN01867", Convert.ToDateTime(txtFecha.Text), "Activo", CodPresentacion, CodLab);

            }

            MessageBox.Show("Datos guardados");

            Mirar();
            LimpiarTabla();

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {

            Modificar();
            LimpiarCampos();

            codempleado = GenerarIdEmpleado(coduser);
            numCompra = GenerarIdCompra();
            txtUltimoId.Text = numCompra;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Mirar();
            LimpiarTabla();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }


        private void barcodeTimer_Tick(object sender, EventArgs e)
        {
            // Procesa el código de barras cuando se complete el temporizador
            if (rjToggleButton1.Checked)
            {
                CBusqueda objetoBusqueda = new CBusqueda();
                objetoBusqueda.buscarCodigo(txtCodigo, txtCodigoBarras, txtPresentacion, txtConcentracion, txtProducto, txtStock, txtCosto);
                //txtCodigoBarras.Text = ""; // Limpiar el campo después de la búsqueda
            }
            // Detener el temporizador
            barcodeTimer.Stop();
        }

        private void rjToggleButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (rjToggleButton1.Checked)
            {
                // Lógica a ejecutar cuando el botón está activado
                // Por ejemplo, iniciar un temporizador o activar la búsqueda automática
                barcodeTimer.Start();
            }
            else
            {
                // Lógica a ejecutar cuando el botón está desactivado
                // Por ejemplo, detener el temporizador o desactivar la búsqueda automática
                barcodeTimer.Stop();
            }
        }

        private void txtCodigoBarras_TextChanged(object sender, EventArgs e)
        {
            // Reinicia el temporizador cada vez que se ingresa un carácter
            if (rjToggleButton1.Checked)
            {
                barcodeTimer.Stop();
                barcodeTimer.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Actualizar las etiquetas de fecha y hora cada vez que el temporizador se active
            labelFecha.Text = FechaHoraActual();
            //labelFechaHora.Text = Fecha();
        }
    }
}
