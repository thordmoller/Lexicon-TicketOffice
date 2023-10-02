using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static System.Console;
using static TicketOfficeAssignment.TicketType;

namespace TicketOfficeAssignment
{
    public enum TicketType
    {
        Seated,
        Standing
    }

    /// <summary>
    /// This is a class that handles all the console or user input related methods of the program, to keep it separated from other functional methods.
    /// The program is initiated when a method from the static TicketOffice class is used.
    /// This initiates the constructor of TicketOffice which in turn calls methods from UserInputHandler (this) class to start receiving input from the user
    /// </summary>
    /// 
    public static class UserInputHandler
    {
        /// <summary>
        /// I already implemented this method before the third assignment was released. That's why i have solved it in a different way than the assignment wants.
        /// But i think it returns the correct result. It's not handling chars, but it effectively accepts only integers between 0 and 120
        /// </summary>
        /// <returns></returns>

        public static int GetCustomerAge() {

            string message = "Please specify your age";

            int age;
            string? userInput;

            do {
                WriteLine(message);
                userInput = ReadLine();
                message = "Invalid input. Please enter a number between 0 and 120";

            } while(!IsValidAgeInput(userInput, out age));  //loop continues as long as the input is invalid age

            return age;
        }

        /// <summary>
        /// Extra check to see if the input age is a valid int while also reusing the IsValidAge method from Customer class.
        /// </summary>
        /// <param name="inputAge"></param>
        /// <param name="age">Age is an output integer additional to the returned bool</param>
        /// <returns></returns>
        private static bool IsValidAgeInput(string? inputAge, out int age) {

            if(int.TryParse(inputAge, out age)) {
                if(Customer.IsValidAge(age))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// I already made the UserPrefSeated() method before the assignment was released, which does the same thing except it returns a boolean for simplicity.
        /// So this method reuses that one and returns a string based on the boolean.
        /// </summary>
        /// <returns>TicketType Seated or Standing</returns>
        public static TicketType GetCustomerPlacePreference() {

            return UserPrefSeated() ? Seated : Standing;
        }

        /// <returns>True if the user prefers a seated ticket</returns>
        public static bool UserPrefSeated() {

            string message = "\nWould you like a seated ticket?";
            string instructionMessage = "press 'y' for a seated ticket or 'n' for a standing ticket";

            ConsoleKeyInfo keyPress;

            while(true) {
                WriteLine(message + "\n" + instructionMessage);
                keyPress = ReadKey(true);

                switch(keyPress.Key) {
                    case ConsoleKey.Y:
                        return true;
                    case ConsoleKey.N:
                        return false;
                }
                message = "Invalid input.";     //if the loop ever runs twice, it means an error occured so the message is changed
            }
        }

        /// <summary>
        /// After a customer is handled the user gets a choice to enter a new customer, display the reservation list or quit
        /// </summary>
        public static void EndChoice() {

            string message = "Thank you for using the TicketOffice! Please decide what happens next: \n";
            string instructionMessage = "For new new customer: press 'n'. To list reserved places: press l. Or to quit: press q";

            ConsoleKeyInfo keyPress;

            bool choiceMade = false;
            while(!choiceMade) {
                WriteLine(message + "\n" + instructionMessage);
                keyPress = ReadKey(true);

                switch(keyPress.Key) {
                    case ConsoleKey.L:
                        DisplayReservationList();
                        EndChoice();
                        choiceMade = true;
                        break;
                    case ConsoleKey.N:
                        TicketOffice.Initiate();
                        choiceMade = true;
                        break;
                    case ConsoleKey.Q:
                        Environment.Exit(0);
                        choiceMade = true;
                        break;
                }

                message = "Invalid input.";     //if the loop ever runs twice, it means an error occured so the message is changed
            }
        }

        public static void DisplayWelcomeMessage() {

            PrintBlock("Welcome to the Ticket Office!");
        }

        /// <summary>
        /// Summarizing the details about the customer and the purchase
        /// </summary>
        public static void DisplaySummary(Customer customer, int price, decimal tax) {
            PrintBlock("\nSummary:");
            WriteLine(customer.ToString());
            DisplayPrice(price, tax);
        }

        public static void DisplayPrice(int price, decimal tax) {

            PrintBlock("price: " + price + " (Tax: " + tax.ToString("F2") + ")");
        }

        public static void DisplayReservationList() {
            PrintBlock(ReservationManager.ReservationList);
        }

        /// <summary>
        /// only adds a new line to the writeline method for convenience to print more readable blocks
        /// </summary>
        private static void PrintBlock(string message) {
            WriteLine(message + "\n");
        }
    }
}
