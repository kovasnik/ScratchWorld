using Microsoft.AspNetCore.Identity;
using ScratchWorld.ViewModels;

namespace ScratchWorld.BLL.Interfaces
{
    public interface IAccountService
    {
        Task<bool> LoginAsync(LoginViewModel loginView);
        Task<IdentityResult> RegisterAsync(RegisterVeiwModel registerView);
        Task LogoutAsync();
    }
}
