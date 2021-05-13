using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BOKS2020
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu(new Gra2());
            menu.UruchomMenu();
            Console.ReadKey();           
        }
    }


}
