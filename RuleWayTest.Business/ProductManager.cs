using AutoMapper;
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
    public class ProductManager : ServiceBase<ProductEntity, IProductRepository>, IProductService
    {
        public ProductManager(IMapper mapper, BaseEntityValidator<ProductEntity> validator, IProductRepository repository) : base(mapper, validator, repository)
        {
        }

        public async Task<BussinessLayerResult<ProductListDto>> Add(ProductDto product)
        {
            var result = new BussinessLayerResult<ProductListDto>();
            try
            {
                var entity = Mapper.Map<ProductEntity>(product);
                entity.IsDeleted = false;

                var validationResult = await Validator.ValidateAsync(entity);
                if (!validationResult.IsValid)
                {
                    foreach (var err in validationResult.Errors)
                    {
                        result.AddError(Dto.EMessageCode.ProductAddValidationError, err.ErrorMessage);
                    }
                    return result;
                }
                await Repository.Add(entity);
                entity=await Repository.Get(entity.Id);
                result.Result = Mapper.Map<ProductListDto>(entity);
                    //result.Result.Live = entity.CategoryId != null && entity.Category.MinStockQuantity < entity.StockQuantity;

            }
            catch (Exception ex)
            {
                result.AddError(Dto.EMessageCode.ProductAddExceptionError, ex.Message);
            }
            return result;
        }

        public async Task<BussinessLayerResult<ProductListDto>> Delete(int id)
        {
            var result = new BussinessLayerResult<ProductListDto>();
            try
            {
                var entity = await Repository.SoftDelete(id);


                result.Result = Mapper.Map<ProductListDto>(entity);

            }
            catch (Exception ex)
            {
                result.AddError(Dto.EMessageCode.ProductDeleteExceptionError, ex.Message);
            }
            return result;
        }

        public async Task<BussinessLayerResult<ProductListDto>> Get(int id)
        {
            var result = new BussinessLayerResult<ProductListDto>();
            try
            {
                var entity = await Repository.Get(id);


                result.Result = Mapper.Map<ProductListDto>(entity);

            }
            catch (Exception ex)
            {
                result.AddError(Dto.EMessageCode.ProductDeleteExceptionError, ex.Message);
            }
            return result;
        }

        public async Task<BussinessLayerResult<List<ProductListDto>>> GetAll(ProductFilter filter)
        {
            var result = new BussinessLayerResult<List<ProductListDto>>();
            try
            {
                var entities = await Repository.GetAll(x=>
                    (string.IsNullOrEmpty(filter.Search)||(x.Title+x.Description+x.Category.Name).Contains(filter.Search))
                    &&(filter.StockMin==null||x.StockQuantity>=filter.StockMin)
                    &&(filter.StockMax==null||x.StockQuantity<=filter.StockMax)
                    &&(filter.IsLive==false||(x.CategoryId != null && x.Category.MinStockQuantity < x.StockQuantity) )
                    );

                result.Result = Mapper.Map<List<ProductListDto>>(entities);

            }
            catch (Exception ex)
            {
                result.AddError(Dto.EMessageCode.ProductGetAllExceptionError, ex.Message);
            }
            return result;
        }

        public async Task<BussinessLayerResult<ProductListDto>> Update(ProductDto product)
        {
            var result = new BussinessLayerResult<ProductListDto>();
            try
            {
                var entity = await Repository.Get(product.Id);
                entity.IsDeleted = false;

                entity.Title = product.Title;
                entity.Description = product.Description;
                entity.CategoryId = product.CategoryId;
                entity.StockQuantity = product.StockQuantity;


                var validationResult = await Validator.ValidateAsync(entity);
                if (!validationResult.IsValid)
                {
                    foreach (var err in validationResult.Errors)
                    {
                        result.AddError(Dto.EMessageCode.ProductAddValidationError, err.ErrorMessage);
                    }
                    return result;
                }
                await Repository.Update(entity);
                entity = await Repository.Get(product.Id);
                result.Result = Mapper.Map<ProductListDto>(entity);
                //result.Result.Live = entity.CategoryId != null && entity.Category.MinStockQuantity < entity.StockQuantity;

            }
            catch (Exception ex)
            {
                result.AddError(Dto.EMessageCode.ProductAddExceptionError, ex.Message);
            }
            return result;
        }
    }
}
