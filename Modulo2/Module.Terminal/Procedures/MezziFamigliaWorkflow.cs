using Galaxy.Core.Managers.Providers.Enum;
using Module.Core.Entities;
using Module.Core.Managers;
using Module.Storage.Json;
using Module.Terminal.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Module.Terminal.Procedures
{
    class MezziFamigliaWorkflow
    {
        internal static void CreaMezzi()
        {
            Console.WriteLine("***********************");
            Console.WriteLine("* Crea mezzi per famiglia *");
            Console.WriteLine("***********************");
            Console.WriteLine("");
            ConsoleUtils.WriteColor(ConsoleColor.Yellow, "Numero bici ");
            int numeroDiBiciclette = ConsoleUtils.ReadLine<int>(a => a > 0);
            ConsoleUtils.WriteColor(ConsoleColor.Yellow, "marca Bici ");
            string marcaBiciclette = ConsoleUtils.ReadLine<string>(t => !string.IsNullOrEmpty(t));

            string[] modelliBiciclette = new string[numeroDiBiciclette];
           for(int i =0; i<numeroDiBiciclette; i++)
            {
                ConsoleUtils.WriteColor(ConsoleColor.Yellow, "modello bici " + i + ": ");
                string modello = ConsoleUtils.ReadLine<string>(t => !string.IsNullOrEmpty(t));
                modelliBiciclette[i] = modello;
            }
           
            
            ConsoleUtils.WriteColor(ConsoleColor.Yellow, "marca auto ");
            string marcaAutomobile = ConsoleUtils.ReadLine<string>(t => !string.IsNullOrEmpty(t));
            ConsoleUtils.WriteColor(ConsoleColor.Yellow, "marca auto ");
            string modelloAutomobile = ConsoleUtils.ReadLine<string>(t => !string.IsNullOrEmpty(t));
            CreaMezziDellaFamiglia(numeroDiBiciclette, marcaBiciclette, modelliBiciclette, marcaAutomobile, modelloAutomobile);



        }

        private static void CreaMezziDellaFamiglia(int numeroDiBiciclette, string marcaBiciclette, string[] modelliBiciclette, string marcaAutomobile, string modelloAutomobile)
        {
            //le bicilette della famiglia è stato salvato sul file delle biciclette
            Bicicletta[] biciFamiglia = new Bicicletta[numeroDiBiciclette];
            IManager<Bicicletta> managerBici = new JsonBiciclettaManager();
            for (int i=0; i<numeroDiBiciclette; i++)
            {
                biciFamiglia[i] = new Bicicletta
                {
                    Marca = marcaBiciclette,
                    Modello = modelliBiciclette[i]
                };
                managerBici.Crea(biciFamiglia[i]);
                Console.WriteLine("bici" + i+  "famiglia dovrebbe essere stato creato su disco!");
                Console.WriteLine();
            }


            //le bicilette della famiglia è stato salvato sul file delle auto
            Automobile autoFamiglia = new Automobile
            {
                Marca = marcaAutomobile,
                Modello = modelloAutomobile
            };
            IManager<Automobile> managerAuto = new JsonAutomobileManager();
            managerAuto.Crea(autoFamiglia);
            Console.WriteLine("auto famiglia dovrebbe essere stato creato su disco!");
            Console.WriteLine();
        }
    }
}