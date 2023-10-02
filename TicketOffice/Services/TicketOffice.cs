﻿using System;
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
        private static Random random = new Random();    //random is a private field because i read that a new random object shouldnt be created everytime a random number is created
                                                        //This way the Random object remains the same as long as the program isnt restarted and can generate new numbers
        /// <summary>
        /// The programs entrypoint
        /// </summary>
        public static void Initiate() {

            UserInputHandler.DisplayWelcomeMessage();

            Ticket customer = CreateCustomer();

            int price = PriceSetter(customer.Age, customer.GetTicketToString());
            decimal tax = TaxCalculator(price);

            UserInputHandler.DisplaySummary(customer, price, tax);
            UserInputHandler.EndChoice();

        }
        /// <summary>
        /// creates customer object and gathers user input doing it
        /// </summary>
        public static Ticket CreateCustomer() {

            int customerAge = UserInputHandler.GetCustomerAge();
            bool customerTicket = UserInputHandler.UserPrefSeated();
            int ticketNumber = TicketNumberGenerator();

            Ticket customer = new Ticket(customerAge, customerTicket, ticketNumber);

            ReservationManager.AddPlace(ticketNumber);

            return customer;
        }

        public static int TicketNumberGenerator() {

            return random.Next(1, 8000);
        }
    }
}
