using FinancasParaCasais.Application.Interfaces.QueryServices;

namespace FinancasParaCasais.Api.Routers
{
    public static class ConjugesRouter
    {
        public static void MapConjugesRoutes(this WebApplication app)
        {
            app.MapGet("/conjuges", (IConjugeQueryService conjugeQueryService) => Results.Ok(conjugeQueryService.ObterConjuges()));
        }
    }
}
