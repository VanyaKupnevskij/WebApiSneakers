using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiSneakers.Models;
using WebApiSneakers.Repositories.Implimentations;
using WebApiSneakers.Repositories.Interfaces;

namespace WebApiSneakers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoritesController : ControllerBase
    {
        private FavoriteRepository favProds;

        public FavoritesController(FavoriteRepository favProds)
        {
            this.favProds = favProds;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Order>> Get()
        {
            return Ok(favProds.GetAll());
        }

        [HttpGet("{id_user}")]
        public ActionResult<IEnumerable<Order>> GetFavorites(int id_user)
        {
            return Ok(favProds.GetByUserId(id_user));
        }


        [HttpPost]
        public ActionResult<Favorite> AddToFavorites(Favorite model)
        {
            return Ok(favProds.AddFavorite(model));
        }

        [HttpDelete("{id_prod}")]
        public ActionResult<Favorite> RemoveFromFavorites(int id_prod)
        {
            var res = favProds.DeleteById(id_prod);
            return res != null ? Ok(res) : NotFound();
        }
    }
}
