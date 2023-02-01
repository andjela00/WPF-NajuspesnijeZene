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
using System.Windows.Shapes;

namespace HCI_projekat
{
    /// <summary>
    /// Interaction logic for Opsirnije.xaml
    /// </summary>
    public partial class Opsirnije : Window
    {
        

        public Opsirnije(UspesneZene uspesnaZena, int indeks)
        {

            InitializeComponent();

            

            labelaIme.Content = uspesnaZena.Ime;
            labelaPrezime.Content = uspesnaZena.Prezime;
            nagrade.Content = uspesnaZena.BrojNagrada.ToString();
            datumR.Content = uspesnaZena.Datum;

            FileStream fileStream = new FileStream($"opis{uspesnaZena.Ime}{uspesnaZena.Prezime}.rtf", FileMode.Open);
            TextRange range = new TextRange(rtbOpis.Document.ContentStart, rtbOpis.Document.ContentEnd);
            range.Load(fileStream, System.Windows.DataFormats.Rtf);
            fileStream.Close();

            if (uspesnaZena.Slika != "")
            {
                BitmapImage back = new BitmapImage();
                back.BeginInit();
                back.UriSource = new Uri(uspesnaZena.Slika);
                back.EndInit();
                FotoKanvas.Background = new ImageBrush(back);
                FotoKanvas.Resources["taken"] = true;
            }
        }

        private void buttonIzadji_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
