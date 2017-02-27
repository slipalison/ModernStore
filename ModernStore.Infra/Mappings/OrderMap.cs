using Microsoft.EntityFrameworkCore;
using ModernStore.Domain.Entities;

namespace ModernStore.Infra.Mappings
{
    public class OrderMap 
    {
        public OrderMap(ModelBuilder mb )
        {
            mb.Entity<Order>(t =>
            {
                t.ToTable("Order");
                t.HasKey(x => x.Id);
                t.Property(x => x.CreateDate);
                t.Property(x => x.DeliveryFee).HasColumnType("money");
                t.Property(x => x.Discount).HasColumnType("money");
                t.Property(x => x.Number).IsRequired().HasMaxLength(8);
                t.Property(x => x.Status);

                t.HasMany(x => x.Items);
                t.HasOne(x => x.Custumer);
            });
        }
    }
}
