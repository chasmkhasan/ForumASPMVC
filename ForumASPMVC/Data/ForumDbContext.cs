//using ForumASPMVC.Models;
//using Microsoft.EntityFrameworkCore;

//namespace ForumASPMVC.Data
//{
//    public class ForumDbContext: DbContext
//    {
//        public ForumDbContext( DbContextOptions<ForumDbContext> options):base(options) { }

//        public DbSet<Topic> Topics { get; set; }
//        public DbSet<ThreadOne> ThreadOnes { get; set; }
//        public DbSet<Comment> Comments { get; set; }
//        public DbSet<Reply> Replies { get; set; }


//    }
//}

using ForumASPMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace ForumASPMVC.Data
{
    public class ForumDbContext : DbContext
    {
        public ForumDbContext(DbContextOptions<ForumDbContext> options) : base(options)
        {
        }

        public DbSet<Topic> Topics { get; set; }
        public DbSet<ThreadOne> ThreadOnes { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Reply> Replies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships here using Fluent API
            modelBuilder.Entity<ThreadOne>()
                .HasOne(t => t.Topic)
                .WithMany(t => t.Threads)
                .HasForeignKey(t => t.TopicId);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Thread)
                .WithMany(t => t.Comments)
                .HasForeignKey(c => c.ThreadOneId);

            modelBuilder.Entity<Reply>()
                .HasOne(r => r.Comment)
                .WithMany(c => c.Replies)
                .HasForeignKey(r => r.CommentId);
        }
    }
}

