using TicketOfficeAssignment;
using static TicketOfficeAssignment.TicketType;

namespace TestProject1
{
    /// <summary>
    /// some test methods. Tried to stick with some of the assignment methods to not make this project too huge
    /// </summary>
    public class UnitTest1
    {
        public class TicketOfficeTests
        {
            [Theory]
            [InlineData(5, Seated, 50)]
            [InlineData(12, Seated, 170)]
            [InlineData(65, Seated, 100)]
            [InlineData(5, Standing, 25)]
            [InlineData(12, Standing, 110)]
            [InlineData(65, Standing, 60)]
            public void PriceSetter(int age, TicketType place, int expectedPrice) {
                Ticket ticket = new Ticket(age, place);
                int price = ticket.Price();
                Assert.Equal(expectedPrice, price);
            }
        }

        public class TicketSalesManagerTests
        {
            [Fact]
            public void AddTicket() {

                Ticket ticket = new Ticket(27, Standing);
                TicketSalesManager.AddTicket(ticket);

                Assert.Equal(1, TicketSalesManager.AmountOfTickets()); //checks if the list is empty
                Assert.Equal(TicketSalesManager.Tickets[0].number, ticket.number); //checks that the created ticket is in the list and has the same number
            }
            /// <summary>
            /// tests that method returns null if trying to add the same ticket twice. This uses the AddTicket method but actually tests the Checkavailability
            /// </summary>
            [Fact]
            public void CheckAvailability() {
                TicketSalesManager.Tickets.Clear();

                Ticket ticket = new Ticket(27, Standing);
                TicketSalesManager.AddTicket(ticket);

                Assert.Null(TicketSalesManager.AddTicket(ticket));
                CheckAmount(1);
            }

            private void CheckAmount(int expected) {
                Assert.Equal(expected, TicketSalesManager.AmountOfTickets());
            }

            //remove object
            [Fact]
            public void remove() {
                TicketSalesManager.Tickets.Clear();
                Ticket ticket = new Ticket(7, Seated);
                TicketSalesManager.AddTicket(ticket);

                Ticket ticketToRemove = TicketSalesManager.Tickets.First();
                Assert.True(TicketSalesManager.RemoveTicket(ticketToRemove));
                Assert.DoesNotContain(ticketToRemove, TicketSalesManager.Tickets);

                Assert.Equal(0, TicketSalesManager.AmountOfTickets());
            }

            [Fact]
            public void SalesTotal() {
                TicketSalesManager.Tickets.Clear();
                TicketSalesManager.AddTicket(new Ticket(7, Seated));
                TicketSalesManager.AddTicket(new Ticket(48, Standing));
                TicketSalesManager.AddTicket(new Ticket(98, Seated));
                TicketSalesManager.AddTicket(new Ticket(27, Standing));

                Assert.Equal(370, TicketSalesManager.SalesTotal());
            }
        }
    }
}