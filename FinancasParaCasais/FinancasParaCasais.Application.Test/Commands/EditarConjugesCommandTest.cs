namespace FinancasParaCasais.Application.Test.Commands
{
    public class EditarConjugesCommandTest
    {
        [Fact]
        public void DeveConsiderarInvalidoQuandoListaDeConjugesForNull() { }

        [Fact]
        public void DeveConsiderarInvalidoQuandoListaDeConjugesForVazia() { }

        [Fact]
        public void DeveConsiderarInvalidoQuandoListaDeConjugesNaoTiverExatamenteDoisElementos() { }

        [Fact]
        public void DeveConsiderarInvalidoQuandoSomatorioDosPercentuaisForDiferenteDeCem() { }
    }
}
