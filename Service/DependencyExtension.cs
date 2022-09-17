using Core.IRepository;
using Core.IService;
using Core.IUnitOfWork;
using Data;
using Data.Repository;
using Data.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Service.IService;
using Service.Mapping;
using Service.Service;
using System.Reflection;

namespace Service
{
    public static class DependencyExtension
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddDbContext<Context>(x =>
                x.UseSqlServer(configuration.GetConnectionString("SqlConnection"), options =>
                {
                    options.MigrationsAssembly(Assembly.GetAssembly(typeof(Context)).GetName().Name);
                })
            );
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IService<>), typeof(Service<>));
            services.AddAutoMapper(typeof(MappingProfile));

            //repository
            services.AddScoped<IPlantCategoryRepository, PlantCategoryRepository>();
            services.AddScoped<IPlantsImageRepository, PlantsImageRepository>();
            services.AddScoped<IPlantsRepository, PlantsRepository>();


            //service
            services.AddScoped<IPlantsService,PlantsService>();
            services.AddScoped<IPlantsCategoryService, PlantCategoryService>();
            services.AddScoped<IPlantsImageService, PlantsImageService>();
        }
    }
}
