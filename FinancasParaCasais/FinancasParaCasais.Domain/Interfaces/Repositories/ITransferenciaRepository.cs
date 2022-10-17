using FinancasParaCasais.Domain.Entities;

namespace FinancasParaCasais.Domain.Interfaces.Repositories
{
    public interface ITransferenciaRepository
    {
        void InserirTransferencia(Transferencia transferencia);
        void ExcluirTransferencia(Guid codigo);
        IReadOnlyCollection<Transferencia> ObterTransferencias();
    }
}
