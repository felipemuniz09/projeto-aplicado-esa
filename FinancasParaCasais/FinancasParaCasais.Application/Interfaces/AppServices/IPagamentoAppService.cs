using FinancasParaCasais.Application.Commands;

namespace FinancasParaCasais.Application.Interfaces.AppServices
{
    public interface IPagamentoAppService
    {
        void InserirPagamento(InserirPagamentoCommand inserirPagamentoCommand);
    }
}
