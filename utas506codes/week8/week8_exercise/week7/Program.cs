using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week7
{
   // This defines a new delegate type that is compatible with any method whose return type is Employee and that takes in a single integer parameter. It doesn’t specify what the behaviour of the method must be, only what parameters and return type it must have 
    public delegate Employee ManageWorker(int id);

    class Program
    {
        static void Main(string[] args)
        {
            //week 7 test 1
            //Employee e = new Employee { name = "Jane", id = 1, gender = Gender.F };
            //Console.WriteLine(e);

            //List<Employee> employees = new List<Employee>();
            //employees.Add(new Employee { name = "Jane", id = 1, gender = Gender.F });
            //employees.Add(new Employee { name = "John", id = 3, gender = Gender.M });
            //employees.Add(new Employee { name = "Mary", id = 7, gender = Gender.F });
            //employees.Add(new Employee { name = "Lindsay", id = 5, gender = Gender.X });
            //employees.Add(new Employee { name = "Meilin", id = 2, gender = Gender.F });

            //DisplayEmployees(employees);
            //Console.WriteLine("\nMale:");
            //DisplayEmployees(FilterByGender(employees, Gender.M));
            //Console.WriteLine("\nFemale:");
            //DisplayEmployees(FilterByGender(employees, Gender.F));
            //Console.WriteLine("\nothers:");
            //DisplayEmployees(FilterByGender(employees, Gender.X));

            // Action is an existing delegate in the System namespace. It is compatible with any method that has no return value (its return type is void) and that takes no parameters
            Action doSomething;
            ManageWorker manage;

            Boss bs = new Boss();

            doSomething = bs.Display;
            //manage = bs.Use;
            manage = bs.Fire;

            doSomething();
            Console.WriteLine("Dealing with {0}", manage(2)); //if 1 is an ID
            doSomething();

            
            //bs.Display();
            //Console.WriteLine("\nuse:");
            //Console.WriteLine(bs.Use(1));
            //Console.WriteLine("\nfire:");
            //bs.Fire(7);
            //bs.Display();
        
        }

        //static List<Employee> FilterByGender(List<Employee> staff, Gender gender)
        //{
        //    List<Employee> result = new List<Employee>();
        //    foreach (Employee e in staff)
        //    {
        //        if (e.gender == gender)
        //        {
        //            result.Add(e);
        //        }
        //    }
        //    return result;
        //}

        //static void DisplayEmployees(List<Employee> staff)
        //{
        //    foreach (Employee e in staff)
        //    {
        //        Console.WriteLine(e);
        //    }
        //}


    }
}
