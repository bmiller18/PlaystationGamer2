using System;
using System.Collections.Generic;

namespace PlaystationGamer2.Models
{
    public partial class Controllers
    {
        public int ControllerId { get; set; }
        public int? ConsoleId { get; set; }
        public string ControllerName { get; set; }
        public int YearReleased { get; set; }
        public string Price { get; set; }

        public Console Console { get; set; }
    }
}
