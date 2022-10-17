using FinancasParaCasais.Domain.Entities;
using FinancasParaCasais.Domain.Interfaces.Repositories;
using FinancasParaCasais.Domain.Interfaces.Services;
using FinancasParaCasais.Domain.ValueObject;

namespace FinancasParaCasais.Domain.Services
{
    public class TransferenciaService : ITransferenciaService
    {
        private readonly ITransferenciaRepository _transferenciaRepository;

        public TransferenciaService(ITransferenciaRepository transferenciaRepository)
        {
            _transferenciaRepository = transferenciaRepository;
        }

        public void InserirTransferencia(Transferencia transferencia)
        {
            if (transferencia.IsValid)
                _transferenciaRepository.InserirTransferencia(transferencia);
        }

        public IReadOnlyCollection<SaldoTransferenciaPorConjugeValueObject> CalcularSaldoTransferenciaPorConjuge(
            IReadOnlyCollection<Guid> codigosConjuges)
        {
            var transferencias = _transferenciaRepository.ObterTransferencias();

            var listaSaldoTransferenciaPorConjugeValueObject = new List<SaldoTransferenciaPorConjugeValueObject>();

            foreach (var codigoConjuge in codigosConjuges)
            {
                var totalPago = transferencias?.Where(p => p.CodigoConjugePagou == codigoConjuge).Sum(p => p.Valor) ?? 0;
                var totalRecebido = transferencias?.Where(p => p.CodigoConjugeRecebeu == codigoConjuge).Sum(p => p.Valor) ?? 0;

                var saldoTransferenciaPorConjugeValueObject = new SaldoTransferenciaPorConjugeValueObject
                {
                    CodigoConjuge = codigoConjuge,
                    Valor = totalPago - totalRecebido
                };

                listaSaldoTransferenciaPorConjugeValueObject.Add(saldoTransferenciaPorConjugeValueObject);
            }

            return listaSaldoTransferenciaPorConjugeValueObject;
        }
    }
}
