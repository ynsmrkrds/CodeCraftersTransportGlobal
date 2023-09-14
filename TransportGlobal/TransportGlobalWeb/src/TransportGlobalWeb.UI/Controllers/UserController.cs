using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TransportGlobalWeb.UI.ApiClients;
using TransportGlobalWeb.UI.Enums;
using TransportGlobalWeb.UI.Enums.UserContextEnums;
using TransportGlobalWeb.UI.Extensions.Attributes;
using TransportGlobalWeb.UI.Helpers;
using TransportGlobalWeb.UI.Models.ConstantModels;
using TransportGlobalWeb.UI.Models.CookieModels;
using TransportGlobalWeb.UI.Models.RequestModels;
using TransportGlobalWeb.UI.Models.ResponseModels;

namespace TransportGlobalWeb.UI.Controllers
{
    public class UserController : BaseController
    {
        private readonly UserContextClient _userContextClient;

        public UserController(UserContextClient userContextClient)
        {
            _userContextClient = userContextClient;
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(LoginRequestModel loginRequestModel)
        {
            ApiResponseModel<LoginResponseModel>? apiResponse = _userContextClient.Login(loginRequestModel);

            IActionResult onData()
            {
                string token = apiResponse!.Data!.Token;
                DateTime tokenExpiryDate = TokenHelper.GetTokenExpiryDate(token);
                UserType userType = TokenHelper.GetUserType(token);

                UserCookieModel userCookie = new(token, userType);

                bool isSuccess = CookieHelper.SetCookie(CookieKey.User, userCookie.ToJson(), tokenExpiryDate);
                if (isSuccess == false) return ReturnWithError(new ExceptionConstantModel("An error occurred in the login process!"));

                return RedirectToAction("index", "home");
            }

            return CreateActionResult(apiResponse, onData);
        }

        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Register(RegisterRequestModel registerRequestModel)
        {
            ApiResponseModel<NonDataResponseModel>? apiResponse = _userContextClient.Register(registerRequestModel);

            return CreateActionResult(apiResponse, null);
        }

        public IActionResult Profile()
        {
            ApiResponseModel<GetProfileResponseModel>? apiResponse = _userContextClient.GetProfile();

            IActionResult onData()
            {
                return View(apiResponse!.Data!);
            }

            return CreateActionResult(apiResponse, onData);
        }

        public IActionResult UpdateProfile()
        {
            ApiResponseModel<GetProfileResponseModel>? apiResponse = _userContextClient.GetProfile();

            IActionResult onData()
            {
                UpdateProfileRequestModel requestModel = new()
                {
                    Name = apiResponse!.Data!.Name,
                    Surname = apiResponse!.Data!.Surname
                };
                return View(requestModel);
            }

            return CreateActionResult(apiResponse, onData);
        }

        [HttpPost]
        public IActionResult UpdateProfile(UpdateProfileRequestModel updateProfileRequestModel)
        {
            ApiResponseModel<NonDataResponseModel>? apiResponse = _userContextClient.UpdateProfile(updateProfileRequestModel);

            return CreateActionResult(apiResponse, null, updateProfileRequestModel);
        }

        public IActionResult UpdatePassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UpdatePassword(UpdatePasswordRequestModel updatePasswordRequestModel)
        {
            ApiResponseModel<NonDataResponseModel>? apiResponse = _userContextClient.UpdatePassword(updatePasswordRequestModel);

            return CreateActionResult(apiResponse, null);
        }
    }
}
