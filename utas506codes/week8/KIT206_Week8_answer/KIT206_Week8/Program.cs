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
            ManageWorker manage;
            Boss boss = new Boss();

            doSomething = boss.Display;
            manage = boss.Use;

            doSomething();
            Console.WriteLine("Dealing with {0}", manage(1));
            Console.WriteLine("After dealing with that employee");
            doSomething();
        }

/*
        From an early part of the tutorial:
  
        static void Main(string[] args)
        {
            Boss boss = new Boss();

            boss.Display();
            Console.WriteLine("Dealing with {0}", boss.Use(1));
            Console.WriteLine("After dealing with that employee");
            boss.Display();
        }
*/
    }
}
