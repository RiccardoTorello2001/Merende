using System;
using System.Collections.Generic;
using System.IO;
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

namespace Merende
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        private List<Merenda> merendeDisponibili;

        public MainWindow()
        {
            InitializeComponent();

            merendeDisponibili = new List<Merenda>();

           
        }
        private void CaricamentoMerende()
        {
            string line;
            StreamReader sr = new StreamReader("Merende.csv");
            sr.ReadLine();
            while ((line = sr.ReadLine()) != null)
            {
                try
                {
                    Merenda m = new Merenda();
                    string[] campi = line.Split(';');
                    string nome = campi[0];
                    m.Nome = nome;
                    double prezzo = Convert.ToDouble(campi[1]);
                    m.Prezzo = prezzo;
                    merendeDisponibili.Add(m);
                }
                catch(Exception e)
                {
                    MessageBox.Show(e.ToString());
                    break;
                }
                

            }
            Dispatcher.Invoke(() => lst_lista.ItemsSource = merendeDisponibili);
        }

        private void Btn_visualizzalista_Click(object sender, RoutedEventArgs e)
        {
            Task.Factory.StartNew(CaricamentoMerende);
        }
    }
}
