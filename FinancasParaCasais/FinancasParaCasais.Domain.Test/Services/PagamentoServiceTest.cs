using FinancasParaCasais.Domain.Entities;
using FinancasParaCasais.Domain.Interfaces.Repositories;
using FinancasParaCasais.Domain.Services;
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
    }
}
