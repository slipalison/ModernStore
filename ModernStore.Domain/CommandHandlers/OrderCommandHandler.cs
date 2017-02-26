using System;
using FluentValidator.Validation;
using ModernStore.Domain.Commands;
using ModernStore.Shared.Commands;
using ModernStore.Domain.Repositories;
using ModernStore.Domain.Entities;
using System.Linq;

namespace ModernStore.Domain.CommandHandlers
{
    public class OrderCommandHandler : Notifiable, ICommandHandler<RegisterOrderCommand>
    {
        private readonly ICustumerPepository _custumerRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;

        public OrderCommandHandler(ICustumerPepository custumerRepository, IProductRepository productRepository, IOrderRepository orderRepository)
        {
            _custumerRepository = custumerRepository;
            _productRepository = productRepository;
            _orderRepository = orderRepository;
        }

        public void Handle(RegisterOrderCommand command)
        {
            var order = new Order(_custumerRepository.Get(command.CustumerId), command.DeviveryFee, command.Discount);
            command.Items.ToList().ForEach(x =>
                order.AddItem(new OrderItem(_productRepository.Get(x.Product), x.Quantity))
            );
            AddNotifications(order.Notifications);
            if (order.IsValid())
                _orderRepository.Save(order);
        }
    }
}
