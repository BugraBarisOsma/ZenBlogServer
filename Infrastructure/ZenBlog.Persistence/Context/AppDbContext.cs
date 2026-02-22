using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Persistence.Context
{
    public class AppDbContext(DbContextOptions options) : IdentityDbContext<AppUser,AppRole,Guid>(options)
    {

        public DbSet<Category> Categories { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<ContactInfo> ContactInfos { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Social> Socials { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Comment>()
                .HasMany(c => c.SubComments)  
                .WithOne(sc => sc.Comment)  
                .HasForeignKey(sc => sc.CommentId) 
                .OnDelete(DeleteBehavior.NoAction);  

            modelBuilder.Entity<Blog>()
                .HasMany(b => b.Comments)  
                .WithOne(c => c.Blog)  
                .HasForeignKey(c => c.BlogId) 
                .OnDelete(DeleteBehavior.NoAction); 

        }
    }
}
