using FinancasParaCasais.Domain.Entities;
using FinancasParaCasais.Domain.Interfaces.Repositories;
using FinancasParaCasais.Domain.Services;
using Moq;

namespace FinancasParaCasais.Domain.Test.Services
{
    public class ConjugeServiceTest
    {
        private readonly ConjugeService _conjugeService;
        private readonly Mock<IConjugeRepository> _conjugeRepositoryMock;

        public ConjugeServiceTest()
        {
            _conjugeRepositoryMock = new Mock<IConjugeRepository>();
            _conjugeService = new ConjugeService(_conjugeRepositoryMock.Object);
        }

        [Fact]
        public void NaoDeveAtualizarQuandoConjugeEstiverInvalido()
        {
            // Given
            var conjuge = new Conjuge(string.Empty, 50);

            // When
            _conjugeService.EditarConjuge(conjuge);

            // Then
            _conjugeRepositoryMock.Verify(c => c.AtualizarConjuge(It.IsAny<Conjuge>()), Times.Never);
        }

        [Fact]
        public void DeveAtualizarQuandoConjugeEstiverValido()
        {
            // Given
            var conjuge = new Conjuge("José", 65);

            // When
            _conjugeService.EditarConjuge(conjuge);

            // Then
            _conjugeRepositoryMock.Verify(c => c.AtualizarConjuge(conjuge), Times.Once);
        }
    }
}
