using Microsoft.EntityFrameworkCore;
using WebApiSneakers.Database;
using WebApiSneakers.Models;
using WebApiSneakers.Repositories.Interfaces;
 
namespace WebApiSneakers.Repositories.Implimentations
{
    public class OrderRepository : BaseRepository<Order>
    {
        public OrderRepository(ApplicationContext context) : base(context)
        {
            
        }

        public IEnumerable<Order> GetBasketByUserId(int id)
        {
            return Context.Orders
                .Include(p => p.Product)
                .Include(p => p.User)
                .Where(ord => ord.User_Id == id && ord.In_Basket == true)
                .ToList();
        }

        public IEnumerable<Order> GetPurchasesByUserId(int id)
        {
            return Context.Orders
                .Include(p => p.Product)
                .Include(p => p.User)
                .Where(ord => ord.User_Id == id && ord.In_Basket == false)
                .ToList();
        }

        public override Order? Create(Order model)
        {
            model.Product = Context.Products.Find(model.Product_Id);
            model.User = Context.Users.Find(model.User_Id);
            Context.Orders.Add(model);
            Context.SaveChanges(); 
            return model;
        }

        public void MoveToPurchase(IEnumerable<Order> orders)
        {
            foreach (var order in orders)
                order.In_Basket = false;
            Context.Orders.UpdateRange(orders);
            Context.SaveChanges();
        }
    }
}
