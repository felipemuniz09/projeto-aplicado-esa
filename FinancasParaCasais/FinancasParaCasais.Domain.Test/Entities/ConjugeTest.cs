using Bogus.DataSets;
using FinancasParaCasais.Domain.Entities;
using FluentAssertions;

namespace FinancasParaCasais.Domain.Test.Entities
{
    public class ConjugeTest
    {
        [Fact]
        public void DeveConsiderarInvalidoQuandoNomeForVazio() 
        { 
            // When
            var conjuge = new Conjuge(string.Empty, 43);

            // Then
            conjuge.Notifications.Should().Contain(n => n.Message == "Nome deve ser informado.");
        }

        [Fact]
        public void DeveConsiderarInvalidoQuandoNomeForApenasEspacoEmBranco() 
        {
            // When
            var conjuge = new Conjuge("   ", 70);

            // Then
            conjuge.Notifications.Should().Contain(n => n.Message == "Nome deve ser informado.");
        }

        [Fact]
        public void DeveConsiderarInvalidoQuandoNomeExcederTamanhoMaximo() 
        {
            // Given
            var lorem = new Lorem("pt_BR");
            var nomeMuitoGrande = lorem.Letter(101);

            // When
            var conjuge = new Conjuge(nomeMuitoGrande, 33);

            // Then
            conjuge.Notifications.Should().Contain(n => n.Message == "Nome possui tamanho máximo de 100 caracteres.");
        }

        [Fact]
        public void DeveConsiderarPercentualInvalidoQuandoForMenorQueZero() 
        {
            // When
            var conjuge = new Conjuge("Maria", -1);

            // Then
            conjuge.Notifications.Should().Contain(n => n.Message == "O percentual deve ser um valor entre 0 e 100.");
        }

        [Fact]
        public void DeveConsiderarPercentualInvalidoQuandoForMaiorQueCem() 
        {
            // When
            var conjuge = new Conjuge("Maria", 101);

            // Then
            conjuge.Notifications.Should().Contain(n => n.Message == "O percentual deve ser um valor entre 0 e 100.");
        }
    }
}
