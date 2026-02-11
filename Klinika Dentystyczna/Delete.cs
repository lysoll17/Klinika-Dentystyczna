using System;
using System.Collections.Generic;
using System.Text;

namespace Klinika_Dentystyczna
{
    internal class Delete
    {
        internal static void DeleteReservation()
        {
            string imie;
            string nazwisko;
            string usuwanie;
            string sciezka = Oddziały.Places();

            Console.WriteLine("Podaj Imie osoby którą chcesz usunąć: ");
            imie = Console.ReadLine();
            Console.WriteLine("Podaj Nazwisko osoby którą chcesz usunąć: ");
            nazwisko = Console.ReadLine();

            string szukany = imie + " " + nazwisko;
            bool znaleziono = false;

            foreach (string linie in File.ReadLines(sciezka))
            {
                if (linie.Contains(szukany, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine(linie);
                    znaleziono = true;
                }
            }
            if (!znaleziono)
            {
                Console.WriteLine("Nie ma takiej osoby w bazie danych");
            }

            Console.WriteLine("Czy napewno chcesz usunąć daną osobe? (t/n)");
            usuwanie = Console.ReadLine();

            if (usuwanie == "t" || usuwanie == "T")
            {


                var linie = File.ReadAllLines(sciezka).ToList();
                foreach (string line in linie.ToList())
                {
                    if (line.Contains(szukany, StringComparison.OrdinalIgnoreCase))
                    {
                        linie.Remove(line);
                    }
                }
                File.WriteAllLines(sciezka, linie);

                Console.WriteLine("Usunięto daną osobe");
            }
            else if (usuwanie == "n" || usuwanie == "N")
            {
                return;
            }
        }
    }
}
