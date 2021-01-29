using System;
using System.Linq;
using FakeItEasy;
using FluentAssertions;
using MediumApi.Data.Database;
using MediumApi.Data.Repository;
using MediumApi.Data.Test.Infrastructure;
using MediumApi.Domain.Entities;
using Xunit;

namespace MediumApi.Data.Test.Repository
{
    public class RepositoryTests : TestBase
    {
        private readonly MediumContext _mediumContextFake;
        private readonly Repository<Post> _testee;
        private readonly Repository<Post> _testeeFake;
        private readonly Post _newPost;

        public RepositoryTests()
        {
            _mediumContextFake = A.Fake<MediumContext>();
            _testee = new Repository<Post>(Context);
            _testeeFake = new Repository<Post>(_mediumContextFake);
            _newPost = new Post
            {
                Title = "Test",
                Description = "Test"
            };
        }

        [Fact]
        public void AddAsync_when_entity_is_null__throws_exception()
        {
            _testee.Invoking(x => x.AddAsync(null)).Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void AddAsync_when_exception_occurs__throws_exception()
        {
            A.CallTo(() => _mediumContextFake.SaveChangesAsync(default)).Throws<Exception>();

            _testeeFake.Invoking(x => x.AddAsync(new Post())).Should().Throw<Exception>()
                .WithMessage("entity could not be saved: Exception of type 'System.Exception' was thrown.");
        }

        [Fact]
        public void GetAll_when_exception_occurs__throws_exception()
        {
            A.CallTo(() => _mediumContextFake.Set<Post>()).Throws<Exception>();

            _testeeFake.Invoking(x => x.GetAll()).Should().Throw<Exception>()
                .WithMessage("Couldn't retrieve entities: Exception of type 'System.Exception' was thrown.");
        }

        [Fact]
        public void UpdateAsync_when_entity_is_null__throws_exception()
        {
            _testee.Invoking(x => x.UpdateAsync(null)).Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void UpdateAsync_when_exception_occurs__throws_exception()
        {
            A.CallTo(() => _mediumContextFake.SaveChangesAsync(default)).Throws<Exception>();

            _testeeFake.Invoking(x => x.UpdateAsync(new Post())).Should().Throw<Exception>()
                .WithMessage("entity could not be updated Exception of type 'System.Exception' was thrown.");
        }

        [Fact]
        public async void create_post_async__when_post_is_not_null__should_return_post()
        {
            var result = await _testee.AddAsync(_newPost);

            result.Should().BeOfType<Post>();
        }

        [Fact]
        public async void create_post_async__when_post_is_not_null__should_add_post()
        {
            var postCount = Context.Posts.Count();

            await _testee.AddAsync(_newPost);

            Context.Posts.Count().Should().Be(postCount + 1);
        }

        [Theory]
        [InlineData("Fire in the hole")]
        [InlineData("Testing the test")]
        public async void update_post_async__when_post_is_not_null__should_return_post(string title)
        {
            var post = Context.Posts.First();
            post.Title = title;

            var result = await _testee.UpdateAsync(post);

            result.Should().BeOfType<Post>();
            result.Title.Should().Be(title);
        }
    }
}