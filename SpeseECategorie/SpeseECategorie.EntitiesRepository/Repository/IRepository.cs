using SpeseECategorie.EntitiesRepository.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeseECategorie.EntitiesRepository.Repository
{
    public interface IRepository<T> where T : IEntity
    {
        //Inserisco le operazioni crud comuni
        bool Create(T item);
        bool Update(T item);
        bool Delete(int id);
    }
}
