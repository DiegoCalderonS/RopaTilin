using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RopaTilin.Modelos;
using System.Reflection;

namespace RopaTilin.AccesoDatos
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public DbSet<Bodega> Bodegas { get; set; }
        public DbSet<Bodega> Categorias { get; set; }
        public DbSet<Bodega> Marca { get; set; }
        public DbSet<Producto> Productos { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
