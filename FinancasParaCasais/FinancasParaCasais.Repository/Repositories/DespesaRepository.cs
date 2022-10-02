using AutoMapper;
using FinancasParaCasais.Domain.Entities;
using FinancasParaCasais.Domain.Interfaces.Repositories;
using FinancasParaCasais.Repository.Entities;

namespace FinancasParaCasais.Repository.Repositories
{
    public class DespesaRepository : BaseRepository, IDespesaRepository
    {
        public DespesaRepository(FinancasParaCasaisContext context, IMapper mapper) 
            : base(context, mapper) { }

        public void InserirDespesa(Despesa despesa)
        {
            var despesaEF = _mapper.Map<DespesaEF>(despesa);
            despesaEF.Codigo = Guid.NewGuid();

            using var transaction = _context.Database.BeginTransaction();

            _context.Despesas.Add(despesaEF);

            _context.SaveChanges();

            foreach (var pagamento in despesa.Pagamentos)
            {
                var despesaConjugeEF = _mapper.Map<DespesaConjugeEF>(pagamento);

                despesaConjugeEF.CodigoDespesa = despesaEF.Codigo;

                _context.DespesaConjuge.Add(despesaConjugeEF);
            }

            _context.SaveChanges();

            transaction.Commit();
        }

        public void ExcluirDespesa(Guid codigo)
        {
            var listaDespesaConjuge = _context.DespesaConjuge.Where(d => d.CodigoDespesa == codigo).ToList();
            var despesa = _context.Despesas.FirstOrDefault(d => d.Codigo == codigo);

            using var transaction = _context.Database.BeginTransaction();

            if (listaDespesaConjuge.Any())
            {
                _context.DespesaConjuge.RemoveRange(listaDespesaConjuge);
                _context.SaveChanges();
            }

            if (despesa != null)
            {
                _context.Despesas.Remove(despesa);
                _context.SaveChanges();
            }

            transaction.Commit();
        }
    }
}
