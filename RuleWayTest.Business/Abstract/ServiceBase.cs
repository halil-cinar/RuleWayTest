using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RuleWayTest.DataAccess.Abstract;
using RuleWayTest.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleWayTest.Business.Abstract
{
    public class ServiceBase<TEntity,TRepository>
        where TEntity : EntityBase, new()
        where TRepository : IEntityRepository<TEntity>
    {
        public TRepository Repository { get; set; }
        public BaseEntityValidator<TEntity> Validator { get; set; }
        public IMapper Mapper { get; set; }

        public ServiceBase(IMapper mapper, BaseEntityValidator<TEntity> validator, TRepository repository)
        {
            Mapper = mapper;
            Validator = validator;
            Repository = repository;
        }



    }
}
