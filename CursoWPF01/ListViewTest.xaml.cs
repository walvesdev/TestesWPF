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
    /// Lógica interna para ListViewTest.xaml
    /// </summary>
    public partial class ListViewTest : Window
    {
        public ListViewTest()
        {
            InitializeComponent();
        }

        private void BtnInserir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var item = txbItem.Text;
                lvProdutos.Items.Add(item);
                txbItem.Text = string.Empty;
            }
            catch
            {
                MessageBox.Show("Digite o intem a ser Inserido.");
            }
            
        }

        private void BtnExcluir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var item = lvProdutos.Items.IndexOf(lvProdutos.SelectedItem);
                lvProdutos.Items.RemoveAt(item);
            }
            catch
            {
                MessageBox.Show("Selecione o intem a ser removido.");
            }
        }
    }
}
