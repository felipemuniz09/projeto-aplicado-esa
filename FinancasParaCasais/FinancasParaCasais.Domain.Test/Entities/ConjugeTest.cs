using FinancasParaCasais.Domain.Entities;
using FluentAssertions;

namespace FinancasParaCasais.Domain.Test.Entities
{
    public class ConjugeTest
    {
        [Fact]
        public void DeveConsiderarInvalidoQuandoCodigoForVazio() 
        {
            // When
            var conjuge = new Conjuge(Guid.Empty, "João", 43);

            // Then
            conjuge.Notifications.Should().Contain(n => n.Message == "Código deve ser informado.");
        }

        [Fact]
        public void DeveConsiderarInvalidoQuandoNomeForVazio() 
        { 
            // When
            var conjuge = new Conjuge(Guid.NewGuid(), string.Empty, 43);

            // Then
            conjuge.Notifications.Should().Contain(n => n.Message == "Nome deve ser informado.");
        }

        [Fact]
        public void DeveConsiderarInvalidoQuandoNomeForApenasEspacoEmBranco() 
        {
            // When
            var conjuge = new Conjuge(Guid.NewGuid(), "   ", 70);

            // Then
            conjuge.Notifications.Should().Contain(n => n.Message == "Nome deve ser informado.");
        }

        [Fact]
        public void DeveConsiderarInvalidoQuandoNomeExcederTamanhoMaximo() 
        {
            // When
            var random = new Random();
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var nomeMuitoGrande = new string(Enumerable.Repeat(chars, 101).Select(s => s[random.Next(s.Length)]).ToArray());
            
            var conjuge = new Conjuge(Guid.NewGuid(), nomeMuitoGrande, 33);

            // Then
            conjuge.Notifications.Should().Contain(n => n.Message == "Nome possui tamanho máximo de 100 caracteres.");
        }

        [Fact]
        public void DeveConsiderarPercentualInvalidoQuandoForMenorQueZero() 
        {
            // When
            var conjuge = new Conjuge(Guid.NewGuid(), "Maria", -1);

            // Then
            conjuge.Notifications.Should().Contain(n => n.Message == "O percentual deve ser um valor entre 0 e 100.");
        }

        [Fact]
        public void DeveConsiderarPercentualInvalidoQuandoForMaiorQueCem() 
        {
            // When
            var conjuge = new Conjuge(Guid.NewGuid(), "Maria", 101);

            // Then
            conjuge.Notifications.Should().Contain(n => n.Message == "O percentual deve ser um valor entre 0 e 100.");
        }
    }
}
