using Microsoft.AspNetCore.Mvc;
using ScratchWorld.Data.Interfaces;

namespace ScratchWorld.Controllers
{
    public class AdminController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IRegionRepository _regionRepository;
        public AdminController(IUserRepository userRepository, IRegionRepository regionRepository) 
        {
            _regionRepository = regionRepository;
            _userRepository = userRepository;
        }
        public async Task<IActionResult> Index()
        {
            //var users = await _userRepository.GetAll();
            var regions = await _regionRepository.GetAll();
            return View(regions);
        }
    }
}
