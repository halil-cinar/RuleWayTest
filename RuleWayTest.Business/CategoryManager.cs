using AutoMapper;
using FluentValidation;
using RuleWayTest.Business.Abstract;
using RuleWayTest.DataAccess.Repository;
using RuleWayTest.Dto.AddOrUpdateDto;
using RuleWayTest.Dto.Filter;
using RuleWayTest.Dto.ListDto;
using RuleWayTest.Dto.Result;
using RuleWayTest.Entity;
using RuleWayTest.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleWayTest.Business
{
    public class CategoryManager : ServiceBase<CategoryEntity, ICategoryRepository>, ICategoryService
    {
        public CategoryManager(IMapper mapper, BaseEntityValidator<CategoryEntity> validator, ICategoryRepository repository) : base(mapper, validator, repository)
        {
        }
        public async Task<BussinessLayerResult<CategoryListDto>> Add(CategoryDto category)
        {
            var result = new BussinessLayerResult<CategoryListDto>();
            try
            {
                var entity = Mapper.Map<CategoryEntity>(category);
                entity.IsDeleted = false;

                var validationResult = await Validator.ValidateAsync(entity);
                if (!validationResult.IsValid)
                {
                    foreach (var err in validationResult.Errors)
                    {
                        result.AddError(Dto.EMessageCode.CategoryAddValidationError, err.ErrorMessage);
                    }
                    return result;
                }
                await Repository.Add(entity);
                entity = await Repository.Get(entity.Id);
                result.Result = Mapper.Map<CategoryListDto>(entity);
                //result.Result.Live = entity.CategoryId != null && entity.Category.MinStockQuantity < entity.StockQuantity;

            }
            catch (Exception ex)
            {
                result.AddError(Dto.EMessageCode.CategoryAddExceptionError, ex.Message);
            }
            return result;
        }

        public async Task<BussinessLayerResult<CategoryListDto>> Delete(int id)
        {
            var result = new BussinessLayerResult<CategoryListDto>();
            try
            {
                var entity = await Repository.SoftDelete(id);


                result.Result = Mapper.Map<CategoryListDto>(entity);

            }
            catch (Exception ex)
            {
                result.AddError(Dto.EMessageCode.CategoryDeleteExceptionError, ex.Message);
            }
            return result;
        }

        public async Task<BussinessLayerResult<CategoryListDto>> Get(int id)
        {
            var result = new BussinessLayerResult<CategoryListDto>();
            try
            {
                var entity = await Repository.Get(id);


                result.Result = Mapper.Map<CategoryListDto>(entity);

            }
            catch (Exception ex)
            {
                result.AddError(Dto.EMessageCode.CategoryGetExceptionError, ex.Message);
            }
            return result;
        }

        public async Task<BussinessLayerResult<List<CategoryListDto>>> GetAll(CategoryFilter filter)
        {
            var result = new BussinessLayerResult<List<CategoryListDto>>();
            try
            {
                var entities = await Repository.GetAll(
                    );
                //x =>
                //(string.IsNullOrEmpty(filter.Search) || (x.Title + x.Description + x.Category.Name).Contains(filter.Search))
                //&& (filter.StockMin == null || x.StockQuantity > filter.StockMin)
                //&& (filter.StockMax == null || x.StockQuantity < filter.StockMax)

                result.Result = Mapper.Map<List<CategoryListDto>>(entities);

            }
            catch (Exception ex)
            {
                result.AddError(Dto.EMessageCode.CategoryGetAllExceptionError, ex.Message);
            }
            return result;
        }

        public async Task<BussinessLayerResult<CategoryListDto>> Update(CategoryDto category)
        {
            var result = new BussinessLayerResult<CategoryListDto>();
            try
            {
                var entity = await Repository.Get(category.Id);
                entity.IsDeleted = false;

                entity.Name = category.Name;
                entity.MinStockQuantity = category.MinStockQuantity;


                var validationResult = await Validator.ValidateAsync(entity);
                if (!validationResult.IsValid)
                {
                    foreach (var err in validationResult.Errors)
                    {
                        result.AddError(Dto.EMessageCode.CategoryAddValidationError, err.ErrorMessage);
                    }
                    return result;
                }
                await Repository.Update(entity);
                entity = await Repository.Get(category.Id);
                result.Result = Mapper.Map<CategoryListDto>(entity);
                //result.Result.Live = entity.CategoryId != null && entity.Category.MinStockQuantity < entity.StockQuantity;

            }
            catch (Exception ex)
            {
                result.AddError(Dto.EMessageCode.CategoryAddExceptionError, ex.Message);
            }
            return result;
        }
    }
}
