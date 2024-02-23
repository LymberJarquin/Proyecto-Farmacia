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
    public partial class Frm_Rpt_Clientes : Form
    {
        public Frm_Rpt_Clientes()
        {
            InitializeComponent();
        }

        private void Frm_Rpt_Clientes_Load(object sender, EventArgs e)
        {
            this.uSP_Cliente_obtenerTableAdapter.Fill(this.dataSet_Farmacia.USP_Cliente_obtener);
            this.reportViewer1.RefreshReport();
        }
    }
}
