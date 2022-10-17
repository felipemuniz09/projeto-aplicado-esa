using FinancasParaCasais.Domain.Entities;
using FluentAssertions;

namespace FinancasParaCasais.Domain.Test.Entities
{
    public class TransferenciaTest
    {
        [Fact]
        public void DeveConsiderarInvalidoQuandoCodigoConjugePagouForVazio()
        {
            // When
            var transferencia = new Transferencia(Guid.Empty, Guid.NewGuid(), 10);

            // Then
            transferencia.Notifications.Should().Contain(n => n.Message == "Código do cônjuge que pagou deve ser informado.");
        }

        [Fact]
        public void DeveConsiderarInvalidoQuandoCodigoConjugeRecebeuForVazio()
        {
            // When
            var transferencia = new Transferencia(Guid.NewGuid(), Guid.Empty, 10);

            // Then
            transferencia.Notifications.Should().Contain(n => n.Message == "Código do cônjuge que recebeu deve ser informado.");
        }

        [Fact]
        public void DeveConsiderarInvalidoQuandoCodigosDosConjugesForemIguais()
        {
            // Given
            var codigoConjuge = Guid.NewGuid();

            // When
            var transferencia = new Transferencia(codigoConjuge, codigoConjuge, 10);

            // Then
            transferencia.Notifications.Should().Contain(
                n => n.Message == "Código do cônjuge que pagou deve ser diferente do código do cônjuge que recebeu.");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-0.01)]
        public void DeveConsiderarInvalidoQuandoValorForNegativoOuZero(decimal valor)
        {
            // When
            var transferencia = new Transferencia(Guid.NewGuid(), Guid.NewGuid(), valor);

            // Then
            transferencia.Notifications.Should().Contain(n => n.Message == "Valor deve ser maior que zero.");
        }
    }
}
