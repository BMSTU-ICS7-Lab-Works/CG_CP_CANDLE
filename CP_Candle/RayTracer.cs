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
using System.Diagnostics;

namespace Candle_CP
{
    class RayTracer
    {
        Size size;
        public Bitmap bitmap;
        private Color[,] ColorBuf;
        private Scene s;
        public List<Sphere> sl;

        public RayTracer(Scene s)
        {
            Particles particles = new Particles(s);

            sl = new List<Sphere>(s.Spheres);
            sl.AddRange(particles.getParticles());

            size = s.size;
            this.ColorBuf = new Color[size.Width, size.Width];
            this.bitmap = new Bitmap(size.Width, size.Height);
            this.s = s;
            int thread_num = 4;
            Render(thread_num);
        }

        public Bitmap GetBitmap()
        {
            return this.bitmap;
        }

        public void tracer(Object obj)
        {
            //Vector origin = new Vector(0, 0, 0);
            int recursion_depth = 3;
            Scene_part sc = (Scene_part)obj;
            for (int y = sc.start_y; y < sc.start_y + sc.height; y++)
            {
                for (int x = sc.start_x; x < sc.start_x + sc.width; x++)
                {
                    
                    Vector origin = new Vector(x, y - 50, 0);
                    //Vector direction = new Vector(0, 0.5, 1);
                    Vector direction = new Vector(0, 0.2, 1);
                    Ray ray = new Ray(origin, direction);

                    Color curcolor = Trace_ray(ray, recursion_depth);
                    PutPixel(x, y, curcolor);      
                }
            }
        }

        private Model Closest_intersec(Vector O, Vector D, double t_min, double t_max, ref double closest_t)
        {
            Vector cent = new Vector(-1, -1, -1);
            Model closest_model = new Model(Color.Black, cent, -1);
            
            
            foreach (Sphere sph in sl)
            {
                double[] res_t = new double[2];

                res_t = intersect_ray_sphere(O, D, sph, res_t);


                if (res_t[0] <= t_max && res_t[0] > t_min && res_t[0] < closest_t)
                {
                    closest_t = res_t[0];
                    closest_model.setCenter(sph.center);
                    closest_model.setColor(sph.color);
                    closest_model.specular = sph.specular;
                    closest_model.reflective = sph.reflective;
                    closest_model.type = "Sphere";
                }
                if (res_t[1] <= t_max && res_t[1] > t_min && res_t[1] < closest_t)
                {
                    closest_t = res_t[1];
                    closest_model.setCenter(sph.center);
                    closest_model.setColor(sph.color);
                    closest_model.specular = sph.specular;
                    closest_model.reflective = sph.reflective;
                    closest_model.type = "Sphere";
                }
            }

            
            /*
            Vector center = new Vector(size.Height / 2, size.Width / 2, 500);
            Vector background_axis = new Vector(0, 0, 1);
            Plane p1 = new Plane(center, background_axis, Color.Red, 500);
            pl.Add(p1);

            Vector ground_center = new Vector(size.Width, size.Height, 200);
            Vector ground_axis = new Vector(0, 1, 0);
            Plane p2 = new Plane(ground_center, ground_axis, Color.White, 500);
            pl.Add(p2);
            */


            foreach (Plane pln in s.Planes)
            {
                double t = 0;
                intersect_ray_plane(O, D, pln, ref t);
                if (t <= t_max && t > t_min && t < closest_t)
                {
                    closest_t = t;
                    closest_model.setCenter(pln.center);
                    closest_model.setColor(pln.color);
                    closest_model.specular = pln.specular;
                    closest_model.reflective = pln.reflective;
                    closest_model.type = "Plane";
                }
            }

            foreach (Cylinder cyl in s.Cylinders)
            {
                double[] res_t = new double[2];
                int flag = 0;
                res_t = intersect_ray_cylinder(O, D, cyl, res_t, ref flag);


                if (res_t[0] <= t_max && res_t[0] > t_min && res_t[0] < closest_t)
                {
                    closest_t = res_t[0];
                    closest_model.setCenter(cyl.center);
                    closest_model.setColor(cyl.color);
                    closest_model.specular = cyl.specular;
                    closest_model.reflective = cyl.reflective;
                    if (flag == 1)
                        closest_model.type = "Plane";
                    else
                        closest_model.type = "Cylinder";
                    closest_model.N = cyl.axis;
                }
                if (res_t[1] <= t_max && res_t[1] > t_min && res_t[1] < closest_t)
                {
                    closest_t = res_t[1];
                    closest_model.setCenter(cyl.center);
                    closest_model.setColor(cyl.color);
                    closest_model.specular = cyl.specular;
                    closest_model.reflective = cyl.reflective;
                    if (flag == 1)
                        closest_model.type = "Plane";
                    else
                        closest_model.type = "Cylinder";
                    closest_model.N = cyl.axis;
                }
            }
                

            return closest_model;
        }

        private Vector ReflectRay(Vector R, Vector N)
        {
            return N * 2 * (N * R) - R;
        }

        private Vector CylinderNorm(Vector P, Model closest_model, Vector O, Vector D, double closest_t)
        {
            Vector CO = O - closest_model.center;

            double dv = D * closest_model.N;
            double cov = CO * closest_model.N;
            double m = dv * closest_t + cov;
            Vector norm = P;
            norm -= closest_model.center;
            norm = norm - closest_model.N * m;
            return norm;
        }

        private Color Trace_ray(Ray ray, int depth)
        {
            Vector O = ray.origin;
            Vector D = ray.direction;

            double closest_t = Double.MaxValue;


            Vector cent = new Vector(-1, -1, -1);
            Model closest_model = new Model(Color.Black, cent, -1);

            double t_min = 1;
            double t_max = Double.MaxValue;
            closest_model = Closest_intersec(O, D, t_min, t_max, ref closest_t);
            //if (closest_t != Double.MaxValue)
               // return closest_model.color;
            //eto potom vernut
            if (closest_t != Double.MaxValue)
            {
                Vector P = O + (D * closest_t);
                Vector N = P - closest_model.center;
                if (closest_model.type == "Sphere")
                {
                    N = P - closest_model.center;
                }
                else if (closest_model.type == "Cylinder")
                {
                    N = CylinderNorm(P, closest_model, O, D, closest_t);
                }
                else if (closest_model.type == "Plane")
                {
                    N = closest_model.center * -1;
                }
                N *= 1 / N.Length();
                double intensity = ComputeLightning(P, N, D * -1, closest_model.specular, s);
                int curcolor = (int)(closest_model.color.R * intensity);
                int red = (curcolor > 255) ? 255 : (curcolor < 0) ? 0 : curcolor;

                curcolor = (int)(closest_model.color.G * intensity);
                int green = (curcolor > 255) ? 255 : (curcolor < 0) ? 0 : curcolor;

                curcolor = (int)(closest_model.color.B * intensity);
                int blue = (curcolor > 255) ? 255 : (curcolor < 0) ? 0 : curcolor;

                Color local_color = Color.FromArgb(red, green, blue);

                double r = closest_model.reflective;
                if (depth <= 0 || r <= 0)
                    return local_color;

                Vector R = ReflectRay(D * -1, N);
                Ray newray = new Ray(P, R);
                Color reflected_color = Trace_ray(newray, depth - 1);

                curcolor = (int)(reflected_color.R * r) + (int)(local_color.R * (1 - r));
                red = (curcolor > 255) ? 255 : (curcolor < 0) ? 0 : curcolor;

                curcolor = (int)(reflected_color.G * r) + (int)(local_color.G * (1 - r));
                green = (curcolor > 255) ? 255 : (curcolor < 0) ? 0 : curcolor;

                curcolor = (int)(reflected_color.B * r) + (int)(local_color.B * (1 - r));
                blue = (curcolor > 255) ? 255 : (curcolor < 0) ? 0 : curcolor;

                Color rescolor = Color.FromArgb(red, green, blue);

                return rescolor;
            }
            return Color.Black;
        }

        private double[] intersect_ray_sphere(Vector O, Vector D, Sphere sphere, double[] res_t)
        {
            Vector C = new Vector(sphere.x, sphere.y, sphere.z);
            int r = sphere.rad;
            Vector OC = O - C;

            double k1 = D * D;
            double k2 = 2 * (OC * D);
            double k3 = OC * OC - r * r;

            double discr = k2 * k2 - 4 * k1 * k3;

            if (discr < 0)
            {
                res_t[0] = Double.PositiveInfinity;
                res_t[1] = Double.PositiveInfinity;
                return res_t;
            }

            res_t[0] = (-k2 + Math.Sqrt(discr)) / (2 * k1);

            res_t[1] = (-k2 - Math.Sqrt(discr)) / (2 * k1);

            return res_t;
        }

        private void intersect_ray_plane(Vector O, Vector D, Plane plane, ref double t)
        {
            Vector C = plane.center;
            Vector V = plane.V;

            Vector OC = O - C;

            double DV = D * V;
            double OCV = OC * V;

            if (DV < 0 || DV > 0)
            {
                t = -OCV / DV;
                if (t < 0)
                    t = Double.PositiveInfinity;

            }
            else
            {
                t = Double.PositiveInfinity;
            }
        }

        private double[] intersect_ray_cylinder(Vector O, Vector D, Cylinder cylinder, double[] res_t, ref int flag)
        {
            Vector C = new Vector(cylinder.x, cylinder.y, cylinder.z);
            int r = cylinder.rad;
            Vector OC = O - C;
            Vector V = cylinder.axis;
            double k1 = D * D - Math.Pow(D * V, 2);
            double k2 = 2 * (OC * D - (D * V)  * (OC * V));
            double k3 = OC * OC - Math.Pow(OC * V, 2) - r * r;

            double discr = k2 * k2 - 4 * k1 * k3;

            if (discr < 0)
            {
                res_t[0] = Double.PositiveInfinity;
                res_t[1] = Double.PositiveInfinity;
                return res_t;
            }
            else if (discr == 0)
            {
                res_t[0] = -k2 / (2 * k1);
                res_t[1] = Double.PositiveInfinity;
            } 
            else
            {
                res_t[0] = (-k2 + Math.Sqrt(discr)) / (2 * k1);

                res_t[1] = (-k2 - Math.Sqrt(discr)) / (2 * k1);
            }
            double m1 = (D * V) * res_t[0] + OC * V;
            
            double m2 = (D * V) * res_t[1] + OC * V;
            if (m1 <= 0)
            {
                intersect_ray_plane(O, D, new Plane(C, V * -1, cylinder.color, cylinder.specular, 0), ref res_t[0]);
                Vector P = O + D * res_t[0];
                double r_ = (P - C).Length();
                if (r_ > r)
                    res_t[0] = Double.PositiveInfinity;
            }

            if (m1 >= cylinder.maxm)
            {
                Vector E = C + cylinder.axis * cylinder.maxm;

                intersect_ray_plane(O, D, new Plane(E, V, cylinder.color, cylinder.specular, 0), ref res_t[0]);
                Vector P = O + D * res_t[0];
                double r_ = (P - E).Length();
                if (r_ > r)
                    res_t[0] = Double.PositiveInfinity;
            }

            if (m2 <= 0)
            {
                intersect_ray_plane(O, D, new Plane(C, V * -1, cylinder.color, cylinder.specular, 0), ref res_t[1]);
                flag = 1;
                Vector P = O + D * res_t[1];
                double r_ = (P - C).Length();
                if (r_ > r)
                    res_t[1] = Double.PositiveInfinity;
            }

            if (m2 >= cylinder.maxm)
            {
                Vector E = C + cylinder.axis * cylinder.maxm;

                intersect_ray_plane(O, D, new Plane(E, V, cylinder.color, cylinder.specular, 0), ref res_t[1]);
                flag = 1;
                Vector P = O + D * res_t[1];
                double r_ = (P - E).Length();
                if (r_ > r)
                    res_t[1] = Double.PositiveInfinity;
            }
            return res_t;
        }

        public double ComputeLightning(Vector P, Vector N, Vector V, int spec, Scene s)
        {
            double i = 0.0;
            Vector L;
            int t_max;
            foreach (Light l in s.GetLights())
            {
                if (l.type == "ambient")
                {
                    i += l.intensity;
                }
                else
                {
                    if (l.type == "point")
                    {
                        L = l.position - P;
                        t_max = 1;
                    }
                    else
                    {
                        L = l.direction;
                        t_max = Int32.MaxValue;
                    }
                    double shadow_t = Double.MaxValue;
                    Model m = Closest_intersec(P, L, 0.001, t_max, ref shadow_t);
                    if (shadow_t != Double.MaxValue)
                       continue;

                    double n_dot_l = N * L;

                    if (n_dot_l > 0)
                        i += l.intensity * n_dot_l / (N.Length() * L.Length());

                    if (spec != -1)
                    {
                        Vector R = N * 2 * (N * L) - L;
                        double r_dot_v = R * V;
                        if (r_dot_v > 0)
                            i += l.intensity * Math.Pow(r_dot_v / (R.Length() * V.Length()), spec);
                    }
                }
            }
            return i;
        }

        private void PutPixel(int x, int y, Color color)
        {
            if (x < 0 || x >= size.Width || y < 0 || y >= size.Height)
            {
                return;
            }

            this.ColorBuf[x, y] = color;
        }

        private void Render(int thread_num)
        {
            Thread[] threads = new Thread[thread_num];
            for (int i = 0; i < thread_num; i++)
            {
                Scene_part sc = new Scene_part(size.Width / thread_num, size.Height, size.Width / thread_num * i, 0);
                threads[i] = new Thread(tracer);
                threads[i].Start(sc);
            }
            foreach(Thread thread in threads)
            {
                thread.Join();
            }
            
            for (int i = 0; i < size.Width; i++)
                for (int j = 0; j < size.Height; j++)
                    this.bitmap.SetPixel(i, j, ColorBuf[i, j]);
        }
    }

    class Scene_part
    {
        public int width;
        public int height;
        public int start_x;
        public int start_y;
        public Scene_part(int width, int height, int start_x, int start_y)
        {
            this.width = width;
            this.height = height;
            this.start_x = start_x;
            this.start_y = start_y;
        }
    }

    class Ray
    {
        public Vector origin, direction;

        public Ray(Vector origin, Vector direction)
        {
            this.origin = origin;
            this.direction = direction;
        }
    }
}
