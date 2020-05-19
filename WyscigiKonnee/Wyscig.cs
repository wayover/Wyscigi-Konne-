using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace WyscigiKonnee
{
    class Wyscig
    {
        int dlugosc;
        Kon[] konie = new Kon[5];
        public static List<Kon> pozycja=new List<Kon>();
        public static Barrier bariera = new Barrier(1);

        public Wyscig(int dlugosc)
        {
            this.dlugosc = dlugosc;
        }


        public void WyscigStart()
        {

            for (int i = 0; i < konie.Length; i++)
            {
                lock(bariera)
                {
                    bariera.AddParticipant();
                }
                
                konie[i] = new Kon("Kon "+(i+1),dlugosc);
                Thread t = new Thread(konie[i].Bieg);
                t.Start();
                

            }
           
            bariera.SignalAndWait();

          
            
            
            
            
            
            
            
            pozycja.Sort((kon1, kon2) => { return kon1.czas.CompareTo(kon2.czas); });
            Wypisz();

            






        }




        public void Wypisz()
        {

            Console.WriteLine("\n\n Tabela końcowa");
            for(int i = 0; i < pozycja.Count; i++)
            {
                if (pozycja[i].koniec == true)
                {
                    Console.WriteLine("Pozycja " + (i + 1) + " " + pozycja[i].name);
                }
                else
                {
                    Console.WriteLine(pozycja[i].name + " nie dojechał do mety :(");
                }
            }
        }
        
    }
}
