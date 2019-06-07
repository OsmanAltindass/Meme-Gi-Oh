using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Kartenspiel.Klassen;

namespace Kartenspiel.Fenster
{
    /// <summary>
    /// Interaction logic for Spielfeld.xaml
    /// </summary>
    public partial class Spielfeld : Page
    {
        public Spielfeld()
        {
            InitializeComponent();
        }

        private void DplSpielfeld_Loaded(object sender, RoutedEventArgs e)
        {
            Spiel.InitSpieler(100, this);
            Karte.InitKarten();

            Uri cardback = new Uri("../../Memes/cardback.png", UriKind.Relative);

            // Eine zufällige Karte als Startkarte nehmen
            int index = new Random().Next(Karte.möglicheKarten.Count);
            imgDeckZiehen.Tag = Karte.möglicheKarten[index];
        }

        private void BtnKarteZiehen_Click(object sender, RoutedEventArgs e)
        {
            Image img = imgDeckZiehen;

            Spiel.KarteZiehen(img);
        }

        private void BtnRundeBeenden_Click(object sender, RoutedEventArgs e)
        {
            switch (Spiel.aktuellerSpieler)
            {
                case 0:
                    Spiel.aktuellerSpieler = 1;
                    lblSpieler1.Background = null;
                    lblSpieler2.Background = Brushes.MediumVioletRed;
                    break;

                case 1:
                    Spiel.aktuellerSpieler = 0;
                    lblSpieler1.Background = Brushes.MediumVioletRed;
                    lblSpieler2.Background = null;
                    break;
            }
        }

        private void ImgSpielerFeld_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Image img = sender as Image;

            Spiel.KarteLegen(img);
        }

        private void ImgSpielerFeld_MouseEnter(object sender, MouseEventArgs e)
        {
            Image img = sender as Image;

            // Wenn das Bild keine zugewiesene Karte hat -> abbrechen
            if (img.Tag is null) return;

            Karte karte = img.Tag as Karte;

            lblS1KarteName.Content = (img.Tag as Karte).name;
            lblS1KartInfoLeben.Content = $"Leben: {karte.leben}";
            lblS1KartInfoAngriff.Content = $"Angriff: {karte.angriff}";
        }

        private void ImgSpielerFeld_MouseLeave(object sender, MouseEventArgs e)
        {
            Image img = sender as Image;


            lblS1KarteName.Content = Spiel.spieler[Spiel.aktuellerSpieler].leben;
            lblS1KartInfoLeben.Content = "Leben: --";
            lblS1KartInfoAngriff.Content = "Angriff: --";
        }

        private void ImgSpielerFeld_Angreifen_Click(object sender, MouseButtonEventArgs e)
        {
            Image img = sender as Image;

            // Wenn das Bild keine zugewiesene Karte besitzt -> abbruch
            if (img.Tag is null) return;

            Karte karte = img.Tag as Karte;

            if (Spiel.angriffsKlick)
            {
                Spiel.angriffsKarte = karte;
            }
            else
            {
                Karte angegriffeneKarte = karte;

                angegriffeneKarte.leben -= Spiel.angriffsKarte.angriff;
                // Leben gleich updaten
                ImgSpielerFeld_MouseEnter(img, null);

                if (angegriffeneKarte.leben < 1)
                {
                    imgDeckTot.Source = new BitmapImage(angegriffeneKarte.dateiPfad);
                    img.Source = new BitmapImage(Spiel.cardback);
                    img.Tag = null;

                    // angegriffeneKarte.leben ist schon negativ, deshalb +=; 1 + (-1) = 0
                    Spiel.spieler[Spiel.aktuellerSpieler].leben += angegriffeneKarte.leben;

                    // TODO:
                    if (Spiel.aktuellerSpieler == 0)
                    {

                    }
                    else if (Spiel.aktuellerSpieler == 1)
                    {

                    }

                    // Leben auf nix stellen
                    ImgSpielerFeld_MouseLeave(img, null);
                }
            }

            Spiel.angriffsKlick = !Spiel.angriffsKlick;
        }
    }
}
