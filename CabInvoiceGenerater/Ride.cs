using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerater
{
    public class Ride
    {
        /// Memeber attributes to get the drive summary.
        public double distance;
        public int time;
        /// <summary>
        /// Parameterised Constructor to initialise the instance of the ride class summary.
        /// </summary>
        /// <param name="distance">The distance.</param>
        /// <param name="time">The time.</param>
        public Ride(double distance, int time)
        {
            this.distance = distance;
            this.time = time;
        }
    }
}
