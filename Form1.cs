using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Poligon2026DUB_b
{
    public partial class Form1 : Form
    {
        private readonly List<Tacka> _points = new List<Tacka>();
        public Form1()
        {
            InitializeComponent();

            
            panel1.Paint += Panel1_Paint;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            AddPoint(new Tacka(100, 100));
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            Tacka prva = new Tacka(1, 1);
            AddPoint(prva);
        }


        public void AddPoint(Tacka t)
        {
            _points.Add(t);
            panel1.Invalidate();
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            foreach (var t in _points)
            {
                Crtaj(e.Graphics, t);
            }
        }

        public void Crtaj(Graphics dr, Tacka t)
        {
            int panelHeight = panel1.ClientSize.Height;
            int x = (int)(t.x - 2);
            int y = panelHeight - (int)t.y - 2;

            using (var cetka = new SolidBrush(Color.Red))
            {
                dr.FillEllipse(cetka, x, y, 8, 8);
            }
        }
    }
}
