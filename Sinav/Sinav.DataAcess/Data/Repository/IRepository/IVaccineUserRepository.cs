using Sinav.Models.Entities;

namespace Sinav.DataAcess.Data.Repository.IRepository
{
    public interface IVaccineUserRepository: IRepository<VaccineUser>
    {
        void Update(VaccineUser vaccineUser);
        IEnumerable<VaccineUser> GetListVaccineUser(int userId);
    }
}
