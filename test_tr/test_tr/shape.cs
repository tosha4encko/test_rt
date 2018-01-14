using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_tr
{
    abstract public class obj
    {
        public Color color_obj;
        public const double Epsilon = 0.001;
        public obj() { }
        abstract public double is_cross(ray r);

        public System.Drawing.Color get_col()
        {
            return System.Drawing.Color.FromArgb((byte)(color_obj.R * 255),
                                                 (byte)(color_obj.G * 255),
                                                 (byte)(color_obj.B * 255));
        }

    }

    public class sphere : obj
    {
        public Vector center;
        public double radius;

        public sphere() { }
        public sphere(Vector cent, double rad, Color color_sh)
        {
            center = cent;
            radius = rad;
            color_obj = color_sh;
        }

        public override double is_cross(ray r)
        {
            var temp = r.begin - center;
            var a = r.dir * r.dir;
            var b = temp * 2.0 * r.dir;
            var c = temp * temp - radius * radius;
            var d = b * b - 4.0 * a * c;

            if (d > 0)
            { 
                var e = System.Math.Sqrt(d);
                var t = (-b - e) / (2.0 * a);
               // if (t > Epsilon)
                    return t;
            }
            return -1;
        }
    }
}

