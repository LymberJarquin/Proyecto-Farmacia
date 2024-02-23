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
    public partial class Frm_Rpt_Proveedores : Form
    {
        public Frm_Rpt_Proveedores()
        {
            InitializeComponent();
        }

        private void Frm_Rpt_Proveedores_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dataSet_Farmacia.USP_proveedor_obtener' Puede moverla o quitarla según sea necesario.
            this.uSP_proveedor_obtenerTableAdapter.Fill(this.dataSet_Farmacia.USP_proveedor_obtener);

            this.reportViewer1.RefreshReport();
        }
    }
}
