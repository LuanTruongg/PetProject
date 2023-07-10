using AutoBiker.Database.Entities;
using AutoBiker.ViewModel.Account;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace AutoBiker.BackEnd_Apis.Repositories.Account
{
    public interface IAccountRepository
    {
        Task<SignInResult> PassSignInAsync(LoginViewModel user);
        Task<AppUser> FindUserByUserName(string username);
        Task<IList<string>> GetListRole(AppUser user);
        Task<List<AppUser>> GetListUsersAsync();
        Task<AppUser> FindByUserNameAsync(string username);
        Task<IdentityResult> CreateUserAsync(AppUser user, string password);
        Task<IdentityResult> SetRoleUserAsync(AppUser user, string role);
        Task<bool> GetRoleUserAsync(AppUser user, string role);
        Task<AppUser> GetUserByIdAsync(string id);
        Task<IdentityResult> UpdateUserAsync(AppUser user);
        Task<IdentityResult> DeleteUserAsync(AppUser user);
        Task<IdentityResult> DeleteUserRoleAsync(AppUser user, string roleId);
    }
}
