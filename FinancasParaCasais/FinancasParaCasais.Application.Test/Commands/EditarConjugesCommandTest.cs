using FinancasParaCasais.Application.Commands;
using FluentAssertions;

namespace FinancasParaCasais.Application.Test.Commands
{
    public class EditarConjugesCommandTest
    {
        [Fact]
        public void DeveConsiderarInvalidoQuandoListaDeConjugesForNull() 
        {
            // Given
            var editarConjugesCommand = new EditarConjugesCommand();

            // When
            editarConjugesCommand.Validar();

            // Then
            editarConjugesCommand.Notifications.Should().Contain(n => n.Message.Equals("Lista de conjuges deve conter 2 elementos."));
        }

        [Fact]
        public void DeveConsiderarInvalidoQuandoListaDeConjugesForVazia() 
        {
            // Given
            var editarConjugesCommand = new EditarConjugesCommand
            {
                Conjuges = new List<EditarConjugesCommand.ConjugeCommand>()
            };

            // When
            editarConjugesCommand.Validar();

            // Then
            editarConjugesCommand.Notifications.Should().Contain(n => n.Message.Equals("Lista de conjuges deve conter 2 elementos."));
        }

        [Fact]
        public void DeveConsiderarInvalidoQuandoListaDeConjugesNaoTiverExatamenteDoisElementos() 
        {
            // Given
            var editarConjugesCommand = new EditarConjugesCommand
            {
                Conjuges = new List<EditarConjugesCommand.ConjugeCommand>
                {
                    new EditarConjugesCommand.ConjugeCommand(),
                    new EditarConjugesCommand.ConjugeCommand(),
                    new EditarConjugesCommand.ConjugeCommand()
                }
            };

            // When
            editarConjugesCommand.Validar();

            // Then
            editarConjugesCommand.Notifications.Should().Contain(n => n.Message.Equals("Lista de conjuges deve conter 2 elementos."));
        }

        [Fact]
        public void DeveConsiderarInvalidoQuandoSomatorioDosPercentuaisForDiferenteDeCem() 
        {
            // Given
            var editarConjugesCommand = new EditarConjugesCommand
            {
                Conjuges = new List<EditarConjugesCommand.ConjugeCommand>
                {
                    new EditarConjugesCommand.ConjugeCommand { Percentual = 25 },
                    new EditarConjugesCommand.ConjugeCommand { Percentual = 70 }
                }
            };

            // When
            editarConjugesCommand.Validar();

            // Then
            editarConjugesCommand.Notifications.Should().Contain(n => n.Message.Equals("Somatório dos percentuais deve ser igual a 100."));
        }
    }
}
