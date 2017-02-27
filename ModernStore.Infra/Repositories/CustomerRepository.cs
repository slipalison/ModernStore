using ModernStore.Domain.Repositories;
using ModernStore.Domain.Entities;
using ModernStore.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using System;

namespace ModernStore.Infra.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {

        private readonly ModerStoreDataContext _context;

        public CustomerRepository(ModerStoreDataContext context)
        {
            _context = context;
        }

        public bool DocumentExists(string document) =>
            _context.Customers.AnyAsync(x => x.Document.Number == document).Result;

        public Customer Get(Guid id)
            => _context.Customers.Include(x => x.User).FirstOrDefaultAsync(x => x.Id == id).Result;

        public Customer GetByUsername(string username)
            => _context.Customers.Include(x => x.User).AsNoTracking().FirstOrDefaultAsync(x => x.User.Username == username).Result;


        public void Save(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public void Update(Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
        }
    }
}
