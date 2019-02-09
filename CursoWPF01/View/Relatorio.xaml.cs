using CrystalDecisions.CrystalReports.Engine;
using CursoWPF01.Relatorios;
using Microsoft.Reporting.WinForms;
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
    /// Lógica interna para Relatorio.xaml
    /// </summary>
    public partial class Relatorio : Window
    {
        public Relatorio()
        {
            InitializeComponent();
        }

        private void WindowsFormsHost_Loaded(object sender, RoutedEventArgs e)
        {
          
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string path_ = System.AppDomain.CurrentDomain.BaseDirectory;
            string caminho = path_ + "ContatosRP.rpt";

            ContatosReport contatoReport = new ContatosReport();
            contatoReport.Load(caminho);
            ContatosReportViewer.ViewerCore.ReportSource = contatoReport;
        }
    }
}
