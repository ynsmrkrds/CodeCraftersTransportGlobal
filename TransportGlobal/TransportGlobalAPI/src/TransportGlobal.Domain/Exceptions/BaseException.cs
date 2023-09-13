using TransportGlobal.Domain.Models;

namespace TransportGlobal.Domain.Exceptions
{
    public abstract class BaseException : Exception
    {
        protected BaseException(ExceptionConstantModel exceptionConstant) : base(exceptionConstant.Message)
        {
        }
    }
}
