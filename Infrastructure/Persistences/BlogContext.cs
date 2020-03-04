using Microsoft.EntityFrameworkCore;
using dotnet_mediatr.Domain.Entity;
using dotnet_mediatr.Application.Interfaces;

namespace dotnet_mediatr.Infrastructure.Persistence
{
    public class BlogContext : DbContext, IBlogContext
    {
        public BlogContext(DbContextOptions<BlogContext> options) : base(options) { }

        public DbSet<Creator> Creators { get; set; }
    }

}