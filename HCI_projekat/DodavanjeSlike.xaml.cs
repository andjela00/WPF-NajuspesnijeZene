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

namespace HCI_projekat
{
    /// <summary>
    /// Interaction logic for DodavanjeSlike.xaml
    /// </summary>
    public partial class DodavanjeSlike : Window
    {
        public string uri = null;
        public bool prevlacenje = false;
        public string izvor = null;

        public DodavanjeSlike()
        {
            InitializeComponent();
        }

        private void KanvasSlika_Drop(object sender, DragEventArgs e)
        {
            base.OnDrop(e);
            if (uri != null)
            {

                izvor = uri;
                this.Close();
            }
            e.Handled = true;
        }

        private void lista_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            uri = null;
            prevlacenje = false;
        }

        private void lista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!prevlacenje)
            {
                prevlacenje = true;
                ListViewItem item = (ListViewItem)lista.SelectedItem;
                uri = ((ImageBrush)item.Background).ImageSource.ToString();
                DragDrop.DoDragDrop(this, uri, DragDropEffects.Move);


            }
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
