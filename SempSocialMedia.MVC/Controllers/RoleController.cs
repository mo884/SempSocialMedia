using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SempSocialMedia.MVC.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }
        public async Task<IActionResult>  Index()
        {
            var Result =await roleManager.Roles.ToListAsync();
            return View(Result);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
           
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(IdentityRole model)
        {
           
            var Result = await roleManager.CreateAsync(model);
            if(Result !=null)
            return RedirectToAction("Index");
            return View(model);
        }
    }
}
