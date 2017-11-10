using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSOConsoleApp
{
    public class Concert
    {
        public DateTime start { get; set; }
        public bool HasIntermission { get; set; }
        public List<MusicalWork> works { get; set; }
        
        public int Duration(int gap)
        {
            int total = gap * (works.Count - 1); //default number of gaps between successive works
            if (HasIntermission)
            {
                total += 20 - gap; //20-minute intermission but one fewer gaps between works
            }
            
            foreach (var work in works)
            {
                total += work.Length;
            }
            return total;
        }

        public override string ToString()
        {
            //This is a reasonably fancy string representation of a concert
            return "Concert on " + start.Date.ToString("d") + " starting at " + start.TimeOfDay +
                ", comprising " + works.Count + " works. Approximately " + Duration(1) + " minutes" +
                (HasIntermission ? " including intermission" : "");
        }
    }
}
