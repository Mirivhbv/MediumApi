using System;
using MediumApi.Data.Database;
using Microsoft.EntityFrameworkCore;

namespace MediumApi.Data.Test.Infrastructure
{
    public class TestBase : IDisposable
    {
        protected readonly MediumContext Context;

        public TestBase()
        {
            var options = new DbContextOptionsBuilder<MediumContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            Context = new MediumContext(options);

            Context.Database.EnsureCreated();

            DatabaseInitializer.Initialize(Context);
        }

        public void Dispose()
        {
            Context.Database.EnsureDeleted();

            Context.Dispose();
        }
    }
}