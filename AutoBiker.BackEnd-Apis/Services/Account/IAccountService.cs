using AutoBiker.Database.Entities;
using AutoBiker.ViewModel.Account;
using AutoBiker.ViewModel.ApiResult.ApiUserResult;
using AutoBiker.ViewModel.Request;
using AutoBiker.ViewModel.Request.Account;

namespace AutoBiker.BackEnd_Apis.Services.Account
{
    public interface IAccountService
    {
        Task<string> LoginAccount(LoginViewModel loginViewModel);
        Task<List<AppUser>> GetListUsersAsync();
        Task<UserResult> AddUserAsync(AddUserRequest user);
        Task<UserResult> SetRoleUserAsync(AppUser user, string role);
        Task<bool> GetUserRoleAsync(string id);
        Task<AppUser> GetUserByIdAsync(string id);
        Task<UserResult> UpdateUserAsync(UpdateUserRequest user, string id);
        Task<UserResult> DeleteUserAsync(string id);
    }
}
