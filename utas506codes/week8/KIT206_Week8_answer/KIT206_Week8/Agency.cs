using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIT206_Week8
{
    abstract class Agency
    {
        public static List<Employee> Generate()
        {
            return new List<Employee>() {
                new Employee { Name = "Jane", ID = 1, Gender = Gender.F },
                new Employee { Name = "John", ID = 3, Gender = Gender.M },
                new Employee { Name = "Mary", ID = 7, Gender = Gender.F },
                new Employee { Name = "Lindsay", ID = 5, Gender = Gender.X },
                new Employee { Name = "Meilin", ID = 2, Gender = Gender.F }
            };
        }
    }
}
