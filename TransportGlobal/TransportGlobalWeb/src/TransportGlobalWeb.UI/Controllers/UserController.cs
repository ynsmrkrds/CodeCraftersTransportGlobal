﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TransportGlobalWeb.UI.ApiClients.UserContextApiClients;
using TransportGlobalWeb.UI.Enums;
using TransportGlobalWeb.UI.Enums.UserContextEnums;
using TransportGlobalWeb.UI.Helpers;
using TransportGlobalWeb.UI.Models.ConstantModels;
using TransportGlobalWeb.UI.Models.CookieModels;
using TransportGlobalWeb.UI.Models.RequestModels.UserContextRequestModels.User;
using TransportGlobalWeb.UI.Models.ResponseModels;
using TransportGlobalWeb.UI.Models.ResponseModels.UserResponseModels.User;
using TransportGlobalWeb.UI.Models.ViewModels.UserContextViewModels;

namespace TransportGlobalWeb.UI.Controllers
{
    public class UserController : BaseController
    {
        private readonly UserClient _userClient;

        public UserController(UserClient userClient)
        {
            _userClient = userClient;
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
            ApiResponseModel<LoginResponseModel>? apiResponse = _userClient.Login(loginRequestModel);

            IActionResult onData()
            {
                string token = apiResponse!.Data!.Token;
                DateTime tokenExpiryDate = TokenHelper.GetTokenExpiryDate(token);
                UserType userType = TokenHelper.GetUserType(token);

                UserCookieModel userCookie = new(token, userType);

                bool isSuccess = CookieHelper.SetCookie(CookieKey.User, userCookie.ToJson(), tokenExpiryDate);
                if (isSuccess == false) return ReturnWithError(new ExceptionConstantModel("An error occurred in the login process!"));

                return RedirectToAction("Index", "TransportRequest");
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
            ApiResponseModel<NonDataResponseModel>? apiResponse = _userClient.Register(registerRequestModel);

            return CreateActionResult(apiResponse, null);
        }

        public IActionResult Profile()
        {
            ApiResponseModel<UserViewModel>? apiResponse = _userClient.GetProfile();

            IActionResult onData()
            {
                return View(apiResponse!.Data!);
            }

            return CreateActionResult(apiResponse, onData);
        }

        public IActionResult UpdateProfile()
        {
            ApiResponseModel<UserViewModel>? apiResponse = _userClient.GetProfile();

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
            ApiResponseModel<NonDataResponseModel>? apiResponse = _userClient.UpdateProfile(updateProfileRequestModel);

            return CreateActionResult(apiResponse, null, updateProfileRequestModel);
        }

        public IActionResult UpdatePassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UpdatePassword(UpdatePasswordRequestModel updatePasswordRequestModel)
        {
            ApiResponseModel<NonDataResponseModel>? apiResponse = _userClient.UpdatePassword(updatePasswordRequestModel);

            return CreateActionResult(apiResponse, null);
        }

        public IActionResult Logout()
        {
            bool isSuccess = CookieHelper.RemoveCookie(CookieKey.User);
            if (isSuccess) return RedirectToAction("Login");

            throw new Exception("An error occurred in the logout process!");
        }
    }
}
