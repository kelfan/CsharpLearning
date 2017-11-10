using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Research
{
    public class Researcher
    {
        // propriate for researcher's id 
        private int id;
        // propriate for researcher's given name  
        public string GivenName { get; set; }
        // propriate for researcher's family name 
        public string FamilyName { get; set; }
        // propriate for researcher's title
        public string Title { get; set; }
        // propriate for researcher's school belong to 
        public string School{ get; set; }
        // propriate for researcher's campus 
        public string Campus { get; set; }
        // propriate for researcher's email
        public string Email { get; set; }
        // propriate for researcher's photo as a url 
        public string Photo { get; set; }
        // propriate for researcher's unit  
        public string Unit { get; set; }
        // propriate for researcher's type  
        public string Type { get; set; }
        // propriate for researcher's level
        public string Level { get; set; }

        // propriate for researcher's current job start date 
        public DateTime CurrentJobStart { get; set; }
        // propriate for researcher's start date commenced with institution 
        public DateTime EarliestStart { get; set; }

        // propriate for number of studnets under researcher's supervisions
        public int Supervisions { get; set; }

        // propriate for researcher's tenure/time period of hired 
        public float Tenure { get; set; }

        // propriate for a list of researcher's previous positions 
        public List<Position> previousPositions { get; set; }

        // propriate for number of researcher's publications 
        public int PublicationsCount { get; set; }

        //Level will be transfered to Job Title
        public string CurrentJobTitle
        {                        
            get
            {
                string currentJob = "";
                switch (Level)
                {
                    case "A":
                        currentJob = "Postdoc";
                        break;
                    case "B":
                        currentJob = "Lecturer";
                        break;
                    case "C":
                        currentJob = "Senior Lecturer";
                        break;
                    case "D":
                        currentJob = "Associate Professor";
                        break;
                    case "E":
                        currentJob = "Professor";
                        break;
                    default:
                        currentJob = "No Job Title - Student";
                        break;
                }

                return currentJob;                
            }
        }

        // method to get researcher's id 
        public int getId()
        {
            return this.id;
        }

        // method to set researcher's id 
        public void setId(int ID)
        {
            this.id = ID;
        }
        // method to get researcher's current position 
        public Position GetCurrentJob()
        {
            return new Position();
        }

        // method to get researcher's earliest position 
        public Position GetEarliestJob()
        {
            return new Position();
        }

        // output the reseacher oject in the follow format 
        public override string ToString()
        {
            return FamilyName+", "+GivenName+" ("+Title+")";
        }
    }
}
