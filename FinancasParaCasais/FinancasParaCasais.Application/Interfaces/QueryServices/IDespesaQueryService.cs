using FinancasParaCasais.Application.QueryResults;

namespace FinancasParaCasais.Application.Interfaces.QueryServices
{
    public interface IDespesaQueryService
    {
        IReadOnlyCollection<DespesaQueryResult> ObterDespesas();
    }
}
