namespace FinancasParaCasais.Repository.Repositories
{
    public abstract class BaseRepository
    {
        protected FinancasParaCasaisContext _context;

        public BaseRepository(FinancasParaCasaisContext context)
        {
            _context = context;
        }
    }
}
