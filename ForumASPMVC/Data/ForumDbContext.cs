using ForumASPMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace ForumASPMVC.Data
{
    public class ForumDbContext: DbContext
    {
        public ForumDbContext( DbContextOptions<ForumDbContext> options):base(options) { }

        public DbSet<Topic> Topics { get; set; }
        public DbSet<ThreadOne> ThreadOnes { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Reply> Replies { get; set; }


    }
}
