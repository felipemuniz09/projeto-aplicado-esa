using FinancasParaCasais.Application.AppServices;
using FinancasParaCasais.Application.Commands;
using FinancasParaCasais.Domain.Entities;
using FinancasParaCasais.Domain.Interfaces.Repositories;
using FinancasParaCasais.Domain.Interfaces.Services;
using Moq;

namespace FinancasParaCasais.Application.Test.AppServices
{
    public class DespesaAppServiceTest
    {
        private readonly DespesaAppService _despesaAppService;
        private readonly Mock<IDespesaService> _despesaServiceMock;
        private readonly Mock<IDespesaRepository> _despesaRepositoryMock;

        public DespesaAppServiceTest()
        {
            _despesaServiceMock = new Mock<IDespesaService>();
            _despesaRepositoryMock = new Mock<IDespesaRepository>();
            _despesaAppService = new DespesaAppService(_despesaServiceMock.Object, _despesaRepositoryMock.Object);
        }

        [Fact]
        public void DeveInserirQuandoDespesaForValida()
        {
            // Given
            var inserirDespesaCommand = new InserirDespesaCommand
            {
                Descricao = "Sofá novo",
                Valor = 2500,
                Pagamentos = new List<InserirDespesaCommand.PagamentoDespesaCommand>
                {
                    new InserirDespesaCommand.PagamentoDespesaCommand { CodigoConjuge = Guid.NewGuid(), Valor = 1000 },
                    new InserirDespesaCommand.PagamentoDespesaCommand { CodigoConjuge = Guid.NewGuid(), Valor = 1500 },
                }
            };

            // When
            _despesaAppService.InserirDespesa(inserirDespesaCommand);

            // Then
            _despesaServiceMock.Verify(d => d.InserirDespesa(It.IsAny<Despesa>()), Times.Once);
        }

        [Fact]
        public void NaoDeveInserirQuandoDespesaForInvalida()
        {
            // Given
            var inserirDespesaCommand = new InserirDespesaCommand
            {
                Descricao = "Sofá novo",
                Valor = 2500,
                Pagamentos = new List<InserirDespesaCommand.PagamentoDespesaCommand>
                {
                    new InserirDespesaCommand.PagamentoDespesaCommand { CodigoConjuge = Guid.NewGuid(), Valor = 1500 },
                    new InserirDespesaCommand.PagamentoDespesaCommand { CodigoConjuge = Guid.NewGuid(), Valor = 1500 },
                }
            };

            // When
            _despesaAppService.InserirDespesa(inserirDespesaCommand);

            // Then
            _despesaServiceMock.Verify(d => d.InserirDespesa(It.IsAny<Despesa>()), Times.Never);
        }

        [Fact]
        public void DeveChamarExclusaoNoRepository()
        {
            // Given
            var codigoDespesa = Guid.NewGuid();

            // When
            _despesaAppService.ExcluirDespesa(codigoDespesa);

            // Then
            _despesaRepositoryMock.Verify(d => d.ExcluirDespesa(codigoDespesa), Times.Once);
        }
    }
}
