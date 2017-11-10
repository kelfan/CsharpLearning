﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIT206_Week9
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

        public int SkillCount
        {
            get { return Skills == null ? 0 : Skills.Count(); }
        }

        //The SkillCount out of 10, expressed as a percentage
        public double SkillPercent
        {
            //This is equivalent to SkillCount / 10.0 * 100
            get { return SkillCount * 10.0; }
        }

        //This is likely the solution you will have devised
        public DateTime MostRecentTraining
        {
            get
            {
                var skillDates = from TrainingSession s in Skills
                                 orderby s.Certified descending
                                 select s.Certified;
                return skillDates.First();
            }
        }

        //This is a more robust implementation, but requires the the return type be made 'nullable'
//        public DateTime? MostRecentTraining
//        {
//            get
//            {
//                if (SkillCount > 0)
//                {
//                    var skillDates = from TrainingSession s in Skills
//                                     orderby s.Certified descending
//                                     select s.Certified;
//                    return skillDates.First();
//                }
//                return null;
//            }
//        }

        public override string ToString()
        {
            //For the purposes of this week's demonstration this returns only the name
            return Name;
        }
    }
}
