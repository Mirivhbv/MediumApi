using System;

namespace MediumApi.Domain.Entities
{
    public partial class Post
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}