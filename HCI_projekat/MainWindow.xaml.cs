using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace HCI_projekat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DataIO serializer = new DataIO();
        public static BindingList<UspesneZene> uspesneZene { get; set; }

       public MainWindow()
        {
            uspesneZene = serializer.DeSerializeObject<BindingList<UspesneZene>>("uspesneZene.xml");
            if (uspesneZene == null)
            {
                uspesneZene = new BindingList<UspesneZene>();
            }

            DataContext = this;

            InitializeComponent();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void DugmeZatvori_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DugmeDodaj_Click(object sender, RoutedEventArgs e)
        {
            Dodaj dodaj = new Dodaj();
            dodaj.ShowDialog();

        }

        private void buttonIzmeni_Click(object sender, RoutedEventArgs e)
        {
            Izmeni i = new Izmeni(uspesneZene[tabela.SelectedIndex], tabela.SelectedIndex);
            i.ShowDialog();
            uspesneZene.ResetBindings();
        }

        private void buttonObrisi_Click(object sender, RoutedEventArgs e)
        {
            
            
                File.Delete($"C:\\Users\\Andjela\\Desktop\\faks\\HCI\\HCI_projekat\\HCI_projekat\\bin\\Debug\\opis{uspesneZene[tabela.SelectedIndex].Ime}{uspesneZene[tabela.SelectedIndex].Prezime}.rtf");

                uspesneZene.RemoveAt(tabela.SelectedIndex);

        }

        private void buttonOpsirnije_Click(object sender, RoutedEventArgs e)
        {
            Opsirnije o = new Opsirnije(uspesneZene[tabela.SelectedIndex], tabela.SelectedIndex);
            o.ShowDialog();
        }

        private void sacuvaj(object sender, CancelEventArgs e)
        {
            serializer.SerializeObject<BindingList<UspesneZene>>(uspesneZene, "uspesneZene.xml");
        }

      
    }
}
