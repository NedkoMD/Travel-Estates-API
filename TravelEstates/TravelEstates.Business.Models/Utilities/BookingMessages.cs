namespace TravelEstates.Business.Models.Utilities
{
    public static class BookingMessages
    {
        public const string BookingNotFound = "Booking not found.";
        public const string BookingNotFoundForUser = "There are no bookings for this user.";

        public const string RentPropertyIdRequired = "RentPropertyId is required.";

        public const string UserIdRequired = "UserId field is required.";
        public const string UserNotFound = "User not found.";

        public const string CheckInDateName = "Check-In Date";
        public const string CheckInDateRequired = "Check-In Date is required.";
        public const string CheckInDateNotBeforeCheckOutDate = "CheckInDate must be before CheckOutDate.";

        public const string CheckOutDateName = "Check-Out Date";
        public const string CheckOutDateRequired = "Check-Out Date is required.";
    }
}
