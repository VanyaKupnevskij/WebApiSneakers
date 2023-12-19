using WebApiSneakers.Database;
using WebApiSneakers.Models.Base;

namespace WebApiSneakers.Repositories.Interfaces
{
    public interface IBaseRepository<TDbModel> where TDbModel : BaseModel
    {
        public List<TDbModel> GetAll();
        public TDbModel? GetById(int id);
        public TDbModel? Create(TDbModel model);
        public TDbModel? Update(TDbModel model);
        public TDbModel? DeleteById(int id);
    }
}
