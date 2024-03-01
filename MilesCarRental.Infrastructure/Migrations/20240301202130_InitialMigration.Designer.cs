﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MilesCarRental.Infrastructure.Persistence.Contexts;

#nullable disable

namespace MilesCarRental.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240301202130_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("MySql:ValueGeneratedOnAdd", true)
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("Sqlite:Autoincrement", true);

            modelBuilder.Entity("MilesCarRental.Domain.Entities.Ciudad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    b.Property<DateTime>("Created")
                        .HasMaxLength(30)
                        .HasColumnType("datetime(6)")
                        .HasColumnName("FechaCreacion");

                    b.Property<DateTime?>("LastModified")
                        .HasMaxLength(30)
                        .HasColumnType("datetime(6)")
                        .HasColumnName("UltimaFechaModificacion");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("Nombre");

                    b.Property<int>("PaisId")
                        .HasMaxLength(30)
                        .HasColumnType("int")
                        .HasColumnName("PaisId");

                    b.HasKey("Id");

                    b.HasIndex("PaisId");

                    b.ToTable("Ciudad", (string)null);
                });

            modelBuilder.Entity("MilesCarRental.Domain.Entities.Localidad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    b.Property<int>("CiudadId")
                        .HasMaxLength(30)
                        .HasColumnType("int")
                        .HasColumnName("CiudadId");

                    b.Property<DateTime>("Created")
                        .HasMaxLength(30)
                        .HasColumnType("datetime(6)")
                        .HasColumnName("FechaCreacion");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("Direccion");

                    b.Property<DateTime?>("LastModified")
                        .HasMaxLength(30)
                        .HasColumnType("datetime(6)")
                        .HasColumnName("UltimaFechaModificacion");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("Nombre");

                    b.HasKey("Id");

                    b.HasIndex("CiudadId");

                    b.ToTable("Localidad", (string)null);
                });

            modelBuilder.Entity("MilesCarRental.Domain.Entities.Pais", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    b.Property<DateTime>("Created")
                        .HasMaxLength(30)
                        .HasColumnType("datetime(6)")
                        .HasColumnName("FechaCreacion");

                    b.Property<DateTime?>("LastModified")
                        .HasMaxLength(30)
                        .HasColumnType("datetime(6)")
                        .HasColumnName("UltimaFechaModificacion");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("Nombre");

                    b.HasKey("Id");

                    b.ToTable("Pais", (string)null);
                });

            modelBuilder.Entity("MilesCarRental.Domain.Entities.Vehiculo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    b.Property<DateTime>("Created")
                        .HasMaxLength(30)
                        .HasColumnType("datetime(6)")
                        .HasColumnName("FechaCreacion");

                    b.Property<bool>("Disponible")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("Disponible");

                    b.Property<DateTime?>("LastModified")
                        .HasMaxLength(30)
                        .HasColumnType("datetime(6)")
                        .HasColumnName("UltimaFechaModificacion");

                    b.Property<int>("LocalidadDevolucionId")
                        .HasMaxLength(30)
                        .HasColumnType("int")
                        .HasColumnName("LocalidadDevolucionId");

                    b.Property<int>("LocalidadRecogidaId")
                        .HasMaxLength(30)
                        .HasColumnType("int")
                        .HasColumnName("LocalidadRecogidaId");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Marca");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)")
                        .HasColumnName("Placa");

                    b.HasKey("Id");

                    b.HasIndex("LocalidadDevolucionId");

                    b.HasIndex("LocalidadRecogidaId");

                    b.ToTable("Vehiculo", (string)null);
                });

            modelBuilder.Entity("MilesCarRental.Domain.Entities.Ciudad", b =>
                {
                    b.HasOne("MilesCarRental.Domain.Entities.Pais", "Pais")
                        .WithMany()
                        .HasForeignKey("PaisId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pais");
                });

            modelBuilder.Entity("MilesCarRental.Domain.Entities.Localidad", b =>
                {
                    b.HasOne("MilesCarRental.Domain.Entities.Ciudad", "Ciudad")
                        .WithMany()
                        .HasForeignKey("CiudadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ciudad");
                });

            modelBuilder.Entity("MilesCarRental.Domain.Entities.Vehiculo", b =>
                {
                    b.HasOne("MilesCarRental.Domain.Entities.Localidad", "LocalidadDevolucion")
                        .WithMany()
                        .HasForeignKey("LocalidadDevolucionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MilesCarRental.Domain.Entities.Localidad", "LocalidadRecogida")
                        .WithMany()
                        .HasForeignKey("LocalidadRecogidaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LocalidadDevolucion");

                    b.Navigation("LocalidadRecogida");
                });
#pragma warning restore 612, 618
        }
    }
}