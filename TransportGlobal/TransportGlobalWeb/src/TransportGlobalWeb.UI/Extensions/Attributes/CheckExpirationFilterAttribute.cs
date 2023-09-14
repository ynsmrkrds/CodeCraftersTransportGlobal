using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TransportGlobalWeb.UI.Enums;
using TransportGlobalWeb.UI.Helpers;

namespace TransportGlobalWeb.UI.Extensions.Attributes
{
    public class CheckExpirationFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ActionDescriptor.EndpointMetadata.Any(em => em.GetType() == typeof(AllowAnonymousAttribute)) == false)
            {
                if (CookieHelper.IsCookieExists(CookieKey.User) == false)
                {
                    context.Result = new RedirectToActionResult("Login", "User", null);
                }
            }

            base.OnActionExecuting(context);
        }
    }
}
