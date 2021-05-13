using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOKS2020
{
   public class EkranWalki
    {
        public void Walka()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("WALKA!!");
            Console.ReadKey();
        }
    }
}
