using ModernStore.Infra.Contexts;

namespace ModernStore.Infra.Transactions
{
    public class Uow : IUow
    {
        private readonly ModerStoreDataContext _context;

        public Uow(ModerStoreDataContext context)
        {
            _context = context;
        }

        public void Commit()=> _context.SaveChanges();

        public void Rollback()
        {
            // Do Nothing :)
        }
    }
}
