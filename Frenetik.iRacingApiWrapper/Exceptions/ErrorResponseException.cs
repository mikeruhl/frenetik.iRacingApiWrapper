using System.Net;

namespace Frenetik.iRacingApiWrapper.Exceptions;

/// <summary>
/// Exception thrown when the iRacing API returns an error response.
/// </summary>
public class ErrorResponseException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ErrorResponseException"/> class.
    /// </summary>
    /// <param name="resultCode">The HTTP status code returned by the API</param>
    /// <param name="error">The error code or type from the API response</param>
    /// <param name="message">The error message describing what went wrong</param>
    public ErrorResponseException(HttpStatusCode resultCode, string error, string message) : base(message)
    {
        ResultCode = resultCode;
        Error = error;
    }

    /// <summary>
    /// Gets the error code or type from the API response.
    /// </summary>
    public string Error { get; } = string.Empty;

    /// <summary>
    /// Gets the HTTP status code returned by the API.
    /// </summary>
    public HttpStatusCode ResultCode { get; }
}
