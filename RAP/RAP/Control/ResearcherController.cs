using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RAP.Research;
using RAP.Database;

namespace RAP.Control
{
    class ResearcherController
    {
        // return the researcher list
        public static List<Researcher> LoadResearchers()
        {
            List<Researcher>  researcherList = ERDAdapter.fetchBasicResearcherDetails();
            return researcherList;
        }

        // filter the list by researche level. if the researcher type is 'Student', the leve is 'Student'
        public static List<Researcher> FilterBy(EmploymentLevel level)
        {
            List<Researcher> researcherList = ERDAdapter.fetchBasicResearcherDetails();

            if (level == EmploymentLevel.All)
            {
                return researcherList;
            }
            else
            {
                var selected = from Researcher r in researcherList
                               where level.ToString().Equals(r.Level)
                               select r;

                return new List<Researcher>(selected);
            }
        }

        // filter by the researcher name
        public static List<Researcher> FilterByName(string name)
        {
            List<Researcher> researcherList = ERDAdapter.fetchBasicResearcherDetails();
            var selected = from Researcher r in researcherList
                           where r.FamilyName.ToLower().Contains(name.ToLower()) || r.GivenName.ToLower().Contains(name)
                           select r;
            return new List<Researcher>(selected);
        }

        // get the details of the researcher
        public static Researcher LoadResearcherDetails(Researcher r)
        {
            Researcher newr = ERDAdapter.fetchFullResearcherDetails(r.getId());


            newr.previousPositions = ERDAdapter.fetchPreviousPositions(r);

            return newr;
        }

        // return the student list in which the students' supervisor is the rearcher
        public static List<Student> LoadSupervisionStudents(Researcher r)
        {
            List<Student> studentList = ERDAdapter.fetchSupervisionStudents(r);
            return studentList;
        }
    }
}
