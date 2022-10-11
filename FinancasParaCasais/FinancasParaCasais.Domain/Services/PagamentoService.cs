using FinancasParaCasais.Domain.Entities;
using FinancasParaCasais.Domain.Interfaces.Repositories;
using FinancasParaCasais.Domain.Interfaces.Services;

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
    }
}
