using System;
using System.Collections.Generic;
using System.Text;

namespace Klinika_Dentystyczna
{
    internal class Find
    {
        internal static void FindReservation(string path)
        {
            string searchingname;
            string searchingsurname;
            do
            {
                Console.WriteLine("Podaj Imie do Wyszukania: ");
                searchingname = Console.ReadLine();

                if (string.IsNullOrEmpty(searchingname))
                {
                    Console.WriteLine("Nie podano imienia");
                }
            } while (string.IsNullOrEmpty(searchingname));

            do
            {
                Console.WriteLine("Podaj Nazwisko: ");
                searchingsurname = Console.ReadLine();

                if (string.IsNullOrEmpty(searchingsurname))
                {
                    Console.WriteLine("Nie podano nazwiska");
                }
            } while (string.IsNullOrEmpty(searchingsurname));

            string searching = searchingname + " " + searchingsurname;

            if (!File.Exists(path))
            {
                Console.WriteLine("Brak pliku z rezerwacjami");
                return;
            }

            bool found = false;

            foreach (string line in File.ReadLines(path))
            {
                if (line.Contains(searching, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Znaleziono Rezerwacje");
                    Console.WriteLine(line);
                    Console.WriteLine(" ");
                    found = true;
                }
            }
            if (!found)
            {
                Console.WriteLine("Nie znaleziono rezerwacji");
            }
            Begining.Start();

        }
    }
}
