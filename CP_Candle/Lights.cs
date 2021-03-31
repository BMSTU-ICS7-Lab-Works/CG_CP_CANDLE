using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candle_CP
{
    class Light
    {
        public string type;
        public double intensity;
        public Vector position;
        public Vector direction;

        public Light(string type, double intensity)
        {
            this.type = type;
            this.intensity = intensity;
        }

        public Light(string type, double intensity, Vector position)
        {
            this.type = type;
            this.intensity = intensity;
            this.position = position;
        }

        public Light(string type, Vector direction, double intensity)
        {
            this.type = type;
            this.intensity = intensity;
            this.direction = direction;
        }

        
    }
}
