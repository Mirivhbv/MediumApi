using System.Collections.Generic;
using MediatR;
using MediumApi.Domain.Entities;

namespace MediumApi.Service.Query
{
    public class GetPostQuery : IRequest<List<Post>>
    {
    }
}