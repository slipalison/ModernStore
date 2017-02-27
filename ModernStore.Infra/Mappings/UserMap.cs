using Microsoft.EntityFrameworkCore;
using ModernStore.Domain.Entities;

namespace ModernStore.Infra.Mappings
{
    public class UserMap
    {
        public UserMap(ModelBuilder mb)
        {

            mb.Entity<User>(t => {

                t.ToTable("User");
                t.HasKey(x => x.Id);
                t.Property(x => x.Username).IsRequired().HasMaxLength(20);
                t.Property(x => x.Password).IsRequired().HasMaxLength(32);
                t.Property(x => x.Active);

            });

           
        }
    }
}
