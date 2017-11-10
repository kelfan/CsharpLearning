using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Entity
{
    public class Person
    {
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public double Weight { get; set; }
        public int Age
        {
            get
            {
                var today = DateTime.Today;
                var age = today.Year - DOB.Year;
                age = DOB.AddYears(age) > today ? age - 1 : age;
                return age;
            }
        }

        public override string ToString()
        {
            return string.Format("{0} ({1}), born {2}, weighs {3} kg", Name, Age, DOB, Weight);
        }
    }
}
