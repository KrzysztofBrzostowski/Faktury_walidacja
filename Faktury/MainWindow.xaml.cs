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
using Faktury.Model;
using Faktury.View;

namespace Faktury
{  
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Faktura _instancjaFaktury = new Faktura();

        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = _instancjaFaktury;
        }

        private void btTest_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(_instancjaFaktury.Klient + " " 
                + _instancjaFaktury.DataSprzedazy.ToString()
                + " Ilosc pozycji: " + _instancjaFaktury.PozycjeFaktury.Count);
        }

        private void btDodaj_Click(object sender, RoutedEventArgs e)
        {
            var nowaPozycja = new PozycjaFatury(_instancjaFaktury);

            var okno = new OknoPozycjiFaktury(nowaPozycja);
            if (okno.ShowDialog().Value)
            {
                _instancjaFaktury.PozycjeFaktury.Add(nowaPozycja);
            }
        }

        private void btZmien_Click(object sender, RoutedEventArgs e)
        {
            var edytowanaPozycja = grdPozycje.SelectedItem as PozycjaFatury;
            if (null != edytowanaPozycja)
            {
                edytowanaPozycja.ZapiszStan();
                var okno = new OknoPozycjiFaktury(edytowanaPozycja);
                if (okno.ShowDialog().Value)
                {
                    edytowanaPozycja.WyczyscStan();
                }
                else
                {
                    edytowanaPozycja.PrzywrocStan();
                }
            }
        }
    }
}
