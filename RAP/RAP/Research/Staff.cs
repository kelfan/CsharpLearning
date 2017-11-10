using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Research
{
    //the enum to store the possible employment levels 
    public enum EmploymentLevel { All, Student, A, B, C, D, E };
    public class Staff : Researcher
    {
        // properity of average of reseacher's publication in the last three years 
        public float ThreeYearAverage { get; set; }
        // properity of performance of researhcer 
        public float Performance { get; set; }
    }
}
