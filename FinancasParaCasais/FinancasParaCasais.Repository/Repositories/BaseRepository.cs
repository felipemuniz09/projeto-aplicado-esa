using AutoMapper;

namespace FinancasParaCasais.Repository.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly FinancasParaCasaisContext _context;
        protected readonly IMapper _mapper;

        public BaseRepository(FinancasParaCasaisContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}
