using AutoMapper;
using Microsoft.AspNetCore.Identity;
using ScratchWorld.BLL.Interfaces;
using ScratchWorld.Data.Interfaces;
using ScratchWorld.Models;
using ScratchWorld.ViewModels;
using System.Security.Claims;

namespace ScratchWorld.BLL.Services
{
    public class LandmarkService : ILandmarkService
    {
        private readonly UserManager<User> _userManager;
        private readonly ILandmarkRepository _landmarkRepository;
        private readonly ILikeRepository _likeRepository;
        private readonly IMapper _mapper;
        public LandmarkService(ILandmarkRepository landmarkRepository, ILikeRepository likeRepository, 
            UserManager<User> userManager, IMapper mapper)
        {
            _landmarkRepository = landmarkRepository;
            _likeRepository = likeRepository;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task CreateLandmarkAsync(LandmarkViewModel landmarkViewModel)
        {
            var newLandmark = _mapper.Map<Landmark>(landmarkViewModel);

            await _landmarkRepository.AddAsync(newLandmark);
        }

        public async Task DeleteLandmarkAsync(LandmarkViewModel landmarkViewModel)
        {
            var landmark = await _landmarkRepository.FindLandmarkByIdAsync(landmarkViewModel.Id);
            await _landmarkRepository.DeleteAsync(landmark);
        }

        public async Task<IEnumerable<Landmark>> GetAllAsync()
        {
            return await _landmarkRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Landmark>> GetApprovedAsync()
        {
            return await _landmarkRepository.GetApprovedAsync();
        }

        public async Task<IEnumerable<Landmark>> GetLikedAsync(int likeCount)
        {
            var landmarkIds = await _likeRepository.GetLandmarksFilteredByLikes(likeCount);

            if (!landmarkIds.Any())
                return Enumerable.Empty<Landmark>();

            var landmarks = await _landmarkRepository.GetLikedAsync(landmarkIds);

            return landmarks;
        }

        public async Task<IEnumerable<Landmark>> GetSharedAsync()
        {
            
            return await _landmarkRepository.GetSharedAsync();
        }

        public async Task<IEnumerable<Landmark>> GetUsersLandmarksAsync(ClaimsPrincipal user)
        {
            var currentUser = await _userManager.GetUserAsync(user);
            if (currentUser == null)
                throw new InvalidOperationException("User is not authorized");

            return await _landmarkRepository.GetUsersLandmarksAsync(currentUser.Id);
        }

        public async Task UpdateLandmarkAsync(LandmarkViewModel landmarkViewModel)
        {
            var landmark = await _landmarkRepository.FindLandmarkByIdAsync(landmarkViewModel.Id);

            _mapper.Map(landmarkViewModel, landmark);

            await _landmarkRepository.UpdateAsync(landmark);
        }
    }
}
