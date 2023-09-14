using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TransportGlobalWeb.UI.Enums;
using TransportGlobalWeb.UI.Helpers;
using TransportGlobalWeb.UI.Models.ViewModels;

namespace TransportGlobalWeb.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            bool isTokenExist = CookieHelper.GetCookie(CookieKey.User) != null;
            if (isTokenExist) return View();

            return RedirectToAction("Login", "User");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}