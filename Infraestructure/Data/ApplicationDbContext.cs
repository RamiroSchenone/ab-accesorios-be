using ab_accesorios_be.Infraestructure.Models;
using Microsoft.EntityFrameworkCore;

namespace ab_accesorios_be.Infraestructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Medida> Medidas { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasMany(d => d.Medidas).WithOne(x => x.Producto).HasForeignKey(x => x.ProductoId).OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Marca>(entity =>
            {
                entity.HasKey(e => e.Id);
            });

            modelBuilder.Entity<Medida>(entity =>
            {
                entity.HasKey(e => e.Id);
            });
        }
    }
}
