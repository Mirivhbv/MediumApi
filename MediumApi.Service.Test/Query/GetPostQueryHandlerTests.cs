using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FakeItEasy;
using FluentAssertions;
using MediumApi.Data.Repository;
using MediumApi.Domain.Entities;
using MediumApi.Service.Query;
using Xunit;

namespace MediumApi.Service.Test.Query
{
    public class GetPostQueryHandlerTests
    {
        private readonly IPostRepository _postRepository;
        private readonly GetPostQueryHandler _testee;
        private readonly List<Post> _posts;

        public GetPostQueryHandlerTests()
        {
            _postRepository = A.Fake<IPostRepository>();
            _testee = new GetPostQueryHandler(_postRepository);

            _posts = new List<Post>{new Post
            {
                Id = Guid.Parse("fd6add27-d961-429a-9f95-5c9af03e46cb"),
                Title = "Hello world",
                Description = "lorem ipsum, once more ipsum. Sometimes not ipsum, you know. It is whole ipsum."
            }, new Post
            {
                Id = Guid.Parse("735c507e-20ee-4a86-9635-ef612417971d"),
                Title = "Hello world",
                Description = "lorem ipsum, once more ipsum. Sometimes not ipsum, you know. It is whole ipsum."
            }};
        }

        [Fact]
        public async void Handle__with_valid_id__should_return_two_posts()
        {
            A.CallTo(() => _postRepository.GetPostsAsync(default)).Returns(_posts);

            var result = await _testee.Handle(new GetPostQuery(), default);

            A.CallTo(() => _postRepository.GetPostsAsync(default)).MustHaveHappenedOnceExactly();

            result.Count.Should().Be(2);
        }
    }
}