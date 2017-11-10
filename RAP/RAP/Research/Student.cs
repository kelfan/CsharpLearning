using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Research
{
    public class Student : Researcher
    {
        // properity of the degree of the student
        public string Degree { get; set; }

        // output the student object in the follow format 
        public override string ToString()
        {
            return this.FamilyName + ", " + GivenName + " (" + Title + ")" + ", " + Degree + " studies " + Unit + " in " + Campus;
        }
    }

    
}
