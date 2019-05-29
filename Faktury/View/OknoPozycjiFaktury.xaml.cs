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
using System.Windows.Shapes;
using Faktury.Model;

namespace Faktury.View
{
    /// <summary>
    /// Interaction logic for OknoPozycjiFaktury.xaml
    /// </summary>
    public partial class OknoPozycjiFaktury : Window
    {
        private PozycjaFatury _instancjaPozycjiFaktury;

        public OknoPozycjiFaktury()
        {
            InitializeComponent();
        }

        public OknoPozycjiFaktury(PozycjaFatury instancjaPozycjiFaktury)
            :this()
        {
            _instancjaPozycjiFaktury = instancjaPozycjiFaktury;
            this.DataContext = _instancjaPozycjiFaktury;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (!_instancjaPozycjiFaktury.IsValid())
                MessageBox.Show(_instancjaPozycjiFaktury.ListaBledow(), "Nazwa aplikacji",
                    MessageBoxButton.OK, MessageBoxImage.Exclamation);
            else
            {
                this.DialogResult = true;
                this.Close();
            }            
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void textBox1_Error(object sender, ValidationErrorEventArgs e)
        {
            textBox4.AppendText(e.Error.ErrorContent.ToString() + Environment.NewLine );
        }
    }
}
