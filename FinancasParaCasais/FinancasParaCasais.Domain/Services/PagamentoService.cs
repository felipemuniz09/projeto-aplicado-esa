using FinancasParaCasais.Domain.Entities;
using FinancasParaCasais.Domain.Interfaces.Repositories;
using FinancasParaCasais.Domain.Interfaces.Services;
using FinancasParaCasais.Domain.ValueObject;

namespace FinancasParaCasais.Domain.Services
{
    public class PagamentoService : IPagamentoService
    {
        private readonly IPagamentoRepository _pagamentoRepository;

        public PagamentoService(IPagamentoRepository pagamentoRepository)
        {
            _pagamentoRepository = pagamentoRepository;
        }

        public void InserirPagamento(Pagamento pagamento)
        {
            if (pagamento.IsValid)
                _pagamentoRepository.InserirPagamento(pagamento);
        }

        public IReadOnlyCollection<SaldoPagamentoPorConjugeValueObject> CalcularSaldoPagamentoPorConjuge(
            IReadOnlyCollection<Guid> codigosConjuges)
        {
            var pagamentos = _pagamentoRepository.ObterPagamentos();

            var listaSaldoPagamentoPorConjugeValueObject = new List<SaldoPagamentoPorConjugeValueObject>();

            foreach (var codigoConjuge in codigosConjuges)
            {
                var totalPago = pagamentos?.Where(p => p.CodigoConjugePagou == codigoConjuge).Sum(p => p.Valor) ?? 0;
                var totalRecebido = pagamentos?.Where(p => p.CodigoConjugeRecebeu == codigoConjuge).Sum(p => p.Valor) ?? 0;

                var saldoPagamentoPorConjugeValueObject = new SaldoPagamentoPorConjugeValueObject
                {
                    CodigoConjuge = codigoConjuge,
                    Valor = totalPago - totalRecebido
                };

                listaSaldoPagamentoPorConjugeValueObject.Add(saldoPagamentoPorConjugeValueObject);
            }

            return listaSaldoPagamentoPorConjugeValueObject;
        }
    }
}
