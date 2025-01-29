using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ScratchWorld.BLL.Interfaces;
using ScratchWorld.Models;
using ScratchWorld.ViewModels;

namespace ScratchWorld.Controllers
{
    [Route("Landmark")]
    public class LandmarkController : Controller
    {
        private readonly ILandmarkService _landmarkService;
        public LandmarkController(ILandmarkService landmarkService)
        {
            _landmarkService = landmarkService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userLanmarks = await _landmarkService.GetUsersLandmarksAsync(User);
            var jsonResult = JsonConvert.SerializeObject(userLanmarks);
            ViewBag.LandmarksJson = jsonResult;
            return View();
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateLandmark([FromBody] LandmarkViewModel viewModel)
        {
            await _landmarkService.CreateLandmarkAsync(viewModel);
            return View();
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateLandmark([FromBody] LandmarkViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data");
            }
            await _landmarkService.UpdateLandmarkAsync(viewModel);
            return Ok("Landmark ");
        }


        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteLandmark([FromBody] LandmarkViewModel viewModel)
        {
            await _landmarkService.DeleteLandmarkAsync(viewModel);
            return Ok("Landmark ");
        }
    }
}
