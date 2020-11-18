using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerater
{
    public class InvoiceGenerator
    {
        /// Declaring the object of the class RideType so as to differentiate the data attributes as time and distance.
        public RideType rideType;
        /// Read-Only attributes acting as constant variable.
        private readonly double MINIMUM_COST_PER_KM;
        private readonly int COST_PER_TIME;
        private readonly double MINIMUM_FARE;
        /// <summary>
        /// Parameterized Constructor.
        /// </summary>
        /// <param name="rideType">Type of the ride.</param>
        public InvoiceGenerator(RideType rideType)
        {
            this.rideType = rideType;
            this.MINIMUM_COST_PER_KM = 10;
            this.COST_PER_TIME = 1;
            this.MINIMUM_FARE = 5;
        }
        /// <summary>
        /// Method to Compute the total fare of the cab journey when passed with distance and time.
        /// </summary>
        /// <param name="distance">The distance.</param>
        /// <param name="time">The time.</param>
        /// <returns></returns>
        /// <exception cref="CabInvoiceException">
        /// Invalid ride type
        /// or
        /// Invalid distance
        /// or
        /// Invalid time
        /// </exception>
        public double CalculateFare(double distance, int time)
        {
            double totalFare = 0;
            totalFare = distance * MINIMUM_COST_PER_KM + time * COST_PER_TIME;
            /// Checks if the ride is null. If ride is null will throw exception
            if (rideType.Equals(null))
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_RIDE_TYPE, "Invalid ride type");
            }
            /// Checks if distance is less than zero if distance is zero will throw exception.
            if (distance <= 0)
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_DISTANCE, "Invalid distance");
            }
            /// Checks if time is less than zero if time is zero will throw exception.
            if (time <= 0)
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_TIME, "Invalid time");
            }
            /// Returns the max value.
            return Math.Max(totalFare, MINIMUM_FARE);
        }
    }
}
