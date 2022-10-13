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

        public void ExcluirPagamento(Guid codigo)
        {
            var pagamento = _context.Pagamentos.FirstOrDefault(p => p.Codigo == codigo);

            if (pagamento == null) return;

            _context.Pagamentos.Remove(pagamento);

            _context.SaveChanges();
        }

        public IReadOnlyCollection<Pagamento> ObterPagamentos()
        {
            var pagamentosEF = _context.Pagamentos.ToList();

            return pagamentosEF.Select(_mapper.Map<Pagamento>).ToList();
        }
    }
}
