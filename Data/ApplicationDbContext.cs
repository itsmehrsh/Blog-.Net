using Blog.Web.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Blog.Web.Models;

namespace Blog.Web.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Post> Posts => Set<Post>();
    public DbSet<Category> Categories => Set<Category>();

    protected override void OnModelCreating(ModelBuilder b)
    {
        base.OnModelCreating(b);
        b.Entity<Category>().HasKey(x => x.Id);
        b.Entity<Post>()
            .HasOne(p => p.Category)
            .WithMany(c => c.Posts)
            .HasForeignKey(p => p.CategoryId)
            .IsRequired();

        // b.Entity<Category>().HasData(
        //     new Category { Id = 1, Title = "Tech" },
        //     new Category { Id = 2, Title = "Lifestyle" }
        // );
        //
        b.Entity<Post>().HasData(
            new Post
            {
                Id = 1, Title = "Hello EF", Summary = "Intro", Content = "Seeded", Published = DateTime.UtcNow,
                CategoryId = 1
            },
            new Post
            {
                Id = 2, Title = "Living Small", Summary = "Notes", Content = "Seeded", Published = DateTime.UtcNow,
                CategoryId = 2
            }
        );
    }
}