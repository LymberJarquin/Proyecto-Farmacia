using CapasDatos;
using CapasEntidad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Farmacia_Tutorial.Vistas
{
    public partial class FrmPrincipal : Form
    {
        //String hora, minutos, segundos;
        public FrmPrincipal()
        {
            InitializeComponent();
            timer.Interval = 1000; // Actualizar cada segundo
            timer.Tick += timer_Tick;
            timer.Start();
            SetCurrentDate();
        }

        private void ActualizarHora()
        {
            DateTime horaActual = DateTime.Now;
            string hora = horaActual.Hour > 9 ? horaActual.Hour.ToString() : "0" + horaActual.Hour;
            string minutos = horaActual.Minute > 9 ? horaActual.Minute.ToString() : "0" + horaActual.Minute;
            string segundos = horaActual.Second > 9 ? horaActual.Second.ToString() : "0" + horaActual.Second;

            lblHora.Text = hora + ":" + minutos + ":" + segundos;
        }

        private void SetCurrentDate()
        {

            DateTime currentDate = DateTime.Now;
            int weekNumber = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(currentDate, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

            string formattedDate = currentDate.ToString("dddd, dd MMMM yyyy");

            lblFecha.Text = $"{formattedDate}";
        }


        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form FrmOpen = Application.OpenForms["FrmProductos"];

            if (FrmOpen == null)
            {
                FrmProductos frmProductos = new FrmProductos();
                frmProductos.MdiParent = this;
                frmProductos.Show();
            }
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form FrmOpen = Application.OpenForms["FrmCliente"];

            if (FrmOpen == null)
            {
                FrmCliente frmCliente = new FrmCliente();
                frmCliente.MdiParent = this;
                frmCliente.Show();
            }
        }

        private void empleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form FrmOpen = Application.OpenForms["FrmEmpleados"];

            if (FrmOpen == null)
            {
                FrmEmpleados frmEmpleados = new FrmEmpleados();
                frmEmpleados.MdiParent = this;
                frmEmpleados.Show();
            }
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form FrmOpen = Application.OpenForms["FrmProveedores"];

            if (FrmOpen == null)
            {
                FrmProveedores frmProveedores = new FrmProveedores();
                frmProveedores.MdiParent = this;
                frmProveedores.Show();
            }
        }

        private void presentacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form FrmOpen = Application.OpenForms["FrmPresentacion"];

            if (FrmOpen == null)
            {
                FrmPresentacion frmPresentacion = new FrmPresentacion();
                frmPresentacion.MdiParent = this;
                frmPresentacion.Show();
            }
        }

        private void laboratoriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form FrmOpen = Application.OpenForms["FrmLaboratorios"];

            if (FrmOpen == null)
            {
                FrmLaboratorios frmLaboratorios = new FrmLaboratorios();
                frmLaboratorios.MdiParent = this;
                frmLaboratorios.Show();
            }
        }

        private void comprobantesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form FrmOpen = Application.OpenForms["FrmComprobante"];

            if (FrmOpen == null)
            {
                FrmComprobantes frmComprobantes = new FrmComprobantes();
                frmComprobantes.MdiParent = this;
                frmComprobantes.Show();
            }
        }

        private void nuevoUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form FrmOpen = Application.OpenForms["FrmUsuario"];

            if (FrmOpen == null)
            {
                FrmUsuario frmUsuario = new FrmUsuario();
                frmUsuario.MdiParent = this;
                frmUsuario.Show();
            }
        }

        private void comprasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form FrmOpen = Application.OpenForms["ConsultaCompras"];

            if (FrmOpen == null)
            {
                ConsultaCompras consultaCompras = new ConsultaCompras();
                consultaCompras.MdiParent = this;
                consultaCompras.Show();
            }
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form FrmOpen = Application.OpenForms["ConsultaClientes"];

            if (FrmOpen == null)
            {
                ConsultaClientes consultaClientes = new ConsultaClientes();
                consultaClientes.MdiParent = this;
                consultaClientes.Show();
            }
        }

        private void empleadosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form FrmOpen = Application.OpenForms["ConsultaEmpleados"];

            if (FrmOpen == null)
            {
                ConsultaEmpleados consultaEmpleados = new ConsultaEmpleados();
                consultaEmpleados.MdiParent = this;
                consultaEmpleados.Show();
            }
        }

        private void productosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form FrmOpen = Application.OpenForms["ConsultaProductos"];

            if (FrmOpen == null)
            {
                ConsultaProductos consultaProductos = new ConsultaProductos();
                consultaProductos.MdiParent = this;
                consultaProductos.Show();
            }
        }

        private void proveedoresToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form FrmOpen = Application.OpenForms["ConsultaProveedores"];

            if (FrmOpen == null)
            {
                ConsultaProveedores consultaProveedores = new ConsultaProveedores();
                consultaProveedores.MdiParent = this;
                consultaProveedores.Show();
            }
        }

        private void ventasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form FrmOpen = Application.OpenForms["ConsultaVentas"];

            if (FrmOpen == null)
            {
                ConsultaVentas consultaVentas = new ConsultaVentas();
                consultaVentas.MdiParent = this;
                consultaVentas.Show();
            }
        }

        private void administrarPerfilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form FrmOpen = Application.OpenForms["AdministradorPerfil"];

            if (FrmOpen == null)
            {
                AdministradorPerfil administradorPerfil = new AdministradorPerfil();
                administradorPerfil.MdiParent = this;
                administradorPerfil.Show();
            }
        }

        private void comprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form FrmOpen = Application.OpenForms["FrmCompras"];

            if (FrmOpen == null)
            {
                FrmCompras frmCompras = new FrmCompras();
                frmCompras.MdiParent = this;
                frmCompras.Show();
            }
        }

        private void ventasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form FrmOpen = Application.OpenForms["FrmVenta"];

            if (FrmOpen == null)
            {
                FrmVenta frmVenta = new FrmVenta();
                frmVenta.MdiParent = this;
                frmVenta.Show();
            }
        }

        private void cajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form FrmOpen = Application.OpenForms["FrmCaja"];

            if (FrmOpen == null)
            {
                FrmCaja frmCaja = new FrmCaja();
                frmCaja.MdiParent = this;
                frmCaja.Show();
            }
        }

        private void clientesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form FrmOpen = Application.OpenForms["ReportesClientes"];

            if (FrmOpen == null)
            {
                ReportesClientes reportesClientes = new ReportesClientes();
                reportesClientes.MdiParent = this;
                reportesClientes.Show();
            }
        }

        private void productosToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Form FrmOpen = Application.OpenForms["ReporteProductos"];

            if (FrmOpen == null)
            {
                ReporteProductos reporteProductos = new ReporteProductos();
                reporteProductos.MdiParent = this;
                reporteProductos.Show();
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            ActualizarHora();
            SetCurrentDate();
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (MessageBox.Show("Are you sure to Cerrar Sesion?", "Warning",
            //    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                this.Close();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            LoadUserData();

            Timer timer = new Timer();
            timer.Tick += timer_Tick;
            timer.Interval = 1000; // 1000 milliseconds = 1 second
            timer.Start();

            if (CE_Usuario1.TipoUsuario == Positions.Administrador)
            {

            }
            if(CE_Usuario1.TipoUsuario == Positions.Vendedor)
            {
                empleadosToolStripMenuItem.Visible = false;
                reportesToolStripMenuItem.Visible = false;
                administradorToolStripMenuItem.Visible = false;
                comprasToolStripMenuItem1.Visible = false;
                comprasToolStripMenuItem.Visible = false;

            }
        }

        private void LoadUserData()
        {
            lblUsuario.Text = CE_Usuario1.Usuario;
            lblRol.Text = CE_Usuario1.TipoUsuario;
            //lblId.Text = CE_Usuario1.idUsuario;
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Display a confirmation message
            DialogResult result = MessageBox.Show("¿Desea cerrar la aplicación?", "Salir de la aplicacion!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Check the user's response
            if (result == DialogResult.Yes)
            {
                // If the user clicks "Yes," close the application
                Application.Exit();
            }
            else
            {
                // If the user clicks "No," display a cancellation message
                MessageBox.Show("Se canceló el cierre de la aplicación.", "Cierre cancelado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form FrmOpen = Application.OpenForms["FrmProductos"];

            if (FrmOpen == null)
            {
                FrmProductos frmProductos = new FrmProductos();
                frmProductos.MdiParent = this;
                frmProductos.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form FrmOpen = Application.OpenForms["FrmCliente"];

            if (FrmOpen == null)
            {
                FrmCliente frmCliente = new FrmCliente();
                frmCliente.MdiParent = this;
                frmCliente.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form FrmOpen = Application.OpenForms["FrmCaja"];

            if (FrmOpen == null)
            {
                FrmCaja frmCaja = new FrmCaja();
                frmCaja.MdiParent = this;
                frmCaja.Show();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form FrmOpen = Application.OpenForms["FrmVenta"];

            if (FrmOpen == null)
            {
                FrmVenta frmVenta = new FrmVenta();
                frmVenta.MdiParent = this;
                frmVenta.Show();
            }
        }

        private void proveedoresToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Form FrmOpen = Application.OpenForms["ReporteProveedores"];

            if (FrmOpen == null)
            {
                ReporteProveedores reporteProveedores = new ReporteProveedores();
                reporteProveedores.MdiParent = this;
                reporteProveedores.Show();
            }
        }

        private void empleadosToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Form FrmOpen = Application.OpenForms["ReporteEmpleado"];

            if (FrmOpen == null)
            {
                ReporteEmpleados reporteEmpleados = new ReporteEmpleados();
                reporteEmpleados.MdiParent = this;
                reporteEmpleados.Show();
            }
        }

        private void comprasToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Form FrmOpen = Application.OpenForms["ReporteCompras"];

            if (FrmOpen == null)
            {
                ReporteCompras reporteCompras = new ReporteCompras();
                reporteCompras.MdiParent = this;
                reporteCompras.Show();
            }
        }

        private void ventasToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Form FrmOpen = Application.OpenForms["ReporteVentas"];

            if (FrmOpen == null)
            {
                ReporteVentas reporteVentas = new ReporteVentas();
                reporteVentas.MdiParent = this;
                reporteVentas.Show();
            }
        }
    }
}
