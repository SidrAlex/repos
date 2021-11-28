using System;
using Microsoft.AspNetCore.Mvc;
using UserRegistrationApp.BusinessLogic.Operations;
using UserRegistrationApp.EFEntity.Models;

namespace UserRegistrationApp.Controllers
{
    // TODO: Add update operations
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            var result = _userService.Delete(id);

            return RedirectToAction("Index", "Home", new { id = result });
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            var validationResult = _userService.AdditionalValidation(user);
            foreach (var (field, message) in validationResult)
            {
                ModelState.AddModelError(field, message);
            }
    
            if (ModelState.IsValid)
            {
                var result = _userService.Create(user);

                return RedirectToAction("Index", "Home", new { id = result });
            }

            return View(user);
        }
    }
}
