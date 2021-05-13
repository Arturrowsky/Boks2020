using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace BOKS2020
{
   public abstract class Zawodnik
    {
        private string imie, nazwisko;
        private int wzrost, waga, suderz, hpf, hpb,wyszkolenie;
        Random rnd = new Random();
        public string Imie { get { return imie.ToUpper(); } set { imie = value; } }
        public string Nazwisko { get { return nazwisko.ToUpper(); } set { nazwisko = value; } }
        public int Wzrost { get { return wzrost; } set { if (value > 0) wzrost = value; else wzrost = 170; } }
        public int Waga { get { return waga; } set { if (value > 0) waga = value; else waga = 65; } }
        public int Suderz { get { return suderz; } set { if (value > 0) suderz = value; else suderz = 20; } } 
        public int Hpb { get { return hpb; } set { if (value > 0) hpb = value; else hpb = 100; } } 
        public int Hpf { get { return hpf; } set { hpf = value; } }
        public int Wyszkolenie { get { return wyszkolenie; } set { wyszkolenie = value; } }
        public Zawodnik(string imie, string nazwisko, int wzrost, int waga, int suderz, int hpb,int wyszkolenie)
        {
            Imie = imie;
            Nazwisko = nazwisko;
            Wzrost = wzrost;
            Waga = waga;
            Suderz = suderz;
            Hpb = hpb;
            Wyszkolenie = wyszkolenie;
        }
        public virtual void wyswietl()
        {
            Console.WriteLine("Imie i nazwisko: " + Imie + " " + Nazwisko);
            Console.WriteLine("Wzrost: " + Wzrost);
            Console.WriteLine("Waga: " + Waga);
            Console.WriteLine("Maksymalna siła uderzenia: " + Suderz);
            Console.WriteLine("Hp: " + Hpb);
            Console.WriteLine("Wyszkolenie: " + Wyszkolenie);
        }
        public virtual void ShortShow()
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.Write(Imie+" "+Nazwisko+":" +" " );
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Write(Hpf); Console.BackgroundColor = ConsoleColor.Gray; Console.WriteLine("                   ");
        
        }
        public int Uderz()
        {
           
            if (Hpf > Hpb / 2)
            {
                Suderz = rnd.Next(Suderz - 10, Suderz+1);
                return Suderz;
            }

            else
            {
                Suderz = rnd.Next(Suderz-Suderz, Suderz+1);
                return Suderz;
            }
           
        }
        public void Wstawaj()
        {
            Console.SetCursorPosition(0, 3);
            Console.WriteLine(Nazwisko + " upadł na deski!!");
            if (Hpf > Hpb / 2)
            {
                for (int i =10; i >= rnd.Next(6, 10); i--)
                {
                    Console.SetCursorPosition(0, 4);
                    Console.WriteLine(i+"                                      ");
                    Thread.Sleep(1000);                    
                }

                if (Wyszkolenie > 0) Wyszkolenie -= 1;
                Console.SetCursorPosition(0, 4);
                Console.WriteLine("Udało się wstać " + Nazwisko );
            }
            else if (Hpf > Hpb / 4)
            {
                for (int i = 10; i >= rnd.Next(3, 8); i--)
                {
                    Console.SetCursorPosition(0, 4);
                    Console.WriteLine(i+"                                        ");
                    Thread.Sleep(1000);
                }
                Console.SetCursorPosition(0, 4);
                Console.WriteLine("Udało się wstać " + Nazwisko );
                if (Wyszkolenie > 0) Wyszkolenie -= 1;
            }
            else
            {
                for (int i = 10; i >= 0; i--)
                {
                    Console.SetCursorPosition(0, 4);
                    Console.WriteLine(i+"                                      ");
                    Thread.Sleep(1000);
                }
                Console.SetCursorPosition(0, 4);
                Console.WriteLine("Nie udało się wstać " + Nazwisko );
                Hpf = 0;
                
            }
            
        }

        public abstract void Unik();

        //dodac zawodnikow 
        //kazdy zawodnik z mozliwoscia uniku im wiekszy poziom wyszkolenia tym wieksza mozliwosc uniku 
        //symulacja walki "sztuczna inteligencja"

    }
}
