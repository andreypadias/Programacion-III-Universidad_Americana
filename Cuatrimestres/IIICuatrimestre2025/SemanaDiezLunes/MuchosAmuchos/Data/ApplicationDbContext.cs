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

        public DbSet<MuchosAmuchos.Models.Cliente> Cliente { get; set; } = default!;
        public DbSet<MuchosAmuchos.Models.Producto> Producto { get; set; } = default!;
        public DbSet<MuchosAmuchos.Models.Factura> Factura { get; set; } = default!;
        public DbSet<MuchosAmuchos.Models.ProductosFactura> ProductosFactura { get; set; } = default!;
    }
}
