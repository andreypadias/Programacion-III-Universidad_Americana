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

        public DbSet<UnoAmuchos.Models.Empleado> Empleado { get; set; } = default!;
        public DbSet<UnoAmuchos.Models.Departamento> Departamento { get; set; } = default!;
    }
}
