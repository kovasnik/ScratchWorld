using ScratchWorld.BLL.Interfaces;
using ScratchWorld.Data.Interfaces;
using ScratchWorld.Models;
using ScratchWorld.ViewModels;

namespace ScratchWorld.BLL.Services
{
    public class LandmarkService : ILandmarkService
    {
        private readonly ILandmarkRepository _landmarkRepository;
        private readonly ILikeRepository _likeRepository;
        public LandmarkService(ILandmarkRepository landmarkRepository, ILikeRepository likeRepository)
        {
            _landmarkRepository = landmarkRepository;
            _likeRepository = likeRepository;
        }
        public async Task ApproveLandmark(LandmarkViewModel viewModel)
        {
            var landmark = new Landmark
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                Description = viewModel.Description,
                Coordinates = viewModel.Coordinates,
                IsApproved = viewModel.IsApproved,
                RegionId = viewModel.RegionId
            };

            await _landmarkRepository.UpdateAsync(landmark);
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
    }
}
