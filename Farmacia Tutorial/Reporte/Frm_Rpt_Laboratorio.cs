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
    public partial class Frm_Rpt_Laboratorio : Form
    {
        public Frm_Rpt_Laboratorio()
        {
            InitializeComponent();
        }

        private void Frm_Rpt_Laboratorio_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dataSet_Farmacia.USP_laboratorio_obtener' Puede moverla o quitarla según sea necesario.
            this.uSP_laboratorio_obtenerTableAdapter.Fill(this.dataSet_Farmacia.USP_laboratorio_obtener);

            this.reportViewer1.RefreshReport();
        }
    }
}
