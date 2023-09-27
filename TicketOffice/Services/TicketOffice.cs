﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace TicketOfficeAssignment
{
    public static class TicketOffice
    {
        private static Customer customer;

        //static constructor is initiated when class is first used
        static TicketOffice() {
            int customerAge = UserInputHandler.getAgeFromUser();
            bool customerTicket = UserInputHandler.userPrefSeated();

            customer = new Customer(customerAge, customerTicket);

            WriteLine(PriceSetter(customerAge, customer.getTicketToString()));
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

        public static string hej() {
            return "hej";
        }
    }
}
