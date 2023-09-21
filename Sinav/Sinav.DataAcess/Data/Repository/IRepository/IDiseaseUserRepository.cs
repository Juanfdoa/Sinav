using Sinav.Models.Entities;

namespace Sinav.DataAcess.Data.Repository.IRepository
{
    public interface IDiseaseUserRepository : IRepository<DiseaseUser>
    {
        void Update(DiseaseUser diseaseUser);
        IEnumerable<DiseaseUser> GetListDiseaseUser(int userId);
    }
}
