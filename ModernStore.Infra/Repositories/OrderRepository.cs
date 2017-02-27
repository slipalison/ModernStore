using ModernStore.Domain.Repositories;
using ModernStore.Domain.Entities;
using ModernStore.Infra.Contexts;

namespace ModernStore.Infra.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ModerStoreDataContext _context;

        public OrderRepository(ModerStoreDataContext context)
        {
            _context = context;
        }

        public void Save(Order order) => _context.Orders.Add(order);
    }
}
