using System;
using System.IO;
class Program
{
    static void Main(string[] args)
    {
        string imie;
        string nazwisko;
        string plec;
        
        do
        {
            Console.WriteLine("Podaj Imie: ");
            imie = Console.ReadLine();
            
            if (string.IsNullOrEmpty(imie))
            {
                Console.WriteLine("Nie podano imienia");

            }
            
        } while(string.IsNullOrEmpty(imie));

        do
        {
            Console.WriteLine("Podaj Nazwisko");
            nazwisko = Console.ReadLine();

            if(string.IsNullOrEmpty(nazwisko))
            {
                Console.WriteLine("Nie podano nazwiska");
            }
        } while (string.IsNullOrEmpty(nazwisko));

        do
        {
            Console.WriteLine("Podaj płeć (Mężczyzna/Kobieta)");
            plec = Console.ReadLine();

            if(string.IsNullOrEmpty (plec))
            {
                Console.WriteLine("Nie podano płci");
            }
        } while (string.IsNullOrEmpty (plec));

        string sciezka = "dane.txt";

        File.AppendAllText(sciezka, imie + " " + nazwisko + " - " + plec + Environment.NewLine);
        Console.WriteLine("Zarezerwowano");
    }
}