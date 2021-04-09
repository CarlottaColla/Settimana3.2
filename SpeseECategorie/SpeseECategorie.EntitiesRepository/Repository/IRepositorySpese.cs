using SpeseECategorie.EntitiesRepository.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeseECategorie.EntitiesRepository.Repository
{
    public interface IRepositorySpese : IRepository<Spesa>
    {
        //Aggiungo i metodi per le spese
        List<Spesa> GetSpeseApprovate();
        List<Spesa> GetSpeseUtente(string utente);
        void SpesePerCategoria();
        List<Spesa> MostraSpese();
        Spesa GetSpesa(int id);
    }
}
