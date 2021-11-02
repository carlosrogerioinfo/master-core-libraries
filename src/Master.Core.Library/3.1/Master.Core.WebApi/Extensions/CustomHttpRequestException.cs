using System;
using System.Net;

namespace Master.Core.WebApi.Extensions
{
    public class CustomHttpRequestException : Exception
    {
        public HttpStatusCode StatusCode;

        public CustomHttpRequestException() { }

        public CustomHttpRequestException(string message, Exception innerException = null)
            : base(message, innerException) { }

        public CustomHttpRequestException(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
        }
    }
}
