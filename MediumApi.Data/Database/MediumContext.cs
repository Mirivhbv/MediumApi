using System;
using MediumApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MediumApi.Data.Database
{
    public class MediumContext : DbContext
    {
        #region Ctors

        public MediumContext()
        {
        }

        public MediumContext(DbContextOptions<MediumContext> options) : base(options)
        {
            // TODO: seed db
            var posts = new[]
            {
                new Post
                {
                    Id = Guid.Parse("9f35b48d-cb87-4783-bfdb-21e36012930a"), Title = "Let's build several projects",
                    Description = "There are should be text consist of lorem ipsum"
                },
                new Post
                {
                    Id = Guid.Parse("bffcf83a-0224-4a7c-a278-5aae00a02c1e"), Title = "Sort of",
                    Description = "Hello world, second chance to get a chance"
                },
            };

            Posts.AddRange(posts);
            SaveChanges();
        }

        #endregion

        #region Properties

        public DbSet<Post> Posts { get; set; }

        #endregion
    }
}