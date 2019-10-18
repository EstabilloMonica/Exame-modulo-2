using Module.Core.Entities;
using Module.Core.Managers;
using Module.Storage.Json;
using Module.Terminal.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Module.Terminal.Procedures
{
    public class AutomobileWorkflow
    {
        public static void EseguiCrea()
        {
            //Creazione dell'istanza del manager dei generi
            Console.WriteLine();
            Console.WriteLine("ESECUZIONE DEL WORKFLOW GENERI...");
            Console.WriteLine();
            //IManager<Genere> manager = new TxtFileGenereManager();
            IManager<Automobile> manager = new JsonAutomobileManager();

            //Visualizzazione contenuto database
            Console.WriteLine("Lettura del database...");
            var automobiliInArchivio = manager.Carica();
            Console.WriteLine($"Trovati {automobiliInArchivio.Count} automobili in archivio");
            foreach (var currentAuto  in automobiliInArchivio)
                Console.WriteLine($"Lettura: {currentAuto.Marca} (ID:{currentAuto.Id})");
            Console.WriteLine("");
            Console.WriteLine("Premere invio per proseguire...");
            Console.ReadLine();

            //Creazione di un nuovo Auto => "C" di CRUD
            ConsoleUtils.WriteColor(ConsoleColor.Yellow, "Modello:");
            string modello = ConsoleUtils.ReadLine<string>(t => !string.IsNullOrEmpty(t));
            ConsoleUtils.WriteColor(ConsoleColor.Yellow, "Marca:");
            string marca = ConsoleUtils.ReadLine<string>(t => !string.IsNullOrEmpty(t));
            ConsoleUtils.WriteColor(ConsoleColor.Yellow, "Numero cavalli:");
            int numeroCavalli = ConsoleUtils.ReadLine<int>(a => a > 0);

            var nuovaAuto = new Automobile
            {
                Modello = modello,
                Marca = marca,
                NumeroCavalli = numeroCavalli
            };
            manager.Crea(nuovaAuto);
            Console.WriteLine("Il libro dovrebbe essere stato creato su disco!");
            Console.WriteLine();


            Console.WriteLine("Lettura del database...");
            automobiliInArchivio = manager.Carica();
            Console.WriteLine($"Trovati {automobiliInArchivio.Count} automobili in archivio");
            foreach (var currentAuto in automobiliInArchivio)
                Console.WriteLine($"Lettura: {currentAuto.Marca} (ID:{currentAuto.Id})");
            Console.WriteLine("");
            Console.WriteLine("Premere invio per proseguire...");
            Console.ReadLine();

            Console.WriteLine("Inserisci il modello da trovare");
            string modelloDaTrovare = ConsoleUtils.ReadLine<string>(t => !string.IsNullOrEmpty(t));
            IList<Automobile> tuttiAutomobili = manager.Carica();

            //4-3) Verifico se esiste un genere con il nome
            foreach(var currentAuto in tuttiAutomobili)
            {
                if (currentAuto.Modello == modelloDaTrovare)
                Console.WriteLine($"Auto trovata: {currentAuto.Modello} {currentAuto.Marca} (ID: {currentAuto.Id})");
            }

        }

        


    }
}
