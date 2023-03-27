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
    [Migration("20230327034416_v1.0.0")]
    partial class v100
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ab_accesorios_be.Infraestructure.Models.Marca", b =>
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

            modelBuilder.Entity("ab_accesorios_be.Infraestructure.Models.Medida", b =>
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

                    b.HasIndex("ProductoId");

                    b.ToTable("Medidas");
                });

            modelBuilder.Entity("ab_accesorios_be.Infraestructure.Models.Producto", b =>
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

            modelBuilder.Entity("ab_accesorios_be.Infraestructure.Models.Medida", b =>
                {
                    b.HasOne("ab_accesorios_be.Infraestructure.Models.Producto", null)
                        .WithMany("Medidas")
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ab_accesorios_be.Infraestructure.Models.Producto", b =>
                {
                    b.HasOne("ab_accesorios_be.Infraestructure.Models.Marca", "Marca")
                        .WithMany()
                        .HasForeignKey("MarcaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Marca");
                });

            modelBuilder.Entity("ab_accesorios_be.Infraestructure.Models.Producto", b =>
                {
                    b.Navigation("Medidas");
                });
#pragma warning restore 612, 618
        }
    }
}
