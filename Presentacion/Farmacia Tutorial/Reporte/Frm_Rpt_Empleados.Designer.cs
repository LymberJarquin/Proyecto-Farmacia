namespace Farmacia_Tutorial.Reporte
{
    partial class Frm_Rpt_Empleados
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dataSet_Farmacia = new Farmacia_Tutorial.Reporte.DataSet_Farmacia();
            this.uSPempleadoobtenerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.uSP_empleado_obtenerTableAdapter = new Farmacia_Tutorial.Reporte.DataSet_FarmaciaTableAdapters.USP_empleado_obtenerTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_Farmacia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uSPempleadoobtenerBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.uSPempleadoobtenerBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Farmacia_Tutorial.Reporte.Rpt_Empleados.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // dataSet_Farmacia
            // 
            this.dataSet_Farmacia.DataSetName = "DataSet_Farmacia";
            this.dataSet_Farmacia.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // uSPempleadoobtenerBindingSource
            // 
            this.uSPempleadoobtenerBindingSource.DataMember = "USP_empleado_obtener";
            this.uSPempleadoobtenerBindingSource.DataSource = this.dataSet_Farmacia;
            // 
            // uSP_empleado_obtenerTableAdapter
            // 
            this.uSP_empleado_obtenerTableAdapter.ClearBeforeFill = true;
            // 
            // Frm_Rpt_Empleados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Frm_Rpt_Empleados";
            this.Text = "Frm_Rpt_Empleados";
            this.Load += new System.EventHandler(this.Frm_Rpt_Empleados_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_Farmacia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uSPempleadoobtenerBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private DataSet_Farmacia dataSet_Farmacia;
        private System.Windows.Forms.BindingSource uSPempleadoobtenerBindingSource;
        private DataSet_FarmaciaTableAdapters.USP_empleado_obtenerTableAdapter uSP_empleado_obtenerTableAdapter;
    }
}