using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProyectoEjemplo.Models;

namespace ProyectoEjemplo.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<ProyectoEjemplo.Models.Factura> Factura { get; set; } = default!;
        public DbSet<ProyectoEjemplo.Models.Producto> Producto { get; set; } = default!;
        public DbSet<ProyectoEjemplo.Models.FacturaProducto> FacturaProducto { get; set; } = default!;


    }
}
