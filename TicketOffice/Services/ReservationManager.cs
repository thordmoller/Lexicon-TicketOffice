using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TicketOfficeAssignment
{
    /// <summary>
    /// This class keeps tracks of the ticket reservation methods tied to optional assignment 2
    /// </summary>
    public static class ReservationManager
    {
        private static string reservationList;  //keeping the reservation list as a field so we can build on it without forgetting the list

        public static string ReservationList
        {
            get { return reservationList; }
        }

        static ReservationManager() {
            reservationList = ",";    //list starts with comma
        }

        /// <summary>
        /// Since i wanted this method to work a little differently im adding my own spin to it, by updating the reservationlist as a field instead of inputting and returning
        /// However, i'm keeping the assignment version in its intended state by overloading this method below.
        /// </summary>
        public static void AddPlace(int placeNumber) {

            reservationList = UpdatePlaceList(reservationList, placeNumber);
        }

        /// <summary>
        /// In this overloaded version it works as stated in the assignment and can be used if the extra placelist parameter is provided. 
        /// Also reusing logic check of UpdatePlaceList in both
        /// </summary>
        public static string AddPlace(string placeList, int placeNumber) {

            if(placeList == "")
                placeList = ",";

            placeList = UpdatePlaceList(placeList, placeNumber);

            return placeList;
        }

        private static string UpdatePlaceList(string placeList, int placeNumber) {
            if(CheckPlaceAvailability(placeList, placeNumber) && isValidListFormat(placeList)) {
                placeList += placeNumber + ",";
            }
            return placeList;
        }

        /// <summary>
        /// Validates the format of the reservationlist
        /// </summary>
        private static bool isValidListFormat(string placeList) {

            //According to the example, i assume the list should start and end with a comma
            if(!placeList.StartsWith(",") && !placeList.EndsWith(",")) {
                return false;
            }

            if(placeList != ",") {
                placeList = placeList.Trim(',');
                string[] numbers = placeList.Split(',');
                foreach(string number in numbers) {
                    if(!int.TryParse(number, out int intNumber)) {  //if the list contains something that can't be parsed into an int, it shouldn't be used.
                        return false;
                    }
                }
            }
            return true;
        }

        public static bool CheckPlaceAvailability(string placeList, int placeNumber) {

            string search = "," + placeNumber.ToString() + ",";

            if(isValidPlaceNumber(placeNumber))
                if(!placeList.Contains(search) || placeList == ",")
                    return true;

            return false;
        }

        private static bool isValidPlaceNumber(int placeNumber) {
            if(placeNumber >= 1 && placeNumber <= 8000)
                return true;
            return false;
        }
    }
}
