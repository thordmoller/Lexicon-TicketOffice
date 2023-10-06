using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TicketOfficeAssignment
{

    public static class TicketSalesManager
    {

        private static List<Ticket> tickets = new List<Ticket>();
        private static Random random = new Random();

        public static List<Ticket> Tickets { get { return tickets; } }

        public static int NextTicket() {

            int ticketNumber;

            do {
                ticketNumber = random.Next(1, 8000);
            } while(!CheckAvailability(ticketNumber));

            return ticketNumber;
        }

        private static bool CheckAvailability(int ticketNumber) {

            foreach(Ticket ticket in tickets) {
                if(ticket.number == ticketNumber)
                    return false;
            }
            return true;
        }
        /// <summary>
        /// Removes a ticket from the list
        /// </summary>
        /// <param name="ticket"></param>
        /// <returns></returns>
        public static bool RemoveTicket(Ticket ticket) {

            if(AmountOfTickets() > 0)
                for(int i = 0; i < tickets.Count; i++) {
                    if(tickets[i].number == ticket.number) {
                        tickets.Remove(ticket);
                        return true;
                    }
                }
            return false;
        }


        /// <returns>Total sum of sold tickets</returns>
        public static decimal SalesTotal() {
            decimal total = 0;
            foreach(Ticket ticket in tickets) {
                total += ticket.Price();
            }
            return total;
        }

        /// <returns>Tickets in the list</returns>
        public static int AmountOfTickets() {
            return tickets.Count;   //the count of the list is the number of tickets
        }

        /// <summary>
        /// Adds ticket to list
        /// </summary>
        /// <param name="ticket"></param>
        /// <returns>Added ticket on success. Null if the ticket is already in the list</returns>
        public static Ticket AddTicket(Ticket ticket) {
            if(!CheckAvailability(ticket.number))
                return null;
            tickets.Add(ticket);
            return ticket;
        }

    }
}
