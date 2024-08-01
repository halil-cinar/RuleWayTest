using FluentValidation;
using RuleWayTest.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleWayTest.Entity.Validator
{
    public class ProductValidator:BaseEntityValidator<ProductEntity>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Title).NotEmpty().NotNull().MaximumLength(200);
        }
    }
}
