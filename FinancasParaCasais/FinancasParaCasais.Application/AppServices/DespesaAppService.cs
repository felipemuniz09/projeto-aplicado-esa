using FinancasParaCasais.Application.Commands;
using FinancasParaCasais.Application.Interfaces.AppServices;
using FinancasParaCasais.Application.Interfaces.Notifications;
using FinancasParaCasais.Domain.Entities;
using FinancasParaCasais.Domain.Interfaces.Repositories;
using FinancasParaCasais.Domain.Interfaces.Services;

namespace FinancasParaCasais.Application.AppServices
{
    public class DespesaAppService : IDespesaAppService
    {
        private readonly IDespesaService _despesaService;
        private readonly IDespesaRepository _despesaRepository;
        private readonly INotificationService _notificationService;

        public DespesaAppService(IDespesaService despesaService, IDespesaRepository despesaRepository, INotificationService notificationService)
        {
            _despesaService = despesaService;
            _despesaRepository = despesaRepository;
            _notificationService = notificationService;
        }

        public void InserirDespesa(InserirDespesaCommand inserirDespesaCommand)
        {
            inserirDespesaCommand.Validar();

            _notificationService.AddNotifications(inserirDespesaCommand.Notifications);

            if (inserirDespesaCommand.IsValid)
            {
                var despesa = new Despesa(inserirDespesaCommand.Descricao ?? string.Empty, inserirDespesaCommand.Valor);

                var pagamentos = inserirDespesaCommand.Pagamentos ?? new List<InserirDespesaCommand.PagamentoDespesaCommand>();

                foreach (var pagamento in pagamentos)
                    despesa.AdicionarPagamento(pagamento.CodigoConjuge, pagamento.Valor);

                _despesaService.InserirDespesa(despesa);

                _notificationService.AddNotifications(despesa.Notifications);
            }
        }

        public void ExcluirDespesa(Guid codigo) => _despesaRepository.ExcluirDespesa(codigo);
    }
}
