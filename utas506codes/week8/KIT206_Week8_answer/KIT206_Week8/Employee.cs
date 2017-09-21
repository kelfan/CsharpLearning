using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIT206_Week8
{
    public enum Gender { M, F, X };

    public class Employee
    {
        //These properties have auto-generated getters and setters and hence are entirely public
        public string Name { get; set; }
        public int ID { get; set; }
        public Gender Gender { get; set; }

        public override string ToString()
        {
            return Name + '\t' + ID + '\t' + Gender;
        }
    }
}
