using FinancasParaCasais.Application.Commands;
using FinancasParaCasais.Application.Interfaces.AppServices;
using FinancasParaCasais.Application.Interfaces.QueryServices;

namespace FinancasParaCasais.Api.Routers
{
    public static class PagamentosRouter
    {
        public static void MapPagamentosRoutes(this WebApplication app)
        {
            app.MapPost("/pagamentos", (IPagamentoAppService pagamentoAppService, InserirPagamentoCommand inserirPagamentoCommand) =>
            {
                pagamentoAppService.InserirPagamento(inserirPagamentoCommand);

                return Results.Ok();
            });

            app.MapDelete("/pagamentos", (IPagamentoAppService pagamentoAppService, Guid codigo) =>
            {
                pagamentoAppService.ExcluirPagamento(codigo);

                return Results.Ok();
            });

            app.MapGet("/pagamentos", (IPagamentoQueryService pagamentoQueryService) => Results.Ok(pagamentoQueryService.ObterPagamentos()));
        }
    }
}
