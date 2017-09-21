using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIT206_Week7_Starting_CSharp
{
    enum Gender { M, F, X };

    class Employee
    {
        public string name;
        public int id;
        public Gender gender;

        public override string ToString()
        {
            return name + "\t" + id + "\t" + gender;
        }
    }
}
