using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Kartenspiel.Fenster;

namespace Kartenspiel.Klassen
{
    class Spieler
    {
        public string name { get; private set; }
        public int leben { get; set; }
        public Image[] handImages { get; private set; }
        public Image[] feldImages { get; private set; }

        public Spieler(string name, int leben, int spielerNR, Spielfeld spielfeld)
        {
            this.name = name;
            this.leben = leben;
            handImages = new Image[4];
            feldImages = new Image[4];

            if (spielerNR == 0)
            {
                handImages[0] = spielfeld.imgSpieler1Feld1;
                handImages[1] = spielfeld.imgSpieler1Feld2;
                handImages[2] = spielfeld.imgSpieler1Feld3;
                handImages[3] = spielfeld.imgSpieler1Feld4;

                feldImages[0] = spielfeld.imgSpieler1Spielfeld1;
                feldImages[1] = spielfeld.imgSpieler1Spielfeld2;
                feldImages[2] = spielfeld.imgSpieler1Spielfeld3;
                feldImages[3] = spielfeld.imgSpieler1Spielfeld4;
            }
            else if (spielerNR == 1)
            {
                handImages[0] = spielfeld.imgSpieler2Feld1;
                handImages[1] = spielfeld.imgSpieler2Feld2;
                handImages[2] = spielfeld.imgSpieler2Feld3;
                handImages[3] = spielfeld.imgSpieler2Feld4;

                feldImages[0] = spielfeld.imgSpieler2Spielfeld1;
                feldImages[1] = spielfeld.imgSpieler2Spielfeld2;
                feldImages[2] = spielfeld.imgSpieler2Spielfeld3;
                feldImages[3] = spielfeld.imgSpieler2Spielfeld4;
            }
        }        
    }
}
