using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOKS2020
{
   public class Golota : Zawodnik
    {
        public Golota(string imie, string nazwisko, int wzrost, int waga, int suderz, int hpb, int wyszkolenie) : base(imie, nazwisko, wzrost, waga, suderz, hpb, wyszkolenie)
        {
            Hpf = hpb;
        }

        public override void Unik()
        {
            Console.WriteLine(Nazwisko + " zrobił unik!            ");
            if (Wyszkolenie > 6)
            {
                Hpf -= Uderz() / 10;
            }
            else if (Wyszkolenie > 4)
            {
                Hpf -= Uderz() / 5;
            }
            else
            {
                Hpf -= Uderz() / 2;
            }
        }
    }
}
