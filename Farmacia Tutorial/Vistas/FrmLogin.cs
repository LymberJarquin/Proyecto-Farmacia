using CapasNegocio;
using Farmacia_Tutorial.Vistas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapasDatos;
using CapasEntidad;

namespace Farmacia_Tutorial
{
    public partial class FrmLogin : Form
    {
        CN_Usuario metodos = new CN_Usuario();
        CD_Usuario Login1 = new CD_Usuario();
        
        public FrmLogin()
        {
            InitializeComponent();

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {

            if(txtUsuario.Text != "Username")
            {
                if(txtContraseña.Text != "Password")
                {
                    CN_Usuario cN_Usuario = new CN_Usuario();
                    var validLogin = cN_Usuario.LoginUser(txtUsuario.Text, txtContraseña.Text);
                    if(validLogin == true)
                    {
                        if (CE_Usuario1.TipoUsuario == Positions.Administrador)
                        {
                            FrmPrincipal MainMenu = new FrmPrincipal();
                            MessageBox.Show("Bienvenido(a):\n" + CE_Usuario1.Nombres + " " + CE_Usuario1.Apellidos + "\nRol: Administrador", "Ingreso Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            MainMenu.Show();
                            MainMenu.FormClosed += Logout;
                            this.Hide();
                        }
                       
                        if (CE_Usuario1.TipoUsuario == Positions.Vendedor)
                        {
                            FrmPrincipal MainMenu = new FrmPrincipal();
                            MessageBox.Show("Bienvenido(a):\n" + CE_Usuario1.Nombres + " " + CE_Usuario1.Apellidos + "\nRol: Vendedor", "Ingreso Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            MainMenu.Show();
                            MainMenu.FormClosed += Logout;
                            this.Hide();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Usuario no registrado", "Error de Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                   
                    txtContraseña.Clear();
                    txtUsuario.Focus();
                }
                else
                {
                    MessageBox.Show("Please enter password");
                }
            }

        }

        private void Logout(object sender, FormClosedEventArgs e)
        {
            txtContraseña.Clear();
            txtUsuario.Clear();
            this.Show();
            txtUsuario.Focus();
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtContraseña.Focus();
            }
        }

        private void txtContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnIngresar.Focus();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
