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

        private async void PreencherDataGridView()
        {
            using (ContatoDao banco = new ContatoDao())
            {
                dgvContatos.ItemsSource = await banco.ListarTodos();
                dgvContatos.Items.Refresh();
            }
        }

        private void TxbSalvar_Click(object sender, RoutedEventArgs e)
        {
            switch (operacao)
            {
                case "inserir":
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

                            LimparCampos();
                            PreencherDataGridView();
                            DesabilitarCampos("inserir");
                        }
                       

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Verifique os dados digitados! {ex.Message}");
                    }
                    break;

                case "alterar":
                    try
                    {
                        Contato contato = new Contato
                        {
                            Id = Convert.ToInt32(txbID.Text),
                            Nome = txbNome.Text,
                            Email = txbEmail.Text,
                            Telefone = Convert.ToInt32(txbTelefone.Text)
                        };
                        using (ContatoDao banco = new ContatoDao())
                        {
                            banco.Alterar(contato);

                            LimparCampos();
                            PreencherDataGridView();
                            DesabilitarCampos("alterar");
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Verifique os dados digitados! {ex.Message}");
                    }
                    break;
            }

        }

        private void TxbCancelar_Click(object sender, RoutedEventArgs e)
        {
           
            LimparCampos();
            DesabilitarCampos("cancelar");
            

        }

        private void LimparCampos()
        {
            txbID.Text = "";
            txbNome.Text = "";
            txbEmail.Text = "";
            txbTelefone.Text = "";
        }

        private  void TxbLocalizar_Click(object sender, RoutedEventArgs e)
        {
            DesabilitarCampos("pesquisa");
            txbPesquisa.Focus();
            
                
        }

        private void TxbInserir_Click(object sender, RoutedEventArgs e)
        {
            this.operacao = "inserir";
            DesabilitarCampos("inserir");
            txbNome.Focus();
        }       

        private void TxbAlterar_Click(object sender, RoutedEventArgs e)
        {
            DesabilitarCampos("alterar");
            txbNome.Focus();

            this.operacao = "alterar";
            Contato contato = dgvContatos.SelectedItem as Contato;

            txbID.Text = contato.Id.ToString();
            txbNome.Text = contato.Nome;
            txbEmail.Text = contato.Email;
            txbTelefone.Text = contato.Telefone.ToString();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PreencherDataGridView();
            DesabilitarCampos("inicio");
        }

        private void DesabilitarCampos(String op)
        {
            switch (op)
            {
                case "inicio":
                    btnInserir.IsEnabled = true;
                    btnLocalizar.IsEnabled = true;
                    btnSalvar.IsEnabled = false;
                    btnAlterar.IsEnabled = false;
                    btnCancelar.IsEnabled = false;
                    btnExcluir.IsEnabled = false;
                    txbID.IsEnabled = false;
                    txbNome.IsEnabled = false;
                    txbEmail.IsEnabled = false;
                    txbTelefone.IsEnabled = false;
                    txbPesquisa.IsEnabled = false;
                    btnPesquisar.IsEnabled = false;
                    break;
                case "alterar":
                    btnInserir.IsEnabled = false;
                    btnLocalizar.IsEnabled = false;
                    btnAlterar.IsEnabled = false;
                    btnSalvar.IsEnabled = true;
                    btnCancelar.IsEnabled = true;
                    btnExcluir.IsEnabled = false;
                    txbID.IsEnabled = false;
                    txbNome.IsEnabled = true;
                    txbEmail.IsEnabled = true;
                    txbTelefone.IsEnabled = true;
                    txbPesquisa.IsEnabled = false;
                    btnPesquisar.IsEnabled = false;
                    operacao = "alterar";
                    break;
                case "pesquisa":
                    btnInserir.IsEnabled = false;
                    btnLocalizar.IsEnabled = false;
                    btnAlterar.IsEnabled = false;
                    btnSalvar.IsEnabled = false;
                    btnCancelar.IsEnabled = true;
                    btnExcluir.IsEnabled = false;
                    txbID.IsEnabled = false;
                    txbNome.IsEnabled = false;
                    txbEmail.IsEnabled = false;
                    txbTelefone.IsEnabled = false;
                    txbPesquisa.IsEnabled = true;
                    btnPesquisar.IsEnabled = true;
                    break;
                case "inserir":
                    btnLocalizar.IsEnabled = false;
                    btnAlterar.IsEnabled = false;
                    btnSalvar.IsEnabled = true;
                    btnCancelar.IsEnabled = true;
                    btnExcluir.IsEnabled = false;
                    txbID.IsEnabled = false;
                    txbNome.IsEnabled = true;
                    txbEmail.IsEnabled = true;
                    txbTelefone.IsEnabled = true;
                    txbPesquisa.IsEnabled = false;
                    btnPesquisar.IsEnabled = false;
                    operacao = "inserir";
                    break;
                case "cancelar":
                    btnInserir.IsEnabled = true;
                    btnLocalizar.IsEnabled = true;
                    btnAlterar.IsEnabled = false;
                    btnSalvar.IsEnabled = false;
                    btnCancelar.IsEnabled = false;
                    btnExcluir.IsEnabled = false;
                    txbID.IsEnabled = false;
                    txbNome.IsEnabled = false;
                    txbEmail.IsEnabled = false;
                    txbTelefone.IsEnabled = false;
                    txbPesquisa.IsEnabled = false;
                    btnPesquisar.IsEnabled = false;
                    operacao = "";
                    break;
                case "linhaDgv":
                    btnInserir.IsEnabled = false;
                    btnLocalizar.IsEnabled = false;
                    btnAlterar.IsEnabled = true;
                    btnSalvar.IsEnabled = false;
                    btnCancelar.IsEnabled = true;
                    btnExcluir.IsEnabled = false;
                    txbID.IsEnabled = false;
                    txbNome.IsEnabled = false;
                    txbEmail.IsEnabled = false;
                    txbTelefone.IsEnabled = false;
                    txbPesquisa.IsEnabled = false;
                    btnPesquisar.IsEnabled = false;
                    break;


            }
        }

        private void BtnExcluir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var result = MessageBox.Show("Gostaria de excluir este item?", "Confirmation", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    using (ContatoDao banco = new ContatoDao())
                    {
                        Contato contato = dgvContatos.SelectedItem as Contato;
                        banco.Excluir(contato);

                        DesabilitarCampos("inicio");
                        PreencherDataGridView();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Algo deu errado! {ex.Message}");
            }


        }

        private void DgvContatos_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            DesabilitarCampos("linhaDgv");
        }

        private async void BtnPesquisar_Click(object sender, RoutedEventArgs e)
        {
            if (txbPesquisa.Text == null || txbPesquisa.Text == string.Empty || txbPesquisa.Text == "")
            {
                PreencherDataGridView();
            }
            else
            {
                using (ContatoDao banco = new ContatoDao())
                {
                    Contato contato = new Contato { Nome = txbPesquisa.Text };

                    dgvContatos.ItemsSource = await banco.PesquisaPorNome(contato.Nome.Trim());
                    dgvContatos.Items.Refresh();
                }
            }
        }
    }
}
