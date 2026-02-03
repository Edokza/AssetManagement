using System.Net;

namespace AssetManagement.Api.Exceptions
{
    public class BadRequestException : AppException
    {
        public BadRequestException(string message) : base(message, (int)HttpStatusCode.BadRequest)
        {
        }
    }
}
