using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleWayTest.Entity.Abstract
{
    public class BaseEntityValidator<TEntity>:AbstractValidator<TEntity>
        where TEntity : EntityBase, new()
    {
        public BaseEntityValidator()
        {
         RuleFor(x=>x.Id).NotNull();   
        }
    }
}
