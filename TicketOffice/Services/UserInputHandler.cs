using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace TicketOfficeAssignment
{
    public static class UserInputHandler
    {
        public static void getUserInput() {
            string welcomeMessage = "Welcome to the Ticket Office!";

            string list = ",34,1003,389,4100,4890,7233,2855,";

            WriteLine(AddPlace(list, 35));

            WriteLine(welcomeMessage);

            WriteLine(TicketOffice.Customer.ToString());
            WriteLine("price: " + TicketOffice.Price);
            WriteLine("Tax: " + TicketOffice.TaxCalculator(TicketOffice.Price));
        }

        public static string AddPlace(string placeList, int placeNumber) {

            if(CheckPlaceAvailability(placeList, placeNumber) && isValidListFormat(placeList)) {
                placeList += placeNumber + ",";
            }

            return placeList;
        }

        private static bool isValidListFormat(string placeList) {

            if(!placeList.StartsWith(",") || !placeList.EndsWith(","))
                return false;

            placeList = placeList.Trim(',');
            string[] numbers = placeList.Split(',');
            foreach(string number in numbers) {
                if(!int.TryParse(number, out int intNumber)) {
                    return false;
                }
            }
            return true;
        }

        public static bool CheckPlaceAvailability(string placeList, int placeNumber) {

            string search = "," + placeNumber.ToString() + ",";

            if(isValidPlaceNumber(placeNumber))
                if(!placeList.Contains(search))
                    return true;

            return false;
        }

        private static bool isValidPlaceNumber(int placeNumber) {
            if(placeNumber >= 1 && placeNumber <= 8000)
                return true;
            return false;
        }

        public static int getAgeFromUser() {

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

        //returns true if the user perfers a seated ticket
        public static bool userPrefSeated() {

            string message = "Would you like a seated ticket?";
            string instructionMessage = "press 'y' for a seated ticket or 'n' for a standing ticket";

            ConsoleKeyInfo keyPress;

            while(true) {
                WriteLine(message + "\n" + instructionMessage);
                keyPress = Console.ReadKey(true);

                switch(keyPress.Key) {
                    case ConsoleKey.Y:
                        return true;
                    case ConsoleKey.N:
                        return false;
                }

                message = "Invalid input.";
            }
        }
    }
}
