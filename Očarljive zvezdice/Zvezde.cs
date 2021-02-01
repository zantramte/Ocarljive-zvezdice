using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Očarljive_zvezdice
{
    public class Zvezde
    {
        public static List<int> Zvezdice = new List<int>();

        public static Random Nakljucno = new Random();

        public static int Sedaj { get; set; }

        public static int Rezultat { get; set; }

        public static int Prvo_stevilo { get; set; }

        public static int Drugo_stevilo { get; set; }

        public static int Vrni_prvo()
        {
            Prvo_stevilo = Convert.ToInt32(Nakljucno.Next(0, 11));

            return Prvo_stevilo;
        }

        public static int Vrni_drugo()
        {
            Drugo_stevilo = Convert.ToInt32(Nakljucno.Next(1, 11));

            return Drugo_stevilo;
        }

        public static bool Preveri_zvezdo()
        {
            if ((Prvo_stevilo * Drugo_stevilo) == Rezultat)
            {
                return true;
            }

            else
            {
                return false;
            }
        }
    }
}
