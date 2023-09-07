using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyFoodDay.Data;
using MyFoodDay.Models;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MyFoodDayWeb.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository accountRepository;
        private readonly UserManager<IdentityUser> userManager;

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
                if (!result.Succeeded)
                {
                    foreach (var errorMessage in result.Errors)
                    {
                        ModelState.AddModelError("", errorMessage.Description);
                    }
                }

                accountRepository.CreateUserAdditionalInfoAsync(userModel.Email);

                ModelState.Clear();
            }

            return RedirectToAction("Login","Account");
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
            if (ModelState.IsValid)
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

        [Route("edit")]
        public IActionResult EditAdditionalInfo()
        {
            return View();
        }

        [Route("edit")]
        [HttpPost]
        public async Task<IActionResult> EditAdditionLInfo(UserAdditionalInfo userInfo)
        {

            string userEmail = User.FindFirstValue(ClaimTypes.Email);
            await accountRepository.EditUserAdditionLInfo(userEmail, userInfo);

            return RedirectToAction("Index", "Home");
        }


        public async Task<IActionResult> Logout()
        {
            await accountRepository.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
