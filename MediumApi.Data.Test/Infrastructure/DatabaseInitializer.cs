using System;
using System.Linq;
using MediumApi.Data.Database;
using MediumApi.Domain.Entities;

namespace MediumApi.Data.Test.Infrastructure
{
    public class DatabaseInitializer
    {
        public static void Initialize(MediumContext context)
        {
            if (context.Posts.Any())
                return;

            Seed(context);
        }

        private static void Seed(MediumContext context)
        {
            var posts = new[]
            {
                new Post
                {
                    Id = Guid.NewGuid(),
                    Title = "Among us",
                    Description = "Once upon a time, there were famous rumor about sealing persons..."
                },
                new Post
                {
                    Id = Guid.NewGuid(),
                    Title = "Call of duty",
                    Description = "let me clarify one thing about future conversations."
                }
            };

            context.Posts.AddRange(posts);
            context.SaveChanges();
        }
    }
}