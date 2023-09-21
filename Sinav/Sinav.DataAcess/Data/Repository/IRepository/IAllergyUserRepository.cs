using Sinav.Models.Entities;

namespace Sinav.DataAcess.Data.Repository.IRepository
{
    public interface IAllergyUserRepository : IRepository<AllergyUser>
    {
        void Update(AllergyUser allergyUser);
        IEnumerable<AllergyUser> GetListAllergyUser(int userId);
    }
}
