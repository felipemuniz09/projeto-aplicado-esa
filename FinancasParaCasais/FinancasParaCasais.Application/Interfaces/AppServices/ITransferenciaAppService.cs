using FinancasParaCasais.Application.Commands;

namespace FinancasParaCasais.Application.Interfaces.AppServices
{
    public interface ITransferenciaAppService
    {
        void InserirTransferencia(InserirTransferenciaCommand inserirTransferenciaCommand);
        void ExcluirTransferencia(Guid codigo);
    }
}
