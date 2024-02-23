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
    public partial class FrmCaja : Form
    {
        public FrmCaja()
        {
            InitializeComponent();


        }

        private void btnCalcular_Ingreso_Click(object sender, EventArgs e)
        {
            BuscarIngresos();
            CrearTabla();
            VentasTotal();
            CantidadVenta();
            GananciaVenta();
        }

        private void BuscarIngresos()
        {

            //try
            //{
            //    CN_Ventas venta = new CN_Ventas();
            //    // Obtenemos las fechas seleccionadas en los DateTimePicker
            //    DateTime fechaInicio = dtpFecha.Value;
            //    DateTime fechaFin = dtpFecha.Value;

            //    // Formateamos las fechas según el formato deseado
            //    DateTime fecha = Convert.ToDateTime(fechaInicio.ToString("yyyy/MM/dd")); ;
            //    DateTime fecha2 = Convert.ToDateTime(fechaFin.ToString("yyyy/MM/dd"));

            //    // Llamamos al método en la capa de negocio para buscar facturas de ventas por rango de fechas
            //    DataTable resultado = venta.ObtenerVentasPorFecha(fecha, fecha2);

            //    dtgCaja.DataSource = resultado;

            //    int[] anchos = { 60, 80, 200, 70, 70 };

            //    for (int i = 0; i < dtgCaja.Columns.Count && i < anchos.Length; i++)
            //    {
            //        dtgCaja.Columns[i].Width = anchos[i];
            //    }
            //    //Sum();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Error: " + ex.Message);
            //}

            try
            {
                CN_Ventas venta = new CN_Ventas();
                // Obtenemos las fechas seleccionadas en los DateTimePicker
                //DateTime fechaInicio = dtpFecha.Value;
                DateTime fechaFin = dtpFecha.Value;

                // Formateamos las fechas según el formato deseado
                //DateTime fecha = Convert.ToDateTime(fechaInicio.ToString("yyyy/MM/dd"));
                DateTime fecha2 = Convert.ToDateTime(fechaFin.ToString("yyyy/MM/dd"));

                // Llamamos al método en la capa de negocio para buscar facturas de ventas por rango de fechas
                DataTable resultado = venta.ObtenerVentasPorFecha( fecha2);

                dtgCaja.DataSource = resultado;

                int[] anchos = { 60, 80, 200, 70, 70 };

                for (int i = 0; i < dtgCaja.Columns.Count && i < anchos.Length; i++)
                {
                    dtgCaja.Columns[i].Width = anchos[i];
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
            ////--------------------PRESENTACION DE DATAGRIDVIEW----------------------

            //DataGridViewCellStyle style = new DataGridViewCellStyle();

            //// Ajustar alineaciones y colores en DataGridView
            //DataGridViewCellStyle centerStyle = new DataGridViewCellStyle();
            //centerStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //DataGridViewCellStyle leftStyle = new DataGridViewCellStyle();
            //leftStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            //for (int i = 0; i < dtgCaja.ColumnCount; i++)
            //{
            //    if (i == 0 || i == 2 || i == 3 || i == 4 || i == 5)
            //    {
            //        dtgCaja.Columns[i].DefaultCellStyle = centerStyle;
            //    }
            //    else
            //    {
            //        dtgCaja.Columns[i].DefaultCellStyle = leftStyle;
            //    }
            //}

            //dtgCaja.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 102, 102);
            //dtgCaja.DefaultCellStyle.SelectionForeColor = Color.White;
            //dtgCaja.BackgroundColor = Color.White;

            //dtgCaja.EnableHeadersVisualStyles = false;
            //dtgCaja.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 102, 102);
            //dtgCaja.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            ////Autoajuste de columnas
            //dtgCaja.AutoResizeColumns();
            //dtgCaja.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            ////Anchos de cada columna
            //int[] anchos = { 60, 185, 70, 70, 70, 70 };
            //for (int i = 0; i < dtgCaja.ColumnCount; i++)
            //{
            //    dtgCaja.Columns[i].Width = anchos[i];
            //}


            //--------------------PRESENTACION DE DATAGRIDVIEW----------------------

            DataGridViewCellStyle style = new DataGridViewCellStyle();

            // Ajustar alineaciones y colores en DataGridView
            DataGridViewCellStyle centerStyle = new DataGridViewCellStyle();
            centerStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            DataGridViewCellStyle leftStyle = new DataGridViewCellStyle();
            leftStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            for (int i = 0; i < dtgCaja.ColumnCount; i++)
            {
                if (i == 0 || i == 2 || i == 3 || i == 4 || i == 5)
                {
                    dtgCaja.Columns[i].DefaultCellStyle = centerStyle;
                }
                else
                {
                    dtgCaja.Columns[i].DefaultCellStyle = leftStyle;
                }
            }

            dtgCaja.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 102, 102);
            dtgCaja.DefaultCellStyle.SelectionForeColor = Color.White;
            dtgCaja.BackgroundColor = Color.White;

            dtgCaja.EnableHeadersVisualStyles = false;
            dtgCaja.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 102, 102);
            dtgCaja.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            //Autoajuste de columnas
            dtgCaja.AutoResizeColumns();
            dtgCaja.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            //Anchos de cada columna
            int[] anchos = { 60, 185, 70, 70, 70, 70, 70 };
            for (int i = 0; i < dtgCaja.ColumnCount; i++)
            {
                dtgCaja.Columns[i].Width = anchos[i];
            }
        }

        private void VentasTotal()
        {

            double Total_venta = 0.0;
            // Suponiendo que dtgCaja es un objeto DataGridView
            foreach (DataGridViewRow row in dtgCaja.Rows)
            {
                Total_venta += Convert.ToDouble(row.Cells[4].Value);
            }
            txtIngresoVentas.Text = Total_venta.ToString();
            txtTotal_Caja.Text = Total_venta.ToString();
        }


        private void CantidadVenta()
        {
            int cantidad = 0;
            // Suponiendo que dtgCaja es un objeto DataGridView
            foreach (DataGridViewRow row in dtgCaja.Rows)
            {
                cantidad += Convert.ToInt32(row.Cells[0].Value);
            }
            txtCant_Productos.Text = cantidad.ToString();
        }


        private void GananciaVenta()
        {
            double ganancia = 0.0;
            // Suponiendo que dtgCaja es un objeto DataGridView
            foreach (DataGridViewRow row in dtgCaja.Rows)
            {
                ganancia += Convert.ToDouble(row.Cells[5].Value);
            }

            txtGanancia.Text = Truncar(ganancia, 2).ToString();
        }

        private double Truncar(double valor, int decimales)
        {
            double factor = Math.Pow(10, decimales);
            return Math.Truncate(valor * factor) / factor;
        }

        private void btnVentas_Realizadas_Click(object sender, EventArgs e)
        {
            TotalVentaRealizadas totalVentaRealizadas = new TotalVentaRealizadas();
            totalVentaRealizadas.ShowDialog();
        }

        private void FrmCaja_Load(object sender, EventArgs e)
        {
            BuscarIngresos();
            CrearTabla();
            VentasTotal();
            CantidadVenta();
            GananciaVenta();
        }
    }
}
