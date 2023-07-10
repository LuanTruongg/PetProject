using AutoBiker.Database.Entities;
using AutoBiker.ViewModel.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Security.Claims;

namespace AutoBiker.BackEnd_Apis.Repositories.Account
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountRepository(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<SignInResult> PassSignInAsync(LoginViewModel user)
        {
            return await _signInManager.PasswordSignInAsync(user.Username, user.Password, user.RememberMe, false);
        }
        public async Task<AppUser> FindUserByUserName(string username)
        {
            return await _userManager.FindByNameAsync(username);
        }
        public async Task<IList<string>> GetListRole(AppUser user)
        {
            return await _userManager.GetRolesAsync(user);
        }

        public async Task<List<AppUser>> GetListUsersAsync()
        {
           return await _userManager.Users.ToListAsync();
        }

        public async Task<AppUser> FindByUserNameAsync(string username)
        {
            return await _userManager.FindByNameAsync(username);
        }

        public async Task<IdentityResult> CreateUserAsync(AppUser user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public async Task<IdentityResult> SetRoleUserAsync(AppUser user, string role)
        {
            return await _userManager.AddToRoleAsync(user, role);
            
        }

        public async Task<AppUser> GetUserByIdAsync(string id)
        {
            return await _userManager.FindByIdAsync(id);
        }

        public async Task<bool> GetRoleUserAsync(AppUser user, string role)
        {
            var a = await _userManager.IsInRoleAsync(user, role);
            if (a) return true;
            return false;
        }

        public async Task<IdentityResult> UpdateUserAsync(AppUser user)
        {
            return await _userManager.UpdateAsync(user);
        }

        public async Task<IdentityResult> DeleteUserAsync(AppUser user)
        {
            return await _userManager.DeleteAsync(user);
        }

        public Task<IdentityResult> DeleteUserRoleAsync(AppUser user, string roleId)
        {
            throw new NotImplementedException();
        }
    }
}
