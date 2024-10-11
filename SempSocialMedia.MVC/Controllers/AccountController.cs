using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SempSocialMedia.BLL.Service.Abstraction;
using SempSocialMedia.BLL.ViewModel.AccountVM;
using SempSocialMedia.DAL.Entities;

namespace SempSocialMedia.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IUserService userService;

        public AccountController(UserManager<User> userManager,SignInManager<User> signInManager,IUserService userService)
        {
            this.userManager=userManager;
            this.signInManager=signInManager;
            this.userService=userService;
        }
        [HttpGet]
        public IActionResult SignUP()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUP(SignUPVM model)
        {
            if(ModelState.IsValid)
            {
                var Result =await userService.Registeration(model);
                if(Result==true)
                {
                    return RedirectToAction("Login");
                }
                
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task< IActionResult> Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                var Result = await userService.Login(model);
                if (Result==true)
                {
                    return RedirectToAction("Index","Post");
                }

            }
            return View(model);

        }
    }
}
