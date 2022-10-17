using AutoMapper;
using FinancasParaCasais.Application.Commands;
using FinancasParaCasais.Application.DTOs;
using FinancasParaCasais.Application.Interfaces.AppService;
using FinancasParaCasais.Application.Interfaces.Notifications;
using FinancasParaCasais.Domain.Entities;
using FinancasParaCasais.Domain.Interfaces.Repositories;
using FinancasParaCasais.Domain.Interfaces.Services;

namespace FinancasParaCasais.Application.AppServices
{
    public class ConjugeAppService : IConjugeAppService
    {
        private readonly IConjugeService _conjugeService;
        private readonly IMapper _mapper;
        private readonly INotificationService _notificationService;
        private readonly IDespesaService _despesaService;
        private readonly ITransferenciaService _pagamentoService;
        private readonly IConjugeRepository _conjugeRepository;

        public ConjugeAppService(
            IConjugeService conjugeService, 
            IMapper mapper, 
            INotificationService notificationService, 
            IDespesaService despesaService,
            ITransferenciaService pagamentoService,
            IConjugeRepository conjugeRepository)
        {
            _conjugeService = conjugeService;
            _mapper = mapper;
            _notificationService = notificationService;
            _despesaService = despesaService;
            _pagamentoService = pagamentoService;
            _conjugeRepository = conjugeRepository;
        }

        public void EditarConjuges(EditarConjugesCommand editarConjugesCommand)
        {
            editarConjugesCommand.Validar();

            _notificationService.AddNotifications(editarConjugesCommand);

            if (!editarConjugesCommand.IsValid)     
                return;

            if (editarConjugesCommand.Conjuges != null)
            {
                foreach (var conjugeCommand in editarConjugesCommand.Conjuges)
                {
                    var conjuge = _mapper.Map<Conjuge>(conjugeCommand);

                    _conjugeService.EditarConjuge(conjuge);

                    if (conjuge != null)
                        _notificationService.AddNotifications(conjuge);
                }
            }
        }

        public IReadOnlyCollection<SaldoPorConjugeDTO> CalcularSaldoPorConjuge()
        {
            var conjuges = _conjugeRepository.ObterConjuges();

            if (conjuges == null) return new List<SaldoPorConjugeDTO>();

            var codigosConjuges = conjuges.Select(c => c.Codigo).ToList();

            var listaSaldoDespesaPorConjugeValueObject = _despesaService.CalcularSaldoDespesaPorConjuge(conjuges);
            var listaSaldoTransferenciaPorConjugeValueObject = _pagamentoService.CalcularSaldoTransferenciaPorConjuge(codigosConjuges);

            var listaSaldoPorConjugeDTO = new List<SaldoPorConjugeDTO>();

            foreach (var conjuge in conjuges)
            {
                var saldoDespesa = 
                    listaSaldoDespesaPorConjugeValueObject?.FirstOrDefault(s => s.CodigoConjuge == conjuge.Codigo)?.Valor ?? 0;

                var saldoPagamento =
                    listaSaldoTransferenciaPorConjugeValueObject?.FirstOrDefault(s => s.CodigoConjuge == conjuge.Codigo)?.Valor ?? 0;

                var saldoPorConjuge = new SaldoPorConjugeDTO
                {
                    NomeConjuge = conjuge.Nome,
                    Valor = saldoDespesa + saldoPagamento
                };

                listaSaldoPorConjugeDTO.Add(saldoPorConjuge);
            }

            return listaSaldoPorConjugeDTO;
        }
    }
}
