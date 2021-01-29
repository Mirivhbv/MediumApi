using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediumApi.Data.Database;

namespace MediumApi.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        protected readonly MediumContext MediumContext;

        public Repository(MediumContext mediumContext)
        {
            MediumContext = mediumContext;
        }

        public IEnumerable<TEntity> GetAll()
        {
            try
            {
                return MediumContext.Set<TEntity>();
            }
            catch (Exception e)
            {
                throw new Exception($"Couldn't retrieve entities: {e.Message}");
            }
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");

            try
            {
                await MediumContext.AddAsync(entity);
                await MediumContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception e)
            {
                throw new Exception($"{nameof(entity)} could not be saved: {e.Message}");
            }
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");

            try
            {
                MediumContext.Update(entity);
                await MediumContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception e)
            {
                throw new Exception($"{nameof(entity)} could not be updated {e.Message}");
            }
        }
    }
}