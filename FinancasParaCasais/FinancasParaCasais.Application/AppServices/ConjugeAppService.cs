using AutoMapper;
using FinancasParaCasais.Application.Commands;
using FinancasParaCasais.Application.Interfaces.AppService;
using FinancasParaCasais.Application.Interfaces.Notifications;
using FinancasParaCasais.Domain.Entities;
using FinancasParaCasais.Domain.Interfaces.Services;

namespace FinancasParaCasais.Application.AppServices
{
    public class ConjugeAppService : IConjugeAppService
    {
        private readonly IConjugeService _conjugeService;
        private readonly IMapper _mapper;
        private readonly INotificationService _notificationService;

        public ConjugeAppService(IConjugeService conjugeService, IMapper mapper, INotificationService notificationService)
        {
            _conjugeService = conjugeService;
            _mapper = mapper;
            _notificationService = notificationService;
        }

        public void EditarConjuges(EditarConjugesCommand editarConjugesCommand)
        {
            editarConjugesCommand.Validar();

            _notificationService.AddNotifications(editarConjugesCommand.Notifications);

            if (!editarConjugesCommand.IsValid)     
                return;

            if (editarConjugesCommand.Conjuges != null)
            {
                foreach (var conjugeCommand in editarConjugesCommand.Conjuges)
                {
                    var conjuge = _mapper.Map<Conjuge>(conjugeCommand);

                    _conjugeService.EditarConjuge(conjuge);

                    _notificationService.AddNotifications(conjuge.Notifications);
                }
            }
        }
    }
}
