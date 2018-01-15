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
            this.Width = 520;
            this.Height = 520;


            pictureBox1.Width = 500;
            pictureBox1.Height = 500;
            pictureBox1.Image = create_map(new Bitmap(500, 500));
        }

        Bitmap create_map(Bitmap map, int z = 600)
        {
            for (int i = 0; i < map.Width; i++)
                for (int j = 0; j < map.Height; j++)
                {
                    ray r = new ray(Scene.camera, new Vector(i, j, z));
                    r.init_color(3000);
                    map.SetPixel(i, j, r.get_col());
                }
            return map;
        }
    }
}
