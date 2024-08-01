using Microsoft.EntityFrameworkCore;
using RuleWayTest.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RuleWayTest.DataAccess.Abstract.EntityFramework
{
    public abstract class EfGenericRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : EntityBase, new()
        where TContext : DbContext, new()
    {

        protected virtual IQueryable<TEntity> BaseGetAll(DbContext context)
        {
            return context.Set<TEntity>().Where(x=>x.IsDeleted==false);
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            using(var context=new TContext())
            {
                var entry=context.Entry(entity);
                entry.State = EntityState.Added;
                await context.SaveChangesAsync();
                return entry.Entity;
            }
        }

        public async Task<TEntity> Get(int id)
        {
            using (var context = new TContext())
            {
                var entity= await BaseGetAll(context).FirstOrDefaultAsync(x=>x.Id==id);
                return entity;
            }
        }

        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContext())
            {
                var entity = await BaseGetAll(context).Where(filter).FirstOrDefaultAsync();
                return entity;
            }
        }

        public async Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                var entities = (filter != null) ? await BaseGetAll(context).Where(filter).ToListAsync()
                    : await BaseGetAll(context).ToListAsync();
                return entities;
            }
        }

        public async Task<TEntity> SoftDelete(int id)
        {
            using (var context = new TContext())
            {
                var entity=await context.Set<TEntity>().FirstOrDefaultAsync(x=>x.Id==id);
                if (entity == null) return null;
                entity.IsDeleted = true;
                return await Update(entity);
            }
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                var entry = context.Entry(entity);
                entry.State = EntityState.Modified;
                await context.SaveChangesAsync();
                return entry.Entity;
            }
        }
    }
}
