using System;
using System.Collections.Generic;
using System.Text;

namespace SpeseECategorie.EntitiesRepository.Entities
{
    //Questa interfaccia viene ereditata dalle classi che rappresentano le tabelle
    public interface IEntity
    {
        int ID { get; set; }
    }
}
