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
        public IActionResult Post()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}