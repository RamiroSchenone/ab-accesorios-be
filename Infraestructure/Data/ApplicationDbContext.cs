using ab_accesorios_be.Infraestructure.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ab_accesorios_be.Infraestructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Medida> Medidas { get; set; }
        public DbSet<MenuItem> Menus { get; set; }


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

                entity.HasOne(p => p.Medidas).WithOne(m => m.Producto).HasForeignKey<Medida>(m => m.ProductoId).OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(d => d.Marca).WithMany().HasForeignKey(d => d.MarcaId).OnDelete(DeleteBehavior.Cascade);
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
                entity.Property(e => e.Profundidad).IsRequired();
                entity.Property(e => e.ProductoId).IsRequired();
            });

            modelBuilder.Entity<MenuItem>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Nombre).IsRequired();
                entity.Property(e => e.Label).IsRequired();
                entity.Property(e => e.RedirectTo).IsRequired();
                entity.Property(e => e.Icon).IsRequired();
            });
        }
    }
}
