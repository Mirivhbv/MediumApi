using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediumApi.Data.Database;
using MediumApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MediumApi.Data.Repository
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        public PostRepository(MediumContext mediumContext) : base(mediumContext)
        {
        }

        public async Task<List<Post>> GetPostsAsync(CancellationToken cancellationToken)
        {
            return await MediumContext.Posts.ToListAsync(cancellationToken);
        }
    }
}