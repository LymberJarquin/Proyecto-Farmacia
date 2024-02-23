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
    public partial class Frm_Rpt_Comprobantes : Form
    {
        public Frm_Rpt_Comprobantes()
        {
            InitializeComponent();
        }

        private void Frm_Rpt_Comprobantes_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dataSet_Farmacia.USP_tipocomprobante_obtener' Puede moverla o quitarla según sea necesario.
            this.uSP_tipocomprobante_obtenerTableAdapter.Fill(this.dataSet_Farmacia.USP_tipocomprobante_obtener);

            this.reportViewer1.RefreshReport();
        }
    }
}
