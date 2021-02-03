using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediumApi.Domain.Entities;

namespace MediumApi.Data.Repository
{
    public interface IPostRepository : IRepository<Post>
    {
        Task<List<Post>> GetPostsAsync(CancellationToken cancellationToken);
    }
}