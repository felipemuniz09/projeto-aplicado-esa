using FinancasParaCasais.Application.Commands;
using FinancasParaCasais.Application.Interfaces.AppServices;

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
        }
    }
}
