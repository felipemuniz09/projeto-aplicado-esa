using FinancasParaCasais.Domain.Entities;
using FinancasParaCasais.Domain.ValueObject;

namespace FinancasParaCasais.Domain.Interfaces.Services
{
    public interface ITransferenciaService
    {
        void InserirTransferencia(Transferencia transferencia);
        IReadOnlyCollection<SaldoTransferenciaPorConjugeValueObject> CalcularSaldoTransferenciaPorConjuge(
            IReadOnlyCollection<Guid> codigosConjuges);
    }
}
