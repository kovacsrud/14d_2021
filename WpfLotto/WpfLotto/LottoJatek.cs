using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfLotto
{
    public class LottoJatek
    {
        private MainWindow mainWindow;
        private List<int> tippek;
        private List<int> nyeroSzamok;
        private int hanySzam;
        private int sorSzam;
        private int oszlopSzam;
        private int szamlalo;
        Random rnd;

        public LottoJatek(MainWindow mainwindow,int hanyszam,int sorszam,int oszlopszam)
        {
            mainWindow = mainwindow;
            tippek = new List<int>();
            nyeroSzamok = new List<int>();
            hanySzam = hanyszam;
            sorSzam = sorszam;
            oszlopSzam = oszlopszam;
            szamlalo = 1;
            Gombok();
            rnd = new Random();
            mainWindow.buttonSorsolas.Click += SorsolasClick;
        }

        

        private void Gombok()
        {
            Grid gridSzamok = new Grid();

            for (int i = 0; i < sorSzam; i++)
            {
                RowDefinition sorDef = new RowDefinition();
                gridSzamok.RowDefinitions.Add(sorDef);
            }

            for (int i = 0; i < oszlopSzam; i++)
            {
                ColumnDefinition oszlopDef = new ColumnDefinition();
                gridSzamok.ColumnDefinitions.Add(oszlopDef);
            }

            var gombszam = 1;
            for (int i = 0; i < sorSzam; i++)
            {
                for (int j = 0; j < oszlopSzam; j++)
                {
                    Button gomb = new Button();
                    gomb.Content = gombszam;
                    gomb.Margin = new System.Windows.Thickness(5);
                    gomb.Click += GombClick;
                    gombszam++;

                    gridSzamok.Children.Add(gomb);
                    Grid.SetRow(gomb, i);
                    Grid.SetColumn(gomb,j);
                }

            }

            //itt kéne megtalálni a gridMain-t valahogy
            mainWindow.gridMain.Children.Add(gridSzamok);
        }

        private void GombClick(object sender,EventArgs e)
        {
            Button gomb = (Button)sender;
            var gombSzam= Convert.ToInt32(gomb.Content);

            if (szamlalo<=hanySzam && !tippek.Contains(gombSzam))
            {
                tippek.Add(gombSzam);
                Debug.WriteLine(gombSzam);
               
                gomb.Foreground = Brushes.Red;
                gomb.Background = Brushes.AliceBlue;

                szamlalo++;
            }
            if (szamlalo>hanySzam)
            {
                mainWindow.buttonSorsolas.IsEnabled = true;
            }
            
        }

        private void SorsolasClick(object sender,EventArgs e)
        {
            Sorsolas();
            //Todo: nyerőszámok megjelenítése
            //Todo: találatok megjelenítése
        }

        private void Sorsolas()
        {
            for (int i = 0; i < hanySzam; i++)
            {
                var nyeroszam = rnd.Next(1, (sorSzam * oszlopSzam) + 1);
                while (nyeroSzamok.Contains(nyeroszam))
                {
                    nyeroszam = rnd.Next(1, (sorSzam * oszlopSzam) + 1);
                }
                nyeroSzamok.Add(nyeroszam);
            }

        }
    }
}
