using FluentValidator.Validation;
using ModernStore.Shared.Commands;
using ModernStore.Domain.Repositories;
using ModernStore.Domain.Entities;
using System.Linq;
using ModernStore.Domain.Commands.Inputs;
using ModernStore.Domain.Commands.Results;

namespace ModernStore.Domain.Commands.Handlers
{
    public class OrderCommandHandler : Notifiable, ICommandHandler<RegisterOrderCommand>
    {
        private readonly ICustomerRepository _custumerRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;

        public OrderCommandHandler(ICustomerRepository custumerRepository, IProductRepository productRepository, IOrderRepository orderRepository)
        {
            _custumerRepository = custumerRepository;
            _productRepository = productRepository;
            _orderRepository = orderRepository;
        }

        public ICommandResult Handle(RegisterOrderCommand command)
        {
            var order = new Order(_custumerRepository.Get(command.CustumerId), command.DeviveryFee, command.Discount);
            command.Items.ToList().ForEach(x =>
                order.AddItem(new OrderItem(_productRepository.Get(x.Product), x.Quantity))
            );
            AddNotifications(order.Notifications);
            if (order.IsValid())
                _orderRepository.Save(order);

            return new RegisterOrderCommandResult(order.Number);
        }
    }
}
