using FinancasParaCasais.Domain.Entities;
using FinancasParaCasais.Domain.Interfaces.Repositories;
using FinancasParaCasais.Domain.Services;
using FluentAssertions;
using Moq;

namespace FinancasParaCasais.Domain.Test.Services
{
    public class TransferenciaServiceTest
    {
        private readonly TransferenciaService _transferenciaService;
        private readonly Mock<ITransferenciaRepository> _transferenciaRepositoryMock;

        public TransferenciaServiceTest()
        {
            _transferenciaRepositoryMock = new Mock<ITransferenciaRepository>();
            _transferenciaService = new TransferenciaService(_transferenciaRepositoryMock.Object);
        }

        [Fact]
        public void DeveInserirQuandoPagamentoEstiverValido()
        {
            // Given
            var transferencia = new Transferencia(Guid.NewGuid(), Guid.NewGuid(), 100);

            // When
            _transferenciaService.InserirTransferencia(transferencia);

            // Then
            _transferenciaRepositoryMock.Verify(p => p.InserirTransferencia(transferencia), Times.Once);
        }

        [Fact]
        public void NaoDeveInserirQuandoPagamentoEstiverInvalido()
        {
            // Given
            var transferencia = new Transferencia(Guid.NewGuid(), Guid.NewGuid(), -10);

            // When
            _transferenciaService.InserirTransferencia(transferencia);

            // Then
            _transferenciaRepositoryMock.Verify(p => p.InserirTransferencia(transferencia), Times.Never);
        }

        [Fact]
        public void DeveRetornarSaldoDeCadaConjuge()
        {
            // Given
            var codigosConjuges = new List<Guid> { Guid.NewGuid(), Guid.NewGuid() };

            // When
            var listaSaldoTransferenciaPorConjuge = _transferenciaService.CalcularSaldoTransferenciaPorConjuge(codigosConjuges);

            // Then
            listaSaldoTransferenciaPorConjuge.Should().HaveCount(2);
        }

        [Fact]
        public void DeveRetornarSaldoCorretoDeCadaConjuge()
        {
            // Given
            var codigoConjuge1 = Guid.NewGuid();
            var codigoConjuge2 = Guid.NewGuid();

            var codigosConjuges = new List<Guid> { codigoConjuge1, codigoConjuge2 };

            var transferencias = new List<Transferencia>
            {
                new Transferencia(codigoConjuge1, codigoConjuge2, 77),
                new Transferencia(codigoConjuge1, codigoConjuge2, 64),
                new Transferencia(codigoConjuge2, codigoConjuge1, 39)
            };

            _transferenciaRepositoryMock.Setup(p => p.ObterTransferencias()).Returns(transferencias);

            // When
            var listaSaldoTransferenciaPorConjuge = _transferenciaService.CalcularSaldoTransferenciaPorConjuge(codigosConjuges);

            // Then
            var saldoConjuge1 =
                listaSaldoTransferenciaPorConjuge.FirstOrDefault(s => s.CodigoConjuge == codigoConjuge1)?.Valor ?? 0;

            var saldoConjuge2 =
                listaSaldoTransferenciaPorConjuge.FirstOrDefault(s => s.CodigoConjuge == codigoConjuge2)?.Valor ?? 0;

            saldoConjuge1.Should().Be(102);
            saldoConjuge2.Should().Be(-102);
        }
    }
}
