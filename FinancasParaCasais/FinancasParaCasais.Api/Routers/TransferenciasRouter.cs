using FinancasParaCasais.Application.Commands;
using FinancasParaCasais.Application.Interfaces.AppServices;
using FinancasParaCasais.Application.Interfaces.QueryServices;

namespace FinancasParaCasais.Api.Routers
{
    public static class TransferenciasRouter
    {
        public static void MapTransferenciasRoutes(this WebApplication app)
        {
            app.MapPost("/transferencias", (ITransferenciaAppService transferenciaAppService, InserirTransferenciaCommand inserirTransferenciaCommand) =>
            {
                transferenciaAppService.InserirTransferencia(inserirTransferenciaCommand);

                return Results.Ok();
            });

            app.MapDelete("/transferencias", (ITransferenciaAppService transferenciaAppService, Guid codigo) =>
            {
                transferenciaAppService.ExcluirTransferencia(codigo);

                return Results.Ok();
            });

            app.MapGet("/transferencias", (ITransferenciaQueryService transferenciaQueryService) => Results.Ok(transferenciaQueryService.ObterTransferencias()));
        }
    }
}
