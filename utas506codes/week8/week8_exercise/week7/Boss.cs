using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week7
{
    class Boss
    {
        List<Employee> staff;
        public Boss()
        {
            staff = Agency.Generate();
        }

        public void Display()
        {
            //foreach (Employee e in staff)
            //{
            //    Console.WriteLine(e);
            //}
            staff.ForEach(Console.WriteLine);
        }

        public Employee Use(int id)
        {
            foreach (Employee e in staff)
            {
                if (e.ID == id)
                {
                    return e;
                }
            }
            return null;
        }

        public Employee Fire(int id)
        {
            Employee target = Use(id);
            if (target != null)
            {
                staff.Remove(target);
            }
            return target;
        }
    }
}
