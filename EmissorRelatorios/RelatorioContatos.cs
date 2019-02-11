using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmissorRelatorios
{
    public partial class frmRelatorioContatos : Form
    {
        public frmRelatorioContatos()
        {
            InitializeComponent();
        }

        private void frmRelatorioContatos_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'agendaDBDataSet.Contatos'. Você pode movê-la ou removê-la conforme necessário.
            this.contatosTableAdapter.Fill(this.agendaDBDataSet.Contatos);

            this.reportViewer1.RefreshReport();
        }
    }
}
