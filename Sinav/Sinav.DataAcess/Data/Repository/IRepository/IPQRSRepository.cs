using Sinav.Models.Entities;

namespace Sinav.DataAcess.Data.Repository.IRepository
{
    public interface IPQRSRepository : IRepository<PQRS>
    {
        void Update(PQRS pqrs);
        void MarkAsRead(int id);
    }
}
