using Module.Core.Entities;
using Module.Terminal.Procedures;
using Module.Terminal.Utils;
using System;

namespace Module.Terminal
{
    class Program
    {
        static void Main(string[] args)
        {
            //Visualizzo menu e richiedo selezione
            Console.WriteLine("*******************************");
            Console.WriteLine("* MENU                        *");
            Console.WriteLine("*******************************");
            Console.WriteLine("* 1 - Operzioni Biciclette (tasto a)");
            Console.WriteLine("* 2 - Operazioni Automobili (tasto b)");
            Console.WriteLine("* 3 - Operazioni Automobili (tasto c)");
            var selezione = ConsoleUtils.LeggiLetteraDaConsole('a', 'b', 'c');
            
            switch (selezione)
            {
                case 'a':
                    BiciclettaWorkflow.EseguiCrea();
                    break;
                case 'b':
                    AutomobileWorkflow.EseguiCrea();
                    break;
                case 'c':
                    
                   MezziFamigliaWorkflow.CreaMezzi();
                    break;
                default:
                    Console.WriteLine("Opzione non valida!");
                    break;
            }
        }
    }
}
