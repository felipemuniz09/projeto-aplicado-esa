using FinancasParaCasais.Domain.Entities;

namespace FinancasParaCasais.Domain.Interfaces.Repositories
{
    public interface IConjugeRepository
    {
        void AtualizarConjuge(Conjuge conjuge);
        IReadOnlyCollection<Conjuge> ObterConjuges();
    }
}
