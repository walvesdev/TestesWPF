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
    /// Lógica interna para Bind.xaml
    /// </summary>
    public partial class Bind : Window
    {
        public Bind()
        {
            InitializeComponent();
        }

        private void TxbTexto_TextChanged(object sender, TextChangedEventArgs e)
        {
            //btnBind.Content = txbTexto.Text;
        }
    }
}
