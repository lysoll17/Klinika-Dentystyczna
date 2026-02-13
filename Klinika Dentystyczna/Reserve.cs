using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Klinika_Dentystyczna
{
    internal class Reserve
    {
        internal static void Reservation(string path)
        {
            string name;
            string surname;
            string time;

            do
            {
                Console.WriteLine("Podaj Imie: ");
                name = Console.ReadLine();

                if (string.IsNullOrEmpty(name))
                {
                    Console.WriteLine("Nie podano imienia");
                }
                else if (name.Length < 3)
                {
                    Console.WriteLine("Imie jest za krótkie");
                }
            } while (string.IsNullOrEmpty(name) || name.Length < 3);

            do
            {
                Console.WriteLine("Podaj Nazwisko");
                surname = Console.ReadLine();

                if (string.IsNullOrEmpty(surname))
                {
                    Console.WriteLine("Nie podano nazwiska");
                }
                else if (surname.Length < 3)
                {
                    Console.WriteLine("Nazwisko jest za krótkie");
                }
            } while (string.IsNullOrEmpty(surname) || surname.Length < 3);

            do
            {
                Console.WriteLine("Podaj Godzine: ");
                time = Console.ReadLine().Trim();
                
                bool correcttime = DateTime.TryParseExact(time, "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime wynik);

                if (!correcttime)
                {
                    Console.WriteLine("Błąd! Wpisz godzine w formacie HH:mm (np. 14:30)");
                    continue;
                }
                else
                {


                    bool reserved = false;

                    if (!File.Exists(path))
                    {
                        File.Create(path).Close();
                    }

                    foreach (string line in File.ReadLines(path))
                    {
                        if (line.Contains(" - " + time))
                        {
                            reserved = true;
                            break;
                        }
                    }

                    if (reserved)
                    {
                        Console.WriteLine("Dana godzina jest już zarezerwowana");

                    }
                    else
                    {
                        File.AppendAllText(path, name + " " + surname + " - " + time + Environment.NewLine);

                        List<string> lines = File.ReadAllLines(path).ToList();
                        lines.Sort(delegate (string a, string b)
                        {
                            DateTime hourA = DateTime.ParseExact(a.Split('-')[1].Trim(), "HH:mm", CultureInfo.InvariantCulture);
                            DateTime hourB = DateTime.ParseExact(b.Split('-')[1].Trim(), "HH:mm", CultureInfo.InvariantCulture);
                            return hourA.CompareTo(hourB);
                        });
                        File.WriteAllLines(path, lines);

                        Console.WriteLine("Zarezerwowano");
                        Begining.Start();
                    }
                }
            } while (true);
        }
    }
}
