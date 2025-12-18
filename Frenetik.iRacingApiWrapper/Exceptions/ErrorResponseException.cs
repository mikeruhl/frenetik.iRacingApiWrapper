using System.Net;

namespace Frenetik.iRacingApiWrapper.Exceptions;

/// <summary>
/// Exception thrown when the iRacing API returns an error response
/// </summary>
public class ErrorResponseException : Exception
{
    /// <summary>
    /// Creates a new instance of ErrorResponseException
    /// </summary>
    /// <param name="resultCode">HTTP status code from the error response</param>
    /// <param name="error">Error code from the API</param>
    /// <param name="message">Error message from the API</param>
    public ErrorResponseException(HttpStatusCode resultCode, string error, string message) : base(message)
    {
        ResultCode = resultCode;
        Error = error;
    }

    /// <summary>
    /// Error code from the API response
    /// </summary>
    public string Error { get; } = string.Empty;

    /// <summary>
    /// HTTP status code from the response
    /// </summary>
    public HttpStatusCode ResultCode { get; }
}
