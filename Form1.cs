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
        poligon radni;
        public Form1()
        {
            InitializeComponent();
            this.Width = 800;
            this.Height = 500;

            // Subscribe to the panel Paint event so drawings persist across repaints
            panel1.Paint += Panel1_Paint;

            this.Resize += Form1_Resize;
            // initial layout
            LayoutPanel();
        }
        private void LayoutPanel()
        {
            // keep 10px margin on left/right and 30px top margin for example
            int left = this.Width / 2;
            int top = 30;
            int right = 10;
            int bottom = 10;

            panel1.Location = new Point(left, top);
            panel1.Size = new Size(
                this.ClientSize.Width - left - right,
                this.ClientSize.Height - top - bottom);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            radni = poligon.ucitaj();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // Adds a point to the list and invalidates the panel to trigger repaint
        public void AddPoint(Tacka t)
        {
            _points.Add(t);
            panel1.Invalidate();
        }

        // Paint event draws all stored points
        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            foreach (var t in _points)
            {
                Crtaj(e.Graphics, t);
            }
        }

        // Draw a single point on the provided Graphics. Coordinates are translated
        // so (0,0) is bottom-left of the panel (y inverted).
        public void Crtaj(Graphics dr, Tacka t)
        {
            int panelHeight = panel1.ClientSize.Height;
            int panelWidth = panel1.ClientSize.Width;
            // ose
            int pocetak = panelWidth / 10;
            int kraj = panelWidth - pocetak;
            int visina = panelHeight - panelHeight / 10;

            Pen linija = new Pen(Color.Black, 2);
            dr.DrawLine(linija, pocetak, visina, kraj, visina);



            int x = panelWidth / 2 + (int)t.x * 20; // Shift x to center
            int y = panelHeight / 2 - (int)t.y * 30; // Invert y and shift to center

            using (var cetka = new SolidBrush(Color.Red))
            {
                dr.FillEllipse(cetka, x, y, 8, 8);
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            double x = Convert.ToDouble(textBox1.Text);
            double y = Convert.ToDouble(textBox2.Text);
            Tacka nova = new Tacka(x, y);
            _points.Add(nova);
            string tacka = "x=" + x.ToString() + " y=" + y.ToString();
            listBox1.Items.Add(tacka);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int duzina = _points.Count;
            Tacka[] temena;
            temena = new Tacka[duzina];
            for (int i = 0; i < duzina; i++)
            {
                temena[i] = _points[i];
            }
            radni = new poligon(duzina, temena);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool prost = radni.prost();
            if (prost) label1.Text = "Prost";
            else label1.Text = "Nije prost";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            radni.snimi();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool konv = radni.konveksan();
            if (konv) label2.Text = "Konveksan";
            else label2.Text = "Konkavan";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            double povrs = radni.povrsina();
            label5.Text = povrs.ToString();
        }
    }
}
