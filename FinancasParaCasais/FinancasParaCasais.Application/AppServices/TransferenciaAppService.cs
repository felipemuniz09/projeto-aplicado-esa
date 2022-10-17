using AutoMapper;
using FinancasParaCasais.Application.Commands;
using FinancasParaCasais.Application.Interfaces.AppServices;
using FinancasParaCasais.Application.Interfaces.Notifications;
using FinancasParaCasais.Domain.Entities;
using FinancasParaCasais.Domain.Interfaces.Repositories;
using FinancasParaCasais.Domain.Interfaces.Services;

namespace FinancasParaCasais.Application.AppServices
{
    public class TransferenciaAppService : ITransferenciaAppService
    {
        private readonly ITransferenciaService _transferenciaService;
        private readonly IMapper _mapper;
        private readonly INotificationService _notificationService;
        private readonly ITransferenciaRepository _transferenciaRepository;

        public TransferenciaAppService(
            ITransferenciaService transferenciaService, 
            IMapper mapper, 
            INotificationService notificationService, 
            ITransferenciaRepository transferenciaRepository)
        {
            _transferenciaService = transferenciaService;
            _mapper = mapper;
            _notificationService = notificationService;
            _transferenciaRepository = transferenciaRepository;
        }

        public void InserirTransferencia(InserirTransferenciaCommand inserirTransferenciaCommand)
        {
            var transferencia = _mapper.Map<Transferencia>(inserirTransferenciaCommand);

            _transferenciaService.InserirTransferencia(transferencia);

            _notificationService.AddNotifications(transferencia);
        }

        public void ExcluirTransferencia(Guid codigo) => _transferenciaRepository.ExcluirTransferencia(codigo);
    }
}