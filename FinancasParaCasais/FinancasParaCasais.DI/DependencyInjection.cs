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

            services.RegisterQueryServices();
            services.RegisterAppServices();
            services.RegisterDomainServices();
            services.RegisterRepositories();
        }

        private static void RegisterQueryServices(this IServiceCollection services)
        {
            services.AddScoped<IConjugeQueryService, ConjugeQueryService>();
            services.AddScoped<IDespesaQueryService, DespesaQueryService>();
        }

        private static void RegisterAppServices(this IServiceCollection services)
        {
            services.AddScoped<IConjugeAppService, ConjugeAppService>();
        }

        private static void RegisterDomainServices(this IServiceCollection services)
        {
            services.AddScoped<IConjugeService, ConjugeService>();
        }

        private static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IConjugeRepository, ConjugeRepository>();
        }
    }
}