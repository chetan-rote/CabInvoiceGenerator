using NUnit.Framework;
using CabInvoiceGenerater;

namespace CabInvoiceTests
{
    public class CabInvoiceGeneratorTest
    {
        /// Initialising the instance of the Invoice generator class and assigning a null value to its reference
        public InvoiceGenerator invoiceGenerator = null;
        /// <summary>
        /// UC1
        /// Givens the distance and time should return fare.
        /// </summary>
        [Test]
        public void GivenDistanceAndTime_Should_Return_Fare()
        {
            ///Arrange
            double distance = 5; //in km
            int time = 20;   //in minutes
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            ///Act
            double fare = invoiceGenerator.CalculateFare(distance, time);
            ///Assert
            Assert.AreEqual(70, fare);
        }
        /// <summary>
        /// UC1
        /// Givens the invalid distance should throw invalid distance exception.
        /// </summary>
        [Test]
        public void GivenInvalidDistance_Should_Throw_InvalidDistanceException()
        {
            ///Arrange
            double distance = -5; //in km
            int time = 20;   //in minute
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            ///Act
            var exception = Assert.Throws<CabInvoiceException>(() => invoiceGenerator.CalculateFare(distance, time));
            ///Assert
            Assert.AreEqual(CabInvoiceException.ExceptionType.INVALID_DISTANCE, exception.exceptionType);
        }
        /// <summary>
        /// UC1
        /// Givens the invalid time should throw invalid time exception.
        /// </summary>
        [Test]
        public void GivenInvalidTime_Should_Throw_InvalidTimeException()
        {
            ///Arrange
            double distance = 5; //in km
            int time = -20;   //in minute
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            ///Act
            var exception = Assert.Throws<CabInvoiceException>(() => invoiceGenerator.CalculateFare(distance, time));
            ///Assert
            Assert.AreEqual(CabInvoiceException.ExceptionType.INVALID_TIME, exception.exceptionType);
        }
        /// <summary>
        /// UC-2&3. 
        /// Givens the multiple rides should return number of ride aggregate fare and average fare.
        /// </summary>
        [Test]
        public void GivenMultipleRides_Should_Return_NumberOfRide_AggregateFareAndAverageFare()
        {
            ///Arrange
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2.0, 9), new Ride(0.1, 1), new Ride(0.2, 1) };
            ///Act
            InvoiceSummary invoiceSummary = invoiceGenerator.CalculateFare(rides);
            var result = invoiceSummary.GetHashCode();
            InvoiceSummary expectedSummary = new InvoiceSummary(3, 39.0, 13.0);
            var resultExpectedHashCode = expectedSummary.GetHashCode();
            ///Assert
            Assert.AreEqual(invoiceSummary, expectedSummary);
        }
        /// <summary>
        /// UC4
        /// Given the user id, invoice service gets list of rides and returns invoice summary.
        /// </summary>
        [Test]
        public void GivenUserId_InvoiceServiceGetsListOfRides_ShouldReturnInvoiceSummary()
        {
            /// Arrange             
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            RideRepository repository = new RideRepository();
            string userId = "101";
            Ride[] rides = { new Ride(2.0, 9), new Ride(0.1, 1), new Ride(0.2, 1) };
            repository.AddRide(userId, rides);
            ///Act
            Ride[] rideData = repository.GetRides(userId);
            InvoiceSummary invoiceSummary = invoiceGenerator.CalculateFare(rideData);
            InvoiceSummary expectedInvoiceSummary = new InvoiceSummary(3, 39.0, 13.0);
            /// Assert
            Assert.AreEqual(expectedInvoiceSummary, invoiceSummary);
        }
        /// <summary>
        /// UC5
        /// Given Distance And Time Should Return TotalFare For PremiumRide.
        /// </summary>
        [Test]
        public void GivenDistanceAndTime_Should_Return_TotalFareForPremiumRide()
        {
            ///Arrange
            double distance = 10;
            int time = 10;
            double expected = 170;
            ///Act
            this.invoiceGenerator = new InvoiceGenerator(RideType.PREMIUM);
            double actual = invoiceGenerator.CalculateFare(distance, time);
            ///Assert
            Assert.AreEqual(expected, actual);
        }
    }
}