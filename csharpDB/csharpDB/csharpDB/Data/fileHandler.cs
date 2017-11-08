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
    class fileHandler
    {
        public static List<Cell> loadJson(string filename)
        {
            try
            {
                using (StreamReader r = new StreamReader(filename))
                {
                    string json = r.ReadToEnd();
                    List<Cell> cells = JsonConvert.DeserializeObject<List<Cell>>(json);
                    return cells;
                }
            }
            catch (JsonReaderException e)
            {
                System.Windows.MessageBox.Show("file is not found or not correct json format");
            }
            return new List<Cell>();
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

        public static void saveJson(string filename, List<Cell> cells)
        {
            string json = JsonConvert.SerializeObject(cells.ToArray(), Formatting.Indented);
            System.IO.File.WriteAllText(filename, json);
        }
    }
}
