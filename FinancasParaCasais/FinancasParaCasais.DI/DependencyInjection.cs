using FinancasParaCasais.Application.Interfaces.QueryServices;
using FinancasParaCasais.Application.QueryServices;
using Microsoft.Extensions.DependencyInjection;

namespace FinancasParaCasais.DI
{
    public static class DependencyInjection
    {
        public static void RegisterDependencies(this IServiceCollection services)
        {
            services.AddScoped<IConjugeQueryService, ConjugeQueryService>();
        }
    }
}