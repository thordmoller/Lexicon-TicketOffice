using System;
using System.Text.Json;
using TicketOfficeAssignment.Models;

namespace TicketOfficeAssignment
{
    internal class Program
    {
        static void Main(string[] args) {
            //TicketOffice.Initiate();

            string concertData = File.ReadAllText("C:\\Users\\thord\\source\\repos\\TicketOffice\\TicketOffice\\concert_data.json");
            List<Concert> concerts = JsonSerializer.Deserialize<List<Concert>>(concertData);

            PrintConcertList(concerts);

            PrintConcertList(UpcomingConcerts(concerts));

            PrintConcertList(ReducedVenues(concerts));

            PrintConcertList(All2024(concerts));

            PrintConcertList(FiveBiggestFullCapacitySales(concerts));

            PrintConcertList(OnlyFriday(concerts));
        }

        private static void PrintConcertList(List<Concert> concerts) {
            foreach(Concert concert in concerts) {
                Console.WriteLine(concert.ToString());
            }
            Console.WriteLine();
        }

        private static List<Concert> UpcomingConcerts(List<Concert> concerts) {

            List<Concert> sorted = concerts
                .Where(concert => concert.Date >= DateTime.Now)
                .OrderBy(concert => concert.Date)
                .ToList();

            return sorted;
        }
        //Return a new List<Concert> with all concerts of a ReducedVenue (true)
        private static List<Concert> ReducedVenues(List<Concert> concerts) {

            List<Concert> sorted = concerts
                .Where(concert => concert.ReducedVenue == true)
                .ToList();

            return sorted;
        }

        //Return a new List<Concert> with all concerts during 2024.
        private static List<Concert> All2024(List<Concert> concerts) {

            List<Concert> sorted = concerts
                .Where(concert => concert.Date.Year == 2024)
                .ToList();

            return sorted;
        }

        //Return a new List<Concert> with the five biggest projected sales figures (theFullCapacitySales value).
        private static List<Concert> FiveBiggestFullCapacitySales(List<Concert> concerts) {

            List<Concert> sorted = concerts
                .OrderByDescending(x => x.FullCapacitySales)
                .Take(5)
                .ToList();

            return sorted;
        }

        //Return a new List<Concert> with all concerts taking place on a Friday. The Date(because it is of DateTime) has a property called DayOfWeek.There is also an enumeration called the same thing, DayOfWeek.
        private static List<Concert> OnlyFriday(List<Concert> concerts) {

            List<Concert> sorted = concerts
                .Where(concert => concert.Date.DayOfWeek == DayOfWeek.Friday)
                .ToList();

            return sorted;
        }
    }
}