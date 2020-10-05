using System;
using System.Collections.Generic;

namespace PlaystationGamer2.Models
{
    public partial class Game
    {
        public int GameId { get; set; }
        public string TitleName { get; set; }
        public string Genre { get; set; }
        public int YearReleased { get; set; }
    }
}
