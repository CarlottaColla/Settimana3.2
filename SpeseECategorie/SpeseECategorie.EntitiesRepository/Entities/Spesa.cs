using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SpeseECategorie.EntitiesRepository.Entities
{
    public class Spesa : IEntity
    {
        //Rispetta la nomenclatura standard, non serve l'annotation [Key] per indicare che è PK
        //Viene impostata autoincremantale in automatico
        public int ID { get; set; }
        public DateTime Data { get; set; }
        public int CategoriaID { get; set; } //FK rispetta la convenzione
        //Aggiungo la Navigation Properties:
        //1 a molti: Una spesa può avere una sola categoria, una categoria può avere più spese
        public Categorie Categoria { get; set; }
        [MaxLength(500)] //Annotation per impostare la lunghezza massima
        public string Descrizione { get; set; }
        [MaxLength(100)]
        public string Utente { get; set; }
        public decimal Importo { get; set; }
        public bool Approvato { get; set; }

        //Metodo ToString() per stampare correttamente l'oggetto
        public override string ToString()
        {
            return $"{ID} : {Descrizione} categoria = {CategoriaID} in data {Data.ToShortDateString()} " +
                $"\neffettuata dall'utente {Utente} di euro {Importo} approvata = {Approvato}";
        }


    }
}
