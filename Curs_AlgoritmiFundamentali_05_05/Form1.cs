using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Curs_AlgoritmiFundamentali_05_05
{
    public partial class Form1 : Form
    {
        Graphics grp;
        Bitmap bmp;
        Point[] P;

        void draw(Point[] P, Color t)
        {
            
            for (int i = 0; i < P.Length - 1; i++)
            {
                grp.DrawLine(new Pen(t), P[i].x, P[i].y, P[i + 1].x, P[i + 1].y);
            }
            grp.DrawLine(new Pen(t), P[P.Length - 1].x, P[P.Length - 1].y, P[0].x, P[0].y);
            /*for (int i = 0; i < P.Length; i++)
            {
                P[i].draw(grp);
            }*/
        }

        Point cg(Point[]P)
        {
            float x = 0;
            float y = 0;
            for (int i = 0; i < P.Length; i++)
            {
                x += P[i].x;
                y += P[i].y;
            }
            x = x / P.Length;
            y = y / P.Length;

            Point tor = new Point();
            tor.x = x;
            tor.y = y;

            return tor;

            //functia care imi returneaza centrul de greutate al poligonului
        }

        Point[] SP (Point[]P)
        {
            Point[] S = new Point[P.Length];
            for (int i = 0; i < P.Length - 1; i++)
            {
                float x = P[i].x + P[i + 1].x;
                float y = P[i].y + P[i + 1].y;
                S[i] = new Point();
                S[i].x = x / 2;
                S[i].y = y / 2;
            }
            
                S[P.Length - 1] = new Point();
            S[P.Length - 1].x = (P[P.Length - 1].x + P[0].x) / 2;
            S[P.Length - 1].y = (P[P.Length - 1].y + P[0].y) / 2;
            return S;
        } // am construit poligonul mai mic
        
        float det(Point A, Point B, Point C)
        {
            float t = A.x * B.y + B.x * C.y + C.x * A.y - C.x * B.y - C.y * A.x - A.y * B.x;

            return t;
        }

        float Arie(Point[]P)
        {
            float a = 0;
            Point O = new Point();
            O.x = 0;
            O.y = 0;
            for (int i = 0; i < P.Length - 1; i++)
            {
                a += det(O, P[i], P[i + 1]);
            }
            a += det(O, P[P.Length -1], P[0]);
            
            return 0.5f * (float)Math.Abs(a);
        }
        //aria unui poligon fara triangulare!!

        void sol (Point[] P)
        {
            while(Arie(P) >=  1)
            {
                draw(P, Color.Black);
                listBox1.Items.Add(Arie(P).ToString("0.0000"));
                Point[] S = SP(P);
                P = S;
            }
        }

        float distanta (Point A, Point B)
        {
            return (float)Math.Sqrt((A.x - B.x) * (A.x - B.x) + (A.y - B.y) * (A.y - B.y));
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            grp = Graphics.FromImage(bmp);
            // cu initializarile astea putem sa desenam

            /*grp.DrawLine(Pens.Red, 10, 10, 300, 50);*/

            P = new Point[20];
            for (int i = 0; i < P.Length; i++)
            {
                P[i] = new Point((float)pictureBox1.Width, (float)pictureBox1.Height); //am obtinut punctele pentru poligon
            }
           /* draw(P, Color.Blue);*/
            Point G = cg(P);
            /*G.draw(grp);*/
            /*Point[] S = SP(P);*/
            /*draw(S, Color.Red);*/

            float a1 = Arie(P);
            /*float a2 = Arie(S);*/
            sol(P);
            Point E = cg(P);
            listBox1.Items.Add("Distanta este " + distanta(G, E));

            /*textBox1.Text = a1.ToString("0.00") + " " + a2.ToString("0.00");*/
            pictureBox1.Image = bmp; //am facut refresh ca sa afizez
        }

    }
}
