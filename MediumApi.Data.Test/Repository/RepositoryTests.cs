using System;
using System.Collections.Generic;
using System.Text;
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

        public RepositoryTests()
        {
            _mediumContextFake = A.Fake<MediumContext>();
            _testee = new Repository<Post>(Context);
            _testeeFake = new Repository<Post>(_mediumContextFake);
        }

        [Fact]
        public void UpdateAsync_when_entity_is_null__throws_exception()
        {
            _testee.Invoking(x => x.UpdateAsync(null)).Should().Throw<ArgumentNullException>();
        }
    }
}