using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Farmacia_Tutorial.Reporte
{
    public partial class Frm_Rpt_Empleados : Form
    {
        public Frm_Rpt_Empleados()
        {
            InitializeComponent();
        }

        private void Frm_Rpt_Empleados_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dataSet_Farmacia.USP_empleado_obtener' Puede moverla o quitarla según sea necesario.
            this.uSP_empleado_obtenerTableAdapter.Fill(this.dataSet_Farmacia.USP_empleado_obtener);

            this.reportViewer1.RefreshReport();
        }
    }
}
