using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TicketOfficeAssignment.TicketType;

namespace TicketOfficeAssignment
{

    /// <summary>
    /// This is a class that can be used as an object, representing a Ticket in the Ticket Office.
    /// </summary>
    public class Ticket
    {
        //fields to be used only within this class
        private int age;
        private TicketType place;   //enum TicketType
        private int number;

        //public getters for outside access
        public int Age
        {
            get { return age; }
        }
        public TicketType Place
        {
            get { return place; }
        }
        public int Number
        {
            get { return number; }
        }

        //constructor. Set fields when creating the object
        public Ticket(int age, TicketType place) {

            if(IsValidAge(age))
                this.age = age;
            else
                throw new ArgumentException("Age must be a value between 0 and 120");   //invalid age. Abort object creation. Only happens in worst case scenario if somoene creates the object wrong

            this.place = place;
            number = TicketOffice.TicketNumberGenerator();
        }

        /// <summary>
        /// Sets the ticket price based on the customers age and ticket type
        /// </summary>
        /// <param name="age"></param>
        /// <param name="place"></param>
        /// <returns>ticket price</returns>
        public int Price() {

            int price = 0;

            if(IsValidAge(age)) {

                if(age < 12) {
                    if(place == Seated)
                        price = 50;
                    else
                        price = 25;
                }
                else if(age > 11 && age < 65) {
                    if(place == Seated)
                        price = 170;
                    else
                        price = 110;
                }
                else {
                    if(place == Seated)
                        price = 100;
                    else
                        price = 60;
                }
            }

            return price;
        }

        public decimal Tax() {
            decimal taxRate = Convert.ToDecimal(1.06);
            return (1 - 1 / taxRate) * Price();
        }

        public static bool IsValidAge(int ageToValidate) {

            if(ageToValidate >= 0 && ageToValidate <= 120)  //only validate ages between 0 and 120
                return true;
            return false;
        }

        //making a string out of this objects fields, for convenient console output. Overriding the original ToString()
        public override string ToString() {

            return "Age: " + age + "\nTicket type: " + GetTicketToString();
        }

        //converting the decided ticket boolean to a string
        public string GetTicketToString() {

            return place.ToString();
        }
    }
}
