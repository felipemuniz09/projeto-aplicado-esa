using FinancasParaCasais.Application.Interfaces.QueryServices;

namespace FinancasParaCasais.Api.Routers
{
    public static class DespesasRouter
    {
        public static void MapDespesasRoutes(this WebApplication app)
        {
            app.MapGet("/despesas", (IDespesaQueryService despesaQueryService) => Results.Ok(despesaQueryService.ObterDespesas()));
        }
    }
}
