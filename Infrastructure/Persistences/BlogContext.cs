using Microsoft.EntityFrameworkCore;
using dotnet_mediatr.Domain.Entities;
using dotnet_mediatr.Application.Interfaces;

namespace dotnet_mediatr.Infrastructure.Persistence
{
    public class BlogContext : DbContext, IBlogContext
    {
        public BlogContext(DbContextOptions<BlogContext> options) : base(options) { }

        public DbSet<Post> Posts { get; set; }
    }

}