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


            string odp;

            Console.WriteLine("Jaką akcje chcesz zrobić?");
            Console.WriteLine("1 - Zarezerwować termin");
            Console.WriteLine("2 - Wyszukać termin");
            Console.WriteLine("3 - Usunąć termin");
            Console.WriteLine("");
            
            odp = Console.ReadLine();
            


            if (odp == "1" || odp == "Zarezerwować termin")
            {
                Reserve.Reservation();
            }
            else if (odp == "2" || odp == "Wyszukać termin")
            {
                Find.FindReservation();
            }
            else if (odp == "3" || odp == "Usunąć termin")
            {
                Delete.DeleteReservation();
            }

        }
    }
}
