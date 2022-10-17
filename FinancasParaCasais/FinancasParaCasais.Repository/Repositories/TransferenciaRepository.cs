using AutoMapper;
using FinancasParaCasais.Domain.Entities;
using FinancasParaCasais.Domain.Interfaces.Repositories;
using FinancasParaCasais.Repository.Entities;

namespace FinancasParaCasais.Repository.Repositories
{
    public class TransferenciaRepository : BaseRepository, ITransferenciaRepository
    {
        public TransferenciaRepository(FinancasParaCasaisContext context, IMapper mapper) 
            : base(context, mapper) { }

        public void InserirTransferencia(Transferencia transferencia)
        {
            var transferenciaEF = _mapper.Map<TransferenciaEF>(transferencia);

            _context.Transferencias.Add(transferenciaEF);

            _context.SaveChanges();
        }

        public void ExcluirTransferencia(Guid codigo)
        {
            var transferencia = _context.Transferencias.FirstOrDefault(p => p.Codigo == codigo);

            if (transferencia == null) return;

            _context.Transferencias.Remove(transferencia);

            _context.SaveChanges();
        }

        public IReadOnlyCollection<Transferencia> ObterTransferencias()
        {
            var transferenciasEF = _context.Transferencias.ToList();

            return transferenciasEF.Select(_mapper.Map<Transferencia>).ToList();
        }
    }
}
