using FinancasParaCasais.Domain.Entities;
using FinancasParaCasais.Domain.Interfaces.Repositories;
using FinancasParaCasais.Domain.Interfaces.Services;
using FinancasParaCasais.Domain.ValueObject;

namespace FinancasParaCasais.Domain.Services
{
    public class DespesaService : IDespesaService
    {
        private readonly IDespesaRepository _despesaRepository;

        public DespesaService(IDespesaRepository despesaRepository)
        {
            _despesaRepository = despesaRepository;
        }

        public void InserirDespesa(Despesa despesa)
        {
            if (despesa.IsValid)
                _despesaRepository.InserirDespesa(despesa);
        }

        public IReadOnlyCollection<SaldoDespesaPorConjugeValueObject> CalcularSaldoDespesaPorConjuge(IReadOnlyCollection<Conjuge> conjuges)
        {
            var despesas = _despesaRepository.ObterDespesas();

            var listaTotalDespesaPorConjugeValueObject = new List<SaldoDespesaPorConjugeValueObject>();

            foreach (var conjuge in conjuges)
            {
                var codigoConjuge = conjuge.Codigo;

                var totalDespesa = despesas?.Sum(d => d.Valor * conjuge.Percentual / 100) ?? 0;

                var totalPagamentos = despesas?.SelectMany(d => d.Pagamentos).Where(p => p.CodigoConjuge == codigoConjuge).Sum(p => p.Valor) ?? 0;

                var totalDespesaPorConjugeValueObject = new SaldoDespesaPorConjugeValueObject
                {
                    CodigoConjuge = codigoConjuge,
                    Valor = totalPagamentos - totalDespesa
                };

                listaTotalDespesaPorConjugeValueObject.Add(totalDespesaPorConjugeValueObject);
            }

            return listaTotalDespesaPorConjugeValueObject;
        }
    }
}
