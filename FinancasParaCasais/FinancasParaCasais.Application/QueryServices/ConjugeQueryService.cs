using Dapper;
using FinancasParaCasais.Application.Interfaces.QueryServices;
using FinancasParaCasais.Application.QueryResults;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace FinancasParaCasais.Application.QueryServices
{
    public class ConjugeQueryService : IConjugeQueryService
    {
        private readonly IConfiguration _configuration;

        public ConjugeQueryService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IReadOnlyCollection<ConjugeQueryResult> ObterConjuges()
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("FinancasParaCasaisDB"));

            const string sql = @"
                SELECT  Codigo, Nome, Percentual
                FROM    dbo.Conjuges";

            var conjuges = connection.Query<ConjugeQueryResult>(sql);

            return conjuges.ToList();
        }
    }
}
