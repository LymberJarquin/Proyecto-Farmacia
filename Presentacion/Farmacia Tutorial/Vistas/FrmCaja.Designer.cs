namespace Farmacia_Tutorial.Vistas
{
    partial class FrmCaja
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCaja));
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCalcular_Ingreso = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtGanancia = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCant_Productos = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIngresoVentas = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dtgCaja = new System.Windows.Forms.DataGridView();
            this.btnVentas_Realizadas = new System.Windows.Forms.Button();
            this.txtTotal_Caja = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCaja)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(173, 26);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(82, 20);
            this.dtpFecha.TabIndex = 48;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(113, 26);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(54, 16);
            this.label14.TabIndex = 47;
            this.label14.Text = "Fecha:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCalcular_Ingreso);
            this.panel1.Location = new System.Drawing.Point(362, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(252, 67);
            this.panel1.TabIndex = 49;
            // 
            // btnCalcular_Ingreso
            // 
            this.btnCalcular_Ingreso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalcular_Ingreso.Image = ((System.Drawing.Image)(resources.GetObject("btnCalcular_Ingreso.Image")));
            this.btnCalcular_Ingreso.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCalcular_Ingreso.Location = new System.Drawing.Point(38, 14);
            this.btnCalcular_Ingreso.Name = "btnCalcular_Ingreso";
            this.btnCalcular_Ingreso.Size = new System.Drawing.Size(175, 39);
            this.btnCalcular_Ingreso.TabIndex = 62;
            this.btnCalcular_Ingreso.Text = "Calcular Ingresos";
            this.btnCalcular_Ingreso.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCalcular_Ingreso.UseVisualStyleBackColor = true;
            this.btnCalcular_Ingreso.Click += new System.EventHandler(this.btnCalcular_Ingreso_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.txtGanancia);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtCant_Productos);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtIngresoVentas);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox1.Location = new System.Drawing.Point(362, 85);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(252, 139);
            this.groupBox1.TabIndex = 53;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Resumen diario";
            // 
            // txtGanancia
            // 
            this.txtGanancia.Location = new System.Drawing.Point(129, 104);
            this.txtGanancia.Name = "txtGanancia";
            this.txtGanancia.Size = new System.Drawing.Size(98, 20);
            this.txtGanancia.TabIndex = 40;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(58, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 39;
            this.label2.Text = "Ganancia:";
            // 
            // txtCant_Productos
            // 
            this.txtCant_Productos.Location = new System.Drawing.Point(129, 62);
            this.txtCant_Productos.Name = "txtCant_Productos";
            this.txtCant_Productos.Size = new System.Drawing.Size(98, 20);
            this.txtCant_Productos.TabIndex = 38;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 13);
            this.label3.TabIndex = 37;
            this.label3.Text = "Cant. de Productos:";
            // 
            // txtIngresoVentas
            // 
            this.txtIngresoVentas.Location = new System.Drawing.Point(129, 24);
            this.txtIngresoVentas.Name = "txtIngresoVentas";
            this.txtIngresoVentas.Size = new System.Drawing.Size(98, 20);
            this.txtIngresoVentas.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ingreso por ventas:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(39, 52);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(231, 172);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 54;
            this.pictureBox1.TabStop = false;
            // 
            // dtgCaja
            // 
            this.dtgCaja.AllowUserToAddRows = false;
            this.dtgCaja.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgCaja.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCaja.Location = new System.Drawing.Point(12, 230);
            this.dtgCaja.Name = "dtgCaja";
            this.dtgCaja.Size = new System.Drawing.Size(602, 234);
            this.dtgCaja.TabIndex = 55;
            // 
            // btnVentas_Realizadas
            // 
            this.btnVentas_Realizadas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVentas_Realizadas.Image = ((System.Drawing.Image)(resources.GetObject("btnVentas_Realizadas.Image")));
            this.btnVentas_Realizadas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVentas_Realizadas.Location = new System.Drawing.Point(12, 470);
            this.btnVentas_Realizadas.Name = "btnVentas_Realizadas";
            this.btnVentas_Realizadas.Size = new System.Drawing.Size(175, 39);
            this.btnVentas_Realizadas.TabIndex = 63;
            this.btnVentas_Realizadas.Text = "Ventas Realizadas";
            this.btnVentas_Realizadas.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVentas_Realizadas.UseVisualStyleBackColor = true;
            this.btnVentas_Realizadas.Click += new System.EventHandler(this.btnVentas_Realizadas_Click);
            // 
            // txtTotal_Caja
            // 
            this.txtTotal_Caja.Location = new System.Drawing.Point(491, 480);
            this.txtTotal_Caja.Name = "txtTotal_Caja";
            this.txtTotal_Caja.Size = new System.Drawing.Size(98, 20);
            this.txtTotal_Caja.TabIndex = 65;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(372, 483);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 13);
            this.label4.TabIndex = 64;
            this.label4.Text = "TOTAL EN CAJA:";
            // 
            // FrmCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 516);
            this.Controls.Add(this.txtTotal_Caja);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnVentas_Realizadas);
            this.Controls.Add(this.dtgCaja);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.label14);
            this.Name = "FrmCaja";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmCaja";
            this.Load += new System.EventHandler(this.FrmCaja_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCaja)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCalcular_Ingreso;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtGanancia;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCant_Productos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIngresoVentas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dtgCaja;
        private System.Windows.Forms.Button btnVentas_Realizadas;
        private System.Windows.Forms.TextBox txtTotal_Caja;
        private System.Windows.Forms.Label label4;
    }
}