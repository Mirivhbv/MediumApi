using MediatR;
using MediumApi.Domain.Entities;

namespace MediumApi.Service.Command
{
    public class CreatePostCommand : IRequest<Post>
    {
        public Post Post { get; set; }
    }
}