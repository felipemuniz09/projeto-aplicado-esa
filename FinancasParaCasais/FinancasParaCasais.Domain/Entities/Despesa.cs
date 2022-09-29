using Flunt.Validations;

namespace FinancasParaCasais.Domain.Entities
{
    public class Despesa : BaseEntity
    {
        public string Descricao { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime DataHoraCriacao { get; private set; }

        public Despesa(Guid codigo, string descricao, decimal valor) 
            : base(codigo)
        {
            Descricao = descricao;
            Valor = valor;
            DataHoraCriacao = DateTime.Now;
        }
    }
}
