using FinancasParaCasais.Application.DTOs;

namespace FinancasParaCasais.Application.Interfaces.QueryServices
{
    public interface IConjugeQueryService
    {
        IReadOnlyCollection<ConjugeDTO> ObterConjuges();
    }
}
