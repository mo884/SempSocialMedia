using SempSocialMedia.BLL.ViewModel.AccountVM;
using SempSocialMedia.BLL.ViewModel.UserVM;

namespace SempSocialMedia.BLL.Service.Abstraction
{
    public interface IUserService
    {
        Task<bool> Registeration(SignUPVM model);

        Task<bool> Login(LoginVM model);
        Task<UserVMByUserName> GetUserByUserName(string userName);
    }
}
