using FinancasParaCasais.Application.Commands;
using FinancasParaCasais.Application.DTOs;

namespace FinancasParaCasais.Application.Interfaces.AppService
{
    public interface IConjugeAppService
    {
        void EditarConjuges(EditarConjugesCommand editarConjugesCommand);
        IReadOnlyCollection<SaldoPorConjugeDTO> CalcularSaldoPorConjuge();
    }
}
