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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CursoWPF01
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCalcular_Click(object sender, RoutedEventArgs e)
        {
            var nome = txbNome.Text;
            double qtd = Convert.ToDouble(txbQtdHoras.Text);
            double valor = Convert.ToDouble(txbValorHora.Text);
            double salarioLiquido = qtd * valor;

            txbSalarioliquido.Text = salarioLiquido.ToString();
        }

        private void TxbTexto_TextChanged(object sender, TextChangedEventArgs e)
        {
            //btnBind.Content = txbTexto.Text;
        }
    }
}
