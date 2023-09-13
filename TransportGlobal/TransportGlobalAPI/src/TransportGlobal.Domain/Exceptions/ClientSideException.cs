using TransportGlobal.Domain.Models;

namespace TransportGlobal.Domain.Exceptions
{
    public class ClientSideException : BaseException
    {
        public ClientSideException(ExceptionConstantModel exceptionConstant) : base(exceptionConstant)
        {
        }
    }
}
