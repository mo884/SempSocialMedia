using Hangfire;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SempSocialMedia.BLL.Service.Abstraction;
using SempSocialMedia.BLL.ViewModel.PostVM;
using SempSocialMedia.DAL.Entities;

namespace SempSocialMedia.MVC.Controllers
{
    //[Authorize(Roles = $"User")]
    public class PostController : Controller
    {
        private readonly IPostService postService;
        private readonly IUserService userService;
        private readonly SignInManager<User> signInManager;

        public PostController(IPostService postService,IUserService userService, SignInManager<User> signInManager)
        {
            this.postService=postService;
            this.userService=userService;
            this.signInManager=signInManager;
        }
        public async Task<IActionResult> Index()
        
        {
            var posts = postService.GetAll();

            PublicPostsVM publicPosts = new PublicPostsVM()
            {
                postsVMs =posts,
                User =(await userService.GetUserByUserName(User.Identity.Name))
            };
            return View(publicPosts);
        }
        [HttpGet]
        public IActionResult Create()
        {
           
            return View();
        }

        [HttpPost]
        public async Task<IActionResult>  Create(CreatePostVM createPostVM)
        {
            var user = await userService.GetUserByUserName(User.Identity.Name);
            createPostVM.UserId = user.Id;
            var Result = postService.Create(createPostVM);
            return RedirectToAction("Index");
        }
       
    }
}
