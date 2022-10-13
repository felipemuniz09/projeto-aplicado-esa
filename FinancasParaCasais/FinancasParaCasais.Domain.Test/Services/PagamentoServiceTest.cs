using FinancasParaCasais.Domain.Entities;
using FinancasParaCasais.Domain.Interfaces.Repositories;
using FinancasParaCasais.Domain.Services;
using FluentAssertions;
using Moq;

namespace FinancasParaCasais.Domain.Test.Services
{
    public class PagamentoServiceTest
    {
        private readonly PagamentoService _pagamentoService;
        private readonly Mock<IPagamentoRepository> _pagamentoRepositoryMock;

        public PagamentoServiceTest()
        {
            _pagamentoRepositoryMock = new Mock<IPagamentoRepository>();
            _pagamentoService = new PagamentoService(_pagamentoRepositoryMock.Object);
        }

        [Fact]
        public void DeveInserirQuandoPagamentoEstiverValido()
        {
            // Given
            var pagamento = new Pagamento(Guid.NewGuid(), Guid.NewGuid(), 100);

            // When
            _pagamentoService.InserirPagamento(pagamento);

            // Then
            _pagamentoRepositoryMock.Verify(p => p.InserirPagamento(pagamento), Times.Once);
        }

        [Fact]
        public void NaoDeveInserirQuandoPagamentoEstiverInvalido()
        {
            // Given
            var pagamento = new Pagamento(Guid.NewGuid(), Guid.NewGuid(), -10);

            // When
            _pagamentoService.InserirPagamento(pagamento);

            // Then
            _pagamentoRepositoryMock.Verify(p => p.InserirPagamento(pagamento), Times.Never);
        }

        [Fact]
        public void DeveRetornarSaldoDeCadaConjuge()
        {
            // Given
            var codigosConjuges = new List<Guid> { Guid.NewGuid(), Guid.NewGuid() };

            // When
            var listaSaldoDespesaPorConjuge = _pagamentoService.CalcularSaldoPagamentoPorConjuge(codigosConjuges);

            // Then
            listaSaldoDespesaPorConjuge.Should().HaveCount(2);
        }

        [Fact]
        public void DeveRetornarSaldoCorretoDeCadaConjuge()
        {
            // Given
            var codigoConjuge1 = Guid.NewGuid();
            var codigoConjuge2 = Guid.NewGuid();

            var codigosConjuges = new List<Guid> { codigoConjuge1, codigoConjuge2 };

            var pagamentos = new List<Pagamento>
            {
                new Pagamento(codigoConjuge1, codigoConjuge2, 77),
                new Pagamento(codigoConjuge1, codigoConjuge2, 64),
                new Pagamento(codigoConjuge2, codigoConjuge1, 39)
            };

            _pagamentoRepositoryMock.Setup(p => p.ObterPagamentos()).Returns(pagamentos);

            // When
            var listaSaldoDespesaPorConjuge = _pagamentoService.CalcularSaldoPagamentoPorConjuge(codigosConjuges);

            // Then
            var saldoConjuge1 =
                listaSaldoDespesaPorConjuge.FirstOrDefault(s => s.CodigoConjuge == codigoConjuge1)?.Valor ?? 0;

            var saldoConjuge2 =
                listaSaldoDespesaPorConjuge.FirstOrDefault(s => s.CodigoConjuge == codigoConjuge2)?.Valor ?? 0;

            saldoConjuge1.Should().Be(102);
            saldoConjuge2.Should().Be(-102);
        }
    }
}
