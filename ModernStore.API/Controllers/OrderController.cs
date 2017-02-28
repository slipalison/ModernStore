using Microsoft.AspNetCore.Mvc;
using ModernStore.Domain.Commands.Handlers;
using ModernStore.Domain.Commands.Inputs;
using ModernStore.Infra.Transactions;
using System.Threading.Tasks;

namespace ModernStore.API.Controllers
{
    [Route("api")]
    public class OrderController : BaseController
    {
        private readonly OrderCommandHandler _handler;
        public OrderController(OrderCommandHandler handler,IUow uow) : base(uow)
        {
            _handler = handler;
        }

        [HttpPost, Route("v1/orders")]
        public async Task<IActionResult> Post([FromBody]RegisterOrderCommand command) =>
            await Response(_handler.Handle(command), _handler.Notifications);
    }
}
