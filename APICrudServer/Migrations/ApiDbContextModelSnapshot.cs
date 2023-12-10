﻿// <auto-generated />
using APICrudServer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace APICrudServer.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    partial class ApiDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("APICrudServer.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("varchar(75)");

                    b.Property<string>("PrimerNombre")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("varchar(75)");

                    b.Property<string>("SegundoNombre")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("varchar(75)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });
#pragma warning restore 612, 618
        }
    }
}
