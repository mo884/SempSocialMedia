using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SempSocialMedia.BLL.Helper;
using SempSocialMedia.BLL.Service.Abstraction;
using SempSocialMedia.BLL.ViewModel.AccountVM;
using SempSocialMedia.BLL.ViewModel.UserVM;
using SempSocialMedia.DAL.Entities;
using SempSocialMedia.DAL.Repo.Abstraction;
using System.Data;


namespace SempSocialMedia.BLL.Service.Impelementation
{
    public class UserServices : IUserService
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IUserRepo userRepo;
        private readonly IMapper mapper;

        public UserServices(UserManager<User> userManager, SignInManager<User> signInManager,IUserRepo userRepo,IMapper mapper)
        {
            this.userManager = userManager;
            this.signInManager=signInManager;
            this.userRepo=userRepo;
            this.mapper=mapper;
        }

        public async Task<bool> Login(LoginVM model)
        {
            var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
            if (result.Succeeded)

                return true;
            return false;
        }

        public async Task< bool> Registeration(SignUPVM model)
        {
            var user = new User()
            {
                UserName = model.Username,
                Email = model.Email
            };
            if (model.File != null)
                user.Image = Upload.UploadFile("Profile", model.File);
            var result =await  userManager.CreateAsync(user, model.Password);//Passward ==> Hash

           

            if (result.Succeeded)
            {
                var Role = await userManager.AddToRoleAsync(user, "User");
                if(Role.Succeeded)
                    return true;

            }
            return false;
        }


        public async Task<UserVMByUserName> GetUserByUserName(string  username)
        {
            var result = await userRepo.GetUserByUserName(username);
            var user = mapper.Map<UserVMByUserName>(result);    
            return user;
        }
    }
}
