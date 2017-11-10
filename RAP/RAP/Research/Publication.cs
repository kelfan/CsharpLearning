using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Research
{
    public enum OutputType { Conference, Journal, Other }
    public class Publication
    {
        // propriate for publication's DOI
        public string DOI { get; set; }
        // propriate for publication's title
        public string Title { get; set; }
        // propriate for publication's authors
        public string Authors { get; set; }
        // propriate for publication's established year
        public int Year { get; set; }
        // propriate for publication's type
        public OutputType Type { get; set; }
        // propriate for publication's cite formats
        public string CiteAs { get; set; }
        // propriate for publication's publicating date
        public DateTime Available { get; set; }

        // propriate for publication's age from the established date to now 
        public int Age 
        {            
            get
            {
                //acquire the time of now
                DateTime localDate = DateTime.Now;
                // returne the difference between now and publication date 
                return ((localDate.Year - Available.Year) * 12) + localDate.Month - Available.Month;                               
            }
            
        }

        // display the publication object in the follow format 
        public override string ToString()
        {
            return DOI + "\t" + Authors + "\t" + Title;
        }
    }
}
