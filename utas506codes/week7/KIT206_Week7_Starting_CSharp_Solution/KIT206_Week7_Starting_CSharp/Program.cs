using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIT206_Week7_Starting_CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            //The first test case
//            Employee e = new Employee{name="Jane", id=1, gender=Gender.F};
//            Console.WriteLine("Test employee == " + e);

            List<Employee> employees = GenerateTestData();
            DisplayEmployees(employees);

            Console.WriteLine("\nMale employees:");
            DisplayEmployees( FilterByGender(employees, Gender.M) );

            Console.WriteLine("\nFemale employees:");
            DisplayEmployees( FilterByGender(employees, Gender.F) );

            Console.WriteLine("\nIndeterminate, unspecified or intersex employees:");
            Console.WriteLine("(Note, you would *never* in real life be using this information about your employees)");
            DisplayEmployees( FilterByGender(employees, Gender.X) );
        }

        // Returns a new list of Employees containing some test examples.
        static List<Employee> GenerateTestData()
        {
            List<Employee> data = new List<Employee>();
            data.Add(new Employee { name = "Jane", id = 1, gender = Gender.F });
            data.Add(new Employee { name = "John", id = 3, gender = Gender.M });
            data.Add(new Employee { name = "Mary", id = 7, gender = Gender.F });
            data.Add(new Employee { name = "Lindsay", id = 5, gender = Gender.X });
            data.Add(new Employee { name = "Meilin", id = 2, gender = Gender.F });

            return data;
        }

        // Returns a new list of Employees containing those with the specified gender.
        static List<Employee> FilterByGender(List<Employee> staff, Gender gender)
        {
            List<Employee> filtered = new List<Employee>();
            foreach (Employee e in staff)
            {
                if (e.gender == gender)
                {
                    filtered.Add(e);
                }
            }
            return filtered;
        }

        // Displays a list of employees on the console.
        static void DisplayEmployees(List<Employee> staff)
        {
            foreach (Employee e in staff)
            {
                Console.WriteLine(e);
            }
        }

    }
}
