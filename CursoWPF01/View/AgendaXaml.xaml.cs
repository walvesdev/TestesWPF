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
                lblQtdContatos.Content = banco.ContarContatos();
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
                           DesabilitarCampos("inicio");
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
                           DesabilitarCampos("inicio");
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
            PreencherDataGridView();


        }

        private void LimparCampos()
        {
            txbID.Text = "";
            txbNome.Text = "";
            txbEmail.Text = "";
            txbTelefone.Text = "";
            txbPesquisa.Text = "";
        }

        private void TxbLocalizar_Click(object sender, RoutedEventArgs e)
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
            btnInserir.IsEnabled = false;
            btnLocalizar.IsEnabled = false;
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

            switch (op)
            {
                case "inicio":
                    btnInserir.IsEnabled = true;
                    btnLocalizar.IsEnabled = true;
                    break;
                case "alterar":
                    btnSalvar.IsEnabled = true;
                    btnCancelar.IsEnabled = true;
                    txbNome.IsEnabled = true;
                    txbEmail.IsEnabled = true;
                    txbTelefone.IsEnabled = true;
                    break;
                case "pesquisa":
                    txbID.IsEnabled = true;
                    btnCancelar.IsEnabled = true;
                    txbPesquisa.IsEnabled = true;
                    btnPesquisar.IsEnabled = true;
                    break;
                case "inserir":
                    btnSalvar.IsEnabled = true;
                    btnCancelar.IsEnabled = true;
                    txbNome.IsEnabled = true;
                    txbEmail.IsEnabled = true;
                    txbTelefone.IsEnabled = true;
                    break;
                case "cancelar":
                    btnInserir.IsEnabled = true;
                    btnLocalizar.IsEnabled = true;
                    operacao = "";
                    break;
                case "linhaDgv":
                    btnAlterar.IsEnabled = true;
                    btnCancelar.IsEnabled = true;
                    btnPesquisar.IsEnabled = true;
                    txbPesquisa.IsEnabled = true;
                    btnExcluir.IsEnabled = true;
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
                    LimparCampos();
                }
            }
        }

        private void TxbID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                try
                {
                    using (ContatoDao banco = new ContatoDao())
                    {
                        Contato contato = banco.PesquisarPorId(Convert.ToInt32(txbID.Text));
                        if (contato != null)
                        {
                            List<Contato> contatos = new List<Contato>();
                            contatos.Add(contato);

                            dgvContatos.ItemsSource = contatos;
                            dgvContatos.Items.Refresh();
                            LimparCampos();
                        }
                        else
                        {
                            MessageBox.Show("ID não encontrado");
                        }
                        
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Digite um ID Válido!");

                }
                   
                
            }
        }

        private void DgvContatos_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            DesabilitarCampos("linhaDgv");
        }
    }
}
