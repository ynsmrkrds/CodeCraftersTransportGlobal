using TransportGlobal.Domain.Models;

namespace TransportGlobal.Domain.Exceptions
{
    public class NotFoundException : BaseException
    {
        public NotFoundException(ExceptionConstantModel exceptionConstant) : base(exceptionConstant)
        {
        }
    }
}
