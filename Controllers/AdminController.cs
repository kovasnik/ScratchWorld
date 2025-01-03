using Microsoft.AspNetCore.Mvc;
using ScratchWorld.Data.Interfaces;

namespace ScratchWorld.Controllers
{
    public class AdminController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IRegionRepository _regionRepository;
        private readonly ILandmarkRepository _landmarkRepository;
        public AdminController(IUserRepository userRepository, IRegionRepository regionRepository)
        {
            _regionRepository = regionRepository;
            _userRepository = userRepository;
        }
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(int status)
        {
            if (status == 0)
            {
                var users = await _userRepository.GetAll();
                return View(users);
            }
            else if (status == 1)
            {
                var regions = await _regionRepository.GetAll();
                return View(regions);
            }
            var landmarks = await _landmarkRepository.GetAll();
            return View(landmarks);
        }
    }
}
