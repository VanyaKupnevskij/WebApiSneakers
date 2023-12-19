using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiSneakers.Controllers.OrdersController.Response;
using WebApiSneakers.Models;
using WebApiSneakers.Repositories.Implimentations;
using WebApiSneakers.Repositories.Interfaces;

namespace WebApiSneakers.Controllers.OrdersController
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private OrderRepository orders;

        public OrdersController(OrderRepository orders)
        {
            this.orders = orders;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Order>> Get()
        {
            return Ok(orders.GetAll());
        }

        [HttpGet("basket/{id_user}")]
        public ActionResult<IEnumerable<Order>> GetBasket(int id_user)
        {
            return Ok(orders.GetBasketByUserId(id_user)); 
        }

        [HttpGet("purchases/{id_user}")]
        public ActionResult<IEnumerable<Order>> GetPurchases(int id_user)
        {
            return Ok(orders.GetPurchasesByUserId(id_user));
        }

        [HttpPost]
        public ActionResult<Order> Create(Order ord)
        {
            var res = orders.Create(ord);
            return res != null ? Ok(res) : BadRequest();
        }

        [HttpPut("buy/{id_user}")]
        public ActionResult MoveToPurchase(int id_user)
        {
            orders.MoveToPurchase(orders.GetBasketByUserId(id_user));
            return Ok();
        }

        [HttpPut]
        public ActionResult<Order> UpdateItem(Order order)
        {
            return Ok(orders.Update(order));
        }

        [HttpDelete("{id_order}")]
        public ActionResult DeleteItem(int id_order)
        {
            var res = orders.DeleteById(id_order);
            return res != null ? Ok(res) : NotFound();
        }
    }
}
