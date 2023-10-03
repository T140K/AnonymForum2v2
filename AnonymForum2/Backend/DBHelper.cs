using AnonymForum2.Models;
using Microsoft.EntityFrameworkCore;

namespace AnonymForum2.Backend
{
    public class DBHelper
    {
        private readonly AnonymForumContext _context;
        public DBHelper(AnonymForumContext context)
        {
            _context = context;
        }

        public async Task<List<Topic>> GetAllTopics()
        {
            var topicsz = await _context.Topics.ToListAsync();

            return topicsz;
        }
    }
}
