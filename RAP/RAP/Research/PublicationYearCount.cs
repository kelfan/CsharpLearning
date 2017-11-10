using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Research
{
    public class PublicationYearCount
    {
        // propriate for publication's year
        public int year { get; set; }
        // propriate for publication's count number of each year
        public int count { get; set; }

        // propriate for height of barchart to display the count of each year
        public float height {
            get
            {
                return (float) Convert.ToDouble(count * 1.5);
            }
        }
    }
}
