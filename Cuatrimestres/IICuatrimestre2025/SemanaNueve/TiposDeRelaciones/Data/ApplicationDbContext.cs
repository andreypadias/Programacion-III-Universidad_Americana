using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TiposDeRelaciones.Models;

namespace TiposDeRelaciones.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<TiposDeRelaciones.Models.Persona> Persona { get; set; } = default!;
        public DbSet<TiposDeRelaciones.Models.Pasaporte> Pasaporte { get; set; } = default!;
    }
}
