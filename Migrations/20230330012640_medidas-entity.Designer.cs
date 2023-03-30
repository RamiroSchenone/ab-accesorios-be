﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ab_accesorios_be.Infraestructure.Data;

#nullable disable

namespace ab_accesorios_be.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230330012640_medidas-entity")]
    partial class medidasentity
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<long>("ProductoId")
                        .HasColumnType("bigint");

                    b.Property<int>("Profudidad")
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

                    b.Property<DateTime>("FechaCreacion")
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

            modelBuilder.Entity("ab_accesorios_be.Infraestructure.Models.Entities.Producto", b =>
                {
                    b.Navigation("Medidas");
                });
#pragma warning restore 612, 618
        }
    }
}
