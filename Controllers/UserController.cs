using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ScratchWorld.Data.Interfaces;
using ScratchWorld.Models;
using ScratchWorld.ViewModels;

namespace ScratchWorld.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IUserRepository _userRepository;
        public UserController(UserManager<User> userManager, IUserRepository userRepository)
        {
            _userManager = userManager;
            _userRepository = userRepository;
        }
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var detailViewModel = new DetailViewModel()
            {
                UserName = user.UserName,
                Email = user.Email,
                Age = user.Age,
                Name = user.Name,
                PhoneNumber = user.PhoneNumber,
            };
            return View(detailViewModel);
        }

        [Authorize]
        public async Task<IActionResult> AddData()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return View("Error");
            }

            var addDataViewModel = new AddDataViewModel()
            {
                UserName = user.UserName,
                Age = user.Age,
                Name = user.Name,
                PhoneNumber = user.PhoneNumber,
            };
            return View(addDataViewModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddData(AddDataViewModel addDataViewModel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit profile");
                return View("AddData", addDataViewModel);
            }
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return View("Error");
            }

            user.Name = addDataViewModel.UserName;
            user.Age = addDataViewModel.Age;
            user.Name = addDataViewModel.Name;
            user.PhoneNumber = addDataViewModel.PhoneNumber;
            await _userManager.UpdateAsync(user);
            return RedirectToAction("Index", "User");   
        }

        [Authorize]
        public async Task<IActionResult> EditUser()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return View("Error");
            }

            var userEditViewModel = new UserEditViewModel()
            {
                Email = user.Email,
            };
            return View(userEditViewModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> EditUser(UserEditViewModel userEditViewModel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit profile");
                return View("EditUser", userEditViewModel);
            }
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return View("Error");
            }
            var userEmail = await _userManager.FindByEmailAsync(userEditViewModel.Email);
            if(user.Email != userEmail.Email)
            {
                if (userEmail != null)
                {
                    ViewBag.Error = "User with this email adres already exists";
                    return View(userEditViewModel);
                }
                user.Email = userEditViewModel.Email;
            }
            //await _userManager.UpdateAsync(user);
            var passwordChek = await _userManager.CheckPasswordAsync(user, userEditViewModel.OldPassword);
            if (passwordChek)
            {
                await _userManager.ChangePasswordAsync(user, userEditViewModel.OldPassword, userEditViewModel.Password);
                return RedirectToAction("Index", "User");
            }
            ViewBag.Error = "Old password is not correct";
            return View(userEditViewModel);
        }
    }
}
