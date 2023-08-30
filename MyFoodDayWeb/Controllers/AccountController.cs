using Microsoft.AspNetCore.Mvc;
using MyFoodDay.Data;
using MyFoodDay.Models;
using System.Threading.Tasks;

namespace MyFoodDayWeb.Controllers
{
    public class AccountController : Controller
    {
        IAccountRepository accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;   
        }

        [Route("signup")]
        public IActionResult SignUp()
        {
            return View();
        }

        [Route("signup")]
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpUserModel userModel)
        {
            if (ModelState.IsValid)
            {

                var result = await accountRepository.CreateUserAsync(userModel);
                if(!result.Succeeded)
                {
                    foreach(var errorMessage in result.Errors)
                    {
                        ModelState.AddModelError("", errorMessage.Description);
                    }
                }
                ModelState.Clear();
            }
            return View();
        }

        [Route("login")]
        public IActionResult Login()
        {
            return View();
        }

        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login(SignInUser signInUser)
        {
            if(ModelState.IsValid)
            {
                var result = await accountRepository.PasswordSignInAsync(signInUser);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Invalid credentials");
            }

            return View(signInUser);
        }

        public async Task<IActionResult> Logout()
        {
            await accountRepository.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
