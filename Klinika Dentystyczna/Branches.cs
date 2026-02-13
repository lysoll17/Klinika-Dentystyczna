using System;
using System.Collections.Generic;
using System.Text;

namespace Klinika_Dentystyczna
{
    internal class Branches
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

                string department = Console.ReadLine();

                if (department.Contains("1") || department.Contains("Szemud", StringComparison.OrdinalIgnoreCase))
                {
                    return "Szemud.txt";
                }
                else if (department.Contains("2") || department.Contains("Kamień", StringComparison.OrdinalIgnoreCase))
                {
                    return "Kamien.txt";
                }
                else if (department.Contains("3") || department.Contains("Przetoczyno", StringComparison.OrdinalIgnoreCase))
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
