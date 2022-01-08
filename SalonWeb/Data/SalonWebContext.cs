using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalonWeb.Models;

namespace SalonWeb.Data
{
    public class SalonWebContext : DbContext
    {
        public SalonWebContext (DbContextOptions<SalonWebContext> options)
            : base(options)
        {
        }

        public DbSet<SalonWeb.Models.Programare> Programare { get; set; }

        public DbSet<SalonWeb.Models.Frizer> Frizer { get; set; }

        public DbSet<SalonWeb.Models.Tip> Tip { get; set; }
    }
}
