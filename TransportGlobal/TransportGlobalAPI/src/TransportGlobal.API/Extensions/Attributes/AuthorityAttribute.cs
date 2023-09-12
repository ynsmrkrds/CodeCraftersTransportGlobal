using Microsoft.AspNetCore.Mvc.Filters;
using TransportGlobal.Application.Helpers;
using TransportGlobal.Domain.Constants;
using TransportGlobal.Domain.Enums.UserContextEnums;
using TransportGlobal.Domain.Exceptions;
using TransportGlobal.Domain.Models;

namespace TransportGlobal.API.Extensions.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class AuthorityAttribute : ActionFilterAttribute
    {
        private readonly List<UserType> _roles;

        public AuthorityAttribute(UserType role, params UserType[] roles)
        {
            _roles = new List<UserType>() { role };
            _roles.AddRange(roles);
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            TokenModel tokenModel = TokenHelper.Instance().DecodeTokenInRequest() ?? throw new ClientSideException(ExceptionConstants.TokenError);

            if (_roles.Contains(tokenModel.UserType) == false)
            {
                throw new ClientSideException(ExceptionConstants.NoAuthority);
            }
        }
    }
}
