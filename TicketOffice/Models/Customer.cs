using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketOfficeAssignment
{

    /// <summary>
    /// This is a class that can be used as an object, representing a Customer in the Ticket Office.
    /// I realize this is way out of the scope of where we are in the course so far- 
    /// and some of this classes features are not directly optimal right now, because of the way the assignment methods were instructed. I was a little too quick to notice the details.
    /// But this was the initial idea and i like to make use of the knowledge i have and practice it, to make things a little more interesting, so i decided to keep it.
    /// I hope this is okay. I have implemented all the assignent methods as they should be either way.
    /// </summary>
    public class Customer
    {
        //fields to be used only within this class
        private int age;
        private bool isTicketSeated;
        private int ticketNumber;

        //public getters for outside access
        public int Age
        {
            get { return age; }
        }
        public bool IsTicketSeated
        {
            get { return isTicketSeated; }
        }
        public int TicketNumber
        {
            get { return ticketNumber; }
        }

        //constructor. Set fields when creating the object
        public Customer(int age, bool isTicketSeated, int ticketNumber) {

            if(IsValidAge(age))
                this.age = age;
            else
                throw new ArgumentException("Age must be a value between 0 and 120");   //invalid age. Abort object creation. Only happens in worst case scenario if somoene creates the object wrong

            this.isTicketSeated = isTicketSeated;
            this.ticketNumber = ticketNumber;
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

            return isTicketSeated ? "Seated" : "Standing";
        }
    }
}
