using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using dotnet_mediatr.Domain.Entities;

namespace dotnet_mediatr.Application.Interfaces
{
    public interface IBlogContext
    {
        DbSet<Post> Posts { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}