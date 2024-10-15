using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Store.Service.HandleResponse;
using Store.Service.Services.UserServices;
using Store.Service.Services.UserServices.Dtos;

namespace Store.Web.Controllers
{
  
    public class AccountController : BaseController
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
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






    }
}
