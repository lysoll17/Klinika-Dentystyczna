using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
class Program
{
    static void Main(string[] args)
    {
        string imie;
        string nazwisko;
        string plec;
        string rezerwacja;
        bool plecpoprawna = false;


        Console.WriteLine("Czy chcesz złożyć rezerwacje? (t/n)");
        rezerwacja = Console.ReadLine();

        if (rezerwacja == "t" || rezerwacja == "T")
        {
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
                    Console.WriteLine("Nazwisko jest za krótkie");
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
                else if(nazwisko.Length < 3)
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
        else if (rezerwacja == "n" || rezerwacja == "N")
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

            string sciezka = "dane.txt";

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