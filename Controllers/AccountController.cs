using Microsoft.AspNetCore.Mvc;
using ScratchWorld.BLL.Interfaces;
using ScratchWorld.ViewModels;

namespace ScratchWorld.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
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
        public async Task<IActionResult> Login(LoginViewModel loginView)
        {
            if (!ModelState.IsValid) return View(loginView);

            try
            {
                var isLoginSuccessful = await _accountService.LoginAsync(loginView);

                if (!isLoginSuccessful)
                {
                    ViewBag.Error = "Password or email is incorrect";
                    return View(loginView);
                }
            }
            catch (InvalidOperationException)
            {
                ViewBag.Error = "Something went wrong. Please try again later.";
                return View(loginView);
            }
           

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register()
        {
            var response = new RegisterVeiwModel();
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVeiwModel registerView)
        {
            if (!ModelState.IsValid) return View(registerView);

            try
            {
                var registerResult = await _accountService.RegisterAsync(registerView);
                if (!registerResult.Succeeded)
                {
                    ViewBag.Error = "Registration failed. Please check your data.";
                    return View(registerView);
                }

            }
            catch (ArgumentException ex)
            {
                ViewBag.Error = ex.Message;
            }
            catch (InvalidOperationException)
            {
                ViewBag.Error = "Something went wrong. Please try again later.";
                return View(registerView);
            }

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await _accountService.LogoutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
