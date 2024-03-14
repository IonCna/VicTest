using System.Net;

namespace VicTest.Handlers;

public class ErrorHandler(HttpStatusCode code, string message) : Exception(message)
{
    public HttpStatusCode StatusCode { get; set; } = code;
    public new string Message { get; set; } = message;
}
