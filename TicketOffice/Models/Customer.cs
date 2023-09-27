using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketOfficeAssignment
{
    public class Customer
    {
        //fields to be used only within this class
        private int age;
        private bool isTicketSeated;

        //public getters for outside access
        public int Age
        {
            get { return age; }
        }
        public bool IsTicketSeated
        {
            get { return isTicketSeated; }
        }

        //constructor. Set fields when creating the object
        public Customer(int age, bool isTicketSeated) {
            if(isValidAge(age))
                this.age = age;
            else
                throw new ArgumentException("Age must be a value between 0 and 120");   //invalid age. Abort object creation. Only happens in worst case scenario if somoene creates the object wrong

            this.isTicketSeated = isTicketSeated;
        }

        public static bool isValidAge(int ageToValidate) {
            if(ageToValidate >= 0 && ageToValidate <= 120)  //only validate ages between 0 and 120
                return true;
            return false;
        }

        //making a string out of this objects fields, for convenient console output
        public string ToString() {
            return "Age: " + age + "\nTicket type: " + getTicketToString();
        }

        public string getTicketToString() {
            return isTicketSeated ? "Seated" : "Standing";
        }
    }
}
