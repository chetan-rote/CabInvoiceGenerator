using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerater
{
    public class CabInvoiceException : Exception
    {
        /// <summary>
        /// Exception enum to denote different exceptions.
        /// </summary>
        public enum ExceptionType
        {
            INVALID_RIDE_TYPE,
            INVALID_DISTANCE,
            INVALID_TIME,
            NULL_RIDES,
            INVALID_USER_ID
        }
        public ExceptionType exceptionType;
        /// <summary>
        /// Parameterised constructor to override the base class message.
        /// </summary>
        /// <param name="exceptionType">Type of the exception.</param>
        /// <param name="message">The message.</param>
        public CabInvoiceException(ExceptionType exceptionType, string message) : base(message)
        {
            this.exceptionType = exceptionType;
        }
    }
}
