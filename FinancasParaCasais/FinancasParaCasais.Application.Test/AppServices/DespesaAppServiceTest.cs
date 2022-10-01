using FinancasParaCasais.Application.AppServices;
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
        public void DeveLancarExceptionQuandoParametroForNull()
        {

        }

        [Fact]
        public void DeveInserirQuandoDespesaForValida()
        {

        }

        [Fact]
        public void NaoDeveInserirQuandoDespesaForInvalida()
        {

        }

        [Fact]
        public void DeveChamarExclusaoNoRepository()
        {

        }
    }
}
