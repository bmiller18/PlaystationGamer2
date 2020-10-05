using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PlaystationGamer2.Models
{
    public partial class Blog
    {
        public int BlogId { get; set; }
        public int? UserId { get; set; }
        public string BlogPost { get; set; }
        public DateTime BlogDate { get; set; }
        public string BlogTitle { get; set; }

        public Users User { get; set; }
    }
}
