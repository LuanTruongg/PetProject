using AutoBiker.BackEnd_Apis.Services.Account;
using AutoBiker.ViewModel.Account;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoBiker.BackEnd_Apis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public LoginController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginViewModel login)
        {
            var result = await _accountService.LoginAccount(login);
            if (string.IsNullOrEmpty(result))
                return Unauthorized();
            return Ok(result);
        }
    }
}
