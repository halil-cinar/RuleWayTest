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
    public class EfCategoryRepository: EfGenericRepositoryBase<CategoryEntity, DatabaseContext>, ICategoryRepository
    {
    }
}
