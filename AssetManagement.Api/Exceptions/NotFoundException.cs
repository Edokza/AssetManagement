using System.Net;

namespace AssetManagement.Api.Exceptions
{
    public class NotFoundException : AppException
    {
        public NotFoundException(string message) : base(message, (int)HttpStatusCode.NotFound)
        {

        }
    }
}
