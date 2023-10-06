# Ticket Office Assignment - Refactoring with with enums and objects
**This is the part 2 assignment. The solution still consists of 4 classes. But Customer was changed into Ticket since the assignment called for it**
### TicketOffice
This class is responsible for handling all the other classes. Its Initiate() method initiates the whole program and is called from the Program main method. It then starts by creating a customer with inputvalues gathered from methods of the UserInputHandler class. Now contains a little less methods since the use of the Ticket class.
### UserInputHandler
Is responsible for everything related to the console. putting out text, asking the user for input etc.
### ReservationManager
Responsible for keeping track of the place numbers, which it stacks in a string. It has methods for validating and adding them to the string.
### Ticket
Previously the "Customer" class. Since my initial Customer class had almost identical features as the Ticket class asked for in the assignment, i just renamed the Customer class and implemented it accordingly. Because of the extra work from last week and thinking in the same path, i didn't have to do much at all. It was already working basically.

## Requirements
**Continue on last week’s Console app with the Ticket Office, by
refactoring (that is changing the code in order to improve it)
with an enum and an object.**

#### First step:
Change the string type for the choices of “Seated” or “Standing” for place
preference into an enum. Therefore add a new class of enum type.
As a consequence, the PriceSetter method needs to change its parameter list
from accepting a string place to accepting an enum place instead.
When this refactoring is done, commit the changes to git and push to GitHub.

### Second step:
Refactor the solution in a major way by adding a new class called Ticket.
The class Ticket should have a constructor with two parameters, an int age and
an enum place.

Give Ticket three properties, with simple getters and setters:
* int Age
* enum Place
* int Number

Move the PriceSetter method into the Ticket class. Rename the method to Price.
The Price method no longer takes any parameters. Instead it is getting the
values from the properties. The Price method still returns an int with the price.

Also move the TaxCalculator method into the Ticket class. Rename the method
to Tax. The Tax method no longer takes any parameters. Instead it is getting the
price value by calling the Price method. The Tax method still returns a decimal
with the tax value.

Leave the TicketNumberGenerator method outside of the Ticket class, but call
the TicketNumberGenerator method from the constructor for setting the Number
property.

Something like this code should be possible to write in the Program.cs (or the
class used for the main application):

Ticket ticket = new Ticket(24, Place.Seated);
ticket.Age;
ticket.Place;
ticket.Price();
ticket.Tax();
