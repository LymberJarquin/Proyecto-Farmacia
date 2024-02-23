using CapasDatos;
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
    public partial class AdministradorPerfil : Form
    {
        public AdministradorPerfil()
        {
            InitializeComponent();
        }



        private void btnSeleccionar_Imagen_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();

                // Configuración del cuadro de diálogo para seleccionar imágenes
                openFileDialog1.Filter = "Archivos de imagen (*.jpg, *.jpeg, *.png, *.gif)|*.jpg; *.jpeg; *.png; *.gif";
                openFileDialog1.Title = "Seleccionar imagen";

                // Si el usuario selecciona una imagen y hace clic en "Aceptar"
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    // Obtener la ruta del archivo seleccionado
                    string imagePath = openFileDialog1.FileName;

                    // Cargar la imagen en un PictureBox u otro control para mostrarla en la interfaz de usuario
                    picturePhoto.Image = Image.FromFile(imagePath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir la imagen: " + ex.Message);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
          
        }



        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
    }
