using TicketOfficeAssignment;

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
            [InlineData(5, "Seated", 50)]
            [InlineData(12, "Seated", 170)]
            [InlineData(65, "Seated", 100)]
            [InlineData(5, "Standing", 25)]
            [InlineData(12, "Standing", 110)]
            [InlineData(65, "Standing", 60)]
            public void PriceSetter(int age, string place, int expectedPrice) {

                int price = TicketOffice.PriceSetter(age, place);
                Assert.Equal(expectedPrice, price);
            }

            [Theory]
            [InlineData(100, 5.66)]
            [InlineData(50, 2.83)]
            public void TaxCalculator(int price, decimal expectedTax) {

                decimal tax = TicketOffice.TaxCalculator(price);

                Assert.Equal(expectedTax, tax, 2); // Check up to 2 decimal places
            }
        }

        public class ReservationManagerTests
        {

            [Theory]
            [InlineData(",34,1003,389,4100,4890,7233,2855,", 7233, false)]  //exists in list
            [InlineData(",34,1003,389,4100,4890,7233,2855,", 9999, false)]  //number out of range
            [InlineData(",", 1, true)] // Empty list
            public void CheckPlaceAvailability(string placeList, int placeNumber, bool expectedAvailability) {

                bool isAvailable = ReservationManager.CheckPlaceAvailability(placeList, placeNumber);

                Assert.Equal(expectedAvailability, isAvailable);
            }

            [Theory]
            [InlineData(",34,1003,389,4100,4890,7233,2855,", 7777, ",34,1003,389,4100,4890,7233,2855,7777,")]
            [InlineData(",", 999, ",999,")] // Adding to an empty list
            [InlineData("", 123, ",123,")] // Adding to an empty string
            public void AddPlace(string placeList, int placeNumber, string expectedExpandedList) {

                string expandedList = ReservationManager.AddPlace(placeList, placeNumber);

                Assert.Equal(expectedExpandedList, expandedList);
            }

            [Fact]
            public void AddPlace_Overflow() {
                string initialList = ",34,1003,";
                int placeNumber = 789;
                string expectedExpandedList = ",34,1003,789,";

                string updatedList = ReservationManager.AddPlace(initialList, placeNumber);

                Assert.Equal(expectedExpandedList, updatedList);
            }
        }
    }
}