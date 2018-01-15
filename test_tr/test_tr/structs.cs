using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_tr
{
    public struct intersection
    {
        public Vector point;
        public double dist;

        public intersection(Vector p, double d)
        {
            point = p;
            dist = d;
        }
    }
}
