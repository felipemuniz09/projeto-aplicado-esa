using FinancasParaCasais.Domain.Entities;
using FinancasParaCasais.Domain.Interfaces.Repositories;
using FinancasParaCasais.Domain.Services;
using FluentAssertions;
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
            var despesa = new Despesa("Boleto de condomínio", 400);
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
            var despesa = new Despesa("Boleto de condomínio", -400);

            // When
            _despesaService.InserirDespesa(despesa);

            // Then
            _despesaRepository.Verify(d => d.InserirDespesa(despesa), Times.Never);
        }

        [Fact]
        public void DeveRetornarSaldoDeCadaConjuge()
        {
            // Given
            var conjuges = new List<Conjuge>
            {
                new Conjuge("Wladimir Meireles", 35),
                new Conjuge("Ana Flor", 65)
            };

            // When
            var listaSaldoDespesaPorConjuge = _despesaService.CalcularSaldoDespesaPorConjuge(conjuges);

            // Then
            listaSaldoDespesaPorConjuge.Should().HaveCount(2);
        }

        [Fact]
        public void DeveRetornarSaldoCorretoDoConjuge()
        {
            // Given
            var conjugeWladimirMeireles = new Conjuge("Wladimir Meireles", 35);
            var conjugeAnaFlor = new Conjuge("Ana Flor", 65);

            var conjuges = new List<Conjuge> { conjugeWladimirMeireles, conjugeAnaFlor };

            var despesaVermifugo = new Despesa("Vermífugo do cachorro", 85);
            despesaVermifugo.AdicionarPagamento(conjugeWladimirMeireles.Codigo, 47);
            despesaVermifugo.AdicionarPagamento(conjugeAnaFlor.Codigo, 38);

            var despesaJogoToalhas = new Despesa("Jogo de toalhas", 230);
            despesaJogoToalhas.AdicionarPagamento(conjugeWladimirMeireles.Codigo, 120);
            despesaJogoToalhas.AdicionarPagamento(conjugeAnaFlor.Codigo, 110);

            var despesas = new List<Despesa> { despesaVermifugo, despesaJogoToalhas };

            _despesaRepository.Setup(d => d.ObterDespesas()).Returns(despesas);

            // When
            var listaSaldoDespesaPorConjuge = _despesaService.CalcularSaldoDespesaPorConjuge(conjuges);

            // Then
            var saldoWladimirMeireles =
                listaSaldoDespesaPorConjuge.FirstOrDefault(s => s.CodigoConjuge == conjugeWladimirMeireles.Codigo)?.Valor ?? 0;

            var saldoAnaFlor =
                listaSaldoDespesaPorConjuge.FirstOrDefault(s => s.CodigoConjuge == conjugeAnaFlor.Codigo)?.Valor ?? 0;

            saldoWladimirMeireles.Should().Be(56.75M);
            saldoAnaFlor.Should().Be(-56.75M);
        }
    }
}
