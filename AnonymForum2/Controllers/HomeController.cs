using AnonymForum2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using AnonymForum2.Models.ViewModel;
using AnonymForum2.Backend;

namespace AnonymForum2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AnonymForumContext _context;
        public HomeController(ILogger<HomeController> logger, AnonymForumContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var dbHelper = new DBHelper(_context);
            var topicModel = await dbHelper.GetAllTopics();

            var topicViewModels = topicModel.Select(topic => new TopicDetailViewModel
            {
                Id = topic.Id,
                Name = topic.Name
            }).ToList();

            return View(topicViewModels);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public async Task<IActionResult> Post(int id)
        {

            var dbHelper = new DBHelper(_context);
            var postModel = await dbHelper.GetPostsByTopicId(id);

            var postViewModel = new PostMoreDetailViewModel
            {
                Posts = postModel.Select(post => new PostDetailViewModel
                {
                    Id = post.Id,
                    Title = post.Title,
                    Contents = post.Contents,
                    PostTime = post.PostTime,
                    FKTopicId = post.FKTopicId
                }).ToList(),
                sentId = id
            };

            return View(postViewModel);
        }
        public IActionResult CreatePost()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreatePost(int id, PostCreateViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            };

            var postModel = new Post
            {
                Title = model.Title,
                Contents = model.Contents,
                PostTime = DateTime.Now,
                FKTopicId = id
            };
            var dbHelper = new DBHelper(_context);
            var createdPost = await dbHelper.CreatePost(postModel);

            return RedirectToAction($"Post",new { id = id});
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}