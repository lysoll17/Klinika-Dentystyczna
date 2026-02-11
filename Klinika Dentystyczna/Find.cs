using System;
using System.Collections.Generic;
using System.Text;

namespace Klinika_Dentystyczna
{
    internal class Find
    {
        internal static void FindReservation()
        {
            string szukaneimie;
            string szukanenazwisko;
            do
            {
                Console.WriteLine("Podaj Imie do Wyszukania: ");
                szukaneimie = Console.ReadLine();

                if (string.IsNullOrEmpty(szukaneimie))
                {
                    Console.WriteLine("Nie podano imienia");

                }

            } while (string.IsNullOrEmpty(szukaneimie));
            do
            {
                Console.WriteLine("Podaj Nazwisko: ");
                szukanenazwisko = Console.ReadLine();

                if (string.IsNullOrEmpty(szukanenazwisko))
                {
                    Console.WriteLine("Nie podano nazwiska");

                }

            } while (string.IsNullOrEmpty(szukanenazwisko));

            string szukany = szukaneimie + " " + szukanenazwisko;

            string sciezka = Oddziały.Places();

            if (!File.Exists(sciezka))
            {
                Console.WriteLine("Brak pliku z rezerwacjami");
                return;
            }

            bool znaleziono = false;

            foreach (string linie in File.ReadLines(sciezka))
            {
                if (linie.Contains(szukany, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Znaleziono Rezerwacje");
                    Console.WriteLine(linie);
                    znaleziono = true;
                }
            }
            if (!znaleziono)
            {
                Console.WriteLine("Nie znaleziono rezerwacji");
            }

        }
    }
}
