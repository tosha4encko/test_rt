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
        public const double Epsilon = 0.0001;
        public obj()
        { }
        abstract public intersection? is_cross(ray r);

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

        public override intersection? is_cross(ray r)
        {
            var v1 = r.begin - center;
            var v2 = r.begin - r.dir;
            var angle = Vector.AngleBet(v1, v2);
            var dist2 = Vector.Dist(r.begin, center);
            var dist1 = Math.Abs(Math.Sin(angle) * dist2);

            bool b = angle > Math.PI / 2;
            if (angle > Math.PI/2 || dist1 > radius)
                return null;

            var dist3 = Math.Abs(Math.Cos(angle) * dist2);
            var dist4 = dist3 - Math.Sqrt(radius * radius - dist1 * dist1);

            var v_cross = r.begin - v2.Normalized() * dist4;
            return new intersection(v_cross, dist4);
        }
    }

    public class wall : obj
    {
        Vector norm;
        Vector point;

        public wall() { }

        public wall(Vector norm, Vector point, Color col_wall)
        {
            this.norm  = norm;
            this.point = point;
            color_obj  = col_wall;
        }
        public override intersection? is_cross(ray r)
        {
            var v1 = point - r.begin;
            var v2 = (r.dir - r.begin).Normalized();

            var temp = v2 * norm;

            if (temp >= 0)
                return null;

            var t = (point - r.begin) * norm / temp;
            return new intersection(r.begin + (v2.Normalized() * t), t);

            /*if (v2 * norm - Epsilon >= 0)
                return null;

            var angle = Vector.AngleBet(v1, v2);
            var angle2 = Vector.AngleBet(v2, norm);

            float dist1 = (float)Vector.Dist(r.begin, point);
            float dist2 = (float)Math.Sin(angle) * dist1;

            float dist3 = (float)(dist2 / (Math.Sin(angle2)));

            float dist4 = (float)(dist3 * (Math.Tan(angle2)));

            float dist5 = (float)Math.Sqrt(dist4 * dist4 - dist2 * dist2);

            float dist01 = (float)(dist1 * dist1);
            float dist02 = (float)(dist2 * dist2);
            float dist03 = (float)(dist01 - dist02);

            float dist6 = (float)Math.Sqrt(dist1 * dist1 - dist2 * dist2);

            float dist = dist5 + dist6;
            if (dist < 1) return null;
            return new intersection(r.begin + (v2.Normalized() * dist), dist);*/
        }
    }


}

