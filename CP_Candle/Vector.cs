using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candle_CP
{
    class Vector
    {
        private double x, y, z;

        public Vector(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public static Vector operator -(Vector a, Vector b)
        {
            Vector temp = new Vector(a.x - b.x, a.y - b.y, a.z - b.z);
            //tempx
            return temp;
        }

        public static Vector operator +(Vector a, Vector b)
        {
            Vector temp = new Vector(a.x + b.x, a.y + b.y, a.z + b.z);
            //tempx
            return temp;
        }

        public static double operator *(Vector a, Vector b)
        {
            double temp = a.x * b.x + a.y * b.y + a.z * b.z;
            //tempx
            return temp;
        }

        public static Vector operator *(Vector a, double b)
        {
            Vector temp = new Vector(a.x * b, a.y * b, a.z * b);
            //tempx
            return temp;
        }

        public double Length()
        {
            double len;
            len = Math.Sqrt(Math.Pow(this.x, 2) + Math.Pow(this.y, 2) + Math.Pow(this.z, 2));
            return len;
        }
    }
}
