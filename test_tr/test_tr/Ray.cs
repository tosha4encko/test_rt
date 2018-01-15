using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace test_tr
{
    public struct ray
    {
        public Vector begin;
        public Vector dir;
        public Color  this_col;
        public ray(Vector begin, Vector dir)
        {
            this.begin = begin;
            this.dir = dir;
            this_col = new Color(0, 0, 0);
        }

        public void init_color(double max_dist)
        {
            double min_dist = max_dist;
            obj o = null;
            intersection? intersec = null;

            int x;
            if (dir.X == 250 && dir.Y == 250)
                x = 1;

            foreach (obj figure in Scene.list_obj)
            {
                intersection? intersec0 = figure.is_cross(this);
                if (intersec0 != null && intersec0.Value.dist < min_dist)
                {
                    min_dist = intersec0.Value.dist;
                    intersec = intersec0;
                    //this_col = figure.color_obj;
                    o = figure;
                }
            }


            if (min_dist < max_dist)
            {
                ray second_ray = new ray(intersec.Value.point, Scene.light);
                //MessageBox.Show(intersec.Value.point.Z + "");
                bool is_light = true;
                intersec = new intersection();
                foreach (obj figure in Scene.list_obj)
                {
                    if (!(figure is wall))
                    {
                        intersec = figure.is_cross(second_ray);
                        if (intersec != null)
                        {
                            is_light = false;
                            break;
                        }
                    }
                }
                if (is_light) this_col = o.color_obj;
            }

        }
        public System.Drawing.Color get_col()
        {
            return System.Drawing.Color.FromArgb((byte)(this_col.R * 255),
                                                 (byte)(this_col.G * 255),
                                                 (byte)(this_col.B * 255));
        }
    }
}
