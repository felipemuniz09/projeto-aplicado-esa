using AutoMapper;
using FinancasParaCasais.Application.AppServices;
using FinancasParaCasais.Application.Commands;
using FinancasParaCasais.Application.Interfaces.Notifications;
using FinancasParaCasais.Domain.Entities;
using FinancasParaCasais.Domain.Interfaces.Repositories;
using FinancasParaCasais.Domain.Interfaces.Services;
using FinancasParaCasais.Domain.ValueObject;
using FluentAssertions;
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

        [Fact]
        public void DeveCalcularSaldoDeCadaConjuge()
        {
            // Given
            var conjuges = new List<Conjuge>
            {
                new Conjuge("Oscar", 27),
                new Conjuge("Hortência", 73)
            };

            _conjugeRepositoryMock.Setup(c => c.ObterConjuges()).Returns(conjuges);

            // When
            var listaSaldoPorConjuge = _conjugeAppService.CalcularSaldoPorConjuge();

            // Then
            listaSaldoPorConjuge.Should().HaveCount(2);
        }

        [Fact]
        public void DeveCalcularSaldoCorretoDoConjuge()
        {
            // Given
            var conjugeOscar = new Conjuge("Oscar", 27);
            var conjugeHortencia = new Conjuge("Hortência", 73);

            var conjuges = new List<Conjuge> { conjugeOscar, conjugeHortencia };

            _conjugeRepositoryMock.Setup(c => c.ObterConjuges()).Returns(conjuges);

            var listaSaldoDespesaPorConjuge = new List<SaldoDespesaPorConjugeValueObject>
            {
                new SaldoDespesaPorConjugeValueObject { CodigoConjuge = conjugeOscar.Codigo, Valor = 100 },
                new SaldoDespesaPorConjugeValueObject { CodigoConjuge = conjugeHortencia.Codigo, Valor = -100 }
            };

            _despesaServiceMock.Setup(d => d.CalcularSaldoDespesaPorConjuge(conjuges)).Returns(listaSaldoDespesaPorConjuge);

            var listaSaldoPagamentoPorConjuge = new List<SaldoPagamentoPorConjugeValueObject>
            {
                new SaldoPagamentoPorConjugeValueObject { CodigoConjuge = conjugeOscar.Codigo, Valor = -80 },
                new SaldoPagamentoPorConjugeValueObject { CodigoConjuge = conjugeHortencia.Codigo, Valor = 80 }
            };

            var codigosConjuges = conjuges.Select(c => c.Codigo).ToList();

            _pagamentoServiceMock
                .Setup(p => p.CalcularSaldoPagamentoPorConjuge(codigosConjuges)).Returns(listaSaldoPagamentoPorConjuge);

            // When
            var listaSaldoPorConjuge = _conjugeAppService.CalcularSaldoPorConjuge();

            // Then
            var saldoOscar = listaSaldoPorConjuge?.FirstOrDefault(s => s.NomeConjuge == conjugeOscar.Nome)?.Valor ?? 0;
            var saldoHortencia = listaSaldoPorConjuge?.FirstOrDefault(s => s.NomeConjuge == conjugeHortencia.Nome)?.Valor ?? 0;

            saldoOscar.Should().Be(20);
            saldoHortencia.Should().Be(-20);
        }
    }
}
