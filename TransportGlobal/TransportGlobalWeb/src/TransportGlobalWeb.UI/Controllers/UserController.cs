using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TransportGlobalWeb.UI.ApiClients;
using TransportGlobalWeb.UI.Models.RequestModels;
using TransportGlobalWeb.UI.Models.ResponseModels;

namespace TransportGlobalWeb.UI.Controllers
{
    public class UserController : Controller
    {
        private readonly UserContextClient _userContextClient;

        public UserController(UserContextClient userContextClient)
        {
            _userContextClient = userContextClient;
        }

        // Login işlemi için
        public IActionResult Login()
        {
            // Giriş ekranının view'ını döndür
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginRequestModel loginRequestModel)
        {
            ApiResponseModel<LoginResponseModel>? apiResponse = _userContextClient.Login(loginRequestModel);
            if (apiResponse?.Data == null)
            {
                return ReturnWithMessage(apiResponse?.Messages);
            }
            else
            {
                LoginResponseModel loginResponse = JsonConvert.DeserializeObject<LoginResponseModel>(apiResponse.Data!.ToString()!)!;
                // cache login response

                return RedirectToAction("index", "home");
            }
        }

        // Kayıt işlemi için
        public IActionResult Register()
        {
            // Kayıt ekranının view'ını döndür
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterRequestModel registerRequestModel)
        {
            // Yeni kullanıcıyı kaydet
            // Başarılıysa giriş yapılmasını sağla ve yönlendirme yap
            // Hata varsa hata mesajını göster

            List<string>? messages = _userContextClient.Register(registerRequestModel);
            return ReturnWithMessage(messages);
        }

        private IActionResult ReturnWithMessage(List<string>? messages)
        {
            ViewBag.Message = string.Join(Environment.NewLine, messages ?? new List<string>() { "An unknown error occurred!" });
            return View();
        }
    }
}
