namespace FinancasParaCasais.Domain.Test.Entities
{
    public class ConjugeTest
    {
        [Fact]
        public void DeveConsiderarInvalidoQuandoCodigoForVazio() { }

        [Fact]
        public void DeveConsiderarInvalidoQuandoNomeForNull() { }

        [Fact]
        public void DeveConsiderarInvalidoQuandoNomeForVazio() { }

        [Fact]
        public void DeveConsiderarInvalidoQuandoNomeForApenasEspacoEmBranco() { }

        [Fact]
        public void DeveConsiderarInvalidoQuandoNomeExcederTamanhoMaximo() { }

        [Fact]
        public void DeveConsiderarPercentualInvalidoQuandoForMenorQueZero() { }

        [Fact]
        public void DeveConsiderarPercentualInvalidoQuandoForMaiorQueCem() { }
    }
}
