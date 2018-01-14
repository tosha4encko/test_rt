using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_tr
{
    public static class Scene
    {
        static public sphere sph1 = new sphere(new Vector(100, 100, 10), 70, new Color(0.2, 0.8, 0.2));
        static public Vector camera = new Vector(250, 250, 550);
        static public Vector light = new Vector(0, 0, 250);
        static public List<obj> list_obj = new List<obj> {sph1};
    }
}
