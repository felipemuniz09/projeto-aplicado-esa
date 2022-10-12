using FinancasParaCasais.Application.QueryResults;

namespace FinancasParaCasais.Application.Interfaces.QueryServices
{
    public interface IPagamentoQueryService
    {
        IReadOnlyCollection<PagamentoQueryResult> ObterPagamentos();
    }
}
