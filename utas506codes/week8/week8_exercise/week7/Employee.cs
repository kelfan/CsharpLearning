using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week7
{
    public enum Gender { M,F,X };

    public class Employee
    {
        //public string name;
        //public int id;
        //public Gender gender;

        //public override string ToString()
        //{
        //    return name+"\t"+id+"\t"+gender;
        //}

        public string Name { get; set; }
        public int ID { get; set; }
        public Gender Gender { get; set; }

        public override string ToString()
        {
            return Name+"\t"+ID+"\t"+Gender;
        }
    }
}
