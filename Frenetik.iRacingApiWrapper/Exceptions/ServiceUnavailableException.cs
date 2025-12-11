namespace Frenetik.iRacingApiWrapper.Exceptions
{
    /// <summary>
    /// Exception that is thrown when a service is unavailable.
    /// </summary>
    [Serializable]
    public class ServiceUnavailableException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceUnavailableException"/> class.
        /// </summary>
        public ServiceUnavailableException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceUnavailableException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public ServiceUnavailableException(string? message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceUnavailableException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public ServiceUnavailableException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}