using Microsoft.AspNetCore.Mvc;
using TransportGlobalWeb.UI.Extensions.Attributes;
using TransportGlobalWeb.UI.Models.ConstantModels;
using TransportGlobalWeb.UI.Models.ResponseModels;

namespace TransportGlobalWeb.UI.Controllers
{
    [CheckExpirationFilter]
    public class BaseController : Controller
    {
        [NonAction]
        public IActionResult CreateActionResult<T>(ApiResponseModel<T>? apiResponse, Func<IActionResult>? onData, object? model = null, string? actionName = null, string? controllerName = null) where T : BaseResponseModel
        {
            IActionResult actionResult;

            if (apiResponse?.Data != null)
            {
                if (onData == null) throw new ArgumentNullException(nameof(onData));
                actionResult = onData();
            }
            else if (apiResponse?.Response != null)
            {
                actionResult = ReturnWithResponseConstant(apiResponse.Response, model, actionName);
            }
            else if (apiResponse?.Errors != null)
            {
                actionResult = ReturnWithError(apiResponse.Errors, model, actionName);
            }
            else
            {
                actionResult = ReturnWithError(new ExceptionConstantModel("An unknown error occurred!"), model, actionName);
            }

            ModelState.Clear();
            return actionResult;
        }

        public IActionResult ReturnWithResponseConstant(ResponseConstantModel responseConstant, object? model = null, string? actionName = null, string? controllerName = null)
        {
            ViewBag.ResponseConstant = responseConstant;
            if (actionName != null) return RedirectToAction(actionName, controllerName, model);

            return View(model);
        }

        public IActionResult ReturnWithError(ExceptionConstantModel exception, object? model = null, string? actionName = null, string? controllerName = null)
        {
            ViewBag.Error = exception.Message;
            if (actionName != null) return RedirectToAction(actionName, controllerName, model);

            return View(model);
        }

        public IActionResult ReturnWithError(List<ExceptionConstantModel> exceptions, object? model, string? actionName = null, string? controllerName = null)
        {
            ViewBag.Error = string.Join(Environment.NewLine, exceptions.Select(x => x.Message));
            if (actionName != null) return RedirectToAction(actionName, controllerName, model);

            return View(model);
        }
    }
}
