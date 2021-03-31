using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Drawing;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Candle_CP
{
    class Model
    {
        public Color color = Color.Black;
        public Vector center;
        public int specular;
        public double reflective = 0;
        public string type = "None";
        public Vector N = new Vector(0, 0, 0);
        public Model(Color color, Vector center, int spec)
        {
            this.color = color;
            this.center = center;
            this.specular = spec;
        }

        public void setCenter(Vector center)
        {
            this.center = center;
        }

        public void setColor(Color color)
        {
            this.color = color;
        }
    }

    class Point
    {
        public int x, y, z;

        public Point()
        {
            this.x = 0;
            this.y = 0;
            this.z = 0;
        }

        public Point(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public static Point operator -(Point a, Point b)
        {
            Point temp = new Point(a.x - b.x, a.y - b.y, a.z - b.z);
            //tempx
            return temp;
        }

    }
}
