using System;
using System.Collections.Generic;
using System.Text;

namespace Modulo2.Terminal.Utils
{
    public static class ConsoleUtilis
    {
        public static char LeggiLetteraDaConsole(char tastoA, char tastoB)
        {
            string valoreString="";
            char valoreChar = '\0';

            //Predisposizione al fallimento
            bool isInRange = false;
            bool isChar = false;

            do
            {
                try
                {
                    //Eseguo la lettura del valore da console
                    Console.Write("- selezione: ");
                    valoreString = Console.ReadLine();
                    //Validazione e parsing del valore
                    valoreChar = Convert.ToChar(valoreString);
                    isChar= true;


                    //Verifico se è nel range
                    if (valoreChar == 'a' || valoreChar == 'b')
                    {
                        //imposto il flag IsInRange
                        isInRange = true;
                    }
                    else
                    {
                        //Messaggio di errore
                        Console.WriteLine("Attenzione! Il valore immesso non è nel range indicato");

                        //Ripristino condizioni di predisposizione fallimento iniziali
                        isChar = false;
                        isInRange = false;
                    }
                }
                catch (Exception exc)
                {
                    //Messaggio di errore
                    Console.WriteLine("Attenzione! Il valore immesso NON è una lettera!");

                    //Ripristino condizioni di predisposizione fallimento iniziali
                    isChar = false;
                    isInRange = false;
                }
            }
            while (isInRange == false || isChar == false);
            
            return valoreChar;
        }
    }
}
