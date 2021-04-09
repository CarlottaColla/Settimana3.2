using Microsoft.EntityFrameworkCore;
using SpeseECategorie.EntitiesRepository.Entities;
using SpeseECategorie.EntitiesRepository.Repository;
using SpeseECategorie.RepositoryEF.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpeseECategorie.RepositoryEF.Repository
{
    public class RepositorySpeseEF : IRepositorySpese
    {
        public bool Create(Spesa item)
        {
            //Inserire nuove spese
            using(var context = new GestioneSpeseContext())
            {
                if (item == null)
                    return false;
                //Una spesa è collegata a una categoria
                //Recupero la categoria
                var categoria = context.Categorie
                    .Where(s => s.ID == item.CategoriaID) //Prendo la categoria con ID alla FK
                    .SingleOrDefault(); //è unica
                if (categoria == null)
                    return false; //Se non esiste la categoria non lo inserisco
                categoria.Spese.Add(item); //Aggiungo la spesa nella lista di spese della categoria
                context.Spese.Add(item); //Aggiungo la spesa alle spese
                context.SaveChanges(); //Aggiungo la modifica al database
                return true;
            }
        }

        public bool Delete(int id)
        {
            //Cancellare le spese esistenti
            using (var context = new GestioneSpeseContext())
            {
                //Recupero la spesa dall'id
                var spesa = context.Spese.Find(id);
                if (spesa == null)
                    return false;
                //Se esiste la cancello
                context.Spese.Remove(spesa);
                context.SaveChanges();
                return true;
            }
        }

        //Void
        public List<Spesa> GetSpeseApprovate()
        {
            //Mostrare l'elenco delle spese approvate
            using (var context = new GestioneSpeseContext())
            {
                //Prendo l'elenco delle spese approvate
                var speseApprovate = context.Spese
                    .Include(c => c.Categoria) //Prende anche la categoria
                    .Where(a => a.Approvato == true) //Solo le spese approvate
                    .ToList(); //Lo converte in una List<Spese>
                
                return speseApprovate;
            }
        }

        public List<Spesa> GetSpeseUtente(string utente)
        {
            //Elenco delle spese di un utente
            using (var context = new GestioneSpeseContext())
            {
                var speseUtente = context.Spese
                    .Where(u => u.Utente == utente) //Prendo solo le spese di quell'utente
                    .ToList();
                
                return speseUtente;
            }
        }

        public void SpesePerCategoria()
        {
            //Totale delle spese per categoria
            using (var context = new GestioneSpeseContext())
            {
                var totaleSpese = context.Spese
                    .GroupBy(
                    x => new { x.Categoria.Categoria, x.Importo },
                    (key, group) => new
                    {
                        Categoria = key.Categoria,
                        TotaleImporto = group.Sum(i => i.Importo)
                    }).ToList();
                foreach (var spese in totaleSpese)
                {
                    Console.WriteLine($"{spese.Categoria} : {spese.TotaleImporto}");
                }
                //return totaleSpese;
            }
        }

        public bool Update(Spesa item)
        {
            //approvare una spesa
            using (var context = new GestioneSpeseContext())
            {
                bool saved = false;
                //Gestisco la concorrenza
                do
                {
                    try
                    {
                        //Modifico lo stato
                        context.Entry<Spesa>(item).State = EntityState.Modified;
                        //Riporto le modifiche sul db
                        context.SaveChanges();
                        saved = true;
                    }
                    catch (DbUpdateConcurrencyException e)
                    {
                        //Rollback: riporto tutti i valori modificati al valore originale
                        foreach (var entity in e.Entries)
                        {
                            var value = entity.GetDatabaseValues();
                            entity.OriginalValues.SetValues(value);
                        }
                    }
                } while (saved == false);
                return true;
            }
        }

        public List<Spesa> MostraSpese()
        {
            using (var context = new GestioneSpeseContext())
            {
                var spese = context.Spese.ToList();
                return spese;
            }
        }

        public Spesa GetSpesa(int id)
        {
            using (var context = new GestioneSpeseContext())
            {
                return context.Spese.Where(s => s.ID == id).SingleOrDefault();
            }
        }
    }
}
