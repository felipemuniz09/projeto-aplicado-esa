using FinancasParaCasais.Application.Commands;
using FinancasParaCasais.Application.Interfaces.AppServices;
using FinancasParaCasais.Application.Interfaces.QueryServices;

namespace FinancasParaCasais.Api.Routers
{
    public static class DespesasRouter
    {
        public static void MapDespesasRoutes(this WebApplication app)
        {
            app.MapGet("/despesas", (IDespesaQueryService despesaQueryService) => Results.Ok(despesaQueryService.ObterDespesas()));

            app.MapGet("/despesas/{codigo}", (IDespesaQueryService despesaQueryService, Guid codigo) =>
                Results.Ok(despesaQueryService.ObterDespesa(codigo)));

            app.MapPost("/despesas", (IDespesaAppService despesaAppService, InserirDespesaCommand inserirDespesaCommand) =>
            {
                despesaAppService.InserirDespesa(inserirDespesaCommand);

                return Results.Ok();
            });
        }
    }
}
