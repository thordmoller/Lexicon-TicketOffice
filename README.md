# Ticket Office Assignment
## Solution
The solution contains 4 different classes
### TicketOffice
This class is responsible for handling all the other classes. Its Initiate() method initiates the whole program and is called from the Program main method. It then starts by creating a customer with inputvalues gathered from methods of the UserInputHandler class. It also generates a place number, determines the price for the customer and sets a place number. It then finally calls methods from the ReservationManager class to store and validate that number.
### UserInputHandler
Is responsible for everything related to the console. putting out text, asking the user for input etc.
### ReservationManager
Responsible for keeping track of the place numbers, which it stacks in a string. It has methods for validating and adding them to the string.
### Customer
This is representing a customer and can be used as an object. It contains fields and methods that represent a customer, such as ticket number, age, and the choice of ticket type. It also has a few methods to process those. While this class hasn't been used fully right now, since its way out of the scope for the assignment, it would be very useful if this assignment expanded into something larger. Right now the ticket number for example is processed in a string. But a better way would be to store every customer in a list, which holds the ticket number. 

I made the class only for fun and because of the way i'm used to think.


## Requirements
**Design a Console app that asks the customer their age and if
they want a standing or a seated ticket. Based on the
customer’s response, give the customer a total price in SEK
(kronor), the amount of tax and a ticket number.**


When you run the app, it should ask the user for:
* Age
* Standing or Seated ticket
  
The app has at least three methods:
* TaxCalculator
* PriceSetter
* TicketNumberGenerator
  
The **PriceSetter** method has six prices to consider.

<table>
  <tr>
    <td>Age</td><td>Seated Place (SEK)</td><td>Standing place(SEK)</td>
  </tr>
  <tr>
    <td>-11</td><td>50</td><td>25</td>
  </tr>
  <tr>
    <td>12-64</td><td>170</td><td>110</td>
  </tr>
  <tr>
    <td>65-</td><td>100</td><td>60</td>
  </tr>
</table> 

**Method parameters:**

<table>
  
<tr><td>int age</br></td></tr>
<tr><td>string place</td></tr>

<tr><td>Return value: int</td></tr>
</table>


The **TaxCalculator** takes the price and returns a value of 6% tax on the price
given.

**Method parameters:**
<table>
  
<tr><td>int price</br></td></tr>

<tr><td>Return value: decimal</td></tr>
</table>

Use this formula to calculate the tax:</br>
tax = (1- 1/1.06) * price

The **TicketNumberGenerator** returns a number between 1 and 8000.
<table>
  
<tr><td>no method parameters</br></td></tr>

<tr><td>Return value: int</td></tr>
</table>

Let the method generate a random number between 1 and 8000
