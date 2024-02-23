using CapasDatos;
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
    public partial class TotalVentaRealizadas : Form
    {
        public TotalVentaRealizadas()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarVenta();
            CrearTabla();
            CantidadTotal();
            VentasTotal();
            CantidadVenta();
            GananciaVenta();
        }

        private void BuscarVenta()
        {
            //DataTable dtm = new DataTable();
            //dtm.Columns.Add("Codigo", typeof(string));
            //dtm.Columns.Add("Producto", typeof(string));
            //dtm.Columns.Add("Presentacion", typeof(string));
            //dtm.Columns.Add("Precio", typeof(double)); // Cambia el tipo de dato según tu necesidad
            //dtm.Columns.Add("Cantidad", typeof(double)); // Cambia el tipo de dato según tu necesidad
            //dtm.Columns.Add("Total", typeof(double)); // Cambia el tipo de dato según tu necesidad
            //dtm.Columns.Add("Ganancia", typeof(DateTime)); // Cambia el tipo de dato según tu necesidad

            //CN_Ventas venta = new CN_Ventas();

            //DateTime fecha_ini = dtpDesde.Value;
            //DateTime fecha_fin = dtpHasta.Value;

            //try
            //{
            //    var ventas = venta.ObtenerListarDetalleVentaPorParametro(fecha_ini,fecha_fin);

            //    bool encuentra = ventas.Rows.Count > 0;

            //    // Limpia las filas existentes en el DataTable
            //    dtm.Clear();

            //    foreach (DataRow ventaActual in ventas.Rows)
            //    {
            //        // Crea una nueva fila para el DataTable
            //        DataRow row = dtm.NewRow();

            //        // Asigna los valores de la venta a la fila
            //        row["Codigo"] = ventaActual["Codigo"];
            //        row["Producto"] = ventaActual["Producto"];
            //        row["Presentacion"] = ventaActual["Presentacion"];
            //        row["Precio"] = ventaActual["Precio"];
            //        row["Cantidad"] = ventaActual["Cantidad"];
            //        row["Total"] = ventaActual["Total"];
            //        row["Ganancia"] = ventaActual["Ganancia"];

            //        // Agrega la fila al DataTable
            //        dtm.Rows.Add(row);
            //    }

            //    if (!encuentra)
            //    {
            //        MessageBox.Show("¡No se encuentra!");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Error: " + ex.Message);
            //}

            //dtgTotalVentaRealizadas.DataSource = dtm;

            try
            {
                CN_Ventas venta = new CN_Ventas();
                // Obtenemos las fechas seleccionadas en los DateTimePicker
                DateTime fechaInicio = dtpDesde.Value;
                DateTime fechaFin = dtpHasta.Value;

                // Formateamos las fechas según el formato deseado
                DateTime fecha = Convert.ToDateTime(fechaInicio.ToString("yyyy/MM/dd"));
                DateTime fecha2 = Convert.ToDateTime(fechaFin.ToString("yyyy/MM/dd"));

                // Llamamos al método en la capa de negocio para buscar facturas de ventas por rango de fechas
                DataTable resultado = venta.ObtenerListarDetalleVentaPorParametro(fecha, fecha2);

                dtgTotalVentaRealizadas.DataSource = resultado;

                int[] anchos = { 60, 80, 200, 70, 70 };

                for (int i = 0; i < dtgTotalVentaRealizadas.Columns.Count && i < anchos.Length; i++)
                {
                    dtgTotalVentaRealizadas.Columns[i].Width = anchos[i];
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
            DataGridViewCellStyle centerStyle = new DataGridViewCellStyle();
            centerStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            DataGridViewCellStyle leftStyle = new DataGridViewCellStyle();
            leftStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            // Asignar estilos a cada columna del DataGridView
            for (int i = 0; i < dtgTotalVentaRealizadas.ColumnCount; i++)
            {
                if (i == 0 || i == 4 || i == 5 || i == 6 || i == 7 || i == 8)
                {
                    dtgTotalVentaRealizadas.Columns[i].DefaultCellStyle = centerStyle;
                }
                else
                {
                    dtgTotalVentaRealizadas.Columns[i].DefaultCellStyle = leftStyle;
                }
            }

            dtgTotalVentaRealizadas.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 102, 102);
            dtgTotalVentaRealizadas.DefaultCellStyle.SelectionForeColor = Color.White;
            dtgTotalVentaRealizadas.BackgroundColor = Color.White;

            dtgTotalVentaRealizadas.EnableHeadersVisualStyles = false;
            dtgTotalVentaRealizadas.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 102, 102);
            dtgTotalVentaRealizadas.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            //Autoajuste de columnas
            dtgTotalVentaRealizadas.AutoResizeColumns();
            dtgTotalVentaRealizadas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            // Definir anchos de cada columna
            int[] anchos = { 50, 130, 120, 80, 80, 80, 80, 80 };
            for (int i = 0; i < dtgTotalVentaRealizadas.ColumnCount; i++)
            {
                dtgTotalVentaRealizadas.Columns[i].Width = anchos[i];
            }

            // Ocultar columnas según índices especificados
            foreach (int index in new int[] { 3 })
            {
                dtgTotalVentaRealizadas.Columns[index].Visible = false;
            }

        }

        private void VentasTotal()
        {
            double totalVenta = 0.0;

            for (int f = 0; f < dtgTotalVentaRealizadas.Rows.Count; f++)
            {
                // Asumiendo que la columna que contiene los valores deseados es la sexta columna (índice 5)
                totalVenta += Convert.ToDouble(dtgTotalVentaRealizadas.Rows[f].Cells[6].Value);
            }

            txtTotalVentas.Text = totalVenta.ToString();
        }


        private void CantidadTotal()
        {
            int total = dtgTotalVentaRealizadas.RowCount;
            lblEstado.Text = "Se cargaron " + total.ToString() + " registros";
        }

        private void CantidadVenta()
        {
            int cantidad = 0;

            for (int f = 0; f < dtgTotalVentaRealizadas.Rows.Count; f++)
            {
                // Asumiendo que la columna que contiene las cantidades deseadas es la sexta columna (índice 5)
                cantidad += Convert.ToInt32(dtgTotalVentaRealizadas.Rows[f].Cells[5].Value);
            }

            txtCantidad.Text = cantidad.ToString();
        }




        private void GananciaVenta()
        {
            //double ganancia = 0.0;

            //for (int f = 0; f < dtgTotalVentaRealizadas.Rows.Count; f++)
            //{
            //    // Asumiendo que la columna que contiene las ganancias deseadas es la octava columna (índice 7)
            //    ganancia += Convert.ToDouble(dtgTotalVentaRealizadas.Rows[f].Cells[8].Value);
            //}

            //txtGanancias.Text = Truncar(ganancia, 2).ToString();

            double Ganancia = 0.0;

            for (int f = 0; f < dtgTotalVentaRealizadas.Rows.Count; f++)
            {
                // Asumiendo que la columna que contiene los valores deseados es la sexta columna (índice 5)
                Ganancia += Convert.ToDouble(dtgTotalVentaRealizadas.Rows[f].Cells[7].Value);
            }

            txtGanancias.Text = Truncar(Ganancia, 2).ToString();
        }

        private double Truncar(double nD, int nDec)
        {
            if (nD > 0)
                nD = Math.Floor(nD * Math.Pow(10, nDec)) / Math.Pow(10, nDec);
            else
                nD = Math.Ceiling(nD * Math.Pow(10, nDec)) / Math.Pow(10, nDec);

            return nD;
        }

        private void TotalVentaRealizadas_Load(object sender, EventArgs e)
        {
            
        }
    }
}
