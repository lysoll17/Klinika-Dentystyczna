using System;
using System.Collections.Generic;
using System.Text;

namespace Klinika_Dentystyczna
{
    internal class Reserve
    {
        internal static void Reservation()
        {
            string imie;
            string nazwisko;
            string plec;
            string rezerwacja;
            bool plecpoprawna = false;

            do
            {
                Console.WriteLine("Podaj Imie: ");
                imie = Console.ReadLine();

                if (string.IsNullOrEmpty(imie))
                {
                    Console.WriteLine("Nie podano imienia");

                }
                else if (imie.Length < 3)
                {
                    Console.WriteLine("Imie jest za krótkie");
                }

            } while (string.IsNullOrEmpty(imie) || imie.Length < 3);

            do
            {
                Console.WriteLine("Podaj Nazwisko");
                nazwisko = Console.ReadLine();

                if (string.IsNullOrEmpty(nazwisko))
                {
                    Console.WriteLine("Nie podano nazwiska");
                }
                else if (nazwisko.Length < 3)
                {
                    Console.WriteLine("Nazwisko jest za krótkie");
                }

            } while (string.IsNullOrEmpty(nazwisko) || nazwisko.Length < 3);

            do
            {
                Console.WriteLine("Podaj płeć (Mężczyzna/Kobieta)");
                plec = Console.ReadLine();



                if (string.IsNullOrEmpty(plec))
                {
                    Console.WriteLine("Nie podano płci");
                }

                else if (plec.Equals("Mężczyzna", StringComparison.OrdinalIgnoreCase) || plec.Equals("Kobieta", StringComparison.OrdinalIgnoreCase))
                {
                    plecpoprawna = true;

                }
                else
                {
                    Console.WriteLine("Podano niepoprawną płeć!");

                }

            } while (!plecpoprawna);

            string sciezka = "dane.txt";
            string szukany = imie + " " + nazwisko;
            bool znaleziony = false;

            foreach (string linie in File.ReadLines(sciezka))
            {
                if (linie.Contains(szukany, StringComparison.OrdinalIgnoreCase))
                {
                    znaleziony = true;
                    break;
                }


            }
            if (znaleziony)
            {
                Console.WriteLine("Dana osoba juz jest w bazie");

            }
            else
            {
                File.AppendAllText(sciezka, imie + " " + nazwisko + " - " + plec + Environment.NewLine);
                Console.WriteLine("Zarezerwowano");

            }
        }
    }
}
