using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIT206_Week8
{
    public delegate Employee ManageWorker(int id);

    class Program
    {
        static void Main(string[] args)
        {
            Action doSomething;
            Boss boss = new Boss();

            //The use of a delegate here is not necessary, but a remnant of the Week 7 tutorial
            doSomething = boss.Display;
            doSomething();

            //For testing optional implementation of step 2.3.4:
            /*
            int start = 2014, end = 2015;
            foreach (Employee e in boss.Workers) {
                Console.WriteLine("Employee {0} has attended {1} training sessions during {2}-{3}",
                    e.Name, Agency.EmployeeTrainingCount(e, start, end), start, end);
            }
            */
        }

    }
}
