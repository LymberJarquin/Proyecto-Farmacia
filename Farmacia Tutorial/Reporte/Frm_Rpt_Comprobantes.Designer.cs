namespace Farmacia_Tutorial.Reporte
{
    partial class Frm_Rpt_Comprobantes
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
            this.uSPtipocomprobanteobtenerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.uSP_tipocomprobante_obtenerTableAdapter = new Farmacia_Tutorial.Reporte.DataSet_FarmaciaTableAdapters.USP_tipocomprobante_obtenerTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_Farmacia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uSPtipocomprobanteobtenerBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.uSPtipocomprobanteobtenerBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Farmacia_Tutorial.Reporte.Rpt_Comprobantes.rdlc";
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
            // uSPtipocomprobanteobtenerBindingSource
            // 
            this.uSPtipocomprobanteobtenerBindingSource.DataMember = "USP_tipocomprobante_obtener";
            this.uSPtipocomprobanteobtenerBindingSource.DataSource = this.dataSet_Farmacia;
            // 
            // uSP_tipocomprobante_obtenerTableAdapter
            // 
            this.uSP_tipocomprobante_obtenerTableAdapter.ClearBeforeFill = true;
            // 
            // Frm_Rpt_Comprobantes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Frm_Rpt_Comprobantes";
            this.Text = "Frm_Rpt_Comprobantes";
            this.Load += new System.EventHandler(this.Frm_Rpt_Comprobantes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_Farmacia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uSPtipocomprobanteobtenerBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private DataSet_Farmacia dataSet_Farmacia;
        private System.Windows.Forms.BindingSource uSPtipocomprobanteobtenerBindingSource;
        private DataSet_FarmaciaTableAdapters.USP_tipocomprobante_obtenerTableAdapter uSP_tipocomprobante_obtenerTableAdapter;
    }
}