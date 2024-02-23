namespace Farmacia_Tutorial.Vistas
{
    partial class ReporteProductos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReporteProductos));
            this.btnVolver = new System.Windows.Forms.Button();
            this.dtgReporteProductos = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtEstado = new System.Windows.Forms.TextBox();
            this.rbEstado = new System.Windows.Forms.RadioButton();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.rbMostrarReporte_General = new System.Windows.Forms.RadioButton();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtPresentacion = new System.Windows.Forms.TextBox();
            this.rbId = new System.Windows.Forms.RadioButton();
            this.rbPresentacion = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dtgReporteProductos)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnVolver
            // 
            this.btnVolver.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolver.Image = ((System.Drawing.Image)(resources.GetObject("btnVolver.Image")));
            this.btnVolver.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnVolver.Location = new System.Drawing.Point(804, 504);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(71, 57);
            this.btnVolver.TabIndex = 65;
            this.btnVolver.Text = "Volver";
            this.btnVolver.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // dtgReporteProductos
            // 
            this.dtgReporteProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgReporteProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgReporteProductos.Location = new System.Drawing.Point(12, 204);
            this.dtgReporteProductos.Name = "dtgReporteProductos";
            this.dtgReporteProductos.Size = new System.Drawing.Size(863, 294);
            this.dtgReporteProductos.TabIndex = 64;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.txtEstado);
            this.groupBox1.Controls.Add(this.rbEstado);
            this.groupBox1.Controls.Add(this.btnGenerar);
            this.groupBox1.Controls.Add(this.rbMostrarReporte_General);
            this.groupBox1.Controls.Add(this.txtId);
            this.groupBox1.Controls.Add(this.txtPresentacion);
            this.groupBox1.Controls.Add(this.rbId);
            this.groupBox1.Controls.Add(this.rbPresentacion);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(863, 186);
            this.groupBox1.TabIndex = 63;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Reportes:";
            // 
            // txtEstado
            // 
            this.txtEstado.Location = new System.Drawing.Point(283, 112);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.Size = new System.Drawing.Size(204, 20);
            this.txtEstado.TabIndex = 59;
            this.txtEstado.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtEstado_KeyUp);
            // 
            // rbEstado
            // 
            this.rbEstado.AutoSize = true;
            this.rbEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbEstado.Location = new System.Drawing.Point(28, 113);
            this.rbEstado.Name = "rbEstado";
            this.rbEstado.Size = new System.Drawing.Size(209, 19);
            this.rbEstado.TabIndex = 58;
            this.rbEstado.TabStop = true;
            this.rbEstado.Text = "Generar Reporte por Estado:";
            this.rbEstado.UseVisualStyleBackColor = true;
            this.rbEstado.CheckedChanged += new System.EventHandler(this.rbEstado_CheckedChanged);
            // 
            // btnGenerar
            // 
            this.btnGenerar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerar.Image = ((System.Drawing.Image)(resources.GetObject("btnGenerar.Image")));
            this.btnGenerar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnGenerar.Location = new System.Drawing.Point(531, 37);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(99, 57);
            this.btnGenerar.TabIndex = 57;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGenerar.UseVisualStyleBackColor = true;
            // 
            // rbMostrarReporte_General
            // 
            this.rbMostrarReporte_General.AutoSize = true;
            this.rbMostrarReporte_General.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbMostrarReporte_General.Location = new System.Drawing.Point(28, 151);
            this.rbMostrarReporte_General.Name = "rbMostrarReporte_General";
            this.rbMostrarReporte_General.Size = new System.Drawing.Size(184, 19);
            this.rbMostrarReporte_General.TabIndex = 56;
            this.rbMostrarReporte_General.TabStop = true;
            this.rbMostrarReporte_General.Text = "Mostrar Reporte General";
            this.rbMostrarReporte_General.UseVisualStyleBackColor = true;
            this.rbMostrarReporte_General.CheckedChanged += new System.EventHandler(this.rbMostrarReporte_General_CheckedChanged);
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(283, 74);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(204, 20);
            this.txtId.TabIndex = 54;
            this.txtId.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtId_KeyUp);
            // 
            // txtPresentacion
            // 
            this.txtPresentacion.Location = new System.Drawing.Point(283, 35);
            this.txtPresentacion.Name = "txtPresentacion";
            this.txtPresentacion.Size = new System.Drawing.Size(204, 20);
            this.txtPresentacion.TabIndex = 53;
            this.txtPresentacion.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPresentacion_KeyUp);
            // 
            // rbId
            // 
            this.rbId.AutoSize = true;
            this.rbId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbId.Location = new System.Drawing.Point(28, 73);
            this.rbId.Name = "rbId";
            this.rbId.Size = new System.Drawing.Size(177, 19);
            this.rbId.TabIndex = 51;
            this.rbId.TabStop = true;
            this.rbId.Text = "Generar Reporte por Id:";
            this.rbId.UseVisualStyleBackColor = true;
            this.rbId.CheckedChanged += new System.EventHandler(this.rbId_CheckedChanged);
            // 
            // rbPresentacion
            // 
            this.rbPresentacion.AutoSize = true;
            this.rbPresentacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbPresentacion.Location = new System.Drawing.Point(28, 33);
            this.rbPresentacion.Name = "rbPresentacion";
            this.rbPresentacion.Size = new System.Drawing.Size(249, 19);
            this.rbPresentacion.TabIndex = 50;
            this.rbPresentacion.TabStop = true;
            this.rbPresentacion.Text = "Generar Reporte por Presentacion:";
            this.rbPresentacion.UseVisualStyleBackColor = true;
            this.rbPresentacion.CheckedChanged += new System.EventHandler(this.rbPresentacion_CheckedChanged);
            // 
            // ReporteProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 570);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.dtgReporteProductos);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ReporteProductos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReporteProductos";
            this.Load += new System.EventHandler(this.ReporteProductos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgReporteProductos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.DataGridView dtgReporteProductos;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.RadioButton rbMostrarReporte_General;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtPresentacion;
        private System.Windows.Forms.RadioButton rbId;
        private System.Windows.Forms.RadioButton rbPresentacion;
        private System.Windows.Forms.TextBox txtEstado;
        private System.Windows.Forms.RadioButton rbEstado;
    }
}