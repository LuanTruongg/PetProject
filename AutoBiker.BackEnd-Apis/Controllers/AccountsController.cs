using AutoBiker.BackEnd_Apis.Services.Account;
using AutoBiker.Database.Entities;
using AutoBiker.ViewModel.Request;
using AutoBiker.ViewModel.Request.Account;
using AutoBiker.ViewModel.Resource;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AutoBiker.BackEnd_Apis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public AccountsController(IAccountService accountService, IMapper mapper)
        {
            _accountService = accountService;
            _mapper = mapper;
        }
        // GET: api/<AccountsController>
        [Authorize(Roles = "Admin , Staff")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var listUsers = await _accountService.GetListUsersAsync();
            var listUsersResource = _mapper.Map<List<AppUser>, List<UserResource>>(listUsers);
            return Ok(listUsersResource);
        }

        // GET api/<AccountsController>/5
        [Authorize(Roles = "Admin , Staff")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var User = await _accountService.GetUserByIdAsync(id);
            var UsesResource = _mapper.Map<AppUser, UserResource>(User);
            return Ok(UsesResource);
        }
        // POST api/<AccountsController>
        [Authorize(Roles = "Admin")]
        [Authorize(Roles = "Staff")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddUserRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _accountService.AddUserAsync(request);
            if (result.Success)
            {
                //await _accountService.SetRoleUserAsync(result.user, "Staff");
                return Ok(result.user);
            } 
            return BadRequest("Error");
        }
        [Authorize(Roles = "Admin")]
        [HttpPost("staff-role-assign/{id}")]
        public async Task<IActionResult> StaffRoleAssign(string id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var user = await _accountService.GetUserByIdAsync(id);
            if (user == null)
                return NotFound();
            var checkRoleEmpty = await _accountService.GetUserRoleAsync(id);
            if (!checkRoleEmpty)
                return BadRequest();
            await _accountService.SetRoleUserAsync(user, "Staff");
            return Ok();
        }
        [Authorize(Roles = "Admin , Staff")]
        [HttpPost("customer-role-assign/{id}")]
        public async Task<IActionResult> CustomerRoleAssign(string id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var user = await _accountService.GetUserByIdAsync(id);
            if (user == null)
                return NotFound();
            var checkRoleEmpty = await _accountService.GetUserRoleAsync(id);
            if (!checkRoleEmpty)
                return BadRequest();
            await _accountService.SetRoleUserAsync(user, "Customer");
            return Ok(); ;
        }

        // PUT api/<AccountsController>/5
        [Authorize(Roles = "Admin , Staff")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] UpdateUserRequest request )
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _accountService.UpdateUserAsync(request, id);
            if (result.Success)
            {
                //await _accountService.SetRoleUserAsync(result.user, "Staff");
                return Ok(result.user);
            }
            return BadRequest("Error");
        }
        [Authorize(Roles = "Admin")]
        // DELETE api/<AccountsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _accountService.DeleteUserAsync(id);
            return Ok(result);
        }
    }
}
