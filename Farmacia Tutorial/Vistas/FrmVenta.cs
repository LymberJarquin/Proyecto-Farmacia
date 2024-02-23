using CapasDatos;
using CapasEntidad;
using CapasNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Farmacia_Tutorial.Vistas
{
    public partial class FrmVenta : Form
    {


        int coduser;
        int codcliente;
        int codcompro;
        int codempleado;

        int CodPresentacion;
        int CodLab;
        string numventa;

        private System.Windows.Forms.Timer barcodeTimer = new System.Windows.Forms.Timer();

        public FrmVenta()
        {
            InitializeComponent();

            barcodeTimer.Interval = 500; // Intervalo en milisegundos
            barcodeTimer.Tick += new EventHandler(barcodeTimer_Tick);

            labelFecha.ForeColor = Color.Blue;

            // Configurar el temporizador
            Timer timer = new Timer();
            timer.Interval = 100; // Intervalo de actualización en milisegundos (1 segundo)
            timer.Tick += timer1_Tick;
            timer.Start();

            //txtVenta.Text = "C0000001";
            //txtNumeroFactura.Text = "0000001";
            txtVenta.Text = "00000" + GenerarIdVenta();
            //txtVenta.Text = "0000001";
            txtNumeroFactura.Text = "00000" + GenerarIdVenta();

            //numventa = GenerarIdVenta();
            //txtVenta.Text = numventa;

            //numventa = GenerarIdVenta();
            //txtUltimoId.Text = numventa;

            //txtNumeroFactura.Text = GenerarIdVenta();

            //this.Size = new Size(860, 723);

            Mirar();
           
            btnNuevo.Focus();
            btnEliminarProducto.Enabled = false;
            btnLimpiarTabla.Enabled = false;

            jpnImporte.Visible = false;
            txtCategoriaProducto.Visible = false;

            //string[] titulos = { "ID", "ID", "PRODUCTO", "DESCRIPCIÓN", "CATEGORÍA.", "CANTIDAD", "PRECIO", "TOTAL", "COSTO" };
            //dtmDetalle.ColumnIdentifiers.AddRange(titulos);
            //tblDetalleProducto.DataSource = dtmDetalle;
            //CrearTablaDetalleProducto();

            txtSerie.Enabled = false;
            txtSerie.Font = new Font("Tahoma", 12); // Establecer fuente y tamaño
            txtSerie.TextAlign = HorizontalAlignment.Center; // Alinear el texto al centro
            txtSerie.Text = "001"; // Establecer el texto predeterminado

            // Agregar el control txtSerie al formulario (asumiendo que ya está agregado)
            Controls.Add(txtSerie);

            // Establecer posición y tamaño del control txtSerie
            //txtSerie.Location = new Point(580, 150);
            //txtSerie.Size = new Size(59, 20);



        }



        private void LimpiarTabla()
        {
            try
            {
                int filas = dtgVenta.Rows.Count;

                for (int i = 0; i < filas; i++)
                {
                    dtgVenta.Rows.RemoveAt(0);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al limpiar la tabla.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            txtValorVenta.Text = "0.0";
            txtSubtotal.Text = "0.0";
            txtIGV.Text = "0.0";
            txtTotalPagar.Text = "0.0";
        }



        private void LimpiarCampos()
        {
            txtValorVenta.Text = "0.0";
            txtDescuento.Text = "0";
            txtSubtotal.Text = "0.0";
            txtIGV.Text = "0.0";
            txtTotalPagar.Text = "0.0";

            txtCodigoProducto.Text = "";
            txtNombreProducto.Text = "";
            txtStockProducto.Text = "";
            txtPrecio.Text = "";
            txtCantidadProducto.Text = "";
            txtCosto.Text = "";
            txtTotal.Text = "";
            txtCodigoProducto.Focus();
          
        }

        private void Mirar()
        {
            btnNuevo.Enabled = true;
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
            btnSalir.Enabled = true;
            btnImprimir.Enabled = false;
            btnComprobante.Enabled = false;
            btnNuevoCosto.Enabled = false;

            txtCodigoProducto.Enabled = false;
            txtSerie.Enabled = false;
            txtCantidadProducto.Enabled = false;
            //txtFecha.Enabled = false;
            txtNumeroFactura.Enabled = false;
            txtNumeroFactura.Enabled = false;

            btnClientes.Enabled = false;
            btnBuscarProducto.Enabled = false;
            btnAgregarProducto.Enabled = false;
            btnEliminarProducto.Enabled = false;
            btnLimpiarTabla.Enabled = false;
            chkCambiarSerie.Enabled = false;
            chkCambiarSerie.Checked = false;

            txtValorVenta.Text = "0.0";
            txtDescuento.Text = "0";
            txtSubtotal.Text = "0.0";
            txtIGV.Text = "0.0";
            txtTotalPagar.Text = "0.0";
            txtCodigoProducto.Text = "";
            txtNombreProducto.Text = "";
            txtStockProducto.Text = "";
            txtPrecio.Text = "";
            txtCantidadProducto.Text = "";
            txtCosto.Text = "";
            txtTotal.Text = "";
            txtNombreCliente.Text = "";
            //txtDni.Text = "";
            //txtDireccion.Text = "";
            txtRuc.Text = "";
            txtComprobante.Text = "";
            txtCategoriaProducto.Text = "";
            txtConcentracion.Text = "";
            txtVenta.Text = "";
            txtVenta.Text = "00000" + GenerarIdVenta();
            txtNumeroFactura.Text = "";
            txtNumeroFactura.Text = "00000" + GenerarIdVenta();
            btnNuevo.Focus();
        }

        private void Modificar()
        {
            btnNuevo.Enabled = false;

            btnCancelar.Enabled = true;
            btnSalir.Enabled = false;
            btnComprobante.Enabled = true;

            txtCodigoProducto.Enabled = true;
            txtSerie.Enabled = true;
            txtCantidadProducto.Enabled = true;
            //txtFecha.Enabled = true;
            txtNumeroFactura.Enabled = true;
            txtNumeroFactura.Enabled = true;

            btnClientes.Enabled = true;
            btnBuscarProducto.Enabled = true;
            btnAgregarProducto.Enabled = true;
            btnEliminarProducto.Enabled = false;
            btnLimpiarTabla.Enabled = false;
            chkCambiarSerie.Enabled = true;

            txtCodigoProducto.Focus();
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
            string formatoFecha = "yyyy-MM-dd";
            return fecha.ToString(formatoFecha);
        }

        void PonerDatos1(int cod, string Nombre, string Ruc)
        {
            this.txtNombreCliente.Text = Nombre;
            this.txtRuc.Text = Ruc;
            codcliente = cod;
        }

        private void btnProveedor_Click(object sender, EventArgs e)
        {
            BuscarClientes buscarClientes = new BuscarClientes();
            buscarClientes.MisDatos1 += new BuscarClientes.Datos(PonerDatos1);
            buscarClientes.ShowDialog();
        }

        void PonerDatos2(string Codigo, string codigobarras, string Descripcion, string Concentracion, string Categoria, string Stock, string costop,  string Venta, int codpre, int codlab)
        {
            this.txtCodigoProducto.Text = Codigo;
            this.txtCodigoBarras.Text = codigobarras;
            this.txtNombreProducto.Text = Descripcion;
            this.txtConcentracion.Text = Concentracion;
            this.txtCategoriaProducto.Text = Categoria;
            this.txtStockProducto.Text = Stock;
            this.txtPrecio.Text = Venta;
            this.txtCosto.Text =costop;
            CodPresentacion = codpre;
            CodLab = codlab;
        }

        private void btnProducto_Click(object sender, EventArgs e)
        {
            BuscarProductosVentas buscarProductosVentas = new BuscarProductosVentas();
            buscarProductosVentas.MisDatos4 += new BuscarProductosVentas.Datos(PonerDatos2);
            buscarProductosVentas.ShowDialog();
        }

        void PonerDatos2(int cod, string Descripcion)
        {
            this.txtComprobante.Text = Descripcion;
            codcompro = cod;
        }

        private void btnComprobante_Click(object sender, EventArgs e)
        {
            BuscarComprobante buscarComprobante = new BuscarComprobante();
            buscarComprobante.MisDatos1 += new BuscarComprobante.Datos(PonerDatos2);
            buscarComprobante.ShowDialog();
        }

        private void btnNuevoCosto_Click(object sender, EventArgs e)
        {
            jpnImporte.Visible = true;
            string ingreso = Microsoft.VisualBasic.Interaction.InputBox("Ingrese Importe a Cancelar", "0.0");

            double importe, cambio;
            if (!string.IsNullOrEmpty(ingreso))
            {
                if (double.TryParse(ingreso, out importe))
                {
                    txtImporte.Text = importe.ToString();
                    cambio = double.Parse(txtImporte.Text) - double.Parse(txtTotalPagar.Text);
                    txtCambio.Text = cambio.ToString();
                }
                else
                {
                    MessageBox.Show("Ingrese un valor numérico válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                txtImporte.Text = "0.0";
            }
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            CalculateCost();
        }

        private void CalculateCost()
        {
            if (double.TryParse(txtCantidadProducto.Text, out double cantidad) && double.TryParse(txtPrecio.Text, out double precio))
            {
                double resultado = cantidad * precio;
                txtTotal.Text = resultado.ToString();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            double cant;
            if (!string.IsNullOrEmpty(txtCantidadProducto.Text))
            {

                if (txtCantidadProducto.Text.Equals(""))
                {
                    txtCantidadProducto.Text = "0";
                    cant = double.Parse(txtCantidadProducto.Text);
                }
                else
                {
                    cant = double.Parse(txtCantidadProducto.Text);
                }


                int Ind = -0;
                decimal NetoLinea;
                string codigoBarras = txtCodigoBarras.Text.Trim();
                string productos = txtNombreProducto.Text.Trim();
                string Concentracion = txtConcentracion.Text.Trim();
                string Categoria = txtCategoriaProducto.Text.Trim();
                string cantidad = Convert.ToInt32(txtCantidadProducto.Text.Trim()).ToString();
                string costo = Convert.ToDecimal(txtCosto.Text.Trim()).ToString();
                string precio = Convert.ToDecimal(txtPrecio.Text.Trim()).ToString();
                string Total = (decimal.Parse(cantidad) * decimal.Parse(precio)).ToString();


                if (cant > 0)
                {
                    foreach (DataGridViewRow dr in dtgVenta.Rows)
                    {

                        Ind = Ind + 1;
                    }



                    dtgVenta.Rows.Add();

                    dtgVenta[0, Ind].Value = txtCodigoProducto.Text;
                    dtgVenta[1, Ind].Value = txtCodigoBarras.Text;
                    dtgVenta[2, Ind].Value = txtNombreProducto.Text;
                    dtgVenta[3, Ind].Value = txtConcentracion.Text;
                    dtgVenta[4, Ind].Value = txtCategoriaProducto.Text;
                    dtgVenta[5, Ind].Value = txtCantidadProducto.Text;
                    dtgVenta[6, Ind].Value = txtCosto.Text;
                    dtgVenta[7, Ind].Value = Convert.ToDecimal(txtPrecio.Text);
                    NetoLinea = Convert.ToInt32(txtCantidadProducto.Text) * Convert.ToDecimal(dtgVenta[7, Ind].Value);
                    dtgVenta[8, Ind].Value = NetoLinea;

                    CalcularTotal();
                    CalcularSubTotal();
                    CalcularIGV();

                    txtCodigoProducto.Text = "";
                    txtCodigoBarras.Text = "";
                    txtNombreProducto.Text = "";
                    txtCategoriaProducto.Text = "";
                    txtConcentracion.Text = "";
                    txtCantidadProducto.Text = "";
                    txtCosto.Text = "";
                    txtPrecio.Text = "";
                    txtStockProducto.Text = "";
                    txtTotal.Text = "";
                }
                else
                {
                    MessageBox.Show("Ingrese Cantidad mayor a 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCantidadProducto.Focus();
                }

            }
            else
            {
                MessageBox.Show("Ingrese cantidad", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCantidadProducto.Focus();
            }

            btnGuardar.Enabled = true;
            btnEliminarProducto.Enabled = true;
            btnLimpiarTabla.Enabled = true;
            btnNuevoCosto.Enabled = true;

        }
        //----------------------------------------------------------------------
        //void CalcularTotal()
        //{
        //    double total_prod = 0;

        //    foreach (DataGridViewRow row in dtgVenta.Rows)
        //    {
        //        double precio_prod, cant_prod;

        //        if (double.TryParse(row.Cells[5].Value.ToString(), out precio_prod) &&
        //           double.TryParse(row.Cells[7].Value.ToString(), out cant_prod))
        //        {
        //            total_prod += precio_prod * cant_prod;
        //        }


        //    }
        //    //txtValorVenta.Text = total_prod.ToString("0.0");
        //    //txtTotalPagar.Text = total_prod.ToString("0.0");
        //    txtValorVenta.Text = total_prod.ToString("0.00");
        //    CalcularTotalPagar();
        //}

        ////void CalcularSubTotal()
        ////{
        ////    double subtotal = 0;
        ////    if (double.TryParse(txtTotalPagar.Text, out double totalPagar))
        ////    {
        ////        subtotal = totalPagar / 1.18;

        ////    }
        ////    txtSubtotal.Text = $"{subtotal:0.00}";

        ////}

        //void CalcularSubTotal()
        //{
        //    if (double.TryParse(txtValorVenta.Text, out double totalVenta))
        //    {
        //        double subtotal = totalVenta - ObtenerDescuento();
        //        txtSubtotal.Text = subtotal.ToString("0.00");
        //    }
        //}



        //void CalcularIGV()
        //{
        //    double igv = 0;
        //    if (double.TryParse(txtSubtotal.Text, out double subtotal))
        //    {
        //         igv = subtotal * 0.18;

        //    }
        //    txtIGV.Text = $"{igv:0.00}";
        //}

        //double ObtenerDescuento()
        //{
        //    if (double.TryParse(txtDescuento.Text, out double descuento))
        //    {
        //        return descuento;
        //    }
        //    return 0;
        //}


        ////private void CalcularTotalPagar()
        ////{
        ////    double totalPagar = 0;
        ////    if (double.TryParse(txtValorVenta.Text, out double totalVenta) &&
        ////        double.TryParse(txtDescuento.Text, out double descuento))
        ////    {
        ////         totalPagar = totalVenta - descuento;

        ////    }
        ////    txtTotalPagar.Text = $"{totalPagar:0.00}";
        ////}

        //private void CalcularTotalPagar()
        //{
        //    double totalPagar = 0;
        //    if (double.TryParse(txtValorVenta.Text, out double totalVenta))
        //    {
        //        totalPagar = totalVenta - ObtenerDescuento() + ObtenerIGV();
        //    }
        //    txtTotalPagar.Text = totalPagar.ToString("0.00");
        //}


        //double ObtenerIGV()
        //{
        //    if (double.TryParse(txtSubtotal.Text, out double subtotal))
        //    {
        //        return subtotal * 0.18;
        //    }
        //    return 0;
        //}

        //private void txtDescuento_TextChanged(object sender, EventArgs e)
        //{
        //    CalcularTotalPagar();
        //    CalcularSubTotal();
        //    CalcularIGV();
        //}
        //--------------------------------------------------------------------------------

        void CalcularTotal()
        {
            double totalProd = 0;

            foreach (DataGridViewRow row in dtgVenta.Rows)
            {
                double precioProd, cantProd;

                if (double.TryParse(Convert.ToString(row.Cells[5].Value), out precioProd) &&
                    double.TryParse(Convert.ToString(row.Cells[7].Value), out cantProd))
                {
                    totalProd += precioProd * cantProd;
                }
            }

            txtValorVenta.Text = totalProd.ToString("0.0");
            CalcularTotalPagar();
        }

        void CalcularSubTotal()
        {
            if (double.TryParse(txtValorVenta.Text, out double totalVenta))
            {
                double subtotal = totalVenta - ObtenerDescuento();
                txtSubtotal.Text = subtotal.ToString("0.0");
            }
        }

        void CalcularIGV()
        {
            if (double.TryParse(txtSubtotal.Text, out double subtotal))
            {
                double igv = subtotal * 0.15;
                txtIGV.Text = igv.ToString("0.0");
            }
        }

        double ObtenerDescuento()
        {
            if (double.TryParse(txtDescuento.Text, out double descuento))
            {
                return descuento;
            }
            return 0;
        }

        private void CalcularTotalPagar()
        {
            double totalPagar = 0;
            if (double.TryParse(txtValorVenta.Text, out double totalVenta) &&
                double.TryParse(txtDescuento.Text, out double descuento))
            {
                // Calcular el subtotal restando el descuento del total de venta
                double subtotal = totalVenta - descuento;

                // Calcular el IGV sobre el subtotal
                double igv = subtotal * 0.15;

                // Sumar el IGV al subtotal para obtener el total a pagar
                totalPagar = subtotal + igv;
            }
            txtTotalPagar.Text = totalPagar.ToString("0.0");
        }

        private void txtDescuento_TextChanged(object sender, EventArgs e)
        {
            CalcularTotalPagar();
            CalcularSubTotal();
            CalcularIGV();
        }

        public string GenerarIdVenta()
        {
            CN_Ventas oCompra = new CN_Ventas();
            try
            {
                SqlDataReader reader = oCompra.CNObtenerUltimoIdVenta();
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

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void MostrarMensaje(string mensaje, string titulo, MessageBoxIcon icono)
        {
            MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, icono);
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrEmpty(txtNombreCliente.Text))
            {
                MostrarMensaje("Debes ingresar un Cliente.", "Advertencia", MessageBoxIcon.Warning);
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

            CN_DetalleVenta comdet = new CN_DetalleVenta();
            CN_Productos prod = new CN_Productos();

            CN_Ventas cN_ = new CN_Ventas();
            cN_.CNAgregarVentas(txtSerie.Text,txtVenta.Text, Convert.ToDateTime(labelFecha.Text),
                Convert.ToDecimal(txtValorVenta.Text),Convert.ToDecimal(txtDescuento.Text), Convert.ToDecimal(txtSubtotal.Text),
                Convert.ToDecimal(txtIGV.Text), Convert.ToDecimal(txtTotalPagar.Text), "Normal", Convert.ToInt32(codcliente), Convert.ToInt32(codempleado), Convert.ToInt32(codcompro));

            /*
            Guardar en la tabla detalle de compras
            y en la tabla productos (Existencias)
            */
            for (i = 0; (i <= (this.dtgVenta.RowCount - 1)); i++)
            {
                comdet.CNAgregarDetalleVenta(Convert.ToInt32(txtVenta.Text), Convert.ToInt32(dtgVenta[0, i].Value), Convert.ToInt32(dtgVenta[5, i].Value), Convert.ToDecimal(dtgVenta[6, i].Value), Convert.ToDecimal(dtgVenta[7, i].Value), Convert.ToDecimal(dtgVenta[8, i].Value));

                //prod.CNAgregarProducto(dtgVenta[2, i].Value.ToString(), dtgVenta[3, i].Value.ToString(), dtgVenta[4, i].Value.ToString(), Convert.ToInt32(dtgVenta[5, i].Value), Convert.ToDecimal(dtgVenta[6, i].Value), Convert.ToDecimal(dtgVenta[6, i].Value) + (Convert.ToDecimal(dtgVenta[6, i].Value) * Convert.ToDecimal(0.2)), "EN01867", Convert.ToDateTime(txtFecha.Text), "Activo", CodPresentacion, CodLab);
                CD_Ventas ventas = new CD_Ventas();
                ventas.GuardarDetalleVentas(Convert.ToInt32(txtVenta.Text), Convert.ToInt32(dtgVenta[0, i].Value.ToString()), Convert.ToInt32(dtgVenta[5, i].Value.ToString()), Convert.ToDecimal(dtgVenta[6, i].Value.ToString()), Convert.ToDecimal(dtgVenta[7, i].Value.ToString()), Convert.ToDecimal(dtgVenta[8, i].Value.ToString()));
            }

            MessageBox.Show("Datos guardados");

            btnImprimir.Enabled = true;
            btnNuevo.Enabled = true;
            btnCancelar.Enabled = false;
            jpnImporte.Visible =false;
            Mirar();
            LimpiarTabla();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

            Mirar();
            LimpiarTabla();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Modificar();
            LimpiarCampos();
            
            codempleado = GenerarIdEmpleado(coduser);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarTabla();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int fila = dtgVenta.SelectedRows.Count;

            if (fila > 0)
            {
                DialogResult result = MessageBox.Show("¿Está seguro de eliminar el producto seleccionado?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in dtgVenta.SelectedRows)
                    {
                        dtgVenta.Rows.Remove(row);
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

        private void FrmVenta_Load(object sender, EventArgs e)
        {
            coduser = CE_Usuario1.idUsuario;
            FechaHoraActual();
        }

       

        private void chkCambiarSerie_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCambiarSerie.Checked)
            {
                txtSerie.Enabled = true;
                txtSerie.ReadOnly = false;
                txtSerie.Focus();
            }
            else
            {
                txtSerie.Enabled = false;
            }
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

        private void barcodeTimer_Tick(object sender, EventArgs e)
        {
            // Procesa el código de barras cuando se complete el temporizador
            if (rjToggleButton1.Checked)
            {
                CBusqueda objetoBusqueda = new CBusqueda();
                objetoBusqueda.buscarCodigosegundo(txtCodigoProducto, txtCodigoBarras, txtNombreProducto, txtConcentracion, txtStockProducto, txtPrecio, txtCosto);
                //txtCodigoBarras.Text = ""; // Limpiar el campo después de la búsqueda
            }
            // Detener el temporizador
            barcodeTimer.Stop();
        }

        private void txtCodigoBarras_TextChanged(object sender, EventArgs e)
        {
            if (rjToggleButton1.Checked)
            {
                barcodeTimer.Stop();
                barcodeTimer.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelFecha.Text = FechaHoraActual();

        }
    }
}
