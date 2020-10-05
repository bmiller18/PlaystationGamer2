using System;
using System.Collections.Generic;

namespace PlaystationGamer2.Models
{
    public partial class Users
    {
        public Users()
        {
            Blog = new HashSet<Blog>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string UserAccountId { get; set; }
        public string PhotoPath { get; set; }

        public ICollection<Blog> Blog { get; set; }
    }
}
