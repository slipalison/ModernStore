using Microsoft.EntityFrameworkCore;
using ModernStore.Domain.Entities;
using ModernStore.Domain.Repositories;
using ModernStore.Infra.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ModernStore.Infra.Repositories
{
    public class ProductRepository: IProductRepository
    {
        private readonly ModerStoreDataContext _context;

        public ProductRepository(ModerStoreDataContext context)
        {
            _context = context;
        }

        public Product Get(Guid id) => _context.Products.AsNoTracking().FirstOrDefaultAsync(x=>x.Id == id).Result;

        public IEnumerable<Product> Get(List<Guid> id)=> _context.Products.AsNoTracking().Where(x => id.Contains(x.Id));
    }
}
