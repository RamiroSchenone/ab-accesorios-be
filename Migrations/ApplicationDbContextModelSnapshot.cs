﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ab_accesorios_be.Infraestructure.Data;

#nullable disable

namespace ab_accesorios_be.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ab_accesorios_be.Infraestructure.Models.Entities.Marca", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("FechaCreacion")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Marcas");
                });

            modelBuilder.Entity("ab_accesorios_be.Infraestructure.Models.Entities.Medida", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<int>("Alto")
                        .HasColumnType("int");

                    b.Property<int>("Ancho")
                        .HasColumnType("int");

                    b.Property<DateTime?>("FechaCreacion")
                        .HasColumnType("datetime(6)");

                    b.Property<long>("ProductoId")
                        .HasColumnType("bigint");

                    b.Property<int>("Profundidad")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductoId")
                        .IsUnique();

                    b.ToTable("Medidas");
                });

            modelBuilder.Entity("ab_accesorios_be.Infraestructure.Models.Entities.MenuItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("FechaCreacion")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("RedirectTo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("ab_accesorios_be.Infraestructure.Models.Entities.Producto", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("Disponible")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("FechaCreacion")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<long>("MarcaId")
                        .HasColumnType("bigint");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<float>("Precio")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("MarcaId");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("ab_accesorios_be.Infraestructure.Models.Entities.Usuario", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("FechaCreacion")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("ab_accesorios_be.Infraestructure.Models.Entities.UsuarioDomicilio", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long?>("CodigoPostal")
                        .IsRequired()
                        .HasColumnType("bigint");

                    b.Property<string>("DireccionCalle")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("DireccionNumero")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("FechaCreacion")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("LocalidadGeoRefDescripcion")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<long>("LocalidadGeoRefId")
                        .HasColumnType("bigint");

                    b.Property<string>("ProvinciaGeoRefDescripcion")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<long>("ProvinciaGeoRefId")
                        .HasColumnType("bigint");

                    b.Property<long>("UsuarioId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId")
                        .IsUnique();

                    b.ToTable("UsuariosDomicilio");
                });

            modelBuilder.Entity("ab_accesorios_be.Infraestructure.Models.Entities.Medida", b =>
                {
                    b.HasOne("ab_accesorios_be.Infraestructure.Models.Entities.Producto", "Producto")
                        .WithOne("Medidas")
                        .HasForeignKey("ab_accesorios_be.Infraestructure.Models.Entities.Medida", "ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("ab_accesorios_be.Infraestructure.Models.Entities.Producto", b =>
                {
                    b.HasOne("ab_accesorios_be.Infraestructure.Models.Entities.Marca", "Marca")
                        .WithMany()
                        .HasForeignKey("MarcaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Marca");
                });

            modelBuilder.Entity("ab_accesorios_be.Infraestructure.Models.Entities.UsuarioDomicilio", b =>
                {
                    b.HasOne("ab_accesorios_be.Infraestructure.Models.Entities.Usuario", "Usuario")
                        .WithOne("UsuarioDomicilio")
                        .HasForeignKey("ab_accesorios_be.Infraestructure.Models.Entities.UsuarioDomicilio", "UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("ab_accesorios_be.Infraestructure.Models.Entities.Producto", b =>
                {
                    b.Navigation("Medidas");
                });

            modelBuilder.Entity("ab_accesorios_be.Infraestructure.Models.Entities.Usuario", b =>
                {
                    b.Navigation("UsuarioDomicilio")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
