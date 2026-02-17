using System;
using System.Collections.Generic;
using System.Text;

namespace Klinika_Dentystyczna
{
    internal class DeleteTerms
    {
        internal static void Delete(string path)
        {

            string deleting;

            foreach (string line in File.ReadLines(path))
            {
                Console.WriteLine(line);
            }

            DateTime equals;

            int StartTime;
            int EndTime;

            while (true)
            {
                Console.WriteLine("Podaj godzine początkową którą chcesz usunąć (HH):");
                bool correctStart = int.TryParse(Console.ReadLine(), out StartTime);

                Console.WriteLine("Podaj godzine końcową którą chcesz usunąć (HH):");
                bool correctEnd = int.TryParse(Console.ReadLine(), out EndTime);
                if (!correctStart || !correctEnd)
                {
                    Console.WriteLine("Błąd! Wpisz godzine w formacie HH (np. 12)");
                    continue;
                }
                if (StartTime < 0 || StartTime > 23 || EndTime < 0 || EndTime > 23)
                {
                    Console.WriteLine("Godzina musi być w zakresie miedzy 0-23");
                    continue;
                }
                if (StartTime >= EndTime)
                {
                    Console.WriteLine("Pierwsza godzina powinna być mniejsza od drugiej");
                    continue;
                }
                break;
            }

            Console.WriteLine("Czy napewno chcesz usunąć rezerwacja o danej godzinie? (t/n)");
            deleting = Console.ReadLine();

            if (deleting == "t" || deleting == "T")
            {
                var linie = File.ReadAllLines(path).ToList();
                bool foundtodelete = false;

                for (int i = linie.Count - 1; i >= 0; i--)
                {
                    string line = linie[i];

                    string[] parts = line.Split(' ');

                    foreach (string part in parts)
                    {
                        {
                            if (TimeSpan.TryParse(part, out TimeSpan time))
                            {
                                int hourFromFile = time.Hours;

                                if (hourFromFile >= StartTime && hourFromFile <= EndTime)
                                {
                                    linie.RemoveAt(i);
                                    foundtodelete = true;
                                    break;
                                }
                            }

                        }
                        
                    }
                    if (foundtodelete)
                    {
                        File.WriteAllLines(path, linie);
                        Console.WriteLine("Usunięto dane rezerwacje z podanego zakresu godzin");
                    }
                    
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
    

