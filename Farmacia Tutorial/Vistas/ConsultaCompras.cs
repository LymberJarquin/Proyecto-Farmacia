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
    public partial class ConsultaCompras : Form
    {
        public ConsultaCompras()
        {
            InitializeComponent();
        }
        
        private void ConsultaCompras_Load(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarCompra();
            CrearTabla();
        }

        private void BuscarCompra()
        {
            //try
            //{
            //    // Obtenemos las fechas seleccionadas en los DateTimePicker
            //    DateTime fechaInicio = dtpDesde.Value;
            //    DateTime fechaFin = dtpHasta.Value;

            //    // Formateamos las fechas según el formato deseado
            //    DateTime fecha = Convert.ToDateTime(fechaInicio.ToString("yyyy/MM/dd"));
            //    DateTime fecha2 = Convert.ToDateTime(fechaFin.ToString("yyyy/MM/dd"));

            //    // Llamamos al método en la capa de negocio para buscar facturas de ventas por rango de fechas
            //    DataTable resultado = _Compra.CN_ObtenerDatosPorRangoFecha(fechaInicio, fechaFin);

            //    dtgConsultaCompras.DataSource = resultado;

            //    int[] anchos = { 60, 80, 200, 70, 70 };

            //    for (int i = 0; i < dtgConsultaCompras.Columns.Count && i < anchos.Length; i++)
            //    {
            //        dtgConsultaCompras.Columns[i].Width = anchos[i];
            //    }
            //    //Sum();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Error: " + ex.Message);
            //}

            try
            {
                CN_Compra commpra = new CN_Compra();
                // Obtenemos las fechas seleccionadas en los DateTimePicker
                DateTime fechaInicio = dtpDesde.Value;
                DateTime fechaFin = dtpHasta.Value;

                // Formateamos las fechas según el formato deseado
                DateTime fecha = Convert.ToDateTime(fechaInicio.ToString("yyyy/MM/dd"));
                DateTime fecha2 = Convert.ToDateTime(fechaFin.ToString("yyyy/MM/dd"));

                // Llamamos al método en la capa de negocio para buscar facturas de ventas por rango de fechas
                DataTable resultado = commpra.CN_ObtenerDatosPorRangoFecha(fecha, fecha2);

                dtgConsultaCompras.DataSource = resultado;

                int[] anchos = { 60, 80, 200, 70, 70 };

                for (int i = 0; i < dtgConsultaCompras.Columns.Count && i < anchos.Length; i++)
                {
                    dtgConsultaCompras.Columns[i].Width = anchos[i];
                }
                //Sum();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        private void CrearTabla()
        {
            // Crear un objeto DataGridViewCellStyle para personalizar la apariencia de las celdas
            DataGridViewCellStyle style = new DataGridViewCellStyle();

            // Alinear el contenido de las celdas
            style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Agregar el estilo a las columnas específicas
            foreach (DataGridViewColumn column in dtgConsultaCompras.Columns)
            {
                if (column.Index == 0 || column.Index == 2 || column.Index == 4 || column.Index == 5 || column.Index == 6 || column.Index == 7 || column.Index == 8)
                {
                    column.DefaultCellStyle = style;
                }
            }

            // Establecer colores de fondo y texto para filas seleccionadas y no seleccionadas
            dtgConsultaCompras.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 102, 102);
            dtgConsultaCompras.RowsDefaultCellStyle.SelectionForeColor = Color.White;

            dtgConsultaCompras.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);

            // Activar el modo de redimensionamiento automático y establecer los anchos de columna preferidos
            dtgConsultaCompras.AutoResizeColumns();
            dtgConsultaCompras.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            int[] anchos = { 50, 160, 85, 130, 80, 73, 74, 75, 80 };

            for (int i = 0; i < dtgConsultaCompras.ColumnCount; i++)
            {
                dtgConsultaCompras.Columns[i].Width = anchos[i];
            }
        }

        //private void ActualizarCantidadTotal()
        //{
        //    int totalRegistros = dtgConsultaCompras.RowCount;
        //    lblEstado.Text = "Se cargaron " + totalRegistros + " registros";
        //}


        private void btnAnular_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblIdcompra.Text))
            {
                MessageBox.Show("¡Se debe seleccionar un registro de compra!", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int filaSeleccionada = dtgConsultaCompras.SelectedCells.Count > 0 ? dtgConsultaCompras.SelectedCells[0].RowIndex : -1;

                if (filaSeleccionada >= 0)
                {
                    string estadoCompra = Convert.ToString(dtgConsultaCompras.Rows[filaSeleccionada].Cells[6].Value);

                    if (!estadoCompra.Equals("ANULADO"))
                    {
                        DialogResult result = MessageBox.Show("¿Desea anular la compra?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            // Suponiendo que tienes un método en la clase CN_Compra para actualizar el estado de la compra
                            CN_Compra compras = new CN_Compra();
                            string estado = "ANULADO";
                            compras.ActualizarCompraEstado(lblIdcompra.Text, estado);

                            BuscarCompra();
                            CrearTabla();
                        }
                        else if (result == DialogResult.No)
                        {
                            MessageBox.Show("Anulación Cancelada!", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("¡Esta compra ya ha sido ANULADA!", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void btnDetalles_Click(object sender, EventArgs e)
        {

        }


        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
