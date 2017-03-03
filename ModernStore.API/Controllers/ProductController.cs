using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModernStore.Domain.Repositories;
using ModernStore.Infra.Transactions;
using System;
using System.Threading.Tasks;

namespace ModernStore.API.Controllers
{
    [Route("api")]
    public class ProductController : BaseController
    {
        private readonly IProductRepository _prodructs;


        public ProductController(IProductRepository prodructs, IUow uow) : base(uow)
        {
            _prodructs = prodructs;
        }


        [HttpGet, AllowAnonymous, Route("v1/produtos")]
        public async Task<IActionResult> Get() =>
        await Response(_prodructs.Get(), null);


        [HttpPost, Route("v1/produtos")]
        public string Create()
        {
            return $"Criando";
        }

        [HttpGet, AllowAnonymous, Route("v1/produtos/{id}")]
        public string Get(Guid id)
        {
            return $"Produto: {id}";
        }
    }
}
