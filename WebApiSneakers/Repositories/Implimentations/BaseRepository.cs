using WebApiSneakers.Database;
using WebApiSneakers.Models.Base;
using WebApiSneakers.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace WebApiSneakers.Repositories.Implimentations
{
    public class BaseRepository<TDbModel> : IBaseRepository<TDbModel> where TDbModel : BaseModel
    {
        protected ApplicationContext Context { get; set; }

        public BaseRepository(ApplicationContext context)
        {
            Context = context;
        }

        public virtual TDbModel? Create(TDbModel model)
        {
            Context.Add(model);
            Context.SaveChanges();
            return model;
        }

        public virtual TDbModel? DeleteById(int id)
        {
            var model = GetById(id);
            if (model != null)
            {
                Context.Remove(model);
                Context.SaveChanges();
            }
            return model;
        }

        public virtual List<TDbModel> GetAll()
        {
            return Context.Set<TDbModel>().ToList();
        }

        public virtual TDbModel? GetById(int id)
        {
            return Context.Find<TDbModel>(id);
        }

        public virtual TDbModel? Update(TDbModel model)
        {
            if (model != null)
            {
                Context.Update(model);
                Context.SaveChanges();
            }
            return model;
        }
    }
}
