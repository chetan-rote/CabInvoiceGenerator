using NUnit.Framework;
using CabInvoiceGenerater;

namespace CabInvoiceTests
{
    public class CabInvoiceGeneratorTest
    {
        /// Initialising the instance of the Invoice generator class and assigning a null value to its reference
        public InvoiceGenerator invoiceGenerator= null;
        /// <summary>
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
            Assert.AreEqual(CabInvoiceException.ExceptionType.INVALID_TIME, exception.exceptionType );
        }        
    }
}