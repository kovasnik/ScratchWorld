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
        private readonly IMapService _mapService;
        public LandmarkController(ILandmarkService landmarkService, IMapService mapService)
        {
            _landmarkService = landmarkService;
            _mapService = mapService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var regions = await _mapService.GetRegionsAsync();
            var userLanmarks = await _landmarkService.GetUsersLandmarksAsync(User);
            ViewBag.RegionJson = JsonConvert.SerializeObject(regions);
            ViewBag.LandmarksJson = JsonConvert.SerializeObject(userLanmarks);
            return View();
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateLandmark([FromBody] LandmarkViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Invalid data" }); 
            }
            await _landmarkService.CreateLandmarkAsync(viewModel);
            return Ok(new { message = "Landmark created successfully" });
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
