using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MediumApi.Data.Repository;
using MediumApi.Domain.Entities;

namespace MediumApi.Service.Query
{
    public class GetPostQueryHandler : IRequestHandler<GetPostQuery, List<Post>>
    {
        private readonly IPostRepository _postRepository;

        public GetPostQueryHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<List<Post>> Handle(GetPostQuery request, CancellationToken cancellationToken)
        {
            return await _postRepository.GetPostsAsync(cancellationToken);
        }
    }
}