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

        //public getters and setters for outside access
        public int Age
        {
            get { return age; }
            set {
                if(isAgeValid(value))
                    age = value;
                else
                    throw new ArgumentException("Age must be a value between 0 and 120");
            }
        }
        public bool IsTicketSeated
        {
            get { return isTicketSeated; }
            set { isTicketSeated = value; }
        }

        //constructor. Set fields when creating the object
        public Customer(int age, bool isTicketSeated) {
            Age = age;
            IsTicketSeated = isTicketSeated;
        }

        //making a string out of this objects fields, for convenient console output
        public string toString() {
            return "Age: " + age + "\nTicket type: " + getTicketToString();
        }

        private bool isAgeValid(int ageToValidate) {
            if(ageToValidate >= 0 && ageToValidate <= 120)  //only validate ages between 0 and 120
                return true;
            return false;
        }

        private string getTicketToString() {
            return isTicketSeated ? "Seated" : "Standing";
        }

    }
}
