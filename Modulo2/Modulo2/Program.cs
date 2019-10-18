using Modulo2.Terminal.Utils;
using System;

namespace Modulo2.Terminal
{
    class Program
    {
        static void Main(string[] args)
        {
            //Visualizzo menu e richiedo selezione
            Console.WriteLine("*******************************");
            Console.WriteLine("* MENU                        *");
            Console.WriteLine("*******************************");
            Console.WriteLine("* 1 - Operzioni Biciclette (tasto A)");
            Console.WriteLine("* 2 - Operazioni Automobili (tasto B)");
            var selzione = ConsoleUtilis.LeggiLetteraDaConsole('a', 'b');
        }
    }
}
