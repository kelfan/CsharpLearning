using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using csharpDB.model;

namespace csharpDB.control
{
    class ListHandler
    {
        public List<Cell> cellsHanlder { get; set; } 

        public static List<Cell> addCell(string title, string content, List<Cell> cells)
        {
            return cells;
        }

        public static List<Cell> sortCells(List<Cell> cells)
        {
            var result = from Cell c in cells
                         orderby c.title ascending
                         select c;
            return new List<Cell>(result);
        }

    }
}
