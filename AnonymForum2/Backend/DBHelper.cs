using AnonymForum2.Models;
using Microsoft.AspNetCore.Mvc;
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
                .Where(p => p.FKTopicId == id).ToListAsync();
            return postsById;
        }

        public async Task<Post> CreatePost(Post post)
        {
            post.PostTime = DateTime.Now;

            _context.Posts.Add(post);
            await _context.SaveChangesAsync();

            return post;
        }
    }
}
