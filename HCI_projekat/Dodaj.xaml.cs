using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace HCI_projekat
{
    /// <summary>
    /// Interaction logic for Dodaj.xaml
    /// </summary>
    public partial class Dodaj : Window
    {
        private List<int> dani = new List<int> { };
        private List<string> meseci = new List<string> { "Januar", "Febrar", "Mart", "April", "Maj", "Jun", "Jul", "Avgust", "Septembar", "Oktobar", "Novembar", "Decembar" };
        private List<int> godine = new List<int> { };

        private List<System.Reflection.PropertyInfo> sveBoje = new List<System.Reflection.PropertyInfo>();
        
        
        private int brojReci = 0;

        public Dodaj()
        {
            for(int i=1; i<=31; i++)
            {
                dani.Add(i);
            }

            for(int i = 2021; i>=1500; i-- )
            {
                godine.Add(i);
            }

            InitializeComponent();

            FotoKanvas.Resources["taken"] = false;

            textBIme.Text = "unesite ime";
            textBIme.Foreground = Brushes.LightSlateGray;

            textBPrezime.Text = "unesite prezime";
            textBPrezime.Foreground = Brushes.LightSlateGray;

            textBNagrada.Text = "unesite broj nagrada";
            textBNagrada.Foreground = Brushes.LightSlateGray;

            comboBDan.ItemsSource = dani;
            comboBMesec.ItemsSource = meseci;
            comboBGodina.ItemsSource = godine;

            comboBFont.ItemsSource = Fonts.SystemFontFamilies.OrderBy(f=>f.Source);
            sveBoje = typeof(Colors).GetProperties().ToList();

            comboBColor.ItemsSource = sveBoje;

            comboBSize.ItemsSource = new List<Int32>() { 8, 12, 14, 16, 18, 20, 24, 32, 40 };

        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void buttonDodaj_Click(object sender, RoutedEventArgs e)
        {
            UspesneZene uspesneZene = new UspesneZene();

            if (proveri())
            {
                string datum = $"{comboBDan.SelectedItem.ToString()}.{(comboBMesec.SelectedIndex + 1).ToString()}.{comboBGodina.SelectedItem.ToString()}.";

               

                FileStream fileStream = new FileStream($"opis{textBIme.Text}{textBPrezime.Text}.rtf", FileMode.Create);
                TextRange range = new TextRange(rtbOpis.Document.ContentStart, rtbOpis.Document.ContentEnd);
                range.Save(fileStream, System.Windows.DataFormats.Rtf);

                MainWindow.uspesneZene.Add(new UspesneZene(textBIme.Text, textBPrezime.Text, Convert.ToInt32(textBNagrada.Text), datum, ((ImageBrush)(FotoKanvas.Background)).ImageSource.ToString(), $"opis{textBIme.Text}{textBPrezime.Text}.rtf"));
                fileStream.Close();

                this.Close();
            }
            else
            {
                MessageBox.Show("Nisu dobro popunjena polja!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);  
            }

        }

        private void buttonIzadji_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private bool proveri()
        {
            bool rezultat = true;

            //IME
            if (textBIme.Text.Trim().Equals("") || textBIme.Text.Trim().Equals("unesite ime"))
            {
                textBIme.BorderBrush = Brushes.Red;
                textBIme.BorderThickness = new Thickness(1);
                labelIme.Content = "Polje ne sme biti prazno";
                rezultat = false;
            }
            else
            {
                rezultat = true;
                textBIme.BorderBrush = Brushes.Green;
                labelIme.Content = string.Empty;
            }

            //PREZIME
            if (textBPrezime.Text.Trim().Equals("") || textBPrezime.Text.Trim().Equals("unesite prezime"))
            {
                textBPrezime.BorderBrush = Brushes.Red;
                textBPrezime.BorderThickness = new Thickness(1);
                labelPrezime.Content = "Polje ne sme biti prazno";
                rezultat = false;
            }
            else
            {
                rezultat = true;
                textBPrezime.BorderBrush = Brushes.Green;
                labelPrezime.Content = string.Empty;
            }

            if (textBNagrada.Text.Trim().Equals("") || textBNagrada.Text.Trim().Equals("unesite broj nagrada"))
            {
                textBNagrada.BorderBrush = Brushes.Red;
                textBNagrada.BorderThickness = new Thickness(1);
                labelBrojNagrada.Content = "Polje ne sme biti prazno";
                rezultat = false;
            }
            else
            {
               

                try
                {
                    if (Int32.Parse(textBNagrada.Text.Trim())<0)
                    {
                        textBNagrada.BorderBrush = Brushes.Red;
                        textBNagrada.BorderThickness = new Thickness(1);
                        labelBrojNagrada.Content = "Broj nagrada ne moze biti negativan";
                        rezultat = false;
                    }
                    
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Niste uneli broj u polje za broj nagrada", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                    Console.WriteLine(exc.Message);
                    rezultat = false;
                }
                textBNagrada.BorderBrush = Brushes.Green;
                labelBrojNagrada.Content = string.Empty;
                

            }

            //DATUM PROVERA
            if (comboBDan.SelectedItem == null)
            {
                comboBDan.BorderBrush = Brushes.Red;
                comboBDan.BorderThickness = new Thickness(1);
                labelDatum.Content = "Niste uneli datum ";
                rezultat = false;
            }
            else
            {
                comboBDan.BorderBrush = Brushes.Green;
                labelDatum.Content = string.Empty;
            }

            //Mesec
            if (comboBMesec.SelectedItem == null)
            {
                comboBMesec.BorderBrush = Brushes.Red;
                comboBMesec.BorderThickness = new Thickness(1);
                labelDatum.Content = "Niste uneli datum ";
                rezultat = false;
            }
            else
            {
                comboBMesec.BorderBrush = Brushes.Green;
                labelDatum.Content = string.Empty;
            }

            //Godina
            if (comboBGodina.SelectedItem == null)
            {
                comboBGodina.BorderBrush = Brushes.Red;
                comboBGodina.BorderThickness = new Thickness(1);
                labelDatum.Content = "Niste uneli datum ";
                rezultat = false;
            }
            else
            {
                comboBGodina.BorderBrush = Brushes.Green;
                labelDatum.Content = string.Empty;
            }

            if (comboBMesec.SelectedIndex == 3 || comboBMesec.SelectedIndex == 5 || comboBMesec.SelectedIndex == 8 || comboBMesec.SelectedIndex == 10)
            {
                if (comboBDan.SelectedItem.Equals(31))
                { 
                    labelDatum.Content = "Izabrani mesec nema 31 dan";
                    comboBMesec.BorderBrush = Brushes.Red;
                    comboBMesec.BorderThickness = new Thickness(1);
                    rezultat = false;
                }
            }
            else if (comboBMesec.SelectedIndex == 1)
            {
                int godina = 2021-comboBGodina.SelectedIndex;

                if (comboBDan.SelectedIndex==29 || comboBDan.SelectedIndex == 30)
                {
                    labelDatum.Content = "Februar nema 30 ili 31 dan";
                    comboBDan.BorderBrush = Brushes.Red;
                    comboBDan.BorderThickness = new Thickness(1);
                    rezultat = false;
                }
                else if(!(godina % 400 == 0 || (godina % 4 == 0 && godina % 100!=0)))
                {
                    if (comboBDan.SelectedItem.Equals(29))
                    {
                        labelDatum.Content = "Godina nije prestupna, nema 29 dana";
                        comboBDan.BorderBrush = Brushes.Red;
                        comboBDan.BorderThickness = new Thickness(1);
                        rezultat = false;
                    }
                }
            }

            if ((bool)FotoKanvas.Resources["taken"] != true)
            {
                rezultat = false;
                MessageBox.Show("Morate staviti sliku", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            string s = new TextRange(rtbOpis.Document.ContentStart, rtbOpis.Document.ContentEnd).Text;
            if (s.Trim() == "")
            {
                rezultat = false;
                MessageBox.Show("Morate uneti opis", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            

            return rezultat;
        }

        private void textBIme_GotFocus(object sender, RoutedEventArgs e)
        {
            if (textBIme.Text.Trim().Equals("unesite ime"))
            {
                textBIme.Text = "";
                textBIme.Foreground = Brushes.Black;
            }
        }

        private void textBIme_LostFocus(object sender, RoutedEventArgs e)
        {
            if (textBIme.Text.Trim().Equals(""))
            {
                textBIme.Text = "unesite ime";
                textBIme.Foreground = Brushes.LightSlateGray;
            }
        }

        private void textBPrezime_GotFocus(object sender, RoutedEventArgs e)
        {
            if (textBPrezime.Text.Trim().Equals("unesite prezime"))
            {
                textBPrezime.Text = "";
                textBPrezime.Foreground = Brushes.Black;
            }

        }

        private void textBPrezime_LostFocus(object sender, RoutedEventArgs e)
        {
            if (textBPrezime.Text.Trim().Equals(""))
            {
                textBPrezime.Text = "unesite prezime";
                textBPrezime.Foreground = Brushes.LightSlateGray;
            }

        }

        private void textBNagrada_GotFocus(object sender, RoutedEventArgs e)
        {
            if (textBNagrada.Text.Trim().Equals("unesite broj nagrada"))
            {
                textBNagrada.Text = "";
                textBNagrada.Foreground = Brushes.Black;
            }

        }

        private void textBNagrada_LostFocus(object sender, RoutedEventArgs e)
        {
            if (textBNagrada.Text.Trim().Equals(""))
            {
                textBNagrada.Text = "unesite broj nagrada";
                textBNagrada.Foreground = Brushes.LightSlateGray;
            }
        }

        private void comboBFont_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBFont.SelectedItem != null && !rtbOpis.Selection.IsEmpty)
            {
                rtbOpis.Selection.ApplyPropertyValue(Inline.FontFamilyProperty, comboBFont.SelectedItem);
            }
        }

        private void rtbOpis_SelectionChanged(object sender, RoutedEventArgs e)
        {
            object temp = rtbOpis.Selection.GetPropertyValue(Inline.FontWeightProperty);
            buttonBold.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(FontWeights.Bold));
            
            temp = rtbOpis.Selection.GetPropertyValue(Inline.TextDecorationsProperty);
            buttonUL.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(TextDecorations.Underline));

            temp = rtbOpis.Selection.GetPropertyValue(Inline.FontStyleProperty);
            buttonItalic.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(FontStyles.Italic));

            temp = rtbOpis.Selection.GetPropertyValue(TextElement.ForegroundProperty);
            comboBColor.SelectedItem = temp;

            temp = rtbOpis.Selection.GetPropertyValue(Inline.FontFamilyProperty);
            comboBFont.SelectedItem = temp;

            temp = rtbOpis.Selection.GetPropertyValue(Inline.FontSizeProperty);
            comboBSize.SelectedItem = Int32.Parse(temp.ToString());

            
            
        }

        private void comboBSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBSize.SelectedItem != null && !rtbOpis.Selection.IsEmpty)
            {
                rtbOpis.Selection.ApplyPropertyValue(Inline.FontSizeProperty, comboBSize.SelectedItem.ToString());
            }
        }

        private void comboBColor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBColor.SelectedItem != null && !rtbOpis.Selection.IsEmpty)
            {
                rtbOpis.Selection.ApplyPropertyValue(TextElement.ForegroundProperty, sveBoje.ElementAt(comboBColor.SelectedIndex).Name) ;
            }

        }

        private void buttonSlika_Click(object sender, RoutedEventArgs e)
        {
            DodavanjeSlike dS = new DodavanjeSlike();
            dS.ShowDialog();
            if (dS.izvor != null)
            { 
                BitmapImage back = new BitmapImage();
                back.BeginInit();
                back.UriSource = new Uri(dS.izvor);
                back.EndInit();
                FotoKanvas.Background = new ImageBrush(back);
                FotoKanvas.Resources["taken"] = true;
            }
            else
                FotoKanvas.Resources["taken"] = false;

        }

        private void rtbOpis_TextChanged(object sender, TextChangedEventArgs e)
        {
            string tekst = new TextRange(rtbOpis.Document.ContentStart, rtbOpis.Document.ContentEnd).Text;

            MatchCollection collection = Regex.Matches(tekst, @"[\S]+");
            labelaBrojReci.Content = "Ukupno reci: " + collection.Count;
            brojReci = collection.Count;

        }
    }
}
