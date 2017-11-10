using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSOConsoleApp
{
    public enum Genre { Medieval, Renaissance, Baroque, Classical, Soundtrack }

    public class MusicalWork
    {
        public string Title { get; set; }
        public string Composer { get; set; }
        public int Length { get; set; }
        public Genre Genre { get; set; }

        public override string ToString()
        {
            return Title + " by " + Composer + " (" + Length + " minutes), " + Genre;
        }
    }
}
