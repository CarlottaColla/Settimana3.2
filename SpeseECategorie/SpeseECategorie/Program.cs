using SpeseECategorie.EntitiesRepository.Entities;
using SpeseECategorie.EntitiesRepository.Repository;
using SpeseECategorie.RepositoryEF.Repository;
using SpeseECategorie.Utente;
using System;

namespace SpeseECategorie
{
    class Program
    {
        static void Main(string[] args)
        {
            //Prove funzionamento

            //IRepositoryCategorie categorie = new RepositoryCategorie();
            //categorie.Create(new Categorie {Categoria = "Viaggi" });

            //IRepositorySpese spese = new RepositorySpeseEF();
            //spese.Create(new Spesa
            //{
            //    Approvato = false,
            //    CategoriaID = 1,
            //    Data = DateTime.Now,
            //    Descrizione = "Meeting a Roma",
            //    Importo = 120.99M,
            //    Utente = "Marco Rossi"
            //});

            //spese.Update(new Spesa
            //{
            //    ID = 3,
            //    Approvato = true,
            //    CategoriaID = 1,
            //    Data = DateTime.Now,
            //    Descrizione = "Meeting a Roma",
            //    Importo = 120.99M,
            //    Utente = "Marco Rossi"
            //});

            ////spese.Delete(2);

            //Console.WriteLine("Fine");

            //spese.GetSpeseApprovate();

            //spese.GetSpeseUtente("Marco Rossi");

            //spese.SpesePerCategoria();

            MenuUtente.MostraMenu();

        }
    }
}
