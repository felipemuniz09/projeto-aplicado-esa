using FinancasParaCasais.Application.Commands;

namespace FinancasParaCasais.Application.Interfaces.AppServices
{
    public interface IDespesaAppService
    {
        void InserirDespesa(InserirDespesaCommand inserirDespesaCommand);
    }
}
