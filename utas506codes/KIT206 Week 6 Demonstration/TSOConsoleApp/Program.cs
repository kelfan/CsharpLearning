using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSOConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
			//Early part of the demonstration
//            MusicalWork piece = new MusicalWork { Composer = "Mozart", Title = "Eine kleine Nachtmusik", Length = 30, Genre = Genre.Classical };
//            Console.WriteLine("Testing MusicalWork: " + piece);

            //Using object and list initialisers is a quick (meaning, little code) way to create them, either
            // for an ad hoc test case like this or when filling their properties with values obtained from
            // a database or similar.
            Concert gig = new Concert
            {
                start = new DateTime(2016, 8, 24, 20, 0, 0),
                HasIntermission = true,
                works = new List<MusicalWork>
                {
                    new MusicalWork { Composer = "Mozart", Title = "Eine kleine Nachtmusik", Length = 30, Genre = Genre.Classical },
                    new MusicalWork { Composer = "Holst", Title = "The Planets", Length = 45, Genre = Genre.Classical },
                    new MusicalWork { Composer = "Giacchino", Title = "Enterprising Young Men", Length = 3, Genre = Genre.Soundtrack }
                }
            };

            Console.WriteLine(gig);
        }
    }
}
