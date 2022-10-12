using Dapper;
using FinancasParaCasais.Application.Interfaces.QueryServices;
using FinancasParaCasais.Application.QueryResults;
using Microsoft.Extensions.Configuration;

namespace FinancasParaCasais.Application.QueryServices
{
    public class ConjugeQueryService : BaseQueryService, IConjugeQueryService
    {
        public ConjugeQueryService(IConfiguration configuration)
            : base(configuration) { }

        public IReadOnlyCollection<ConjugeQueryResult> ObterConjuges()
        {
            using var connection = ObterNovaConexao();

            const string sql = @"
                SELECT  Codigo, Nome, Percentual
                FROM    dbo.Conjuges";

            var conjuges = connection.Query<ConjugeQueryResult>(sql);

            return conjuges.ToList();
        }
    }
}
