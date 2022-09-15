using FinancasParaCasais.Application.Commands;

namespace FinancasParaCasais.Application.Interfaces.AppService
{
    public interface IConjugeAppService
    {
        void EditarConjuges(EditarConjugesCommand editarConjugesCommand);
    }
}
