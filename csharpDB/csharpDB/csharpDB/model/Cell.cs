using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharpDB.model
{
    class Cell
    {
        public string title { get; set; }
        public string content { get; set; }
        public DateTime created { get; set; }
        public DateTime updated { get; set; }
        public string level { get; set; }
    }
}
