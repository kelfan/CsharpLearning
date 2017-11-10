using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RAP.Research;
using RAP.Database;

namespace RAP.Control
{
    class PublicationsController
    {
        // retrieve publication information of the researcher
        public static List<Publication> loadPublicationsFor(Researcher r)
        {
            return ERDAdapter.fetchBasicPublicationDetails(r);
        }

        // invert the publication list data according to the 'Year', order flag is the sequence flag
        public static List<Publication> invert(List<Publication> ps, string orderFlag)
        {
            if (orderFlag == "asc")
            {
                var selected = from Publication p in ps
                               orderby p.Year ascending
                               select p;
                return new List<Publication>(selected);
            }
            else
            {
                var selected = from Publication p in ps
                               orderby p.Year descending
                               select p;
                return new List<Publication>(selected);
            }            
        }

        // Search by year range
        public static List<Publication> search(List<Publication> ps, int fromYear, int toYear)
        {
            var selected = from Publication p in ps
                           where (p.Year >= fromYear && p.Year <= toYear )
                           select p;            

            return new List<Publication>(selected);            
        }

        //get the year ranges of the rearsearcher's publications
        public static List<int> fetchPublicationYearList(Researcher r)
        {
            return ERDAdapter.fetchPublicationYearList(r);
        }

        //get the statistic information of the publication count group by year
        public static List<PublicationYearCount> genPublicationYearData(Researcher r)
        {
            return ERDAdapter.genPublicationYearData(r);
            
        }

        
    }
}
