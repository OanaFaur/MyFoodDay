using Microsoft.AspNetCore.Identity;
using MyFoodDay.Models;
using System.Threading.Tasks;

namespace MyFoodDay.Data
{
    public interface IAccountRepository
    {
        Task<IdentityResult> CreateUserAsync(SignUpUserModel userModel);
        Task<SignInResult> PasswordSignInAsync(SignInUser signInModel);
        Task SignOutAsync();
        Task<UserAdditionalInfo> GetUserAdditionalInfoByEmail(string email);

        void CreateUserAdditionalInfoAsync(string email);

        Task<UserAdditionalInfo> EditUserAdditionLInfo(string email, UserAdditionalInfo newInfo);
    }
}
