using SpeseECategorie.EntitiesRepository.Entities;
using SpeseECategorie.EntitiesRepository.Repository;
using SpeseECategorie.RepositoryEF.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpeseECategorie.RepositoryEF.Repository
{
    public class RepositoryCategorie : IRepositoryCategorie
    {
        public bool Create(Categorie item)
        {
            using ( var context = new GestioneSpeseContext())
            {
                //Se non sono presenti categorie allora ne inserisco 3
                var categorie = context.Categorie;
                var count = context.Categorie.Count(x => x.ID > 0);
                if(count == 0)
                {
                    context.Categorie.Add(item);
                    context.Categorie.Add(new Categorie { Categoria = "Cibo" });
                    context.Categorie.Add(new Categorie { Categoria = "Varie" });
                }
                context.SaveChanges();
                return true;
            }
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Categorie item)
        {
            throw new NotImplementedException();
        }

        public List<Categorie> MostraCategorie()
        {
            using (var context = new GestioneSpeseContext())
            {
                var categorie = context.Categorie.ToList();
                return categorie;
            }
        }
    }
}
