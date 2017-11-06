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
        List<Cell> cells = new List<Cell>();
        Cell c = new Cell()
        {
            title = "hello",
            content = "hhhhhhhhhhhhhh"
        };
        public List<Cell> getData()
        {
            cells.Add(c);
            return cells;
        }
    }
}
