using System;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;
using UserRegistrationApp.BusinessLogic.Operations;
using UserRegistrationApp.Models;

namespace UserRegistrationApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _userService;

        public HomeController(IUserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        // TODO: id need for showing additional information of last changes
        [HttpGet]
        public IActionResult Index(int id)
        {
            var users = _userService.Query().ToList();

            return View(users);
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
