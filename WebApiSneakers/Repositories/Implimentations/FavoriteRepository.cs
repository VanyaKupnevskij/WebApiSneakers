using Microsoft.EntityFrameworkCore;
using WebApiSneakers.Database;
using WebApiSneakers.Models;
using WebApiSneakers.Repositories.Interfaces;
 
namespace WebApiSneakers.Repositories.Implimentations
{
    public class FavoriteRepository : BaseRepository<Favorite>
    {
        public FavoriteRepository(ApplicationContext context) : base(context)
        {
            
        }

        public IEnumerable<Favorite> GetByUserId(int id)
        {
            return Context.Favorites
                .Include(p => p.Product)
                .Include(p => p.User)
                .Where(ord => ord.User_Id == id)
                .ToList();
        }

        public Favorite? AddFavorite(Favorite model)
        {
            model.Product = Context.Products.Find(model.Product_Id);
            model.User = Context.Users.Find(model.User_Id);
            Context.Favorites.Add(model);
            Context.SaveChanges(); 
            return model;
        }
    }
}
