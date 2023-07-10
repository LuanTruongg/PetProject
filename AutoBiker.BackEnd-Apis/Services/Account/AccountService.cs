using AutoBiker.BackEnd_Apis.Repositories.Account;
using AutoBiker.Database.Entities;
using AutoBiker.ViewModel.Account;
using AutoBiker.ViewModel.ApiResult.ApiUserResult;
using AutoBiker.ViewModel.Request;
using AutoBiker.ViewModel.Request.Account;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AutoBiker.BackEnd_Apis.Services.Account
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IConfiguration _configuration;

        public AccountService(IAccountRepository accountRepository, IConfiguration configuration)
        {
            _accountRepository = accountRepository;
            _configuration = configuration;
        }


        public async Task<string> LoginAccount(LoginViewModel loginViewModel)
        {
            var result = await _accountRepository.PassSignInAsync(loginViewModel);
            if(!result.Succeeded)
                return string.Empty;

            var user = await _accountRepository.FindUserByUserName(loginViewModel.Username);

            var roles = await _accountRepository.GetListRole(user);

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.GivenName, user.FirstName),
                new Claim(ClaimTypes.Role, string.Join(";",roles)),
            };

            var authKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]!));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddMinutes(20),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authKey, SecurityAlgorithms.HmacSha512)
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<List<AppUser>> GetListUsersAsync()
        {
            return await _accountRepository.GetListUsersAsync();
        }

        public async Task<UserResult> AddUserAsync(AddUserRequest user)
        {
            var userExist = await _accountRepository.FindUserByUserName(user.UserName);
            if (userExist != null)
                return new UserResult("UserName does exist");
            else
            {
                var newUser = new AppUser()
                {
                    UserName = user.UserName,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    CIC = user.CIC,
                    PhoneNumber = user.PhoneNumber,
                };
                try
                {
                    await _accountRepository.CreateUserAsync(newUser, user.Password);
                    return new UserResult(newUser);
                }
                catch (Exception ex)
                {
                    return new UserResult($"Cannot create new user: {ex.Message}");
                }
            }
            
        }

        public async Task<UserResult> SetRoleUserAsync(AppUser user, string role)
        {
            try
            {
                await _accountRepository.SetRoleUserAsync(user, role);
                return new UserResult(user);
            }
            catch (Exception ex)
            {
                return new UserResult($"Cannot set role for user: {ex.Message}");
            }
        }

        public async Task<AppUser> GetUserByIdAsync(string id)
        {
            return await _accountRepository.GetUserByIdAsync(id);
        }

        public async Task<bool> GetUserRoleAsync(string id)
        {
            var user = await _accountRepository.GetUserByIdAsync(id);
            var checkroleAdmin = await _accountRepository.GetRoleUserAsync(user, "Admin");
            var checkroleStaff = await _accountRepository.GetRoleUserAsync(user, "Staff");
            var checkroleCus = await _accountRepository.GetRoleUserAsync(user, "Customer");
            if (checkroleAdmin)
                return false;
            if (checkroleStaff)
                return false;
            if (checkroleCus)
                return false;
            return true;
        }

        public async Task<UserResult> UpdateUserAsync(UpdateUserRequest user, string id)
        {
            var editUser = await _accountRepository.GetUserByIdAsync(id);
            if (editUser == null)
                return new UserResult("Account does not exist");
            else
            {
                editUser.FirstName = user.FirstName;
                editUser.LastName = user.LastName;
                editUser.Email = user.Email;
                editUser.PhoneNumber = user.PhoneNumber;
                editUser.CIC = user.CIC;
                try
                {
                    await _accountRepository.UpdateUserAsync(editUser);
                    return new UserResult(editUser);
                } catch (Exception ex)
                {
                    return new UserResult($"Error: {ex.Message}");
                }
            }
            
        }

        public async Task<UserResult> DeleteUserAsync(string id)
        {
            var user = await _accountRepository.GetUserByIdAsync(id);
            if (user == null)
                return new UserResult($"User with Id: {id} does not exist");
            try
            {
                await _accountRepository.DeleteUserAsync(user);
                return new UserResult(user);
            } catch (Exception ex)
            {
                return new UserResult($"Error: {ex.Message}");
            }
        }
    }
}
