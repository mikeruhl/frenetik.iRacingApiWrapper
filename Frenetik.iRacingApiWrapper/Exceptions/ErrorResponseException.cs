using System.Net;

namespace Frenetik.iRacingApiWrapper.Exceptions;
public class ErrorResponseException : Exception
{
    public ErrorResponseException(HttpStatusCode resultCode, string error, string message) : base(message)
    {
        ResultCode = resultCode;
        Error = error;
    }

    public string Error { get; } = string.Empty;

    public HttpStatusCode ResultCode { get; }
}
