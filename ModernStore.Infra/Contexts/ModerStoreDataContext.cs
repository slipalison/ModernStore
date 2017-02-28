using FluentValidator.Validation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using ModernStore.Domain.Entities;
using ModernStore.Infra.Mappings;
using ModernStore.Shared.ValueObjects;

namespace ModernStore.Infra.Contexts
{
    public class ModerStoreDataContext : DbContext
    {
        public ModerStoreDataContext() : base()
        {

        }
        public ModerStoreDataContext(DbContextOptions<ModerStoreDataContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Password=sysadm;Persist Security Info=True;User ID=sa;Initial Catalog=ModernStore;Data Source=DESKTOP-KTK8HTQ");

        }



        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Ignore<Notification>();

            modelBuilder.Ignore<Document>();
            modelBuilder.Ignore<Name>();
            modelBuilder.Ignore<Email>();

            new CustomerMap(modelBuilder);
            new OrderMap(modelBuilder);
            new ProductMap(modelBuilder);
            new OrderItemMap(modelBuilder);
            new UserMap(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
    }


    public class ModerStoreDbContextFactory : IDbContextFactory<ModerStoreDataContext>
    {
        public ModerStoreDataContext Create(DbContextFactoryOptions options)
        {
            var builder = new DbContextOptionsBuilder<ModerStoreDataContext>();
            builder.UseSqlServer(@"Password=sysadm;Persist Security Info=True;User ID=sa;Initial Catalog=ModernStore;Data Source=DESKTOP-KTK8HTQ");

            return new ModerStoreDataContext(builder.Options);
        }
    }

}
