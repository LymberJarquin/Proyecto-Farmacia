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
    public partial class ConsultaVentas : Form
    {
        public ConsultaVentas()
        {
            InitializeComponent();
        }

        CN_Ventas _Ventas = new CN_Ventas();

        //public void mostrados()
        //{
        //    dtgConsultaVentas.DataSource = _Ventas.CN_ObtenerDatosPorRangoFecha2();
        //}
        private void ConsultaVentas_Load(object sender, EventArgs e)
        {
            //mostrados();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarVentas();
            CrearTabla();
        }

        private void BuscarVentas()
        {
          
            try
            {
                CN_Ventas ventas = new CN_Ventas();
                // Obtenemos las fechas seleccionadas en los DateTimePicker
                DateTime fechaInicio = dtpDesde.Value;
                DateTime fechaFin = dtpHasta.Value;

                // Formateamos las fechas según el formato deseado
                DateTime fecha = Convert.ToDateTime(fechaInicio.ToString("yyyy/MM/dd"));
                DateTime fecha2 = Convert.ToDateTime(fechaFin.ToString("yyyy/MM/dd"));

                // Llamamos al método en la capa de negocio para buscar facturas de ventas por rango de fechas
                DataTable resultado = ventas.CN_ObtenerDatosPorRangoFecha2(fecha, fecha2);

                dtgConsultaVentas.DataSource = resultado;

                int[] anchos = { 60, 80, 200, 70, 70 };

                for (int i = 0; i < dtgConsultaVentas.Columns.Count && i < anchos.Length; i++)
                {
                    dtgConsultaVentas.Columns[i].Width = anchos[i];
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
            foreach (DataGridViewColumn column in dtgConsultaVentas.Columns)
            {
                if (column.Index == 0 || column.Index == 2 || column.Index == 4 || column.Index == 5 || column.Index == 6 || column.Index == 7 || column.Index == 8)
                {
                    column.DefaultCellStyle = style;
                }
            }

            // Establecer colores de fondo y texto para filas seleccionadas y no seleccionadas
            dtgConsultaVentas.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 102, 102);
            dtgConsultaVentas.RowsDefaultCellStyle.SelectionForeColor = Color.White;

            dtgConsultaVentas.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);

            // Activar el modo de redimensionamiento automático y establecer los anchos de columna preferidos
            dtgConsultaVentas.AutoResizeColumns();
            dtgConsultaVentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            int[] anchos = { 50, 160, 85, 130, 80, 73, 74, 75, 80 };

            for (int i = 0; i < dtgConsultaVentas.ColumnCount; i++)
            {
                dtgConsultaVentas.Columns[i].Width = anchos[i];
            }
        }
    }
}
