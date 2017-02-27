using Microsoft.EntityFrameworkCore;
using ModernStore.Domain.Entities;

namespace ModernStore.Infra.Mappings
{
    public class ProductMap
    {
        public ProductMap(ModelBuilder mb)
        {
            mb.Entity<Product>(t =>
            {
                t.ToTable("Product");
                t.HasKey(x => x.Id);
                t.Property(x => x.Image).IsRequired().HasMaxLength(1024);
                t.Property(x => x.Price);
                t.Property(x => x.QuantityOnHand);
                t.Property(x => x.Title).IsRequired().HasMaxLength(80);
            });
        }
    }
}
