using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SpeseECategorie.EntitiesRepository.Entities
{
    public class Categorie : IEntity
    {
        //PK autoincrementale
        public int ID { get; set; }
        [MaxLength(100)] //Annotation per stabilire la lunghezza massima
        public string Categoria { get; set; }
        //Navigation Properties:
        //1 a molti: Una spesa può avere una sola categoria, una categoria può avere più spese
        public ICollection<Spesa> Spese { get; set; } = new List<Spesa>();

        //ToString
        public override string ToString()
        {
            return $"{ID} - {Categoria}";
        }

    }
}
