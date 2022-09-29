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
    }
}
