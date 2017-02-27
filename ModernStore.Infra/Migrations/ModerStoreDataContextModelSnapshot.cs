using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ModernStore.Infra.Contexts;
using ModernStore.Domain.Enums;

namespace ModernStore.Infra.Migrations
{
    [DbContext(typeof(ModerStoreDataContext))]
    partial class ModerStoreDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ModernStore.Domain.Entities.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("BirthDate");

                    b.Property<string>("Document_Number")
                        .IsRequired()
                        .HasMaxLength(11);

                    b.Property<string>("Email_Address")
                        .IsRequired()
                        .HasMaxLength(160);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<Guid?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("ModernStore.Domain.Entities.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateDate");

                    b.Property<Guid?>("CustumerId");

                    b.Property<decimal>("DeliveryFee")
                        .HasColumnType("money");

                    b.Property<decimal>("Discount")
                        .HasColumnType("money");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(8);

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.HasIndex("CustumerId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("ModernStore.Domain.Entities.OrderItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("OrderId");

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.Property<Guid?>("ProductId");

                    b.Property<int>("Quantity");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderItem");
                });

            modelBuilder.Entity("ModernStore.Domain.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasMaxLength(1024);

                    b.Property<decimal>("Price");

                    b.Property<int>("QuantityOnHand");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(80);

                    b.HasKey("Id");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("ModernStore.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(32);

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("ModernStore.Domain.Entities.Customer", b =>
                {
                    b.HasOne("ModernStore.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("ModernStore.Domain.Entities.Order", b =>
                {
                    b.HasOne("ModernStore.Domain.Entities.Customer", "Custumer")
                        .WithMany()
                        .HasForeignKey("CustumerId");
                });

            modelBuilder.Entity("ModernStore.Domain.Entities.OrderItem", b =>
                {
                    b.HasOne("ModernStore.Domain.Entities.Order")
                        .WithMany("Items")
                        .HasForeignKey("OrderId");

                    b.HasOne("ModernStore.Domain.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");
                });
        }
    }
}
