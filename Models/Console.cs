using System;
using System.Collections.Generic;

namespace PlaystationGamer2.Models
{
    public partial class Console
    {
        public Console()
        {
            Controllers = new HashSet<Controllers>();
        }

        public int ConsoleId { get; set; }
        public string ConsoleName { get; set; }
        public int YearReleased { get; set; }
        public string UnitsSold { get; set; }
        public string Price { get; set; }

        public ICollection<Controllers> Controllers { get; set; }
    }
}
