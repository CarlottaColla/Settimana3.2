﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SpeseECategorie.RepositoryEF.Context;

namespace SpeseECategorie.RepositoryEF.Migrations
{
    [DbContext(typeof(GestioneSpeseContext))]
    partial class GestioneSpeseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SpeseECategorie.EntitiesRepository.Entities.Categorie", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Categoria")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ID");

                    b.ToTable("Categorie");
                });

            modelBuilder.Entity("SpeseECategorie.EntitiesRepository.Entities.Spesa", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Approvato")
                        .HasColumnType("bit");

                    b.Property<int>("CategoriaID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descrizione")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<decimal>("Importo")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Utente")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ID");

                    b.HasIndex("CategoriaID");

                    b.ToTable("Spese");
                });

            modelBuilder.Entity("SpeseECategorie.EntitiesRepository.Entities.Spesa", b =>
                {
                    b.HasOne("SpeseECategorie.EntitiesRepository.Entities.Categorie", "Categoria")
                        .WithMany("Spese")
                        .HasForeignKey("CategoriaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("SpeseECategorie.EntitiesRepository.Entities.Categorie", b =>
                {
                    b.Navigation("Spese");
                });
#pragma warning restore 612, 618
        }
    }
}