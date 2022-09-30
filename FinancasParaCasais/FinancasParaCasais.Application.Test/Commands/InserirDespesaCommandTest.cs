using FinancasParaCasais.Application.Commands;
using FluentAssertions;

namespace FinancasParaCasais.Application.Test.Commands
{
    public class InserirDespesaCommandTest
    {
        [Fact]
        public void DeveConsiderarInvalidoQuandoListaDePagamentosNaoTiverDoisElementos()
        {
            // Given
            var despesa = new InserirDespesaCommand
            {
                Descricao = "Conta de energia",
                Valor = 149.75M,
                Pagamentos = new List<InserirDespesaCommand.PagamentoDespesaCommand>
                {
                    new InserirDespesaCommand.PagamentoDespesaCommand { CodigoConjuge = Guid.NewGuid(), Valor = 49.75M }
                }
            };

            // When
            despesa.Validar();

            // Then
            despesa.Notifications.Should().Contain(n => n.Message == "Lista de pagamentos deve conter 2 elementos.");
        }

        [Fact]
        public void DeveConsiderarInvalidoQuandoSomaDosPagamentosForDiferenteDoValorDaDespesa()
        {
            // Given
            var despesa = new InserirDespesaCommand
            {
                Descricao = "Conta de energia",
                Valor = 149.75M,
                Pagamentos = new List<InserirDespesaCommand.PagamentoDespesaCommand>
                {
                    new InserirDespesaCommand.PagamentoDespesaCommand { CodigoConjuge = Guid.NewGuid(), Valor = 49.75M },
                    new InserirDespesaCommand.PagamentoDespesaCommand { CodigoConjuge = Guid.NewGuid(), Valor = 90M }
                }
            };

            // When
            despesa.Validar();

            // Then
            despesa.Notifications.Should().Contain(n => n.Message == "Soma dos pagamentos deve ser igual ao valor da despesa.");
        }
    }
}
