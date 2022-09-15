using FinancasParaCasais.Application.QueryResults;

namespace FinancasParaCasais.Application.Interfaces.QueryServices
{
    public interface IConjugeQueryService
    {
        IReadOnlyCollection<ConjugeQueryResult> ObterConjuges();
    }
}
