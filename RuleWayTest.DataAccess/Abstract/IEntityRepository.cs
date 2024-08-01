using RuleWayTest.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RuleWayTest.DataAccess.Abstract
{
    public interface IEntityRepository<TEntity> 
        where TEntity : EntityBase, new()
    {
        public Task<TEntity> Add(TEntity entity);
        public Task<TEntity> Update(TEntity entity);
        public Task<TEntity> SoftDelete(int id);
        public Task<TEntity> Get(int id);
        public Task<TEntity> Get(Expression<Func<TEntity, bool>> filter);
        public Task<List<TEntity>> GetAll(Expression<Func<TEntity,bool>> filter=null);


    }
}
