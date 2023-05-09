using ab_accesorios_be.Infraestructure.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ab_accesorios_be.Infraestructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<MedidasProducto> Medidas { get; set; }
        public DbSet<MenuItem> Menus { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<UsuarioDomicilio> UsuariosDomicilio { get; set; }
        public DbSet<Archivo> Archivos { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("ab_Productos");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.MarcaId).IsRequired();
                entity.Property(e => e.Nombre).IsRequired();
                entity.Property(e => e.Descripcion).IsRequired();
                entity.Property(e => e.Precio).IsRequired();
                entity.Property(e => e.Disponible).IsRequired();
                entity.Property(e => e.ImageURL).IsRequired();

                entity.HasOne(p => p.Medidas).WithOne(m => m.Producto).HasForeignKey<MedidasProducto>(m => m.ProductoId).OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(d => d.Marca).WithMany().HasForeignKey(d => d.MarcaId).OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Marca>(entity =>
            {
                entity.ToTable("ab_Marcas");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Nombre).IsRequired();
            });

            modelBuilder.Entity<MedidasProducto>(entity =>
            {
                entity.ToTable("ab_MedidasProducto");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Alto).IsRequired();
                entity.Property(e => e.Ancho).IsRequired();
                entity.Property(e => e.Profundidad).IsRequired();
                entity.Property(e => e.ProductoId).IsRequired();
            });

            modelBuilder.Entity<MenuItem>(entity =>
            {
                entity.ToTable("ab_MenuItems");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Nombre).IsRequired();
                entity.Property(e => e.Label).IsRequired();
                entity.Property(e => e.RedirectTo).IsRequired();
                entity.Property(e => e.Icon).IsRequired();
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("ab_Usuarios");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Nombre).IsRequired();
                entity.Property(e => e.Apellido).IsRequired();
                entity.Property(e => e.Username).IsRequired();
                entity.Property(e => e.Telefono).IsRequired();
                entity.Property(e => e.Email).IsRequired();

                entity.HasOne(p => p.UsuarioDomicilio).WithOne(m => m.Usuario).HasForeignKey<UsuarioDomicilio>(m => m.UsuarioId).OnDelete(DeleteBehavior.Cascade);
            });


            modelBuilder.Entity<UsuarioDomicilio>(entity =>
            {
                entity.ToTable("ab_UsuariosDomicilio");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.ProvinciaGeoRefId).IsRequired();
                entity.Property(e => e.LocalidadGeoRefId).IsRequired();
                entity.Property(e => e.DireccionCalle).IsRequired();
                entity.Property(e => e.DireccionNumero).IsRequired();
                entity.Property(e => e.CodigoPostal).IsRequired();
            });

            modelBuilder.Entity<Archivo>(entity =>
            {
                entity.ToTable("ab_Archivos");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.FilePath).IsRequired();
                entity.Property(e => e.FileName).IsRequired();
                entity.Property(e => e.Size).IsRequired();
                entity.Property(e => e.DownloadName).IsRequired();
                entity.Property(e => e.ContentType).IsRequired();
            });
        }
    }
}
