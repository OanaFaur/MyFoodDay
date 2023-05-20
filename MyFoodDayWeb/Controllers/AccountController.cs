using Microsoft.AspNetCore.Mvc;
using MyFoodDay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFoodDayWeb.Controllers
{
    public class AccountController : Controller
    {
        [Route("signup")]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(SignUpUserModel userModel)
        {
            if (ModelState.IsValid)
            {
                ModelState.Clear();
            }
            return View();
        }
    }
}
