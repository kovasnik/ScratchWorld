using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScratchWorld.BLL.Interfaces;
using ScratchWorld.ViewModels;
using System.Security.Claims;

namespace ScratchWorld.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                return View("Error");
            }

            try
            {
                var detailViewModel = await _userService.GetUserDetailsAsync(userId);
                return View(detailViewModel);
            }
            catch (KeyNotFoundException ex)
            {
                ViewBag.Error = ex.Message;
                return View("Error");
            }
        }

        [Authorize]
        public async Task<IActionResult> AddData()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
                return View("Error");

            try
            {
                var addDataViewModel = await _userService.GetUserAddDataViewModelAsync(userId);
                return View(addDataViewModel);
            }
            catch (KeyNotFoundException ex)
            {
                ViewBag.Error = ex.Message;
                return View("Error");
            }
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

            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
                return View("Error");

            try
            {
                await _userService.UpdateUserDataAsync(userId, addDataViewModel);
                return RedirectToAction("Index");
            }
            catch (KeyNotFoundException ex)
            {
                ViewBag.Error = ex.Message;
                return View(addDataViewModel);
            }
            catch (InvalidOperationException ex)
            {
                ViewBag.Error = ex.Message;
                return View(addDataViewModel);
            }
        }

        [Authorize]
        public async Task<IActionResult> EditUser()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
                return View("Error");

            try
            {
                var userEditViewModel = await _userService.GetUserEditViewModelAsync(userId);
                return View(userEditViewModel);
            }
            catch (KeyNotFoundException ex)
            {
                ViewBag.Error = ex.Message;
                return View("Error");
            }
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

            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
                return View("Error");

            try
            {
                var result = await _userService.UpdateUserEmailAndPasswordAsync(userId, userEditViewModel);
                if (result)
                    return RedirectToAction("Index");

                ModelState.AddModelError("", "Failed to update email or password");
                return View(userEditViewModel);
            }
            catch (ArgumentException ex)
            {
                ViewBag.Error = ex.Message;
                return View(userEditViewModel);
            }
            catch (InvalidOperationException ex)
            {
                ViewBag.Error = ex.Message;
                return View(userEditViewModel);
            }
        }
    }
}
