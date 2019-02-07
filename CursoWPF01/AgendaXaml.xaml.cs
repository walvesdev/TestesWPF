using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CursoWPF01
{
    /// <summary>
    /// Lógica interna para Agenda.xaml
    /// </summary>
    public partial class AgendaXaml : Window
    {
        private string operacao;
        public AgendaXaml()
        {
            InitializeComponent();
        }

        private void TxbSalvar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Contato contato = new Contato
                {
                    Nome = txbNome.Text,
                    Email = txbEmail.Text,
                    Telefone = Convert.ToInt32(txbTelefone.Text)
                };
                using (ContatoDao banco = new ContatoDao())
                {
                    banco.Inserir(contato);
                }
                txbNome.Text = string.Empty;
                txbEmail.Text = string.Empty;
                txbTelefone.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Verifique os dados digitados! {ex.Message}");
            }
           

            

        }

        private void TxbCancelar_Click(object sender, RoutedEventArgs e)
        {
            txbNome.Text = string.Empty;
            txbEmail.Text = string.Empty;
            txbTelefone.Text = string.Empty;

            this.Close();
        }
    }
}
