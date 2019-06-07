using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Kartenspiel.Fenster;

namespace Kartenspiel.Klassen
{
    class Spiel
    {
        public static Spielfeld spielfeld;
        public static int aktuellerSpieler = 0;
        public static Spieler[] spieler = new Spieler[2];
        public static bool angriffsKlick = true;
        public static Karte angriffsKarte;
        public static Uri cardback = new Uri("../../Memes/cardback.png", UriKind.Relative);

        public  static void InitSpieler(int leben, Spielfeld spielfeld)
        {
            Spiel.spielfeld = spielfeld;

            spieler[0] = new Spieler(Login.window.txtSpieler1Name.Text, leben, 0, spielfeld);
            spieler[1] = new Spieler(Login.window.txtSpieler2Name.Text, leben, 1, spielfeld);

            spielfeld.lblSpieler1.Content = spieler[0].name;
            spielfeld.lblSpieler2.Content = spieler[1].name;
        }

        //Die Funktion wo man Karten ziehen will
        public static void KarteZiehen(Image img)
        {
            Image[] handBilder = spieler[aktuellerSpieler].handImages;

            for (int i = 0; i < handBilder.Length; i++)
            {
                Image handBild = handBilder[i];
                //shcuat ob die Hand Leer ist damit er Karten ziehen kann
                if (handBild.Tag is null)
                {
                    handBild.Tag = new Karte(img.Tag as Karte);
                    handBild.Source = new BitmapImage((handBild.Tag as Karte).dateiPfad);

                    break;
                }
                else if (i == handBilder.Length - 1)
                {
                    return;
                }
            }

            // Eine zufällige Karte auswählen
            Random rdm = new Random();
            int index = rdm.Next(Karte.möglicheKarten.Count);
            // zwischenspeichern
            Karte neueKarte = Karte.möglicheKarten[index];

            // Die ausgewählte Karte von den möglichen Karten entfernen
            Karte.möglicheKarten.Remove(img.Tag as Karte);

            // Bild anzeigen
            img.Source = new BitmapImage(neueKarte.dateiPfad);
            img.Tag = neueKarte;
        }
        
        public static void KarteLegen(Image img)
        {
            if (img.Tag is null) return;

            // Array, welches die Bilder beinhaltet, die im Spielfeld vorhanden sind
            Image[] feldBilder = spieler[aktuellerSpieler].feldImages;
            //das Spielfeld durchgehen 
            for (int i = 0; i < feldBilder.Length; i++)
            {
                // Image.Tag beinhaltet die Karte, die dem Bild zugewiesen wurde.
                Karte karte = img.Tag as Karte;

                //schauen ob dort eine Karte ist 
                if (feldBilder[i].Tag is null)
                {
                    //wenn man in die If bedingung hineinkommt 
                    var feldImage = feldBilder[i];
                    feldImage.Source = new BitmapImage(karte.dateiPfad);
                    feldImage.Tag = karte;

                    // Die zugewiesene Karte von der Spielerhand entfernen
                    img.Tag = null;
                    img.Source = new BitmapImage(cardback);

                    // Nach der Zuweisung aus der Schleife raus gehen
                    break;
                }
            }
        }
    }
}
