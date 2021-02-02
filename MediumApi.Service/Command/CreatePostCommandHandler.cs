using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MediumApi.Data.Repository;
using MediumApi.Domain.Entities;

namespace MediumApi.Service.Command
{
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, Post>
    {
        private readonly IRepository<Post> _postRepository;

        public CreatePostCommandHandler(IRepository<Post> postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<Post> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            return await _postRepository.AddAsync(request.Post);
        }
    }
}