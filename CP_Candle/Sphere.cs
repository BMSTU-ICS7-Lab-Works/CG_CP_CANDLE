using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Candle_CP
{
    class Sphere
    {
        public string type = "Sphere";
        public int x, y, z, rad;
        public int specular;
        public Vector center;
        public double reflective;
        public Color color;
        public Sphere(int x, int y, int z, int rad, Color color, int specular, double reflect)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.rad = rad;
            this.color = color;
            this.center = new Vector(x, y, z);
            this.specular = specular;
            this.reflective = reflect;
        }
    }
}
