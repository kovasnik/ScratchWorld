using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ScratchWorld.BLL.Interfaces;
using ScratchWorld.Data;
using ScratchWorld.Models;
using ScratchWorld.ViewModels;

namespace ScratchWorld.BLL.Services
{
    public class AccountService : IAccountService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;

        public AccountService(RoleManager<IdentityRole> roleManager, UserManager<User> userManager, 
            SignInManager<User> signInManager, IMapper mapper)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }

        public async Task SeedRolesAsync()
        {
            if (await _roleManager.RoleExistsAsync(UserRoles.Admin) == null)
                _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));

            if (await _roleManager.RoleExistsAsync(UserRoles.User) == null)
                _roleManager.CreateAsync(new IdentityRole(UserRoles.User));
        }

        public async Task<bool> LoginAsync(LoginViewModel loginView)
        {

            var user = await _userManager.FindByEmailAsync(loginView.Email);
            if (user == null) return false;

            var passwordChek = await _userManager.CheckPasswordAsync(user, loginView.Password);
            if (!passwordChek) return false;
            
            var result = await _signInManager.PasswordSignInAsync(user, loginView.Password, false, false);
            return result.Succeeded;
        }

        public async Task<IdentityResult> RegisterAsync(RegisterVeiwModel registerView)
        {
            var user = await _userManager.FindByEmailAsync(registerView.Email);
            if (user != null) throw new ArgumentException("User with this email already exists");

            var newUser = _mapper.Map<User>(registerView);

            var newUserResponse = await _userManager.CreateAsync(newUser, registerView.Password);
            if (newUserResponse.Succeeded)
            {
                await _userManager.AddToRoleAsync(newUser, UserRoles.User);
            }

            return newUserResponse;
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
