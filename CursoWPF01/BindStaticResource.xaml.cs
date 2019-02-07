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
    /// Lógica interna para BindStaticResource.xaml
    /// </summary>
    public partial class BindStaticResource : Window
    {
        public BindStaticResource()
        {
            InitializeComponent();

            Filme filme = new Filme
            {
                Id = 02,
                Nome = "Os Trapalhoes",
                Ano = 1990
            };

            Binding bdFilme = new Binding()
            {
                Source = filme
                
            };
            bdFilme.Path = new PropertyPath("Id");
            bdFilme.Path = new PropertyPath("Nome");
            bdFilme.Path = new PropertyPath("Ano");

            txbCodigo_Copy.SetBinding(TextBox.TextProperty, bdFilme);
            txbNome_Copy.SetBinding(TextBox.TextProperty, bdFilme);
            txbAno_Copy.SetBinding(TextBox.TextProperty, bdFilme);
        }
    }
}
