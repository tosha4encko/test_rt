using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test_tr
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            pictureBox1.Width = 500;
            pictureBox1.Height = 500;
            this.Width = 520;
            this.Height = 520;
 
            pictureBox1.Image = create_map(Scene.camera, Scene.list_obj, new Bitmap(500, 500));
        }

        Bitmap create_map(Vector camera, List<obj> figures, Bitmap map, int z = 520)
        {
            for (int i = 0; i < map.Width; i++)
                for (int j = 0; j < map.Height; j++)
                {
                    ray r = new ray(camera, new Vector(i, j, z));
                    double min_dist = z;

                    obj res_obj = new sphere();

                    foreach (obj figure in figures)
                    {
                        double dist_ray = figure.is_cross(r);
                        if (dist_ray != -1 && dist_ray < min_dist)
                        {
                            min_dist = dist_ray;
                            res_obj = figure;
                        }
                    }

                    if (min_dist < z)
                        map.SetPixel(i, j, res_obj.get_col());


                }
            return map;
        }
    }
}
