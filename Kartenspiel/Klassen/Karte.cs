using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kartenspiel.Klassen
{
    class Karte
    {
        internal enum Kampfausgang { gewinnen, verlieren }

        public string name;
        public int leben;
        public int angriff;
        public Uri dateiPfad;

        public static List<Karte> alleKarten = new List<Karte>(50);
        public static List<Karte> möglicheKarten = new List<Karte>(50);

        //Konstruktor
        public Karte(Karte karte)
        {
            this.name = karte.name;
            this.leben = karte.leben;
            this.angriff = karte.angriff;
            this.dateiPfad = karte.dateiPfad;
        }
        public Karte(string name, int leben, int angriff, Uri dateiPfad)
        {
            this.name = name;
            this.leben = leben;
            this.angriff = angriff;
            this.dateiPfad = dateiPfad;
        }

        public static void InitKarten()
        {
            Karte.KartenEinlesen("../../Memes/");
        }


        public Kampfausgang KampfGegen(Karte other)
        {
            if (this.leben <= other.angriff)
            {
                int transferint = this.leben - other.angriff;
                

                return Kampfausgang.verlieren;
            }
            else
            {
                this.leben = this.leben - other.angriff;
                

                return Kampfausgang.gewinnen;
            }
        }

        public static Uri GetDateiPfad(string name)
        {
            foreach (Karte karte in Karte.alleKarten)
            {
                if (karte.name == name)
                {
                    return karte.dateiPfad;
                }
            }

            return null;
        }

        // Dateiname;Name;Leben;Angriff
        public static void KartenEinlesen(string dateiPfad)
        {
            string[] infoKarten = File.ReadAllLines($"{dateiPfad}Daten.txt");

            foreach (string infoKarte in infoKarten)
            {
                string[] infos = infoKarte.Split(';');

                Uri uri = null;
                string dateiName = infos[0];
                string name = infos[1];
                int leben = int.Parse(infos[2]);
                int angriff = int.Parse(infos[3]);

                if (infoKarte.StartsWith("N"))
                {
                    uri = new Uri($"{dateiPfad}Normal/{dateiName}", UriKind.Relative);
                }
                else if (infoKarte.StartsWith("M"))
                {
                    uri = new Uri($"{dateiPfad}Magic/{dateiName}", UriKind.Relative);
                }
                else if (infoKarte.StartsWith("L"))
                {
                    uri = new Uri($"{dateiPfad}Legendary/{dateiName}", UriKind.Relative);
                }

                Karte karte = new Karte(name, leben, angriff, uri);
                möglicheKarten.Add(karte);//hier wird dann die Karte erstellt und in das "Deck" getan bzw in die Möglichen Karten
            }

            Karte.alleKarten = new List<Karte>(möglicheKarten);
        }

        public static Karte SucheKarteNachName(string name)
        {
            foreach (Karte suchKarte in Karte.alleKarten)
            {
                if (suchKarte.name == name)
                {
                    return suchKarte;
                }
            }

            return null;
        }
    }
}
