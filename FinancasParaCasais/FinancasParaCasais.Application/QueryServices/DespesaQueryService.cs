using Dapper;
using FinancasParaCasais.Application.Interfaces.QueryServices;
using FinancasParaCasais.Application.QueryResults;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace FinancasParaCasais.Application.QueryServices
{
    public class DespesaQueryService : BaseQueryService, IDespesaQueryService
    {
        public DespesaQueryService(IConfiguration configuration)
            : base (configuration) { }

        public IReadOnlyCollection<DespesaQueryResult> ObterDespesas()
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("FinancasParaCasaisDB"));

            const string sql = @"
                SELECT  Codigo, Descricao, Valor, DataHoraCriacao
                FROM    dbo.Despesas";

            var despesas = connection.Query<DespesaQueryResult>(sql);

            return despesas.ToList();
        }
    }
}
