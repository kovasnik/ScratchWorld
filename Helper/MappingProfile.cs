using AutoMapper;
using ScratchWorld.Models;
using ScratchWorld.ViewModels;

namespace ScratchWorld.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterVeiwModel, User>();
            CreateMap<LoginViewModel, User>();
            CreateMap<AddDataViewModel, User>();
            CreateMap<DetailViewModel, User>();
            CreateMap<LandmarkViewModel, Landmark>();
            CreateMap<MapViewModel, Region>();

        }
    }
}
