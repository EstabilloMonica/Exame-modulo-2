using System;
using System.Collections.Generic;
using System.Text;

namespace Module.Terminal.Utils
{
    public static class ConsoleUtils
    {
        public static char LeggiLetteraDaConsole(char tastoA, char tastoB, char tastoC)
        {
            string valoreString = "";
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
                    isChar = true;


                    //Verifico se è nel range
                    if (valoreChar == 'a' || valoreChar == 'b' || valoreChar == 'c')
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

        public static TOutput ReadLine<TOutput>(Func<TOutput, bool> acceptanceCondition)
        {
            //Predisposizione valori            
            TOutput valoreConvertito = default(TOutput);
            bool isValidCast = false;
            bool isAccepted = false;

            while (!isValidCast || !isAccepted)
            {
                //Try perchè il cast potrebbe fallire
                try
                {
                    //Lettura da console
                    string valueFromConsole = Console.ReadLine();

                    //Tento il casting forzato
                    valoreConvertito = (TOutput)Convert
                        .ChangeType(valueFromConsole, typeof(TOutput));

                    //Il cast è andato bene
                    isValidCast = true;

                    //Verifico la condizione di accettazione
                    isAccepted = acceptanceCondition(valoreConvertito);

                    //La condizione è stata accetta o meno
                    if (!isAccepted)
                    {
                        //Mostro un messaggio utente con l'errore di parsing
                        WriteColorLine(ConsoleColor.Yellow, "Condizione non valida. Riprova: ");
                    }
                }
                catch (Exception exc)
                {
                    //Mostro un messaggio utente con l'errore di parsing
                    WriteColorLine(ConsoleColor.Yellow, "Selezione non valida. Riprova: ");

                    //Il cast non è valido
                    isValidCast = false;
                }
            }

            //Se arrivo qui, il casting ok, ed esco
            return valoreConvertito;
        }

        public static void WriteColorLine(ConsoleColor color, string message)
        {
            WriteColorBase(color, message,
                s => Console.WriteLine(s)
            );
        }

        private static void WriteColorBase(ConsoleColor color, string message,
           Action<string> actionToExecute)
        {
            //Salvo il vecchio colore (quello di default)
            var vecchioColore = Console.ForegroundColor;

            //Impostiamo il nuovo colore della console per la scrittura
            Console.ForegroundColor = color;

            //Lanciamo la funzione delegata (Lambda Expression)
            actionToExecute(message);

            //Reimpostiamo il vecchio colore
            Console.ForegroundColor = vecchioColore;
        }

        public static void WriteColor(ConsoleColor color, string message)
        {
            WriteColorBase(color, message,
                s => Console.Write(s)
            );
        }
    }
}
