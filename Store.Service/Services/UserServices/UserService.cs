using Microsoft.AspNetCore.Identity;
using Store.Data.Entites.identityAppUser;
using Store.Service.Services.TokenServices;
using Store.Service.Services.UserServices.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Service.Services.UserServices
{
    public class UserService : IUserService
    {



        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;

        public UserService(UserManager<AppUser> userManager ,
            SignInManager<AppUser> signInManager ,
            ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }


        public async Task<UserDto> Login(LoginDto input)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(input.Email);

                if (user == null)
                    throw new Exception("Not Found Email");

                var result = await _signInManager.CheckPasswordSignInAsync(user, input.Password, false);

                if (!result.Succeeded)
                    throw new Exception("login Faild");

                return new UserDto
                {
                    Id = Guid.Parse(user.Id),
                    DisplayName = user.DisplayName,
                    Email = user.Email,
                    Token = _tokenService.GenerateToken(user)


                };


            }
            catch (Exception ex) 
            {
                throw new Exception("Not Valid");
            
            } 
            
            


        }

        public async Task<UserDto> Register(RegisterDto input)
        {
            var user = await _userManager.FindByEmailAsync(input.Email);

            if (user != null)
                throw new Exception(" Email Already Exist");

            var appUser = new AppUser
            {
                DisplayName = input.DisplayName,
                Email = input.Email,
                UserName = input.DisplayName

            };

            var result = await _userManager.CreateAsync(appUser,input.Password);

            if (!result.Succeeded)
                throw new Exception(result.Errors.Select(x=>x.Description).FirstOrDefault());
                
            return new UserDto
            {
                Id = Guid.Parse(appUser.Id),
                DisplayName = appUser.DisplayName,
                Email = appUser.Email,
                Token = _tokenService.GenerateToken(appUser)


            };

        }
    }
}
