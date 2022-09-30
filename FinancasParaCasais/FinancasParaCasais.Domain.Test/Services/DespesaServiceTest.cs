using FinancasParaCasais.Domain.Entities;
using FinancasParaCasais.Domain.Interfaces.Repositories;
using FinancasParaCasais.Domain.Services;
using Moq;

namespace FinancasParaCasais.Domain.Test.Services
{
    public class DespesaServiceTest
    {
        private readonly DespesaService _despesaService;
        private readonly Mock<IDespesaRepository> _despesaRepository;

        public DespesaServiceTest()
        {
            _despesaRepository = new Mock<IDespesaRepository>();
            _despesaService = new DespesaService(_despesaRepository.Object);
        }

        [Fact]
        public void DeveInserirQuandoDespesaEstiverValida()
        {
            // Given
            var despesa = new Despesa(Guid.NewGuid(), "Boleto de condomínio", 400);
            despesa.AdicionarPagamento(Guid.NewGuid(), 200);
            despesa.AdicionarPagamento(Guid.NewGuid(), 200);

            // When
            _despesaService.InserirDespesa(despesa);

            // Then
            _despesaRepository.Verify(d => d.InserirDespesa(despesa), Times.Once);
        }

        [Fact]
        public void NaoDeveInserirQuandoDespesaEstiverInvalida()
        {
            // Given
            var despesa = new Despesa(Guid.Empty, "Boleto de condomínio", 400);

            // When
            _despesaService.InserirDespesa(despesa);

            // Then
            _despesaRepository.Verify(d => d.InserirDespesa(despesa), Times.Never);
        }
    }
}
