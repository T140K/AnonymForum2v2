using AnonymForum2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using AnonymForum2.Models.ViewModel;
using AnonymForum2.Backend;
using Microsoft.AspNetCore.Mvc.DataAnnotations;

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
            await dbHelper.CreatePost(postModel);

            return RedirectToAction($"Post", new { id = id});
        }

        public async Task<IActionResult> Thread(int id)
        {
            var dbHelper = new DBHelper(_context);
            var replyModel = await dbHelper.GetRepliesByPostId(id);
            var originalPost = await dbHelper.GetPostsById(id);

            var replyViewModel = new ThreadMoreDetailViewModel
            {
                Replies = replyModel.Select(reply => new ThreadDetailViewModel
                {
                    Contents = reply.Contents,
                    ReplyDate =reply.ReplyDate,
                    FKPostId = reply.FKPostId
                }
            ).ToList(),
                postId = id,
                Post = originalPost.Select(post => new PostDetailViewModel()
                {
                    Title=post.Title,
                    Contents = post.Contents,
                    PostTime = post.PostTime,
                    FKTopicId = post.FKTopicId

                }).ToList(),
            };
            return View(replyViewModel);
        }
        public IActionResult CreateReply()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateReply(int id, ReplyCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            };

            var replyModel = new Reply
            {
                Contents = model.Contents,
                ReplyDate = DateTime.Now,
                FKPostId = id
            };
            var dbHelper = new DBHelper(_context);
            await dbHelper.CreateReply(replyModel);

            return RedirectToAction($"Thread", new { id = id });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}