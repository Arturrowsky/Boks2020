using System;
using System.Linq;
using System.Threading;

namespace BOKS2020
{
    public class Gra
    {
        Random rnd = new Random(DateTime.Now.Millisecond);
        Zawodnik[] Zawodnicy =
       {
            new Michalczewski("Dariusz", "Michalczewski", 185, 80, 30, 130, 8),
            new Adamek("tomasz", "adamek", 188, 103, 30, 140, 9),
            new Wlodarczyk("Krzysztof", "Włodarczyk", 186, 87, 27, 135, 8),
            new Golota("Andrzej", "Gołota", 193, 116, 34, 145, 8),
            new Proksa("grzegorz", "proksa", 173, 73, 22, 115, 7),
         };
        public virtual string[] Pozycja()
        {
            string[] pozycjeMenu = new string[Zawodnicy.Length];
            for (int i = 0; i < Zawodnicy.Length ; i++)
            { 
               pozycjeMenu[i] =  Zawodnicy[i].Imie + " " + Zawodnicy[i].Nazwisko;
            }
            return pozycjeMenu;
        } 
        protected virtual int Los()
        {
            
            int p = 0;
            p = rnd.Next(0, Zawodnicy.Length-1);
            return p;
        }
    
        protected virtual Zawodnik LosPrzeciwnika(int wybrany)
        {
            var pozostali = Zawodnicy.ToList();

            pozostali.RemoveAt(wybrany);
            pozostali.TrimExcess();
            return pozostali[Los()];

        }
    public virtual void Walka(int wybor)
        {
            Console.Clear();
            var z1 = Zawodnicy[wybor];
            var z2 = LosPrzeciwnika(wybor);
            TwojZawodnik();
            z1.wyswietl();
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("Twój przeciwnik to: ");
            Console.BackgroundColor = ConsoleColor.Gray;
            z2.wyswietl();
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("WALKA!!!");
            Console.WriteLine();
            while (z1.Hpf > 0 && z2.Hpf > 0)
            {
                Console.BackgroundColor = ConsoleColor.Gray;

                Random random = new Random();
                int m = random.Next(0, 4);
                switch (m)
                {
                    case 1:
                        Console.SetCursorPosition(0, 2);
                        Console.WriteLine(z1.Nazwisko + " uderza!              ");
                        z2.Hpf -= z1.Uderz();
                        if (z1.Uderz() == 30)
                        {
                            z2.Wstawaj();
                            Console.BackgroundColor = ConsoleColor.Gray;
                        }
                        z1.ShortShow();
                        z2.ShortShow();
                        Thread.Sleep(3000);
                        break;
                    case 0:
                        Console.SetCursorPosition(0, 2);
                        z1.Unik();
                        z1.ShortShow();
                        z2.ShortShow();
                        Thread.Sleep(3000);
                        break;
                    case 2:
                        Console.SetCursorPosition(0, 2);
                        Console.WriteLine(z2.Nazwisko + " uderza!            ");
                        z1.Hpf -= z2.Uderz();
                        if (z2.Uderz() == 30)
                        {
                            z1.Wstawaj();
                            Console.BackgroundColor = ConsoleColor.Gray;
                            Console.SetCursorPosition(0, 2);
                        }
                        z1.ShortShow();
                        z2.ShortShow();
                        Thread.Sleep(3000);
                        break;
                    case 3:
                        Console.SetCursorPosition(0, 2);
                        z2.Unik();
                        z1.ShortShow();
                        z2.ShortShow();
                        Thread.Sleep(3000);
                        break;
                    default:
                        Console.WriteLine("Błąd!");
                        break;
                }
            }
            if (z1.Hpf <= 0)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Wygrał " + z2.Nazwisko + "!!!!                    ");
                Console.WriteLine("                                              ");
                Console.WriteLine("                                              ");
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Wygrał " + z1.Nazwisko + "!!!!                ");
            }
        }

        protected virtual void TwojZawodnik()
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("Twój zawodnik to:");
            Console.BackgroundColor = ConsoleColor.Gray;
        }
    }
}