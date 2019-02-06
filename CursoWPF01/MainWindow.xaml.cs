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

        

       
        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ListViewTest lvt = new ListViewTest();
            lvt.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Bind bind = new Bind();
            bind.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            DockPanel dockPanel = new DockPanel();
            dockPanel.ShowDialog();

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            CalculoSalario calculoSalario = new CalculoSalario();
            calculoSalario.ShowDialog();
        }

        private void BtnStackpanel_Click(object sender, RoutedEventArgs e)
        {
            StackPanel stackPanel = new StackPanel();
            stackPanel.ShowDialog();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            BindStaticResource bindStaticResource = new BindStaticResource();
            bindStaticResource.ShowDialog();
        }
    }
}
