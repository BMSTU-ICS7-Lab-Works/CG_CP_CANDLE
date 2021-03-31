using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Candle_CP
{
    class Plane
    { 
        public string type = "Plane";
        public int specular;
        public Vector center;
        public Vector V;
        public double reflective;
        public Color color;
        public Plane(Vector C, Vector V, Color color, int specular, double reflect)
        {
            this.color = color;
            this.center = C;
            this.specular = specular;
            this.V = V;
            this.reflective = reflect;
        }
    }
}
