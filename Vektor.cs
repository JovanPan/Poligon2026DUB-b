using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poligon2026DUB_b
{
    internal class Vektor
    {
        public Tacka pocetak;
        public Tacka kraj;
        public Tacka centriraj()
        {
            double x = kraj.x - pocetak.x;
            double y = kraj.y - pocetak.y;
            return new Tacka(x, y);
        }
        public void stampaj()
        {
            Console.WriteLine("Od x1={0}, y1={1} Do x2={2}, y2={3}", pocetak.x, pocetak.y, kraj.x, kraj.y);
        }
        public Vektor(Tacka a, Tacka b)
        {
            pocetak = a;
            kraj = b;
        }
        public static double SP(Vektor a, Vektor b)
        {
            Tacka A = a.centriraj();
            Tacka B = b.centriraj();
            return A.x * B.x + A.y * B.y;
        }
        public static double VP(Vektor a, Vektor b)
        {
            Tacka A = a.centriraj();
            Tacka B = b.centriraj();
            double k = A.x * B.y - A.y * B.x;
            return k;
        }
        public double duzina()
        {
            Tacka druga = this.centriraj();
            return druga.d();
        }
        public bool sece(Vektor b)
        {
            int x = Ravan.SIS(this, b.pocetak, b.kraj);
            int y = Ravan.SIS(b, this.pocetak, this.kraj);
            if ((x != 1) && (y != 1)) return true;
            else return false;
        }
    }
}
