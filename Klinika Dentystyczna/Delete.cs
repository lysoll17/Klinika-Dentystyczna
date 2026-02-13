using System;
using System.Collections.Generic;
using System.Text;

namespace Klinika_Dentystyczna
{
    internal class Delete
    {
        internal static void DeleteReservation(string path)
        {
            string name;
            string surname;
            string deleting;

            Console.WriteLine("Podaj Imie osoby którą chcesz usunąć: ");
            name = Console.ReadLine();
            Console.WriteLine("Podaj Nazwisko osoby którą chcesz usunąć: ");
            surname = Console.ReadLine();

            string searching = name + " " + surname;
            bool found = false;

            foreach (string line in File.ReadLines(path))
            {
                if (line.Contains(searching, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine(line);
                    found = true;
                }
            }
            if (!found)
            {
                Console.WriteLine("Nie ma takiej osoby w bazie danych");
            }

            string time;
            DateTime equals;

            while (true)
            {
                Console.WriteLine("Podaj godzine którą chcesz usunąć (HH:mm):");
                time = Console.ReadLine().Trim();

                bool correcttime = DateTime.TryParseExact(time, "HH:mm", System.Globalization.CultureInfo.InvariantCulture,System.Globalization.DateTimeStyles.None, out equals);

                if (!correcttime)
                {
                    Console.WriteLine("Błąd! Wpisz godzine w formacie HH:mm (np. 12:30)");
                }
                else
                {
                    break;
                }                
            }

            Console.WriteLine("Czy napewno chcesz usunąć rezerwacja o danej godzinie? (t/n)");
            deleting = Console.ReadLine();

            if (deleting == "t" || deleting == "T")
            {
                var linie = File.ReadAllLines(path).ToList();
                bool foundtodelete = false;

                for(int i = linie.Count - 1;i >= 0;i--)
                {
                    string line = linie[i];

                    if(line.IndexOf(searching, StringComparison.OrdinalIgnoreCase) >= 0 && line.Contains(" - " + time))
                    {
                        linie.RemoveAt(i);
                        foundtodelete = true;
                        break;
                    }
                }
                if (foundtodelete)
                {
                    File.WriteAllLines(path, linie);
                    Console.WriteLine("Usunięto daną rezerwacje");
                }
                else
                {
                    Console.WriteLine("Nie znaleziono rezerwacji danej osoby o tej godzinie");
                }
            }
            else if (deleting == "n" || deleting == "N")
            {
                return;
            }
            Begining.Start();
        }
        
    }
}
