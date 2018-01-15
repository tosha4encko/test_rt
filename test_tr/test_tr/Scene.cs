using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_tr
{
    public static class Scene
    {
        static public sphere sph1 = new sphere(new Vector(250, 250, 200), 150, new Color(0.2, 0.8, 0.2));

        static public wall w1 = new wall(new Vector(0, 0, 10),   new Vector(0, 0, 0), new Color(0.2, 0.2, 0.8));
        static public wall w2 = new wall(new Vector(-10, 0, 0),  new Vector(400, 0, 0), new Color(0.3, 0.2, 0.6));
        static public wall w3 = new wall(new Vector(0, -10, 0),  new Vector(0, 400, 0), new Color(0.1, 0.4, 0.11));
        static public List<obj> list_obj = new List<obj> { sph1, w1, w2, w3};

        static public Vector camera      = new Vector(250, 250, 750);
        static public Vector light       = new Vector(0, 0, 450);
    }
}
