using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace TicketOfficeAssignment
{
    public static class TicketOffice
    {
        private static Customer customer;
        private enum AgeCategory
        {
            Child,
            Adult,
            Senior
        }

        //static constructor is initiated when class is first used
        static TicketOffice() {
            int customerAge = UserInputHandler.getAgeFromUser();
            bool customerTicket = UserInputHandler.userPrefSeated();

            customer = new Customer(customerAge, customerTicket);

            Console.WriteLine(GetAgeCategory(customerAge).ToString());
        }

        public static int PriceSetter(int age, string place) {


            return 1;
        }

        private static AgeCategory GetAgeCategory(int age) {
            if(Customer.isValidAge(age)) {
                if(age < 12)
                    return AgeCategory.Child;
                if(age > 11 && age < 65)
                    return AgeCategory.Adult;
                if(age > 64)
                    return AgeCategory.Senior;
            }
            return AgeCategory.Adult;   //if all fails for some reason, adult is the default
        }

        public static string hej() {
            return "hej";
        }
    }
}
