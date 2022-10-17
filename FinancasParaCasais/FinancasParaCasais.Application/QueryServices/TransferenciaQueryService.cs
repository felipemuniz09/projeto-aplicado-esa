using Dapper;
using FinancasParaCasais.Application.Interfaces.QueryServices;
using FinancasParaCasais.Application.QueryResults;
using Microsoft.Extensions.Configuration;

namespace FinancasParaCasais.Application.QueryServices
{
    public class TransferenciaQueryService : BaseQueryService, ITransferenciaQueryService
    {
        public TransferenciaQueryService(IConfiguration configuration) 
            : base(configuration) { }

        public IReadOnlyCollection<TransferenciaQueryResult> ObterTransferencias()
        {
            const string sql = @"
                SELECT  t.Codigo, cp.Nome as NomeConjugePagou, cr.Nome as NomeConjugeRecebeu, t.Valor, t.DataHoraCriacao
                FROM    Transferencias t
                JOIN    Conjuges cp on t.CodigoConjugePagou = cp.Codigo
                JOIN    Conjuges cr on t.CodigoConjugeRecebeu = cr.Codigo";

            using var connection = ObterNovaConexao();

            var resultado = connection.Query(sql);

            var transferencias = resultado.Select(r => new TransferenciaQueryResult
            {
                Codigo = r.Codigo,
                Descricao = $"De {r.NomeConjugePagou} Para {r.NomeConjugeRecebeu}",
                Valor = r.Valor,
                DataHoraCriacao = r.DataHoraCriacao
            });

            return transferencias.ToList();
        }
    }
}
