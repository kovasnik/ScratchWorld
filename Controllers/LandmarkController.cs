using Microsoft.AspNetCore.Mvc;
using ScratchWorld.BLL.Interfaces;
using ScratchWorld.Models;

namespace ScratchWorld.Controllers
{
    public class LandmarkController : Controller
    {
        private readonly ILandmarkService _landmarkService;
        public LandmarkController(ILandmarkService landmarkService)
        {
            _landmarkService = landmarkService;
        }

        [Route("Landmark")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("Landmark")]
        [HttpPost]
        public IActionResult CreateLandmark([FromBody] Landmark landmark)
        {
            return Ok("Landmark created");
        }

        [Route("Landmark")]
        [HttpPut]
        public IActionResult UpdateLandmark([FromBody] Landmark landmark)
        {
            return Ok("Landmark ");
        }
    }
}
