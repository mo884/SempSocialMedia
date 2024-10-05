using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SempSocialMedia.BLL.ViewModel.AccountVM;
using SempSocialMedia.DAL.Entities;

namespace SempSocialMedia.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public AccountController(UserManager<User> userManager,SignInManager<User> signInManager)
        {
            this.userManager=userManager;
            this.signInManager=signInManager;
        }
        [HttpGet]
        public IActionResult SignUP()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUP(SignUPVM model)
        {
            
            var user = new User()
            {
                UserName = model.Username,
                Email = model.Email
            };

            var result = await userManager.CreateAsync(user, model.Password);//Passward ==> Hash

            if (result.Succeeded)
            {
                return RedirectToAction("Index","Post");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task< IActionResult> Login(LoginVM model)
        {
            var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Post");
            }
            else
            {
                ModelState.AddModelError("", "Invalid UserName Or Password");

            }
            return View();
        }
    }
}
