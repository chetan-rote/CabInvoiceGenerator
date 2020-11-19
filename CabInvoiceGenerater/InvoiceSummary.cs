using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerater
{
    public class InvoiceSummary
    {
        private int numberOfRides;
        private double totalFare;
        private double averageFare;
        /// <summary>
        /// Initializes a new instance of the <see cref="InvoiceSummary"/> class.
        /// </summary>
        /// <param name="numberOfRides">The number of rides.</param>
        /// <param name="totalFare">The total fare.</param>
        public InvoiceSummary(int numberOfRides, double totalFare)
        {
            this.numberOfRides = numberOfRides;
            this.totalFare = totalFare;
            this.averageFare = this.totalFare / this.numberOfRides;
        }
        /// <summary>
        /// Over riding the Equals method so as to match the value of the object references
        /// Default Equals method comapre the reference of the objects and not the values.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (!(obj is InvoiceSummary)) return false;
            InvoiceSummary inputedObject = (InvoiceSummary)obj;
            return ((this.numberOfRides == inputedObject.numberOfRides) && (this.totalFare == inputedObject.totalFare) && (this.averageFare == inputedObject.averageFare));
        }
        /// <summary>
        /// Returns a hash code for this instance.
        /// Overriding equals method require overriding the GetHashCode method too else we get a compiler warning.
        /// </summary>
        public override int GetHashCode()
        {
            return this.numberOfRides.GetHashCode() ^ this.totalFare.GetHashCode() ^ this.averageFare.GetHashCode();
        }
    }
}
