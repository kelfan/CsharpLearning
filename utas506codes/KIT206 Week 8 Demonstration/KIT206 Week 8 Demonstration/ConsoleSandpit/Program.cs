using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSandpit
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person() { Name = "Anne", DOB = new DateTime(1980, 09, 07), Weight = 62 };

            Console.WriteLine("Test person: " + p);
        }
    }
}
