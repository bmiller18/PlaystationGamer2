using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlaystationGamer2.Models
{
    public class SecurityContext : IdentityDbContext
    {
        public SecurityContext()
        {

        }

        public SecurityContext(DbContextOptions<SecurityContext> options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost\\sqlexpress;Database=PlaystationGamer;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }
    }
}
