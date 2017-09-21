using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIT206_Week8
{

    //As an example, this includes an additional 'gender' called Any that could be used in a GUI drop-down list.
    //The filtering could then be modified that if Gender.Any is selected that the full list is returned with no filtering performed.
    public enum Gender { Any, M, F, X };

    /// <summary>
    /// A class baring a striking resemblance to a university researcher
    /// </summary>
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public List<TrainingSession> Skills { get; set; }

        //Step 2.3.4 in Week 8 tutorial
        public int RecentTraining()
        {
            if (Skills != null)
            {
                int endYear = DateTime.Today.Year;
                int startYear = endYear - 1; //window is up to 2 years in length
                var allRecent = from TrainingSession skill in Skills
                                where skill.Year >= startYear && skill.Year <= endYear
                                select skill;
                return allRecent.Count();
                
                //which could be rewritten as a single expression:
                //return (from TrainingSession skill in Skills
                //        where skill.Year >= startYear && skill.Year <= endYear
                //        select skill).Count();
            }
            return 0;
        }

        public override string ToString()
        {
            //As part of step 2.3.2 and 2.3.4 in Week 8 tutorial, have modified this to display the work times and if the employee is currently busy
            return String.Format("{0}\t{1}\tSkills: {2}\tRecent training sessions: {3}", ID, Name, String.Join(", ", Skills), RecentTraining() );
            //previous version: return Name + '\t' + ID + '\t' + Gender;
        }
    }
}
