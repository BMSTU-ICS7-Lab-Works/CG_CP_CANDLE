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
    class Scene
    {
        public List<Sphere> Spheres;
        public List<Cylinder> Cylinders;
        public List<Plane> Planes;
        public List<Light> lights;
        public Size size;
        int ground = 250;

        public Scene(Size size)
        {
            Spheres = new List<Sphere>();
            Cylinders = new List<Cylinder>();
            Planes = new List<Plane>();
            lights = new List<Light>();
            this.size = size;
        }

        public void addSphere(Sphere s)
        {
            Spheres.Add(s);
        }

        public void addCylinder(Cylinder cyl)
        {
            Cylinders.Add(cyl);
        }

        public void addPlane(Plane pl)
        {
            Planes.Add(pl);
        }

        public void addLight(Light l)
        {
            lights.Add(l);
        }

        public List<Light> GetLights()
        {
            return lights;
        }

        public void createScene()
        {
            createLights();
            createModels();
        }

        public void createLights()
        {
            
            Light al = new Light("ambient", 0.25);
            this.addLight(al);
           
            Vector pos = new Vector(400, 250, 200);
            Light ap1 = new Light("point", 0.2, pos);

            //pos = new Vector(400, 250, 550);
            //Light ap2 = new Light("point", 0.2, pos);
            

            //Vector dir = new Vector(0, 0, 1);
            //Light ad = new Light("directional", dir, 0.6);
            //this.addLight(ad);



            this.addLight(ap1);
            //this.addLight(ap2);
            // this.addLight(ap3);

            //

        }
        private void createModels()
        {
            Sphere b = new Sphere(600, 460, 450, 100, Color.Blue, 800, 0.7);
            addSphere(b);
            Sphere c = new Sphere(200, 460, 250, 100, Color.Green, 200, 0.3);
            addSphere(c);

            this.addSphere(b);
            this.addSphere(c);

            Vector center = new Vector(size.Height / 2, size.Width / 2, 2000);
            Vector background_axis = new Vector(0, 0, 1);
            Plane p1 = new Plane(center, background_axis, Color.White, 100, 0.9);
            this.addPlane(p1);

            Vector ground_center = new Vector(0, size.Height, 0);
            Vector ground_axis = new Vector(0, 1, 0);
            Plane p2 = new Plane(ground_center, ground_axis, Color.White, 100, 0);
            this.addPlane(p2);

            
            Vector axis = new Vector(0, 1, 0);
            Cylinder f = new Cylinder(400, 340, 450, 100, axis, 220, Color.Orange, 500, 0);
            addCylinder(f);

            Cylinder wick = new Cylinder(400, 320, 450, 5, axis, 20, Color.Gray, 500, 0);
            addCylinder(wick);
            
        }
        /*
        
        private void createSphere(int cx, int cy, int cz, int r)
        {

        }
        */
    }
}
