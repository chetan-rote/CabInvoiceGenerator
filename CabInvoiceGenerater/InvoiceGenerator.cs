using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerater
{
    public class InvoiceGenerator
    {
        /// Declaring the object of the class RideType so as to differentiate the data attributes as time and distance.
        public RideType rideType;
        private readonly RideRepository rideRepository;
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
        /// UC-1.
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
        /// <summary>
        ///  UC2&3.
        /// Calculates the average fare for multiple rides.
        /// </summary>
        /// <param name="rides">The rides.</param>
        /// <returns></returns>
        /// <exception cref="CabInvoiceException">Rides are NULL</exception>
        public InvoiceSummary CalculateFare(Ride[] rides)
        {
            double totalFare = 0;
            double averageFare = 0;
            try
            {
                /// Iterating to find fare for every ride.
                foreach (Ride ride in rides)
                {
                    totalFare += this.CalculateFare(ride.distance, ride.time);
                }
                /// Computing average fare = (total fare/ number of rides)
                averageFare = (totalFare / rides.Length);
            }
            catch (CabInvoiceException)
            {
                /// Checks for the ride if it's null will throw exception.
                if (rides == null)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.NULL_RIDES, "Rides are NULL");
                }
            }
            /// Returns number of rides and the total fare.
            return new InvoiceSummary(rides.Length, totalFare, averageFare);
        }
        /// <summary>
        /// UC4
        /// Method to add the Customer info to the ride repository as a dictionary with key as UserID and value as ride history
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="rides"></param>
        public void AddRides(string userID, Ride[] rides)
        {
            /// Exception handling for null rides
            /// While adding the data to the dictionary with use Id and ride history
            try
            {
                /// Calling the Add ride method of Ride Repository class
                rideRepository.AddRide(userID, rides);
            }
            catch (CabInvoiceException)
            {
                /// Returning the custom exception in case the rides are null
                if (rides == null)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.NULL_RIDES, "Rides passed are null..");
                }
            }
        }
        /// <summary>
        /// Method to return the invoice summary when passed with user ID
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public InvoiceSummary GetInvoiceSummary(string userId)
        {
            try
            {
                return this.CalculateFare(rideRepository.GetRides(userId));
            }
            catch (CabInvoiceException)
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_USER_ID, "Invalid user id");
            }
        }
    }
}
