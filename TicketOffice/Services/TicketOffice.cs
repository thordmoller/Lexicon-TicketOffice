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
        public static Customer getUserInput() {

            WriteLine("Welcome to the Ticket Office!\nPlease specify your age and press enter");

            return new Customer(-1, true);
        }
    }
}
