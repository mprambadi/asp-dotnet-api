using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using dotnet_mediatr.Domain.Entity;

namespace dotnet_mediatr.Application.Interfaces
{
    public interface IBlogContext
    {
        DbSet<Creator> Creators { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}