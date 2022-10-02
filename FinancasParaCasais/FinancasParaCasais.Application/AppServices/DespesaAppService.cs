using FinancasParaCasais.Application.Commands;
using FinancasParaCasais.Application.Interfaces.AppServices;
using FinancasParaCasais.Domain.Entities;
using FinancasParaCasais.Domain.Interfaces.Repositories;
using FinancasParaCasais.Domain.Interfaces.Services;

namespace FinancasParaCasais.Application.AppServices
{
    public class DespesaAppService : IDespesaAppService
    {
        private readonly IDespesaService _despesaService;
        private readonly IDespesaRepository _despesaRepository;

        public DespesaAppService(IDespesaService despesaService, IDespesaRepository despesaRepository)
        {
            _despesaService = despesaService;
            _despesaRepository = despesaRepository;
        }

        public void InserirDespesa(InserirDespesaCommand inserirDespesaCommand)
        {
            inserirDespesaCommand.Validar();

            if (inserirDespesaCommand.IsValid)
            {
                var despesa = new Despesa(inserirDespesaCommand.Descricao, inserirDespesaCommand.Valor);

                foreach (var pagamento in inserirDespesaCommand.Pagamentos)
                    despesa.AdicionarPagamento(pagamento.CodigoConjuge, pagamento.Valor);

                _despesaService.InserirDespesa(despesa);
            }
        }

        public void ExcluirDespesa(Guid codigo)
        {
            _despesaRepository.ExcluirDespesa(codigo);
        }
    }
}
