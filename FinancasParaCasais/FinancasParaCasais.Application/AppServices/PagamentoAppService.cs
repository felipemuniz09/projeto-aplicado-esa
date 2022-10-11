﻿using AutoMapper;
using FinancasParaCasais.Application.Commands;
using FinancasParaCasais.Application.Interfaces.AppServices;
using FinancasParaCasais.Application.Interfaces.Notifications;
using FinancasParaCasais.Domain.Entities;
using FinancasParaCasais.Domain.Interfaces.Services;

namespace FinancasParaCasais.Application.AppServices
{
    public class PagamentoAppService : IPagamentoAppService
    {
        private readonly IPagamentoService _pagamentoService;
        private readonly IMapper _mapper;
        private readonly INotificationService _notificationService;

        public PagamentoAppService(IPagamentoService pagamentoService, IMapper mapper, INotificationService notificationService)
        {
            _pagamentoService = pagamentoService;
            _mapper = mapper;
            _notificationService = notificationService;
        }

        public void InserirPagamento(InserirPagamentoCommand inserirPagamentoCommand)
        {
            var pagamento = _mapper.Map<Pagamento>(inserirPagamentoCommand);

            _pagamentoService.InserirPagamento(pagamento);

            _notificationService.AddNotifications(pagamento);
        }
    }
}