using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketOfficeAssignment.Models
{
    internal class Customer
    {
        //fields to be used only within this class
        private int age;
        private bool isTicketSeated;

        //public getters and setters for outside access
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        public bool IsTicketSeated
        {
            get { return isTicketSeated; }
            set { isTicketSeated = value; }
        }

        //constructor. Set fields when creating the object
        public Customer(int age, bool isTicketSeated) {
            this.age = age;
            this.isTicketSeated = isTicketSeated;
        }

    }
}
