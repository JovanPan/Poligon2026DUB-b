using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poligon2026DUB_b
{
    internal class Ravan
    {
        public static int SIS(Vektor a, Tacka b, Tacka c)
        {
            Vektor AB = new Vektor(a.pocetak, b);
            Vektor AC = new Vektor(a.pocetak, c);
            double aAB = Vektor.VP(a, AB);
            double aAC = Vektor.VP(a, AC);
            if (aAC * aAB > 0) return 1;
            if (aAC * aAB < 0) return 1;
            return 0;
        }
    }
}
