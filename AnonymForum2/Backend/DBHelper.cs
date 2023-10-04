using AnonymForum2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

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

        public async Task<List<Post>> GetPostsById(int id)
        {
            var postsById = await _context.Posts
                .Where(p => p.Id == id).ToListAsync();
            return postsById;
        }

        public async Task<Post> CreatePost(Post post)
        {
            post.PostTime = DateTime.Now;

            _context.Posts.Add(post);
            await _context.SaveChangesAsync();

            return post;
        }

        public async Task<List<Reply>> GetRepliesByPostId(int id)
        {
            var replyByPostId = await _context.Replies
                .Where(p => p.FKPostId == id).ToListAsync();
            return replyByPostId;
        }

        public async Task<Reply> CreateReply(Reply reply)
        {
            reply.ReplyDate = DateTime.Now;

            _context.Replies.Add(reply);
            await _context.SaveChangesAsync();

            return reply;
        }
    }
}
