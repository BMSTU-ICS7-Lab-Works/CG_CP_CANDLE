using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Drawing;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace Candle_CP
{
    class Particles
    {
        public List<Sphere> particles;
        public Scene sc;

        public Particles(Scene sc)
        {
            particles = new List<Sphere>();
            this.sc = sc;
            GenerateParticle();
        }
        private void GenerateParticle()
        {
            Random rndx = new Random();
            Random rndz = new Random();
            List<Color> spectre = new List<Color>();

            double redc = 176;//2.5
            double greenc = 76;//2
            double bluec = 16;//0.5
            Color curcol;

            int level1 = 300;
            int level2 = 250;
            int level0 = 320;

            int bz = 425;
            int fz = 475;
            int lowz = 450;
            int lowz2 = 450;
            // a= 25, 425
            int a = 25;
            //b = 80, 250
            int b = 80;
            double b2 = Math.Pow(b, 2);

            for (int y = 320; y > 170; y--)
            {
                
                redc += 1.875;
                greenc += 1.5;
                bluec += 0.375;
                if (redc >= 255)
                    redc = 255;
                if (greenc >= 255)
                    greenc = 255;
                curcol = Color.FromArgb((int)redc, (int)greenc, (int)bluec);
                double y2 = Math.Pow((y - 250), 2);
                int rx = (int)(Math.Sqrt(1 - y2 / b2) * a);
                int lx = -rx + 400;
                rx += 400;

                if (y > 300)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        int x = rndx.Next(lx, rx);
                        int z = rndz.Next(lowz, lowz2);
                        lowz -= 1;
                        lowz2 += 1;
                        Sphere sph = new Sphere(x, y, z, 2, curcol, 1000, 0);
                        
                        particles.Add(sph);
                    }
                }
                else
                {
                    for (int i = 0; i < 5; i++)
                    {
                        int x = rndx.Next(lx, rx);
                        int z = rndz.Next(bz, fz);
                        Sphere sph = new Sphere(x, y, z, 2, curcol, 1000, 0);
                        particles.Add(sph);
                    }
                }   
            }
        }

        public List<Sphere> getParticles()
        {
            return particles;
        }
    }
}