using FinancasParaCasais.Application.Commands;
using FinancasParaCasais.Application.Interfaces.AppService;
using FinancasParaCasais.Application.Interfaces.QueryServices;

namespace FinancasParaCasais.Api.Routers
{
    public static class ConjugesRouter
    {
        public static void MapConjugesRoutes(this WebApplication app)
        {
            app.MapGet("/conjuges", (IConjugeQueryService conjugeQueryService) => Results.Ok(conjugeQueryService.ObterConjuges()));

            app.MapPut("/conjuges", (IConjugeAppService conjugeAppService, EditarConjugesCommand editarConjugesCommand) =>
            {
                conjugeAppService.EditarConjuges(editarConjugesCommand);

                return Results.Ok();
            });
        }
    }
}
