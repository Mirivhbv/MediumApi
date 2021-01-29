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
        }

        #endregion

        #region Properties

        public DbSet<Post> Posts { get; set; }

        #endregion
    }
}