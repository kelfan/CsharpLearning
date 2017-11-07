using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using csharpDB.model;

namespace csharpDB.Data
{
    class FreData
    {
        public static string filefolder = "C:/Users/chaofanz/Desktop/CsharpLearning/csharpDB/csharpDB/csharpDB/Data";
                
        static public List<Cell> getData()
        {
            List<Cell> cells = new List<Cell>();
            string mainfile = filefolder + "\\app.json";
            cells = readfile.loadJson(mainfile);
            return cells;
        }
    }
}
