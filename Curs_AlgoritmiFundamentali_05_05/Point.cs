using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Curs_AlgoritmiFundamentali_05_05
{
    public class Point
    {
        public static Random rnd = new Random();
        public float x, y;
        public Point (float x, float y)
        {
            this.x = (float)(rnd.NextDouble() * x);
            this.y = (float)(rnd.NextDouble() * y);
        }

        public void draw(Graphics grp)
        {
            grp.DrawEllipse(Pens.Black, x - 3, y - 3, 7, 7); //deseneaza in xy o elipsa de raza 3
        }

        public Point()
        {

        }
        
    }
}
