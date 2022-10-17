using FinancasParaCasais.Application.Notifications;
using FinancasParaCasais.Domain.Entities;
using FluentAssertions;

namespace FinancasParaCasais.Application.Test.Notifications
{
    public class NotificationServiceTest
    {
        private readonly NotificationService _notificationService;

        public NotificationServiceTest()
        {
            _notificationService = new NotificationService();
        }

        [Fact]
        public void DeveInserirNotificacoesQuandoObjetoEstiverInvalido()
        {
            // Given
            var transferencia = new Transferencia(Guid.NewGuid(), Guid.Empty, -1);

            // When
            _notificationService.AddNotifications(transferencia);

            // Then
            _notificationService.GetNotifications().Should().HaveCount(2);
        }

        [Fact]
        public void NaoDeveInserirNotificacoesQuandoObjetoEstiverValido()
        {
            // Given
            var transferencia = new Transferencia(Guid.NewGuid(), Guid.NewGuid(), 1);

            // When
            _notificationService.AddNotifications(transferencia);

            // Then
            _notificationService.GetNotifications().Should().BeEmpty();
        }
    }
}
