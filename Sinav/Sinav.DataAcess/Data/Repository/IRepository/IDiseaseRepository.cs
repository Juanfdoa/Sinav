using Sinav.Models.Entities;

namespace Sinav.DataAcess.Data.Repository.IRepository
{
    public interface IDiseaseRepository : IRepository<Disease>
    {
        void Update(Disease disease);
    }
}
