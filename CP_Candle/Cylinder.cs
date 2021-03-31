using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Candle_CP
{
    class Cylinder
    {
        public string type = "Cylinder";
        public int x, y, z, rad;
        public int specular;
        public Vector center;
        public Vector axis;
        public int maxm;
        public double reflective;

        public Color color;
        public Cylinder(int x, int y, int z, int rad, Vector axis, int maxm, Color color, int specular, double reflect)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.rad = rad;
            this.color = color;
            this.center = new Vector(x, y, z);
            this.maxm = maxm;
            this.axis = axis;
            this.specular = specular;
            this.reflective = reflect;
        }
    }
}
