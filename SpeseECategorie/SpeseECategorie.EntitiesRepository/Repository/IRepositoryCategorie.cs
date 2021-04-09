using SpeseECategorie.EntitiesRepository.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeseECategorie.EntitiesRepository.Repository
{
    public interface IRepositoryCategorie : IRepository<Categorie>
    {
        List<Categorie> MostraCategorie();
    }
}
