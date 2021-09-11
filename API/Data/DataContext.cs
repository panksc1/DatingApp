using API.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
            //options are added to this constructor when we add the 
            //dbcontext to the startup class
        }

        public DbSet<AppUser> Users { get; set; }
    }
}
