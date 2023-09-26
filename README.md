# Ticket Office Assignment
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
