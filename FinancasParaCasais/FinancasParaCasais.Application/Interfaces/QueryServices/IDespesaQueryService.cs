using FinancasParaCasais.Application.QueryResults;

namespace FinancasParaCasais.Application.Interfaces.QueryServices
{
    public interface IDespesaQueryService
    {
        IReadOnlyCollection<DespesaListaQueryResult> ObterDespesas();
        DespesaDetalhesQueryResult ObterDespesa(Guid codigo);
    }
}
