using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace TicketOfficeAssignment
{
    public static class TicketOffice
    {
        private static Customer customer;
        private static int price;
        private static Random random = new Random();

        public static int Price
        {
            get { return price; }
        }
        public static Customer Customer
        {
            get { return customer; }
        }

        //static constructor is initiated when class is first used
        static TicketOffice() {
            int customerAge = UserInputHandler.getAgeFromUser();
            bool customerTicket = UserInputHandler.userPrefSeated();
            int ticketNumber = TicketNumberGenerator();

            customer = new Customer(customerAge, customerTicket, ticketNumber);
            price = PriceSetter(customer.Age, customer.getTicketToString());

        }

        public static int PriceSetter(int age, string place) {

            int price = 0;

            if(Customer.isValidAge(age)) {

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
