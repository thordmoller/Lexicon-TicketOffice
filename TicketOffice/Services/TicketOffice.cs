using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static TicketOfficeAssignment.TicketType;

namespace TicketOfficeAssignment
{
    public static class TicketOffice
    {


        /// <summary>
        /// The programs entrypoint
        /// </summary>
        public static void Initiate() {

            UserInputHandler.DisplayWelcomeMessage();

            Ticket ticket = NewTicket();
            UserInputHandler.DisplaySummary(ticket);
            UserInputHandler.EndChoice();

        }
        /// <summary>
        /// creates ticket object and gathers user input doing it
        /// </summary>
        public static Ticket NewTicket() {

            int customerAge = UserInputHandler.GetCustomerAge();
            TicketType customerTicket = GetCustomerPlacePreference();

            Ticket ticket = new Ticket(customerAge, customerTicket);

            TicketSalesManager.AddTicket(ticket);

            return ticket;
        }

        /// <summary>
        /// Gets the customer place preference by calling a method from UserInputHandler and converting the bool to enum
        /// </summary>
        /// <returns>TicketType Seated or Standing</returns>
        public static TicketType GetCustomerPlacePreference() {

            return UserInputHandler.UserPrefSeated() ? Seated : Standing;
        }
    }
}
