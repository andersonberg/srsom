using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SOM
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            DateTime inicio = DateTime.Now;

            Treinamento train = new Treinamento();
            StringBuilder texto = train.Saida;
            texto.Append(train.Teste());

            DateTime fim = DateTime.Now;
            TimeSpan duracao = fim.Subtract(inicio);

            texto.Append("\n\nSimulação levou: " + duracao.Hours + ":" + duracao.Minutes + ":" + duracao.Seconds);

            train.EscreveArquivo(texto);

            train.CreateChart(gridPrincipal);

            //this.Close();
        }
    }
}
