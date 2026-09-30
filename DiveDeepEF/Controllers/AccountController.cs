using DiveDeepEF.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DiveDeepEF.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult SignUp()
        {
            return View();
        }
        public IActionResult User_Profile()
        {
            return View();
        }
        public IActionResult Admin()
        {
            return View();
        }

    }
}
