namespace EmissorRelatorios
{
    partial class frmRelatorioContatos
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.contatosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.agendaDBDataSet = new EmissorRelatorios.AgendaDBDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.contatosTableAdapter = new EmissorRelatorios.AgendaDBDataSetTableAdapters.ContatosTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.contatosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.agendaDBDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // contatosBindingSource
            // 
            this.contatosBindingSource.DataMember = "Contatos";
            this.contatosBindingSource.DataSource = this.agendaDBDataSet;
            // 
            // agendaDBDataSet
            // 
            this.agendaDBDataSet.DataSetName = "AgendaDBDataSet";
            this.agendaDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.AutoSize = true;
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.contatosBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "EmissorRelatorios.RelatoriosWPF.ContatosRelatorio.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // contatosTableAdapter
            // 
            this.contatosTableAdapter.ClearBeforeFill = true;
            // 
            // frmRelatorioContatos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmRelatorioContatos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relatorio de Contatos Cadastrados";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRelatorioContatos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.contatosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.agendaDBDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private AgendaDBDataSet agendaDBDataSet;
        private System.Windows.Forms.BindingSource contatosBindingSource;
        private AgendaDBDataSetTableAdapters.ContatosTableAdapter contatosTableAdapter;
    }
}

