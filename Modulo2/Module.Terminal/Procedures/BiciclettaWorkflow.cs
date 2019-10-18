using Module.Core.Entities;
using Module.Core.Managers;
using Module.Storage.Json;
using Module.Terminal.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Module.Terminal.Procedures
{
    public class BiciclettaWorkflow
    {
       public static void EseguiCrea()
        {
            //Creazione dell'istanza del manager dei generi
            Console.WriteLine();
            Console.WriteLine("ESECUZIONE DEL WORKFLOW GENERI...");
            Console.WriteLine();
            //IManager<Genere> manager = new TxtFileGenereManager();
            IManager<Bicicletta> manager = new JsonBiciclettaManager();

            //Visualizzazione contenuto database
            Console.WriteLine("Lettura del database...");
            var bicicletteInArchivio = manager.Carica();
            Console.WriteLine($"Trovati {bicicletteInArchivio.Count} biciclette in archivio");
            foreach (var currentBici in bicicletteInArchivio)
                Console.WriteLine($"Lettura: {currentBici.NumeroTelaio} (ID:{currentBici.Id})");
            Console.WriteLine("");
            Console.WriteLine("Premere invio per proseguire...");
            Console.ReadLine();

            //Creazione di un nuovo libro => "C" di CRUD
            ConsoleUtils.WriteColor(ConsoleColor.Yellow, "Modello:");
            string modello = ConsoleUtils.ReadLine<string>(t => !string.IsNullOrEmpty(t));
            ConsoleUtils.WriteColor(ConsoleColor.Yellow, "Marca:");
            string marca = ConsoleUtils.ReadLine<string>(t => !string.IsNullOrEmpty(t));
            ConsoleUtils.WriteColor(ConsoleColor.Yellow, "Numero cavalli:");
            int numeroTelaio= ConsoleUtils.ReadLine<int>(a => a > 0);

            var nuovaBicicletta = new Bicicletta
            {
                Modello = modello,
                Marca = marca,
                NumeroTelaio = numeroTelaio
            };
            manager.Crea(nuovaBicicletta);
            Console.WriteLine("Il libro dovrebbe essere stato creato su disco!");
            Console.WriteLine();

            Console.WriteLine("Lettura del database...");
            bicicletteInArchivio = manager.Carica();
            Console.WriteLine($"Trovati {bicicletteInArchivio.Count} automobili in archivio");
            foreach (var currentAuto in bicicletteInArchivio)
                Console.WriteLine($"Lettura: {currentAuto.Marca} (ID:{currentAuto.Id})");
            Console.WriteLine("");
            Console.WriteLine("Premere invio per proseguire...");
            Console.ReadLine();

            Console.WriteLine("Inserisci il modello da trovare");
            string modelloDaTrovare = ConsoleUtils.ReadLine<string>(t => !string.IsNullOrEmpty(t));
            IList<Bicicletta> tuttiBici = manager.Carica();

            //4-3) Verifico se esiste un genere con il nome
           
            foreach (var currentBici in tuttiBici)
            {
                if (currentBici.Modello == modelloDaTrovare)
                {
                    Console.WriteLine($"Auto trovata: {currentBici.Modello} {currentBici.Marca} (ID: {currentBici.Id})");
                    
                }

            }

            

        }
    }
}
