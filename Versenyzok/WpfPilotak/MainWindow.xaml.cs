using Microsoft.Win32;
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

namespace WpfPilotak
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        VersenyzoAdatok versenyzoAdatok;
        public MainWindow()
        {
            InitializeComponent();
                     


        }

        private void buttonMegnyit_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            if (dialog.ShowDialog()==true)
            {
                try
                {
                    versenyzoAdatok = new VersenyzoAdatok(dialog.FileName);
                    MessageBox.Show($"Adatok száma:{versenyzoAdatok.Versenyzok.Count}");
                    datagridVersenyzok.ItemsSource = versenyzoAdatok.Versenyzok;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            
        }
    }
}
