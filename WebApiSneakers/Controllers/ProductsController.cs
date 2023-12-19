using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiSneakers.Models;
using WebApiSneakers.Repositories.Interfaces;

namespace WebApiSneakers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IBaseRepository<Product> products { get; set; }

        public ProductsController(IBaseRepository<Product> products)
        {
            this.products = products;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            return Ok(products.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            var res = products.GetById(id);
            return res == null ? NotFound() : Ok(res);
        }
    }
}
