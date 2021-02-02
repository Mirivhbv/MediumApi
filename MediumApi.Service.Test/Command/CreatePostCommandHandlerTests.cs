using FakeItEasy;
using FluentAssertions;
using MediumApi.Data.Repository;
using MediumApi.Domain.Entities;
using MediumApi.Service.Command;
using Xunit;

namespace MediumApi.Service.Test.Command
{
    public class CreatePostCommandHandlerTests
    {
        private readonly CreatePostCommandHandler _testee;
        private readonly IRepository<Post> _postRepository;

        public CreatePostCommandHandlerTests()
        {
            _postRepository = A.Fake<IRepository<Post>>();
            _testee = new CreatePostCommandHandler(_postRepository);
        }

        [Fact]
        public async void Handle_should_call_add_async()
        {
            await _testee.Handle(new CreatePostCommand(), default);

            A.CallTo(() => _postRepository.AddAsync(A<Post>._)).MustHaveHappenedOnceExactly();
        }

        [Fact]
        public async void Handle_should_return_created_post()
        {
            A.CallTo(() => _postRepository.AddAsync(A<Post>._)).Returns(new Post
            {
                Title = "Shalom"
            });

            var result = await _testee.Handle(new CreatePostCommand(), default);

            result.Should().BeOfType<Post>();
            result.Title.Should().Be("Shalom");
        }
    }
}