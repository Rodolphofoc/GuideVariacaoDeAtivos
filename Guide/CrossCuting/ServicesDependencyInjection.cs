using Applications.Interfaces.Repository;
using Applications.Interfaces.Service;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Infrastructure.Services.Finance;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using System.Reflection;

namespace CrossCuting
{
    public static class ServicesDependencyInjection
    {
        private const string applicationProjectName = "Applications";


        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var assembly = Assembly.Load(applicationProjectName);

            services.AddDbContext<GuideContext>(options =>
                 options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                 o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)));

            services.AddScoped<IFinanceService, FinanceService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddAutoMapper(assembly);

            services.AddMediatr();
            return services;

        }

        public static IServiceCollection AddRepository(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IMetaRepository, MetaRepository>();


            return services;
        }

        private static void AddMediatr(this IServiceCollection services)
        {
            var assembly = Assembly.Load(applicationProjectName);
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.Load(applicationProjectName)));
        }
    }
}
