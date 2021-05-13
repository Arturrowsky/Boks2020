using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace BOKS2020
{
    public class Menu
    {
        protected Gra gra;
        public Menu(Gra gra)
        {
            this.gra = gra;
        }
        public void UruchomMenu()
        {
            var pozycjeMenu = gra.Pozycja();

            int aktywnaPozycjaMenu = 0;

            Console.CursorVisible = false;
            while (true)
            {
                PokazMenu();
                WybieranieOpcji();
                UruchomOpcje();
            }
            void PokazMenu()
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("---BOKS 2020---");
                Console.WriteLine();
                Console.WriteLine("Wybierz swojego zawodnika!");
                Console.WriteLine();
                for (int i = 0; i < pozycjeMenu.Length; i++)
                {
                    if (i == aktywnaPozycjaMenu)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkCyan;

                        Console.WriteLine("{0,-35}", pozycjeMenu[i]);
                        Console.BackgroundColor = ConsoleColor.Gray;
                    }
                    else
                    {
                        Console.WriteLine(pozycjeMenu[i]);
                    }
                }
            }
            void WybieranieOpcji()
            {
                do
                {
                    ConsoleKeyInfo klawisz = Console.ReadKey();
                    if (klawisz.Key == ConsoleKey.UpArrow)
                    {
                        aktywnaPozycjaMenu = (aktywnaPozycjaMenu > 0) ? aktywnaPozycjaMenu - 1 : pozycjeMenu.Length - 1;
                        PokazMenu();
                    }
                    else if (klawisz.Key == ConsoleKey.DownArrow)
                    {
                        aktywnaPozycjaMenu = (aktywnaPozycjaMenu + 1) % pozycjeMenu.Length;
                        PokazMenu();
                    }
                    else if (klawisz.Key == ConsoleKey.Escape)
                    {
                        aktywnaPozycjaMenu = pozycjeMenu.Length - 1;
                        break;
                    }
                    else if (klawisz.Key == ConsoleKey.Enter)
                        break;
                } while (true);

            }

            void UruchomOpcje()
            {
                switch (aktywnaPozycjaMenu)
                {
                    case 0:
                        gra.Walka(0);
                        Console.ReadKey();
                        break;
                    case 1:
                        gra.Walka(1);
                        Console.ReadKey();
                        break;

                    case 2:
                        gra.Walka(2);
                        Console.ReadKey();
                        break;

                    case 3:
                        gra.Walka(3);
                        Console.ReadKey();
                        break;
                    case 4:
                        gra.Walka(4);
                        Console.ReadKey();
                        break;
                    case 5: Environment.Exit(0); break;
                }
            }
        }

    }
}