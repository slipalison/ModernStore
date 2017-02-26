using ModernStore.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModernStore.Domain.Commands
{
    public class RegisterOrderCommand: ICommand
    {
        public Guid CustumerId { get; set; }
        public decimal DeviveryFee { get; set; }
        public decimal Discount { get; set; }
        public IEnumerable<RegisterOrderItemCommand> Items { get; set; }
    }
}
