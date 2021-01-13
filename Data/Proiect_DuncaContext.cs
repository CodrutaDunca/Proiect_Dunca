using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proiect_Dunca.Models;

namespace Proiect_Dunca.Data
{
    public class Proiect_DuncaContext : DbContext
    {
        public Proiect_DuncaContext (DbContextOptions<Proiect_DuncaContext> options)
            : base(options)
        {
        }

        public DbSet<Proiect_Dunca.Models.Clothe> Clothe { get; set; }

        public DbSet<Proiect_Dunca.Models.Designer> Designer { get; set; }

        public DbSet<Proiect_Dunca.Models.Category> Category { get; set; }
    }
}
