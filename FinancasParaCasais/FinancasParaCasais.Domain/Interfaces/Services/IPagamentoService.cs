using FinancasParaCasais.Domain.Entities;

namespace FinancasParaCasais.Domain.Interfaces.Services
{
    public interface IPagamentoService
    {
        void InserirPagamento(Pagamento pagamento);
    }
}
