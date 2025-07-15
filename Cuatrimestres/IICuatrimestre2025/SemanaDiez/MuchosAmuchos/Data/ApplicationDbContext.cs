using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MuchosAmuchos.Models;

namespace MuchosAmuchos.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<MuchosAmuchos.Models.CursoEstudiante> CursoEstudiante { get; set; } = default!;
        public DbSet<MuchosAmuchos.Models.Curso> Curso { get; set; } = default!;
        public DbSet<MuchosAmuchos.Models.Estudiante> Estudiante { get; set; } = default!;
    }
}
