using FinancasParaCasais.Application.AppServices;
using FinancasParaCasais.Application.Interfaces.AppService;
using FinancasParaCasais.Application.Interfaces.QueryServices;
using FinancasParaCasais.Application.QueryServices;
using FinancasParaCasais.Domain.Interfaces.Repositories;
using FinancasParaCasais.Domain.Interfaces.Services;
using FinancasParaCasais.Domain.Services;
using FinancasParaCasais.Repository;
using FinancasParaCasais.Repository.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FinancasParaCasais.DI
{
    public static class DependencyInjection
    {
        public static void RegisterDependencies(this IServiceCollection services)
        {
            var mapper = AutoMapperConfiguration.CriarMapper();
            services.AddScoped((s) => mapper);

            services.AddScoped<FinancasParaCasaisContext>();
            
            // Query Services
            services.AddScoped<IConjugeQueryService, ConjugeQueryService>();
            
            // App Services
            services.AddScoped<IConjugeAppService, ConjugeAppService>();

            // Services
            services.AddScoped<IConjugeService, ConjugeService>();

            // Repositories
            services.AddScoped<IConjugeRepository, ConjugeRepository>();
        }
    }
}