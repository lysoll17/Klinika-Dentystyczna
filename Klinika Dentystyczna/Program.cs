using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Runtime.CompilerServices;
class Program
{
    static void Main(string[] args)
    {
        string odp;

        Console.WriteLine("Jaką akcje chcesz zrobić?");
        Console.WriteLine("1 - Zarezerwować termin");
        Console.WriteLine("2 - Wyszukać termin");
        Console.WriteLine("3 - Usunąć termin");
        Console.WriteLine("");
        odp = Console.ReadLine();


        if (odp == "1" || odp == "Zarezerwować termin")
        {
            Reserve();
        }
        else if (odp == "2" || odp == "Wyszukać termin")
        {
            FindReservation();
        }
        else if (odp == "3" || odp == "Usunąć termin")
        {
            DeleteReservation();
        }
    }



    private static void Reserve()
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
    private static void FindReservation()
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
    private static void DeleteReservation()
    {
        string imie;
        string nazwisko;
        string usuwanie;
        string sciezka = "dane.txt";

        Console.WriteLine("Podaj Imie osoby którą chcesz usunąć: ");
        imie = Console.ReadLine();
        Console.WriteLine("Podaj Nazwisko osoby którą chcesz usunąć: ");
        nazwisko = Console.ReadLine();

        string szukany = imie + " " + nazwisko;
        bool znaleziono = false;

        foreach (string linie  in File.ReadLines(sciezka))
        {
            if(linie.Contains(szukany,StringComparison.OrdinalIgnoreCase))
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
        usuwanie =  Console.ReadLine();

        if (usuwanie == "t" ||  usuwanie == "T")
        {
            

            var linie = File.ReadAllLines(sciezka).ToList();
            foreach (string line in linie.ToList())
            {
                if(line.Contains(szukany, StringComparison.OrdinalIgnoreCase))
                {
                    linie.Remove(line);
                }
            }
            File.WriteAllLines(sciezka, linie);

            Console.WriteLine("Usunięto daną osobe");
        }
        else if (usuwanie == "n" ||  usuwanie == "N")
        {
            return;
        }
    }
}
    

        

