using AutoMapper;
using FinancasParaCasais.Application.AppServices;
using FinancasParaCasais.Application.Commands;
using FinancasParaCasais.Domain.Entities;
using FinancasParaCasais.Domain.Interfaces.Services;
using Moq;

namespace FinancasParaCasais.Application.Test.AppServices
{
    public class ConjugeAppServiceTest
    {
        private readonly ConjugeAppService _conjugeAppService;
        private readonly Mock<IConjugeService> _conjugeService;

        public ConjugeAppServiceTest()
        {
            var mapper = new Mock<IMapper>();
            _conjugeService = new Mock<IConjugeService>();
            _conjugeAppService = new ConjugeAppService(_conjugeService.Object, mapper.Object);
        }

        [Fact]
        public void NaoDeveSalvarEdicaoQuandoCommandEstiverInvalido()
        {
            // Given
            var editarConjugesCommand = new EditarConjugesCommand();

            // When
            _conjugeAppService.EditarConjuges(editarConjugesCommand);

            // Then
            _conjugeService.Verify(c => c.EditarConjuge(It.IsAny<Conjuge>()), Times.Never());
        }

        [Fact]
        public void DeveSalvarEdicaoDeCadaConjugeQuandoCommandEstiverValido()
        {
            // Given
            var editarConjugesCommand = new EditarConjugesCommand
            {
                Conjuges = new List<EditarConjugesCommand.ConjugeCommand>
                {
                    new EditarConjugesCommand.ConjugeCommand
                    {
                        Codigo = Guid.NewGuid(),
                        Nome = "João",
                        Percentual = 40
                    },
                    new EditarConjugesCommand.ConjugeCommand
                    {
                        Codigo = Guid.NewGuid(),
                        Nome = "José",
                        Percentual = 80
                    }
                }
            };

            // When
            _conjugeAppService.EditarConjuges(editarConjugesCommand);

            // Then
            _conjugeService.Verify(c => c.EditarConjuge(It.IsAny<Conjuge>()), Times.Exactly(2));
        }
    }
}
