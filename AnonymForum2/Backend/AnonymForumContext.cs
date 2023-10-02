using AnonymForum2.Models;
using Microsoft.EntityFrameworkCore;

namespace AnonymForum2.Backend
{
    public class AnonymForumContext : DbContext
    {
        public AnonymForumContext(DbContextOptions<AnonymForumContext> options) : base(options) 
        { 
        
        }

        public DbSet<Topic> Topics { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Reply> Replies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Topic>()
                .HasKey(t => t.Id);

            modelBuilder.Entity<Post>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Reply>()
                .HasKey(r => r.Id);

            modelBuilder.Entity<Post>()
                .HasOne(p => p.Topic)
                .WithMany(p => p.Posts)
                .HasForeignKey(p => p.FKTopicId);

            modelBuilder.Entity<Reply>()
               .HasOne(r => r.Post)
               .WithMany(r => r.Replies)
               .HasForeignKey(r => r.FKPostId);

        }
    }
}
