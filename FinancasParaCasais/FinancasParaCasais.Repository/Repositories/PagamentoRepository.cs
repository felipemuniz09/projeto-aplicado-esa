using AutoMapper;
using FinancasParaCasais.Domain.Entities;
using FinancasParaCasais.Domain.Interfaces.Repositories;
using FinancasParaCasais.Repository.Entities;

namespace FinancasParaCasais.Repository.Repositories
{
    public class PagamentoRepository : BaseRepository, IPagamentoRepository
    {
        public PagamentoRepository(FinancasParaCasaisContext context, IMapper mapper) 
            : base(context, mapper) { }

        public void InserirPagamento(Pagamento pagamento)
        {
            var pagamentoEF = _mapper.Map<PagamentoEF>(pagamento);

            _context.Pagamentos.Add(pagamentoEF);

            _context.SaveChanges();
        }
    }
}
