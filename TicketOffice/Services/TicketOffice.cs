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

            Customer customer = CreateCustomer();

            int price = PriceSetter(customer.Age, customer.GetTicketToString());
            decimal tax = TaxCalculator(price);

            UserInputHandler.DisplaySummary(customer, price, tax);
            UserInputHandler.EndChoice();

        }
        /// <summary>
        /// creates customer object and gathers user input doing it
        /// </summary>
        public static Customer CreateCustomer() {

            int customerAge = UserInputHandler.GetCustomerAge();
            bool customerTicket = UserInputHandler.UserPrefSeated();
            int ticketNumber = TicketNumberGenerator();

            Customer customer = new Customer(customerAge, customerTicket, ticketNumber);

            ReservationManager.AddPlace(ticketNumber);

            return customer;
        }

        public static int PriceSetter(int age, string place) {

            int price = 0;

            if(Customer.IsValidAge(age)) {

                if(age < 12) {
                    if(place == "Seated")
                        price = 50;
                    else
                        price = 25;
                }
                else if(age > 11 && age < 65) {
                    if(place == "Seated")
                        price = 170;
                    else
                        price = 110;
                }
                else {
                    if(place == "Seated")
                        price = 100;
                    else
                        price = 60;
                }
            }

            return price;
        }
        public static decimal TaxCalculator(int price) {
            decimal taxRate = Convert.ToDecimal(1.06);
            return (1 - 1 / taxRate) * price;
        }

        private static int TicketNumberGenerator() {

            return random.Next(1, 8000);
        }
    }
}
