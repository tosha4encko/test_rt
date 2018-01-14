using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_tr
{
    public struct ray
    {
        public Vector begin;
        public Vector dir;
        public double dist;

        public ray(Vector begin, Vector dir)
        {
            this.begin = begin;
            this.dir = dir;
            dist = -1;
        }


    }
}
