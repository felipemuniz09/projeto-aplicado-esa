using Dapper;
using FinancasParaCasais.Application.Interfaces.QueryServices;
using FinancasParaCasais.Application.QueryResults;
using Microsoft.Extensions.Configuration;

namespace FinancasParaCasais.Application.QueryServices
{
    public class DespesaQueryService : BaseQueryService, IDespesaQueryService
    {
        public DespesaQueryService(IConfiguration configuration)
            : base (configuration) { }

        public IReadOnlyCollection<DespesaListaQueryResult> ObterDespesas()
        {
            using var connection = ObterNovaConexao();

            const string sql = @"
                SELECT  Codigo, Descricao, Valor, DataHoraCriacao
                FROM    dbo.Despesas";

            var despesas = connection.Query<DespesaListaQueryResult>(sql);

            return despesas.ToList();
        }

        public DespesaDetalhesQueryResult ObterDespesa(Guid codigo)
        {
            using var connection = ObterNovaConexao();

            var sql = @"
                SELECT  Codigo, Descricao, Valor, DataHoraCriacao
                FROM    dbo.Despesas
                WHERE   Codigo = @codigo";

            var despesa = connection.QueryFirstOrDefault<DespesaDetalhesQueryResult>(sql, new { codigo });

            sql = @"
                SELECT  c.Nome as NomeConjuge, dc.Valor
                FROM    dbo.Conjuges c
                JOIN    dbo.DespesaConjuge dc ON c.Codigo = dc.CodigoConjuge
                WHERE   dc.CodigoDespesa = @codigoDespesa";

            var pagamentos = connection.Query<DespesaDetalhesQueryResult.PagamentoQueryResult>(sql, new { codigoDespesa = codigo });

            despesa.Pagamentos = pagamentos.ToList();

            return despesa;
        }
    }
}
