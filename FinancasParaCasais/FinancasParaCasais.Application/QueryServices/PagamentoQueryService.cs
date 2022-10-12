using Dapper;
using FinancasParaCasais.Application.Interfaces.QueryServices;
using FinancasParaCasais.Application.QueryResults;
using Microsoft.Extensions.Configuration;

namespace FinancasParaCasais.Application.QueryServices
{
    public class PagamentoQueryService : BaseQueryService, IPagamentoQueryService
    {
        public PagamentoQueryService(IConfiguration configuration) 
            : base(configuration) { }

        public IReadOnlyCollection<PagamentoQueryResult> ObterPagamentos()
        {
            const string sql = @"
                SELECT  p.Codigo, cp.Nome as NomeConjugePagou, cr.Nome as NomeConjugeRecebeu, p.Valor, p.DataHoraCriacao
                FROM    Pagamentos p
                JOIN    Conjuges cp on p.CodigoConjugePagou = cp.Codigo
                JOIN    Conjuges cr on p.CodigoConjugeRecebeu = cr.Codigo";

            using var connection = ObterNovaConexao();

            var resultado = connection.Query(sql);

            var pagamentos = resultado.Select(r => new PagamentoQueryResult
            {
                Codigo = r.Codigo,
                Descricao = $"De {r.NomeConjugePagou} Para {r.NomeConjugeRecebeu}",
                Valor = r.Valor,
                DataHoraCriacao = r.DataHoraCriacao
            });

            return pagamentos.ToList();
        }
    }
}
