using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repository.EFRepository
{
    public class EFEntityRepositoryBase<TEntity, IContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where IContext : DbContext,new()
    {
        public Task<TEntity> Get(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new IContext())
            {
                return filter == null 
                    ? context.Set<TEntity>().FirstOrDefaultAsync() 
                    : context.Set<TEntity>().Where(filter).FirstOrDefaultAsync();
            }
        }

        Task<List<TEntity>> IEntityRepository<TEntity>.GetAll(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new IContext())
            {
                return filter == null 
                    ? context.Set<TEntity>().ToListAsync() 
                    : context.Set<TEntity>().Where(filter).ToListAsync();
            }
        }

        //public void Add(TEntity entity)
        //{
        //    using (var context = new IContext())
        //    {
        //        var addEntity = context.Entry(entity);
        //        addEntity.State = EntityState.Added;
        //        context.SaveChangesAsync();
        //    }
        //}
        async Task IEntityRepository<TEntity>.Add(TEntity entity)
        {
            using (var context = new IContext())
            {
                var addEntity = context.Entry(entity);
                addEntity.State = EntityState.Added;
                await context.SaveChangesAsync();
            }
        }
        //public void Update(TEntity entity)
        //{
        //    using (var context = new IContext())
        //    {
        //        var addEntity = context.Entry(entity);
        //        addEntity.State = EntityState.Modified;
        //        context.SaveChangesAsync();
        //    }
        //}

        //public void Delete(TEntity entity)
        //{
        //    using (var context = new IContext())
        //    {
        //        var addEntity = context.Entry(entity);
        //        addEntity.State = EntityState.Deleted;
        //        context.SaveChangesAsync();
        //    }
        //}

        async Task IEntityRepository<TEntity>.Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        async Task IEntityRepository<TEntity>.Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
