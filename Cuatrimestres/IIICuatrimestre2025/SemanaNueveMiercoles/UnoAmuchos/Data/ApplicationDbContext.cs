using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UnoAmuchos.Models;

namespace UnoAmuchos.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Proyecto> Proyecto { get; set; } = default!;
        public DbSet<Tarea> Tarea { get; set; } = default!;
    }
}
