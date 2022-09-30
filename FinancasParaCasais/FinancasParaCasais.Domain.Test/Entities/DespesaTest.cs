using Bogus.DataSets;
using FinancasParaCasais.Domain.Entities;
using FluentAssertions;

namespace FinancasParaCasais.Domain.Test.Entities
{
    public class DespesaTest
    {
        [Fact]
        public void DeveConsiderarInvalidoQuandoCodigoForVazio()
        {
            // When
            var despesa = new Despesa(Guid.Empty, "Almoço", 50);

            // Then
            despesa.Notifications.Should().Contain(n => n.Message == "Código deve ser informado.");
        }

        [Fact]
        public void DeveConsiderarInvalidoQuandoDescricaoExcederTamanhoMaximo()
        {
            // Given
            var lorem = new Lorem("pt_BR");
            var descricaoMuitoLonga = lorem.Letter(201);

            // When
            var despesa = new Despesa(Guid.NewGuid(), descricaoMuitoLonga, 50);

            // Then
            despesa.Notifications.Should().Contain(n => n.Message == "Descrição possui tamanho máximo de 200 caracteres.");
        }

        [Fact]
        public void DeveConsiderarInvalidoQuandoValorForNegativo()
        {
            // When
            var despesa = new Despesa(Guid.NewGuid(), "Internet", -0.01M);

            // Then
            despesa.Notifications.Should().Contain(n => n.Message == "Valor deve ser maior ou igual a zero.");
        }

        [Fact]
        public void DeveIncluirPagamentoValidoNaListaDePagamentos()
        {
            // Given
            var codigoConjuge = Guid.NewGuid();
            var despesa = new Despesa(Guid.NewGuid(), "Conta de energia", 149.75M);

            // When
            despesa.AdicionarPagamento(codigoConjuge, 49.75M);

            // Then
            despesa.Pagamentos.Should().Contain(p => p.CodigoConjuge == codigoConjuge);
        }

        [Fact]
        public void NaoDeveIncluirPagamentoInvalidoNaListaDePagamentos()
        {
            // Given
            var despesa = new Despesa(Guid.NewGuid(), "Conta de água", 80.5M);

            // When
            despesa.AdicionarPagamento(Guid.Empty, 80.5M);

            // Then
            despesa.Pagamentos.Should().BeEmpty();
        }

        [Fact]
        public void DeveConsiderarInvalidoQuandoListaDePagamentosNaoTiverDoisElementos()
        {
            // Given
            var despesa = new Despesa(Guid.NewGuid(), "Conta de energia", 149.75M);
            despesa.AdicionarPagamento(Guid.NewGuid(), 49.75M);

            // When
            despesa.Validar();

            // Then
            despesa.Notifications.Should().Contain(n => n.Message == "Lista de pagamentos deve conter 2 elementos.");
        }

        [Fact]
        public void DeveConsiderarInvalidoQuandoSomaDosPagamentosForDiferenteDoValorDaDespesa()
        {
            // Given
            var despesa = new Despesa(Guid.NewGuid(), "Conta de energia", 149.75M);
            despesa.AdicionarPagamento(Guid.NewGuid(), 49.75M);
            despesa.AdicionarPagamento(Guid.NewGuid(), 90M);

            // When
            despesa.Validar();

            // Then
            despesa.Notifications.Should().Contain(n => n.Message == "Soma dos pagamentos deve ser igual ao valor da despesa.");
        }
    }
}
