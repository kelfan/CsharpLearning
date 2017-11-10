using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Entity
{
    public class SportsBall
    {
        public int Age { get; set; }
        public double Weight { get; set; }

        public override string ToString()
        {
            return string.Format("A {0} kg ball, in service for {1} years", Weight, Age);
        }
    }
}
