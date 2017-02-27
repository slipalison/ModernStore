using FluentValidator.Validation;
using ModernStore.Domain.Enums;
using ModernStore.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ModernStore.Domain.Entities
{
    public class Order : Entity
    {

        protected Order()
        {

        }
        public Order(Customer custumer, decimal deliveryFee, decimal discount)
        {
            Custumer = custumer;
            CreateDate = DateTime.Now;
            Number = Guid.NewGuid().ToString().Substring(0, 8).ToUpper();
            Status = EOrderStatus.Created;
            DeliveryFee = deliveryFee;
            Discount = discount;
            _itens = new List<OrderItem>();
            _validate = new ValidationContract<Order>(this);

            _validate.IsGreaterThan(x => x.DeliveryFee, 0);
            _validate.IsGreaterThan(x => x.Discount, -1);
        }

        private readonly IList<OrderItem> _itens;

        public Customer Custumer { get; private set; }

        public DateTime CreateDate { get; private set; }
        public string Number { get; private set; }
        public EOrderStatus Status { get; private set; }

        public ICollection<OrderItem> Items => _itens.ToArray();

        public decimal DeliveryFee { get; private set; }
        public decimal Discount { get; private set; }
        private ValidationContract<Order> _validate { get; set; }

        public decimal SubTotal() => Items.Sum(x => x.Total());

        public decimal Total() => (SubTotal() + DeliveryFee) - Discount;

        public void AddItem(OrderItem item)
        {
            AddNotifications(item.Notifications);
            if (item.IsValid())
                _itens.Add(item);
        }

        public void Place()
        {


        }
    }
}
