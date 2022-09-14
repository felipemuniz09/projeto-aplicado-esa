using FinancasParaCasais.Application.DTOs;
using FinancasParaCasais.Application.Interfaces.QueryServices;

namespace FinancasParaCasais.Application.QueryServices
{
    public class ConjugeQueryService : IConjugeQueryService
    {
        public IReadOnlyCollection<ConjugeDTO> ObterConjuges()
        {
            return new List<ConjugeDTO> { new ConjugeDTO { Codigo = Guid.NewGuid(), Nome = "teste", Percentual = 70 } };
        }
    }
}
