using AutoMapper;
using FinancasParaCasais.Application.AppServices;
using FinancasParaCasais.Application.Commands;
using FinancasParaCasais.Application.Interfaces.Notifications;
using FinancasParaCasais.Domain.Entities;
using FinancasParaCasais.Domain.Interfaces.Repositories;
using FinancasParaCasais.Domain.Interfaces.Services;
using Moq;

namespace FinancasParaCasais.Application.Test.AppServices
{
    public class ConjugeAppServiceTest
    {
        private readonly ConjugeAppService _conjugeAppService;
        private readonly Mock<IConjugeService> _conjugeServiceMock;
        private readonly Mock<INotificationService> _notificationServiceMock;
        private readonly Mock<IDespesaService> _despesaServiceMock;
        private readonly Mock<IPagamentoService> _pagamentoServiceMock;
        private readonly Mock<IConjugeRepository> _conjugeRepositoryMock;

        public ConjugeAppServiceTest()
        {
            var mapper = new Mock<IMapper>();
            _conjugeServiceMock = new Mock<IConjugeService>();
            _notificationServiceMock = new Mock<INotificationService>();
            _despesaServiceMock = new Mock<IDespesaService>();
            _pagamentoServiceMock = new Mock<IPagamentoService>();
            _conjugeRepositoryMock = new Mock<IConjugeRepository>();
            
            _conjugeAppService = new ConjugeAppService(
                _conjugeServiceMock.Object, 
                mapper.Object, 
                _notificationServiceMock.Object,
                _despesaServiceMock.Object,
                _pagamentoServiceMock.Object,
                _conjugeRepositoryMock.Object);
        }

        [Fact]
        public void NaoDeveSalvarEdicaoQuandoCommandEstiverInvalido()
        {
            // Given
            var editarConjugesCommand = new EditarConjugesCommand();

            // When
            _conjugeAppService.EditarConjuges(editarConjugesCommand);

            // Then
            _conjugeServiceMock.Verify(c => c.EditarConjuge(It.IsAny<Conjuge>()), Times.Never());
        }

        [Fact]
        public void DeveSalvarEdicaoDeCadaConjugeQuandoCommandEstiverValido()
        {
            // Given
            var editarConjugesCommand = new EditarConjugesCommand
            {
                Conjuges = new List<EditarConjugesCommand.ConjugeCommand>
                {
                    new EditarConjugesCommand.ConjugeCommand
                    {
                        Codigo = Guid.NewGuid(),
                        Nome = "João",
                        Percentual = 40
                    },
                    new EditarConjugesCommand.ConjugeCommand
                    {
                        Codigo = Guid.NewGuid(),
                        Nome = "José",
                        Percentual = 60
                    }
                }
            };

            // When
            _conjugeAppService.EditarConjuges(editarConjugesCommand);

            // Then
            _conjugeServiceMock.Verify(c => c.EditarConjuge(It.IsAny<Conjuge>()), Times.Exactly(2));
        }
    }
}
