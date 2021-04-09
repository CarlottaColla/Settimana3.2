using SpeseECategorie.EntitiesRepository.Entities;
using SpeseECategorie.EntitiesRepository.Repository;
using SpeseECategorie.RepositoryEF.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeseECategorie.Utente
{
    public class MenuUtente
    {
        //Gestisco l'interazione con l'utente
        public static void MostraMenu()
        {
            Console.WriteLine("Benvenuto!");
            int op = 1;
            bool esci = false;
            IRepositorySpese spesaRepo = new RepositorySpeseEF();
            IRepositoryCategorie categorieRepo = new RepositoryCategorie();
            do
            {
                Console.Clear();
                Console.WriteLine("Cosa vuoi fare?\n" +
                    "1 - Inserisci una nuova spesa\n" +
                    "2 - Approva una spesa\n" +
                    "3 - Cancella una spesa\n" +
                    "4 - Mostra le spese approvate\n" +
                    "5 - Mostra le spese di un utente\n" +
                    "6 - Mostra l'importo totale per ogni categoria\n" +
                    "7 - Esci");
                bool corretto = true;
                do
                {
                    if (corretto == false || op < 1 || op > 7)
                        Console.WriteLine("Errore, riprova:");
                    corretto = Int32.TryParse(Console.ReadLine(), out op);
                } while (corretto == false || op < 1 || op > 7);

                switch (op)
                {
                    case 1:
                        //Inserisci una nuova spesa
                        Spesa spesa = new Spesa();
                        
                        List<Categorie> categorie = categorieRepo.MostraCategorie();
                        foreach (var categoria in categorie)
                        {
                            Console.WriteLine(categoria);
                        }
                        Console.WriteLine("Inserisci la categoria:");
                        bool categoriaCorretta = true;
                        int nCategoria = 1;
                        do
                        {
                            if (categoriaCorretta == false || nCategoria < 0 || nCategoria > 3)
                                Console.WriteLine("Errore, riprova:");
                            categoriaCorretta = Int32.TryParse(Console.ReadLine(), out nCategoria);
                        } while (categoriaCorretta == false || nCategoria < 0 || nCategoria > 3);
                        spesa.CategoriaID = nCategoria;
                        spesa.Data = DateTime.Now;
                        spesa.Approvato = false;
                        Console.WriteLine("Inserisci una descrizione:");
                        string descrizione = Console.ReadLine();
                        spesa.Descrizione = descrizione;
                        Console.WriteLine("Nome dell'utente:");
                        string utente = Console.ReadLine();
                        spesa.Utente = utente;
                        Console.WriteLine("Inserisci l'importo:");
                        bool importoCorretto = true;
                        decimal importo = 1;
                        do
                        {
                            if (importoCorretto == false || importo < 0)
                                Console.WriteLine("Errore, riprova:");
                            importoCorretto = Decimal.TryParse(Console.ReadLine(), out importo);
                        } while (importoCorretto == false || importo < 0);
                        spesa.Importo = importo;
                        
                        if (spesaRepo.Create(spesa))
                            Console.WriteLine("Spesa inserita correttamente");
                        else
                            Console.WriteLine("Attenzione! Spesa non inserita");
                        break;
                    case 2:
                        //Approva una spesa
                        List<Spesa> spese = spesaRepo.MostraSpese();
                        foreach (var item in spese)
                        {
                            Console.WriteLine(item);
                        }
                        Console.WriteLine("Quale spesa vuoi approvare?");
                        int nSpesa = Int32.Parse(Console.ReadLine());
                        Spesa spesaDaApprovare = spesaRepo.GetSpesa(nSpesa);
                        spesaDaApprovare.Approvato = true;
                        if (spesaRepo.Update(spesaDaApprovare))
                            Console.WriteLine("Spesa approvata con successo");
                        else
                            Console.WriteLine("Attenzione! Spesa non approvata");
                        break;
                    case 3:
                        //Cancella una spesa
                        List<Spesa> mostraSpese = spesaRepo.MostraSpese();
                        foreach (var item in mostraSpese)
                        {
                            Console.WriteLine(item);
                        }
                        Console.WriteLine("Quale spesa vuoi cancellare?");
                        int spesaDaCacellare = Int32.Parse(Console.ReadLine());
                        if (spesaRepo.Delete(spesaDaCacellare))
                            Console.WriteLine("Spesa cancellata con successo");
                        else
                            Console.WriteLine("Attenzione! Spesa non cancellata");
                        break;
                    case 4:
                        //Mostra le spese approvate
                        List<Spesa> speseApprovate = spesaRepo.GetSpeseApprovate();
                        if (speseApprovate.Count == 0)
                        {
                            Console.WriteLine("Non sono presenti spese approvate");
                        }
                        else
                        {
                            foreach (var item in speseApprovate)
                            {
                                Console.WriteLine($"{item}");
                            }
                        }
                        break;
                    case 5:
                        //Mostra spese utente
                        Console.WriteLine("Inserisci il nome dell'utente:");
                        string utenteS = Console.ReadLine();
                        List<Spesa> speseUtente = spesaRepo.GetSpeseUtente(utenteS);
                        if (speseUtente.Count == 0)
                        {
                            Console.WriteLine($"L'utente non ha effettuato nessuna spesa");
                        }
                        else
                        {
                            foreach (var item in speseUtente)
                            {
                                Console.WriteLine(item);
                            }
                        }
                        break;
                    case 6:
                        //Mostra l'importo totale
                        spesaRepo.SpesePerCategoria();
                        break;
                    case 7:
                        Console.WriteLine("Arrivederci!");
                        esci = true;
                        break;
                }
                if(op != 7)
                {
                    Console.WriteLine("Premi un tasto per continuare...");
                    Console.ReadKey();
                }
            } while (esci == false);
        }
    }
}
