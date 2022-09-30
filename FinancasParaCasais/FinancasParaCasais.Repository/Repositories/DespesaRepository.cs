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

            _context.Despesas.Add(despesaEF);

            _context.SaveChanges();
        }
    }
}
