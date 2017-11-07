using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using csharpDB.model;
using Newtonsoft.Json;

namespace csharpDB.Data
{
    class readfile
    {
        public static List<Cell> loadJson(string filename)
        {
            using (StreamReader r = new StreamReader(filename))
            {
                string json = r.ReadToEnd();
                List<Cell> cells = JsonConvert.DeserializeObject<List<Cell>>(json);
                return cells;
            }
        }

        public static List<Cell> dynamicLoadJson(string filename)
        {
            List<Cell> cells = new List<Cell>();
            using (StreamReader r = new StreamReader(filename))
            {
                string json = r.ReadToEnd();
                dynamic array = JsonConvert.DeserializeObject(json);
                foreach (var item in array)
                {
                    Cell c = new Cell();
                    c.title = item.title;
                    c.content = item.content;
                    cells.Add(c);
                }
            }
            return cells;
        }
    }
}
