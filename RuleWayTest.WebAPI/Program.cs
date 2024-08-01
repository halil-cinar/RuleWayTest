
using RuleWayTest.Business;
using RuleWayTest.Business.Abstract;
using RuleWayTest.Business.Mapper.AutoMapper;
using RuleWayTest.DataAccess.EntityFramework;
using RuleWayTest.DataAccess.Repository;
using RuleWayTest.Entity;
using RuleWayTest.Entity.Abstract;
using RuleWayTest.Entity.Validator;

namespace RuleWayTest.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

            builder.Services.AddScoped<IProductService, ProductManager>();
            builder.Services.AddScoped<IProductRepository, EfProductRepository>();
            builder.Services.AddScoped<BaseEntityValidator<ProductEntity>, ProductValidator>();


            builder.Services.AddScoped<ICategoryService, CategoryManager>();
            builder.Services.AddScoped<ICategoryRepository, EfCategoryRepository>();
            builder.Services.AddScoped<BaseEntityValidator<CategoryEntity>, CategoryValidator>();



            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
