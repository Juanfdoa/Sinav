using Sinav.Models.Entities;

namespace Sinav.DataAcess.Data.Repository.IRepository
{
    public interface INewRepository : IRepository<News>
    {
        void Update(News news);
    }
}
