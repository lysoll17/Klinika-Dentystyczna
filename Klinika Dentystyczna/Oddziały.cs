using System;
using System.Collections.Generic;
using System.Text;

namespace Klinika_Dentystyczna
{
    internal class Oddziały
    {
        internal static string Places()
        {
            while (true)
            {

                Console.WriteLine("Wybierz Klinike: ");
                Console.WriteLine("");
                Console.WriteLine("1 - Szemud");
                Console.WriteLine("2 - Kamień");
                Console.WriteLine("3 - Przetoczyno");
                string klinika = Console.ReadLine();



                if (klinika.Contains("1") || klinika.Contains("Szemud", StringComparison.OrdinalIgnoreCase))
                {
                    return "Szemud.txt";
                }
                else if (klinika.Contains("2") || klinika.Contains("Kamień", StringComparison.OrdinalIgnoreCase))
                {
                    return "Kamien.txt";
                }
                else if (klinika.Contains("3") || klinika.Contains("Przetoczyno", StringComparison.OrdinalIgnoreCase))
                {
                    return "Przetoczyno.txt";
                }
                else
                {
                    Console.WriteLine("Wybrano niepoprawną klinike");

                }
            }
        }
    }
}
