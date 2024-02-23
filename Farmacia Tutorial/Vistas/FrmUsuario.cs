using CapasDatos;
using CapasEntidad;
using CapasNegocio;
using Microsoft.ReportingServices.ReportProcessing.OnDemandReportObjectModel;
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
    public partial class FrmUsuario : Form
    {
        public FrmUsuario()
        {
            InitializeComponent();
        }
        CN_Usuario con = new CN_Usuario();
        CE_Usuario obj = new CE_Usuario();
        private string _Usuarios = null;
        string Operacion = "Insertar";

        void limpiar()
        {
            txtDni.Text = "";
            txtApellidos.Text = "";
            txtNombres.Text = "";
            txtEmail.Text = "";
            txtUsuario.Text = "";
            txtContrasena.Text = "";
            cbmTipoUsuario.Text = "";
            ckActivo.Checked = false;
        }

        public void mostrados()
        {
            dtgUsuario.DataSource = con.CNObtenerUsuario();
        }

        private void FrmUsuario_Load(object sender, EventArgs e)
        {
            mostrados();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Operacion == "Insertar")
            {
                con.CNAgregarUsuario(txtNombres.Text, txtApellidos.Text, txtDni.Text, txtEmail.Text, txtUsuario.Text, txtContrasena.Text, cbmTipoUsuario.Text, ckActivo.Checked ? "Activo" : "Inactivo");
            }
            else if (Operacion == "Update")
            {
                if (dtgUsuario.SelectedRows.Count > 0)
                {
                    txtNombres.Text = dtgUsuario.CurrentRow.Cells["Nombres"].Value.ToString();
                    txtApellidos.Text = dtgUsuario.CurrentRow.Cells["Apellidos"].Value.ToString();
                    txtDni.Text = dtgUsuario.CurrentRow.Cells["Dni"].Value.ToString();
                    txtEmail.Text = dtgUsuario.CurrentRow.Cells["Email"].Value.ToString();
                    txtUsuario.Text = dtgUsuario.CurrentRow.Cells["Usuario"].Value.ToString();
                    txtContrasena.Text = dtgUsuario.CurrentRow.Cells["Contrasena"].Value.ToString();
                    cbmTipoUsuario.Text = dtgUsuario.CurrentRow.Cells["Tipo Usuario"].Value.ToString();
                    ckActivo.Text = dtgUsuario.CurrentRow.Cells["Estado"].Value.ToString();

                }
                else
                {
                    con.CNActualizarUsuario(_Usuarios, txtNombres.Text, txtApellidos.Text, txtDni.Text, txtEmail.Text, txtUsuario.Text, txtContrasena.Text, cbmTipoUsuario.Text, ckActivo.Checked ? "Activo" : "Inactivo");
                    MessageBox.Show("Update correcto", "Mensaje");
                    Operacion = "Insertar";
                }
            }
            limpiar();
            mostrados();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dtgUsuario.SelectedRows.Count > 0)
            {
                _Usuarios = dtgUsuario.CurrentRow.Cells["idUsuario"].Value.ToString();
                con.CNEliminarUsuario(_Usuarios);
                MessageBox.Show("Eliminado correctamente", "Mensaje", MessageBoxButtons.OK);
                mostrados();
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            Reporte.Frm_Rpt_Usuario frm_Rpt_Usuario = new Reporte.Frm_Rpt_Usuario();
            frm_Rpt_Usuario.ShowDialog();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMostrar_Todo_Click(object sender, EventArgs e)
        {
            mostrados();
        }

        private void btnPresentacion_Click(object sender, EventArgs e)
        {
            BuscarEmpleados buscarEmpleados = new BuscarEmpleados();
            buscarEmpleados.MisDatos1 += new BuscarEmpleados.Datos(PonerDatos1);
            buscarEmpleados.Show();
            
        }
        void PonerDatos1(string Nombres, string Apellidos, string Dni, string Email)
        {
            this.txtDni.Text =  Dni;
            this.txtApellidos.Text = Apellidos;
            this.txtNombres.Text = Nombres;
            this.txtEmail.Text = Email;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string busqueda = txtBuscar.Text;
            DataTable Resultado = con.CN_Buscar(busqueda);

            dtgUsuario.DataSource = Resultado;

        }

        private void dtgUsuario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = dtgUsuario.CurrentCell.RowIndex;

            Operacion = "Update";
            _Usuarios = dtgUsuario[0, fila].Value.ToString();
            txtDni.Text = dtgUsuario[3, fila].Value.ToString();
            txtApellidos.Text = dtgUsuario[2, fila].Value.ToString();
            txtNombres.Text = dtgUsuario[1, fila].Value.ToString();
            txtEmail.Text = dtgUsuario[4, fila].Value.ToString();
            txtUsuario.Text = dtgUsuario[5, fila].Value.ToString();
            txtContrasena.Text = dtgUsuario[6, fila].Value.ToString();
            cbmTipoUsuario.Text = dtgUsuario[7, fila].Value.ToString();
            bool isActive = Convert.ToBoolean(dtgUsuario[8, fila].Value?.ToString() == "Activo");

            if (isActive)
            {
                ckActivo.Checked = true;
            }
            else
            {
                ckActivo.Checked = false;
            }
        }
    }
}
