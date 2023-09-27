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
        public static void getUserInput() {

            string ticketMessage = "Would you like a standing ticket?\n(type 'y' for a standing ticket or 'n' for a seated ticket and press enter.";
            string welcomeMessage = "Welcome to the Ticket Office!";

            WriteLine(welcomeMessage);

            Customer customer = new Customer(getValidAgeFromUser(), true);
        }

        private static int getValidAgeFromUser() {

            string message = "Please specify your age";

            int age;
            string? userInput;

            do {
                WriteLine(message);
                userInput = ReadLine();
                message = "Invalid input. Please enter a number between 0 and 120";

            } while(!isValidAgeInput(userInput, out age));  //loop continues as long as the input is invalid age

            return age;
        }

        //Extra check to see if the input age is a valid int while also reusing the isValidAge method from Customer class.
        private static bool isValidAgeInput(string? inputAge, out int age) {

            if(int.TryParse(inputAge, out age)) {
                if(Customer.isValidAge(age))
                    return true;
            }
            return false;
        }
    }
}
