using ab_accesorios_be.Infraestructure.Models.Entities;
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

                entity.Property(e => e.MarcaId).IsRequired();
                entity.Property(e => e.Nombre).IsRequired();
                entity.Property(e => e.Descripcion).IsRequired();
                entity.Property(e => e.Precio).IsRequired();
                entity.Property(e => e.Disponible).IsRequired();
                entity.Property(e => e.ImageURL).IsRequired();

                entity.HasMany(d => d.Medidas).WithOne(x => x.Producto).HasForeignKey(x => x.ProductoId).OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Marca>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Nombre).IsRequired();
            });

            modelBuilder.Entity<Medida>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Alto).IsRequired();
                entity.Property(e => e.Ancho).IsRequired();
                entity.Property(e => e.Profudidad).IsRequired();
                entity.Property(e => e.ProductoId).IsRequired();
            });
        }
    }
}
