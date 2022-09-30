using FinancasParaCasais.Domain.ValueObject;
using FluentAssertions;

namespace FinancasParaCasais.Domain.Test.ValueObject
{
    public class PagamentoDespesaValueObjectTest
    {
        [Fact]
        public void DeveConsiderarInvalidoQuandoCodigoDoConjugeNaoForInformado()
        {
            // When
            var despesaConjugeValueObject = new PagamentoDespesaValueObject(Guid.Empty, 7);

            // Then
            despesaConjugeValueObject.Notifications.Should().Contain(n => n.Message == "Código do cônjuge deve ser informado.");
        }

        [Fact]
        public void DeveConsiderarInvalidoQuandoValorForNegativo()
        {
            // When
            var despesaConjugeValueOject = new PagamentoDespesaValueObject(Guid.NewGuid(), -0.01M);

            // Then
            despesaConjugeValueOject.Notifications.Should().Contain(n => n.Message == "Valor deve ser maior ou igual a zero.");
        }
    }
}
