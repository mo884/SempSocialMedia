using Hangfire;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SempSocialMedia.BLL.Service.Abstraction;
using SempSocialMedia.BLL.ViewModel.PostVM;

namespace SempSocialMedia.MVC.Controllers
{
    [Authorize("Admin")]
    public class PostController : Controller
    {
        private readonly IPostService postService;

        public PostController(IPostService postService)
        {
            this.postService=postService;
        }
        public IActionResult Index()
        
        {
            var Result = postService.GetAll();
            return View(Result);
        }
        [HttpGet]
        public IActionResult Create()
        {
           
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreatePostVM createPostVM)
        {
            //Hang Fire
            PrintInConsole();
            //BackgroundJob.Enqueue(() => PrintHello()); //Send email
            ////BackgroundJob.Schedule(() => postService.Create(createPostVM), TimeSpan.FromMinutes(1));
            RecurringJob.AddOrUpdate(() => postService.Create(createPostVM), Cron.Monthly);
            return View();
        }
        public void PrintInConsole()
        {
            Console.WriteLine("Welcome");
        }

        public void PrintHello()
        {
            Console.WriteLine("Hello");

        }
    }
}
