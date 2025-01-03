using ScratchWorld.ViewModels;


namespace ScratchWorld.BLL.Interfaces
{
    public interface IUserService
    {
        Task<DetailViewModel> GetUserDetailsAsync(string userId);
        Task<AddDataViewModel> GetUserAddDataViewModelAsync(string userId);
        Task UpdateUserDataAsync(string userId, AddDataViewModel addDataViewModel);
        Task<UserEditViewModel> GetUserEditViewModelAsync(string userId);
        Task<bool> UpdateUserEmailAndPasswordAsync(string userId, UserEditViewModel userEditViewModel);
    }
}
