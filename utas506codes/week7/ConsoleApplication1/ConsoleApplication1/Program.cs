using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Employee e = new Employee { name = "Jane", id = 1, gender = Employee.Gender.F };
            //Console.WriteLine(e);
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee { name = "Jane2", id = 1, gender = Gender.F });
            employees.Add(new Employee { name = "he", id = 2, gender = Gender.F });
            employees.Add(new Employee { name = "she", id = 3, gender = Gender.M });
            employees.Add(new Employee { name = "li", id = 4, gender = Gender.M });
            employees.Add(new Employee { name = "di", id = 5, gender = Gender.X });
            foreach(Employee e in employees)
            {
                Console.WriteLine(e);
            }
            Console.WriteLine("-----filtered list-----");
            List<Employee> femp = new List<Employee>();
            femp = FilterByGender(employees,Gender.F);
            foreach(Employee e in femp)
            {
                Console.WriteLine(e);
            }


        }
        static List<Employee> FilterByGender(List<Employee> staff, Gender gender)
        {
            List<Employee> result = new List<Employee>();
            foreach (Employee e in staff)
            {
                
                if (e.gender == gender)
                {
                    result.Add(e);
                }
            }
            return result;
        }
    }
}
