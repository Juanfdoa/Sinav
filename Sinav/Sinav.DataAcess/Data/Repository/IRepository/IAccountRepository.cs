using Sinav.Models.Entities;

namespace Sinav.DataAcess.Data.Repository.IRepository
{
    public interface IAccountRepository : IRepository<Account>
    {
        void LockUser(string userId);
        void UnlockUser(string userId);
    }
}
