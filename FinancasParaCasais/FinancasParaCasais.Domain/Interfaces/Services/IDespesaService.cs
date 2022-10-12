using FinancasParaCasais.Domain.Entities;
using FinancasParaCasais.Domain.ValueObject;

namespace FinancasParaCasais.Domain.Interfaces.Services
{
    public interface IDespesaService
    {
        void InserirDespesa(Despesa despesa);
        IReadOnlyCollection<SaldoDespesaPorConjugeValueObject> CalcularSaldoDespesaPorConjuge(IReadOnlyCollection<Conjuge> conjuges);
    }
}
