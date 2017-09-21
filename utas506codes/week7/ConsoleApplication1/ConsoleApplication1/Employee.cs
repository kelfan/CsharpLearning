using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    enum Gender { M, F, X };
    class Employee
    {
        public string name;
        public int id;
        public Gender gender;
        public override string ToString()
        {
            return id +"\t"+name+"\t"+gender;
        }


    }
}
