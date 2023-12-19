using WebApiSneakers.Database;
using WebApiSneakers.Models;

namespace WebApiSneakers.Repositories.Implimentations
{
    public class ProductRepository : BaseRepository<Product>
    {
        public ProductRepository(ApplicationContext context) : base(context)
        {
        }

    }
}
