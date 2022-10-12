using FinancasParaCasais.Domain.Entities;

namespace FinancasParaCasais.Domain.Interfaces.Repositories
{
    public interface IDespesaRepository
    {
        void InserirDespesa(Despesa despesa);
        void ExcluirDespesa(Guid codigo);
        IReadOnlyCollection<Despesa> ObterDespesas();
    }
}
