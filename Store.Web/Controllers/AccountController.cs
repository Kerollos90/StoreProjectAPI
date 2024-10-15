using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Store.Data.Entites.identityAppUser;
using Store.Service.HandleResponse;
using Store.Service.Services.UserServices;
using Store.Service.Services.UserServices.Dtos;
using System.Security.Claims;

namespace Store.Web.Controllers
{
  
    public class AccountController : BaseController
    {
        private readonly IUserService _userService;
        private readonly UserManager<AppUser> _userManager;

        public AccountController(IUserService userService , UserManager<AppUser> userManager)
        {
            _userService = userService;
            _userManager = userManager;
        }


        [HttpPost]
        public async Task<ActionResult<UserDto>> LogIn(LoginDto login)
        { 
            var user = await _userService.Login(login);
            if (user == null)
                return BadRequest(new CustomExeption(408, "Email Does Not Exist"));

            return Ok(user);
        
        
        }


        [HttpPost]
        public async Task<ActionResult<UserDto>> Register(RegisterDto login)
        {
            var user = await _userService.Register(login);
            if (user == null)
                return BadRequest(new CustomExeption(408, "Email Already Exist"));

            return Ok(user);


        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<UserDto>> GetUser()
        {
            var userId = User?.FindFirst(ClaimTypes.Email);


            var user = await _userManager.FindByEmailAsync(userId.Value);


            return new UserDto
            {
                Id = Guid.Parse(user.Id),
                DisplayName = user.DisplayName,
                Email = user.Email,
                


            };


        }





    }
}
