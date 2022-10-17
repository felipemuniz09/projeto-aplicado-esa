using FinancasParaCasais.Application.QueryResults;

namespace FinancasParaCasais.Application.Interfaces.QueryServices
{
    public interface ITransferenciaQueryService
    {
        IReadOnlyCollection<TransferenciaQueryResult> ObterTransferencias();
    }
}
