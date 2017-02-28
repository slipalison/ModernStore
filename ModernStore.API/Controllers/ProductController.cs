using Microsoft.AspNetCore.Mvc;
using ModernStore.Domain.Repositories;
using System;

namespace ModernStore.API.Controllers
{
    [Route("api")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _prodructs;

        public ProductController(IProductRepository prodructs)
        {
            _prodructs = prodructs;
        }


        [HttpGet, Route("v1/produtos")]
        public IActionResult Get()
        {
            return Ok(_prodructs.Get());
        }

        [HttpPost, Route("v1/produtos")]
        public string Create()
        {
            return $"Criando";
        }

        [HttpGet, Route("v1/produtos/{id}")]
        public string Get(Guid id)
        {
            return $"Produto: {id}";
        }
    }
}
