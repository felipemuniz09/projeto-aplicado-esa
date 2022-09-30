using FinancasParaCasais.Application.Commands;
using FinancasParaCasais.Application.Interfaces.AppServices;
using FinancasParaCasais.Domain.Entities;
using FinancasParaCasais.Domain.Interfaces.Services;

namespace FinancasParaCasais.Application.AppServices
{
    public class DespesaAppService : IDespesaAppService
    {
        private readonly IDespesaService _despesaService;

        public DespesaAppService(IDespesaService despesaService)
        {
            _despesaService = despesaService;
        }

        public void InserirDespesa(InserirDespesaCommand inserirDespesaCommand)
        {
            if (inserirDespesaCommand == null)
                throw new ArgumentNullException(nameof(inserirDespesaCommand));

            inserirDespesaCommand.Validar();

            if (inserirDespesaCommand.IsValid)
            {
                var despesa = new Despesa(inserirDespesaCommand.Descricao, inserirDespesaCommand.Valor);

                foreach (var pagamento in inserirDespesaCommand.Pagamentos)
                    despesa.AdicionarPagamento(pagamento.CodigoConjuge, pagamento.Valor);

                _despesaService.InserirDespesa(despesa);
            }
        }
    }
}
