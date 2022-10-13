using FinancasParaCasais.Domain.Entities;
using FinancasParaCasais.Domain.ValueObject;

namespace FinancasParaCasais.Domain.Interfaces.Services
{
    public interface IPagamentoService
    {
        void InserirPagamento(Pagamento pagamento);
        IReadOnlyCollection<SaldoPagamentoPorConjugeValueObject> CalcularSaldoPagamentoPorConjuge(
            IReadOnlyCollection<Guid> codigosConjuges);
    }
}
