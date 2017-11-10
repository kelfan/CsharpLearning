using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Research
{
    public class Position
    {
        // propriate for position level 
        public string level { get; set; }
        // propriate for position start date 
        public DateTime start { get; set; }
        // propriate for position end date 
        public DateTime end { get; set; }

        // propriate for position title
        public string Title {
            get
            {
                //acquire position's title based on position level
                return this.ToTitle(level);
            }   
        }

        //acquire position's title based on position level
        public string ToTitle(String l)
        {
            
                string JobTitle = "";
                switch (l)
                {
                    case "A":
                        JobTitle = "Postdoc";
                        break;
                    case "B":
                        JobTitle = "Lecturer";
                        break;
                    case "C":
                        JobTitle = "Senior Lecturer";
                        break;
                    case "D":
                        JobTitle = "Associate Professor";
                        break;
                    case "E":
                        JobTitle = "Professor";
                        break;
                    default:
                        JobTitle = "No Job Title - Student";
                        break;
                }

                return JobTitle;
         }

        // display the position object in the follow format 
        public override string ToString()
        {
            // if the position is current position will display in first format 
            if (end.Year == 1)
            {
                return "Level: " + level + ", start: " + start.ToString("MM/dd/yyyy") + ", up till now.";
            }
            else
            {
                return "Level: " + level + ", start: " + start.ToString("MM/dd/yyyy") + ", end: " + end.ToString("MM/dd/yyyy");
            }
        }

    }
}
