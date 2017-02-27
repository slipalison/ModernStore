using Microsoft.EntityFrameworkCore;
using ModernStore.Domain.Entities;

namespace ModernStore.Infra.Mappings
{
    public class OrderItemMap 
    {
        public OrderItemMap(ModelBuilder mb)
        {

            mb.Entity<OrderItem>(t =>
            {

                t.ToTable("OrderItem");
                t.HasKey(x => x.Id);
                t.Property(x => x.Price).HasColumnType("money");
                t.Property(x => x.Quantity);
                t.HasOne(x => x.Product);

            });

        }
    }
}
