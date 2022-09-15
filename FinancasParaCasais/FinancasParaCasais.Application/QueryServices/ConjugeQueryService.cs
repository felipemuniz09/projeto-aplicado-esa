using Dapper;
using FinancasParaCasais.Application.DTOs;
using FinancasParaCasais.Application.Interfaces.QueryServices;
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

        public IReadOnlyCollection<ConjugeDTO> ObterConjuges()
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("FinancasParaCasaisDB"));

            const string sql = @"
                SELECT  Codigo, Nome, Percentual
                FROM    dbo.Conjuges";

            var conjuges = connection.Query<ConjugeDTO>(sql);

            return conjuges.ToList();
        }
    }
}
