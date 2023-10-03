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
            var topics = await _context.Topics.ToListAsync();

            return topics;
        }

        public async Task<List<Post>> GetPostsByTopicId(int id)
        {
            var postsById = await _context.Posts
                .Where(p => p.Id == id).ToListAsync();
            return postsById;

        }
    }
}
