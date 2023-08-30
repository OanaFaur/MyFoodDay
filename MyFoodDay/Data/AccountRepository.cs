using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyFoodDay.DataContext;
using MyFoodDay.Models;
using System.Threading.Tasks;

namespace MyFoodDay.Data
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<IdentityUser> userManager;

        private readonly SignInManager<IdentityUser> signInManager;

        private MyFoodContext foodContext = new MyFoodContext();

        public AccountRepository(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public async Task<IdentityResult> CreateUserAsync(SignUpUserModel userModel)
        {
            var user = new IdentityUser()
            {
                Email = userModel.Email,
                UserName = userModel.Email
            };
            var result = await userManager.CreateAsync(user, userModel.Password);

            return result;
        }

        public async Task<UserAdditionalInfo> GetUserAdditionalInfoByEmail(string email)
        {
            var user = await userManager.FindByEmailAsync(email);

            if(user == null) 
            {
                return null;
            }

            UserAdditionalInfo userAdditionalInfo = await foodContext.UserAdditionalInfo.FirstOrDefaultAsync(u => u.User.Email == user.Email);

            return userAdditionalInfo;
        }

        public async Task<SignInResult> PasswordSignInAsync(SignInUser signInUser)
        {
           var result = await signInManager.PasswordSignInAsync(signInUser.Email, signInUser.Password, signInUser.RememberMe, false);

            return result;
        }

        public async Task SignOutAsync()
        {
            await signInManager.SignOutAsync();
        }
    }
}
