using FinancasParaCasais.Domain.Entities;

namespace FinancasParaCasais.Domain.Interfaces.Repositories
{
    public interface IPagamentoRepository
    {
        void InserirPagamento(Pagamento pagamento);
        void ExcluirPagamento(Guid codigo);
    }
}
