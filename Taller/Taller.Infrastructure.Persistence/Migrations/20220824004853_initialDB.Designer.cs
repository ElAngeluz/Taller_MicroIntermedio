﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Taller.Infrastructure.Persistence.Contexts;

#nullable disable

namespace Taller.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220824004853_initialDB")]
    partial class initialDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Taller.Domain.Entities.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(10,5)");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Number")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("State")
                        .HasColumnType("bit");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("Taller.Domain.Entities.Client", b =>
                {
                    b.Property<Guid>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Password")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid>("PersonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("State")
                        .HasColumnType("bit");

                    b.HasKey("ClientId");

                    b.HasIndex("PersonId")
                        .IsUnique();

                    b.ToTable("cliente");
                });

            modelBuilder.Entity("Taller.Domain.Entities.Movement", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("MovementType")
                        .HasColumnType("int");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(10,5)");

                    b.Property<decimal>("ValueBalance")
                        .HasColumnType("decimal(10,5)");

                    b.HasKey("Id");

                    b.ToTable("Movement");
                });

            modelBuilder.Entity("Taller.Domain.Entities.Person", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Identification")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Phone")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<long>("YearsOld")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("person");
                });

            modelBuilder.Entity("Taller.Domain.Entities.Account", b =>
                {
                    b.HasOne("Taller.Domain.Entities.Client", "ClientNav")
                        .WithMany("AccountsNav")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClientNav");
                });

            modelBuilder.Entity("Taller.Domain.Entities.Client", b =>
                {
                    b.HasOne("Taller.Domain.Entities.Person", "PersonNav")
                        .WithOne("ClientNav")
                        .HasForeignKey("Taller.Domain.Entities.Client", "PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PersonNav");
                });

            modelBuilder.Entity("Taller.Domain.Entities.Client", b =>
                {
                    b.Navigation("AccountsNav");
                });

            modelBuilder.Entity("Taller.Domain.Entities.Person", b =>
                {
                    b.Navigation("ClientNav");
                });
#pragma warning restore 612, 618
        }
    }
}
