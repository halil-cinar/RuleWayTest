using Microsoft.EntityFrameworkCore;
using RuleWayTest.DataAccess.Abstract.EntityFramework;
using RuleWayTest.DataAccess.Context;
using RuleWayTest.DataAccess.Repository;
using RuleWayTest.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleWayTest.DataAccess.EntityFramework
{
    public class EfProductRepository:EfGenericRepositoryBase<ProductEntity,DatabaseContext>,IProductRepository
    {
        protected override IQueryable<ProductEntity> BaseGetAll(DbContext context)
        {
            return base.BaseGetAll(context).Include(x=>x.Category);
        }
    }
}
