using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.Arm;
using System.Text;

namespace Klinika_Dentystyczna
{
    internal class Begining
    {
        internal static void Start()
        {
            string answer;

            Console.WriteLine("Jaką akcje chcesz zrobić?");
            Console.WriteLine("1 - Zarezerwować termin");
            Console.WriteLine("2 - Usunąć termin");
            Console.WriteLine("3 - Wyszukać termin");
            Console.WriteLine("4 - Wyczyścić terminy");
            Console.WriteLine("5 - Zakończ program");
            Console.WriteLine("");
          
            answer = Console.ReadLine();


            if (answer == "1" || answer == "Zarezerwować termin")
            {
                string path = Branches.Places();
                Reserve.Reservation(path);
            }
            else if (answer == "2" || answer == "Usunąc termin")
            {
                string path = Branches.Places();
                Delete.DeleteReservation(path);
            }
            else if (answer == "3" || answer == "Wyszukać termin")
            {
                string path = Branches.Places();
                Find.FindReservation(path);
            }
            else if (answer == "4" || answer == "Wyczyścić terminy")
            {
                string path = Branches.Places();
                DeleteTerms.Delete(path);
            }
            else if (answer == "5" || answer == "Zakończ program")
            {
                Environment.Exit(0);
            }    
        }
    }
}
