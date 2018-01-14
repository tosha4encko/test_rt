using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AffineTransformationsIn3D.Geometry;

namespace test_TR
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            pictureBox1.Width   = 500;
            pictureBox1.Height  = 500;
            this.Width          = 520;
            this.Height         = 520;

            List<Sphare> l = new List<Sphare>();
            var sh1 = new Sphare(new Vector(100, 100, 10), 150);
            var sh2 = new Sphare(new Vector(350, 350, 10), 110);
            l.Add(sh1);
            l.Add(sh2);

            Vector camera_pos       = new Vector(250, 250, 550);
            Vector light1           = new Vector(250, 550,550);
            Vector light2           = new Vector(0, 550, 200);
            Vector light3           = new Vector(200, 0, 300);
            Vector light4           = new Vector(400, 200, 0);
            List<Vector> list_light = new List<Vector>();
            list_light.Add(light1); list_light.Add(light2); list_light.Add(light3); list_light.Add(light4);

            color  ambient_col  = new color(50, 50, 50);
            double intence = 10;
            color diffuse_col = new color(0.0, 0.0, 50);


            var bitmap = new Bitmap(500, 500);

            int ind = -1;
            double min_dist = double.MaxValue;
            color res_col = new color();
            Vector point = new Vector(0, 0, 0);
            for (int i = 0; i < bitmap.Width; i++)
                for (int j = 0; j < bitmap.Height; j++)
                {
                    Vector pix_pos = new Vector(i, j, 500);
                    Vector dir = pix_pos - camera_pos;
                    Intersection inter;
                    for (int t = 0; t < l.Count; t++)
                    {
                        inter = l[t].Intersect(pix_pos, dir);
                        point = inter.point;
                        if (inter.is_create && inter.dist < min_dist)
                        {
                            min_dist = inter.dist;
                            ind = t;
                        }
                    }

                    if (ind != -1)
                    {
                        for (int p = 0; p < list_light.Count; p++)
                        {
                            res_col += ambient_col;
                            Vector init_p = point;
                            Vector l_dir = list_light[p] - init_p;
                            bool shadowed = false; // Сначала точка не в тени
                            Intersection inter2;
                            for (int t = 0; t < l.Count; t++)
                            {
                                inter2 = l[t].Intersect(init_p, l_dir);
                                if (inter2.is_create) // Если да
                                {
                                    label1.Text = "123";
                                    shadowed = true; // Объект в l_dir
                                    break;
                                }
                            }
                            if (!shadowed)
                                res_col += diffuse_col * intence; // То добавим к цвету интенсивность света ****
                            var col = System.Drawing.Color.FromArgb(
                                (byte)(res_col.R * 255),
                                (byte)(res_col.G * 255),
                                (byte)(res_col.B * 255)
                                    );
                            bitmap.SetPixel(i, j, col);
                        }
                    }
                                     
                }
                pictureBox1.Image = bitmap;
        }
 
           
    }       

}

