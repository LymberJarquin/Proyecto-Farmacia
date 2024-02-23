namespace Farmacia_Tutorial.Vistas
{
    partial class ReportesClientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportesClientes));
            this.label1 = new System.Windows.Forms.Label();
            this.txtCantidadRegistros = new System.Windows.Forms.TextBox();
            this.btnVolver = new System.Windows.Forms.Button();
            this.dtgReporteClientes = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.rbMostrarReporte_General = new System.Windows.Forms.RadioButton();
            this.txtRuc = new System.Windows.Forms.TextBox();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.rbRuc = new System.Windows.Forms.RadioButton();
            this.rbDni = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dtgReporteClientes)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(236, 493);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 16);
            this.label1.TabIndex = 62;
            this.label1.Text = "Cantidad de Registros:";
            // 
            // txtCantidadRegistros
            // 
            this.txtCantidadRegistros.Location = new System.Drawing.Point(408, 489);
            this.txtCantidadRegistros.Name = "txtCantidadRegistros";
            this.txtCantidadRegistros.Size = new System.Drawing.Size(156, 20);
            this.txtCantidadRegistros.TabIndex = 61;
            // 
            // btnVolver
            // 
            this.btnVolver.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolver.Image = ((System.Drawing.Image)(resources.GetObject("btnVolver.Image")));
            this.btnVolver.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnVolver.Location = new System.Drawing.Point(804, 481);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(71, 57);
            this.btnVolver.TabIndex = 60;
            this.btnVolver.Text = "Volver";
            this.btnVolver.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // dtgReporteClientes
            // 
            this.dtgReporteClientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgReporteClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgReporteClientes.Location = new System.Drawing.Point(12, 181);
            this.dtgReporteClientes.Name = "dtgReporteClientes";
            this.dtgReporteClientes.Size = new System.Drawing.Size(863, 294);
            this.dtgReporteClientes.TabIndex = 59;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.btnImprimir);
            this.groupBox1.Controls.Add(this.rbMostrarReporte_General);
            this.groupBox1.Controls.Add(this.txtRuc);
            this.groupBox1.Controls.Add(this.txtDni);
            this.groupBox1.Controls.Add(this.rbRuc);
            this.groupBox1.Controls.Add(this.rbDni);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(863, 163);
            this.groupBox1.TabIndex = 58;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Reportes:";
            // 
            // btnImprimir
            // 
            this.btnImprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimir.Image")));
            this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnImprimir.Location = new System.Drawing.Point(517, 35);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(99, 57);
            this.btnImprimir.TabIndex = 57;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.UseVisualStyleBackColor = true;
            // 
            // rbMostrarReporte_General
            // 
            this.rbMostrarReporte_General.AutoSize = true;
            this.rbMostrarReporte_General.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbMostrarReporte_General.Location = new System.Drawing.Point(25, 126);
            this.rbMostrarReporte_General.Name = "rbMostrarReporte_General";
            this.rbMostrarReporte_General.Size = new System.Drawing.Size(184, 19);
            this.rbMostrarReporte_General.TabIndex = 56;
            this.rbMostrarReporte_General.TabStop = true;
            this.rbMostrarReporte_General.Text = "Mostrar Reporte General";
            this.rbMostrarReporte_General.UseVisualStyleBackColor = true;
            this.rbMostrarReporte_General.CheckedChanged += new System.EventHandler(this.rbMostrarReporte_General_CheckedChanged);
            // 
            // txtRuc
            // 
            this.txtRuc.Location = new System.Drawing.Point(245, 82);
            this.txtRuc.Name = "txtRuc";
            this.txtRuc.Size = new System.Drawing.Size(204, 20);
            this.txtRuc.TabIndex = 54;
            this.txtRuc.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtRuc_KeyUp);
            // 
            // txtDni
            // 
            this.txtDni.Location = new System.Drawing.Point(245, 33);
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(156, 20);
            this.txtDni.TabIndex = 53;
            this.txtDni.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDni_KeyUp);
            // 
            // rbRuc
            // 
            this.rbRuc.AutoSize = true;
            this.rbRuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbRuc.Location = new System.Drawing.Point(28, 83);
            this.rbRuc.Name = "rbRuc";
            this.rbRuc.Size = new System.Drawing.Size(194, 19);
            this.rbRuc.TabIndex = 51;
            this.rbRuc.TabStop = true;
            this.rbRuc.Text = "Generar Reporte por RUC:";
            this.rbRuc.UseVisualStyleBackColor = true;
            this.rbRuc.CheckedChanged += new System.EventHandler(this.rbRuc_CheckedChanged);
            // 
            // rbDni
            // 
            this.rbDni.AutoSize = true;
            this.rbDni.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDni.Location = new System.Drawing.Point(28, 33);
            this.rbDni.Name = "rbDni";
            this.rbDni.Size = new System.Drawing.Size(189, 19);
            this.rbDni.TabIndex = 50;
            this.rbDni.TabStop = true;
            this.rbDni.Text = "Generar Reporte por DNI:";
            this.rbDni.UseVisualStyleBackColor = true;
            this.rbDni.CheckedChanged += new System.EventHandler(this.rbDni_CheckedChanged);
            // 
            // ReportesClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 547);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCantidadRegistros);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.dtgReporteClientes);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ReportesClientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReportesClientes";
            ((System.ComponentModel.ISupportInitialize)(this.dtgReporteClientes)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCantidadRegistros;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.DataGridView dtgReporteClientes;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.RadioButton rbMostrarReporte_General;
        private System.Windows.Forms.TextBox txtRuc;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.RadioButton rbRuc;
        private System.Windows.Forms.RadioButton rbDni;
    }
}