using Microsoft.EntityFrameworkCore;
using SpeseECategorie.EntitiesRepository.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeseECategorie.RepositoryEF.Context
{
    class GestioneSpeseContext : DbContext
    {
        //Costruttore vuoto
        public GestioneSpeseContext() : base () { }
        //Costruttore con un parametro
        public GestioneSpeseContext(DbContextOptions<GestioneSpeseContext> options) : base(options) { }

        //Stringa di connessione
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(@"Persist Security Info = False; Integrated Security = true; Initial Catalog = GestioneSpese; Server = .\SQLEXPRESS");
        }

        //Creazione delle tabelle con DbSet
        public DbSet<Spesa> Spese { get; set; }
        public DbSet<Categorie> Categorie { get; set; }

        //Uso le Fluent Api per creare le relazioni tra tabelle
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Spesa>()
                .HasOne(c => c.Categoria) //Spesa ha una sola categoria
                .WithMany(s => s.Spese); //Una categoria ha più spese
                //La chiave esterna non è necessaria perchè si rispetta la convenzione
        }
    }
}
