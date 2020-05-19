using System;
using System.Collections.Generic;
using System.Text;

namespace WyscigiKonnee
{
    class Kon
    {
        public string name;
        public int speed;
        public int dystans;
        public bool koniec = true;
        public int czas=0;


        public Kon(string imie,int dyst)
        {
            this.name = imie;
            this.dystans = dyst;
            this.speed = PredkoncRand();
        }

        public Kon(string imie,int predkosc,int dyst)
        {
            this.name = imie;
            this.speed = predkosc;
            this.dystans = dyst;
        }

        public int PredkoncRand()
        {
            int predkosc=0;

            Random rand = new Random();
            predkosc= rand.Next(1, 10);


            return predkosc;
        }

        public void Bieg()
        {
            Random rand = new Random();
            for (int i = 0; i < dystans;)
            {
                i += speed;
                czas++;
                if (rand.Next(1, 80000) <3)
                {
                    koniec = false;
                    break;
                }

            }
            if (koniec == true)
            {
                Console.WriteLine(name + " dobiegł do mety");
            }
            else
            {
                Console.WriteLine(name + " nie dobiegł do mety");
                czas = 99999999;
            }
                Wyscig.pozycja.Add(this);
            
            
            Wyscig.bariera.SignalAndWait();

        }

    }



}
