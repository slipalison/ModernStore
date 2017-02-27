using Microsoft.EntityFrameworkCore;
using ModernStore.Domain.Entities;
using System;

namespace ModernStore.Infra.Mappings
{
    public class CustomerMap
    {
        public CustomerMap(ModelBuilder mb)
        {
            mb.Entity<Customer>(t => {
                t.ToTable("Customer");
                t.HasKey(x => x.Id);
                t.Property(x => x.BirthDate);

                t.Property(x => x.Document_Number).IsRequired(true).HasMaxLength(11);
                t.Property(x => x.Email_Address).IsRequired(true).HasMaxLength(160);

                t.Property(x => x.FirstName).IsRequired(true).HasMaxLength(60);
                t.Property(x => x.LastName).IsRequired(true).HasMaxLength(60);

                t.HasOne(x => x.User);

                //t.Property(x => x.User.Username).IsRequired(true).HasMaxLength(20);
                //t.Property(x => x.User.Password).IsRequired(true).HasMaxLength(32);
                //t.Property(x => x.User.Active);


            });     
        }

    }
}
