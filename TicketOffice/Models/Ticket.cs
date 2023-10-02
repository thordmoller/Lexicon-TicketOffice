using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
