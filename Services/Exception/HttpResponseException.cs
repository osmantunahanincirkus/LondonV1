using System.Net;

public class HttpResponseException : Exception
{
    public HttpResponseException(HttpStatusCode statusCode, string value) =>
        (StatusCode, Value) = ((int)statusCode, new {Message=value});

    public int StatusCode { get; }

    public object? Value { get; }
}
