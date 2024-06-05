using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ScratchWorld.Data;
using ScratchWorld.Models;
using ScratchWorld.ViewModels;

namespace ScratchWorld.Controllers
{
    public class AccountController : Controller
    {
        RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            if (_roleManager.RoleExistsAsync(UserRoles.Admin) == null)
                _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
            if (_roleManager.RoleExistsAsync(UserRoles.User) == null)
                _roleManager.CreateAsync(new IdentityRole(UserRoles.User));
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            var response = new LoginViewModel();
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginModel)
        {
            if (!ModelState.IsValid) return View(loginModel);
            
            var user = await _userManager.FindByEmailAsync(loginModel.Email);
            
            if (user != null)
            {
                var passwordChek = await _userManager.CheckPasswordAsync(user, loginModel.Password);
                if (passwordChek)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginModel.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }

                }
                ViewBag.Error = "Password is not correct";
                return View(loginModel);
            }
            ViewBag.Error = "User not found";
            return View(loginModel);
        }

        public IActionResult Register()
        {
            var response = new RegisterVeiwModel();
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVeiwModel registerModel)
        {
            if (!ModelState.IsValid) return View(registerModel);
            var user = await _userManager.FindByEmailAsync(registerModel.Email);
            if (user != null)
            {
                ViewBag.Error = "User with this email adres already exists";
                return View(registerModel);
            }

            var newUser = new User()
            {
                Email = registerModel.Email,
                UserName = registerModel.UserName,
                Age = registerModel.Age
            };
            var newUserResponse = await _userManager.CreateAsync(newUser, registerModel.Password);
            if (newUserResponse.Succeeded)
            {
                await _userManager.AddToRoleAsync(newUser, UserRoles.User);
            }
            else
            {
                ViewBag.Error = "Bad password. Try Latin letters with digits";
                return View(registerModel);
            }
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
