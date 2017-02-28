using Microsoft.AspNetCore.Mvc;
using ModernStore.Domain.Commands.Handlers;
using ModernStore.Domain.Commands.Inputs;
using ModernStore.Infra.Transactions;
using System.Threading.Tasks;

namespace ModernStore.API.Controllers
{
    [Route("api")]
    public class CustumerController : BaseController
    {
        private readonly CustomerCommandHandler _handler;

        public CustumerController(CustomerCommandHandler handler, IUow uow) : base(uow)
        {
            _handler = handler;
        }

        [HttpPost, Route("v1/customer")]
        public async Task<IActionResult> Post([FromBody]RegisterCustomerCommand command) => 
            await Response(_handler.Handle(command), _handler.Notifications);
    }
}
